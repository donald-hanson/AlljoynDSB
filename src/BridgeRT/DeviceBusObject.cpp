//
// Copyright (c) 2015, Microsoft Corporation
//
// Permission to use, copy, modify, and/or distribute this software for any
// purpose with or without fee is hereby granted, provided that the above
// copyright notice and this permission notice appear in all copies.
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
// WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY
// SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
// WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
// ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR
// IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
//

#include "pch.h"

#include <sstream>

#include "Bridge.h"
#include "BridgeDevice.h"
#include "DeviceBusObject.h"
#include "DeviceInterface.h"
#include "DeviceProperty.h"
#include "PropertyInterface.h"
#include "AllJoynProperty.h"
#include "AllJoynHelper.h"

using namespace Platform;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace Windows::Foundation;

using namespace BridgeRT;
using namespace std;
using namespace Windows::Foundation;

DeviceBusObject::DeviceBusObject() 
    : m_parent(nullptr),
    m_AJBusObject(NULL),
    m_registeredOnAllJoyn(false)
{
}

DeviceBusObject::~DeviceBusObject()
{
}

QStatus DeviceBusObject::Initialize(IAdapterBusObject^ busObject, BridgeDevice ^parent)
{
    QStatus status = ER_OK;
    string tempString;
    alljoyn_busobject_callbacks callbacks =
    {
        &DeviceBusObject::GetProperty,
        &DeviceBusObject::SetProperty,
        nullptr,
        nullptr
    };

    // sanity check
    if (nullptr == busObject)
    {
        status = ER_BAD_ARG_1;
        goto leave;
    }\
    if (nullptr == busObject->ObjectPath)
    {
        status = ER_BAD_ARG_1;
        goto leave;
    }
    if (nullptr == parent)
    {
        status = ER_BAD_ARG_2;
        goto leave;
    }

    m_parent = parent;

    // build bus object path
    AllJoynHelper::EncodeBusObjectName(busObject->ObjectPath, tempString);
    m_AJBusObjectPath = "/" + tempString;

    alljoyn_busobject bus = parent->GetBusObject(m_AJBusObjectPath);
    if (bus != nullptr)
    {
        status = ER_BAD_ARG_1;
        goto leave;
    }

    // create alljoyn bus object and register it
    m_AJBusObject = alljoyn_busobject_create(m_AJBusObjectPath.c_str(), QCC_FALSE, &callbacks, this);
    if (NULL == m_AJBusObject)
    {
        status = ER_OUT_OF_MEMORY;
        goto leave;
    }

    for (auto iface : busObject->Interfaces)
    {
        // create device property
        auto deviceProperty = new (std::nothrow) DeviceInterface();
        if (nullptr == deviceProperty)
        {
            status = ER_OUT_OF_MEMORY;
            goto leave;
        }
        status = deviceProperty->Initialize(iface, this, parent);
        if (ER_OK != status)
        {
            goto leave;
        }
        m_interfaces.insert(std::make_pair(*deviceProperty->GetInterfaceName(), deviceProperty));
        deviceProperty = nullptr;
    }
    status = alljoyn_busattachment_registerbusobject(parent->GetBusAttachment(), m_AJBusObject);
    m_registeredOnAllJoyn = true;
leave:
    return status;
}

void DeviceBusObject::Shutdown()
{
    for (auto &var : m_interfaces)
    {
        var.second->Shutdown();
        delete var.second;
    }
    if (NULL != m_AJBusObject)
    {
        if (m_registeredOnAllJoyn)
        {
            // unregister bus object
            alljoyn_busattachment_unregisterbusobject(m_parent->GetBusAttachment(), m_AJBusObject);
            m_registeredOnAllJoyn = false;
        }
        alljoyn_busobject_destroy(m_AJBusObject);
        m_AJBusObject = NULL;
    }
    m_parent = nullptr;
    m_AJBusObjectPath.clear();
}


QStatus AJ_CALL DeviceBusObject::GetProperty(_In_ const void* context, _In_z_ const char* ifcName, _In_z_ const char* propName, _Out_ alljoyn_msgarg val)
{
    QStatus status = ER_OK;
    uint32 adapterStatus = ERROR_SUCCESS;
    DeviceBusObject *deviceBus = nullptr;
    IAdapterAttribute ^adapterAttr = nullptr;
    IAdapterValue ^adapterValue = nullptr;
    AllJoynProperty *ajProperty = nullptr;
    IAdapterIoRequest^ request;
    DeviceProperty* deviceProperty = nullptr;
    UNREFERENCED_PARAMETER(ifcName);

    deviceBus = (DeviceBusObject *)context;
    if (nullptr == deviceBus)	// sanity test
    {
        return ER_BAD_ARG_1;
    }
    auto ifIndex = deviceBus->m_interfaces.find(ifcName);
    if (deviceBus->m_interfaces.end() == ifIndex)
    {
        return ER_BUS_NO_SUCH_INTERFACE;
    }

    auto iface = ifIndex->second;
    deviceProperty = iface->GetDeviceProperties();
    auto pairs = deviceProperty->GetAJpropertyAdapterValuePairs();
    // identify alljoyn property and its corresponding adapter value
    auto index = pairs.find(propName);
    if (pairs.end() == index)
    {
        status = ER_BUS_NO_SUCH_PROPERTY;
        goto leave;
    }

    ajProperty = index->second.ajProperty;
    adapterAttr = index->second.adapterAttr;
    adapterValue = adapterAttr->Value;

    // get value of adapter value
    adapterStatus = DsbBridge::SingleInstance()->GetAdapter()->GetPropertyValue(deviceProperty->GetAdapterProperty(), adapterValue->Name, &adapterValue, &request);
    if (ERROR_IO_PENDING == adapterStatus &&
        nullptr != request)
    {
        // wait for completion
        adapterStatus = request->Wait(WAIT_TIMEOUT_FOR_ADAPTER_OPERATION);
    }
    if (ERROR_SUCCESS != adapterStatus)
    {
        status = ER_OS_ERROR;
        goto leave;
    }

    // build alljoyn response to get
    status = AllJoynHelper::SetMsgArg(adapterValue, val);

leave:
    return status;
}

QStatus AJ_CALL DeviceBusObject::SetProperty(_In_ const void* context, _In_z_ const char* ifcName, _In_z_ const char* propName, _In_ alljoyn_msgarg val)
{
    QStatus status = ER_OK;
    uint32 adapterStatus = ERROR_SUCCESS;
    DeviceBusObject *deviceBus = nullptr;
    DeviceProperty *deviceProperty = nullptr;
    IAdapterAttribute^ adapterAttr = nullptr;
    IAdapterValue ^adapterValue = nullptr;
    AllJoynProperty *ajProperty = nullptr;
    IAdapterIoRequest^ request;

    UNREFERENCED_PARAMETER(ifcName);

    deviceBus = (DeviceBusObject *)context;
    if (nullptr == deviceBus)	// sanity test
    {
        return ER_BAD_ARG_1;
    }
    auto ifIndex = deviceBus->m_interfaces.find(ifcName);
    if (deviceBus->m_interfaces.end() == ifIndex)
    {
        return ER_BUS_NO_SUCH_INTERFACE;
    }

    // identify alljoyn property and its corresponding adapter value
    auto iface = ifIndex->second;
    deviceProperty = iface->GetDeviceProperties();
    auto pairs = deviceProperty->GetAJpropertyAdapterValuePairs();
    auto index = pairs.find(propName);
    if (pairs.end() == index)
    {
        status = ER_BUS_NO_SUCH_PROPERTY;
        goto leave;
    }

    ajProperty = index->second.ajProperty;
    adapterAttr = index->second.adapterAttr;
    adapterValue = adapterAttr->Value;

    // update IAdapterValue from AllJoyn message
    status = AllJoynHelper::GetAdapterValue(adapterValue, val);
    if (ER_OK != status)
    {
        goto leave;
    }

    // set value in adapter
    adapterStatus = DsbBridge::SingleInstance()->GetAdapter()->SetPropertyValue(deviceProperty->GetAdapterProperty(), adapterValue, &request);
    if (ERROR_IO_PENDING == adapterStatus &&
        nullptr != request)
    {
        // wait for completion
        adapterStatus = request->Wait(WAIT_TIMEOUT_FOR_ADAPTER_OPERATION);
    }
    if (ERROR_ACCESS_DENIED == adapterStatus)
    {
        status = ER_BUS_PROPERTY_ACCESS_DENIED;
        goto leave;
    }
    if (ERROR_SUCCESS != adapterStatus)
    {
        status = ER_BUS_PROPERTY_VALUE_NOT_SET;
        goto leave;
    }

leave:
    return status;
}

void DeviceBusObject::EmitSignalCOV(IAdapterValue ^newValue, const std::vector<alljoyn_sessionid>& sessionIds)
{
    QStatus status = ER_OK;
    alljoyn_msgarg msgArg = NULL;
    throw;
    /* TODO
    auto valuePair = m_AJpropertyAdapterValuePairs.end();

    // sanity check
    if (nullptr == newValue)
    {
        goto leave;
    }

    // get AllJoyn property that match with IAdapterValue that has changed
    for (valuePair = m_AJpropertyAdapterValuePairs.begin(); valuePair != m_AJpropertyAdapterValuePairs.end(); valuePair++)
    {
        if (valuePair->second.adapterAttr->Value->Name == newValue->Name)
        {
            break;
        }
    }
    if (valuePair == m_AJpropertyAdapterValuePairs.end())
    {
        // can't find any Alljoyn property that correspond to IAdapterValue
        goto leave;
    }

    // prepare signal arguments
    msgArg = alljoyn_msgarg_create();
    if (NULL == msgArg)
    {
        goto leave;
    }

    // build alljoyn message from IAdapterValue
    status = AllJoynHelper::SetMsgArg(newValue, msgArg);
    if (status != ER_OK)
    {
        goto leave;
    }

	for (auto sessionId : sessionIds)
	{
		// emit property change
		alljoyn_busobject_emitpropertychanged(m_AJBusObject,
			m_propertyInterface->GetInterfaceName()->c_str(),
			valuePair->second.ajProperty->GetName()->c_str(),
			msgArg, sessionId);
	}

leave:
    if (NULL != msgArg)
    {
        alljoyn_msgarg_destroy(msgArg);
    }
    */
    return;
}
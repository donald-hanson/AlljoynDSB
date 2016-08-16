﻿/*  
* AllJoyn Device Service Bridge 
*  
* Copyright (c) Morten Nielsen
* All rights reserved.  
*  
* MIT License  
*  
* Permission is hereby granted, free of charge, to any person obtaining a copy of this  
* software and associated documentation files (the "Software"), to deal in the Software  
* without restriction, including without limitation the rights to use, copy, modify, merge,  
* publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons  
* to whom the Software is furnished to do so, subject to the following conditions:  
*  
* The above copyright notice and this permission notice shall be included in all copies or  
* substantial portions of the Software.  
*  
* THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,  
* INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR  
* PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE  
* FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR  
* OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER  
* DEALINGS IN THE SOFTWARE.  
*/

using System;

namespace AllJoyn.Dsb.MockDevices
{
    public class MockBulbDevice : AdapterDevice
    {
        public MockBulbDevice(MockLightingServiceHandler handler) : base(handler.Name,
            "MockDevices Inc", "Mock Bulb", "1", handler.Id, "")
        {
            base.LightingServiceHandler = handler;
            Icon = new AdapterIcon(new Uri("ms-appx:///AllJoyn.Dsb.MockDevices/Icons/Light.png"));
            if (handler.LampState_LampStateChanged != null)
            {
                handler.LampStateChanged += Handler_LampStateChanged;
            }
        }

        private void Handler_LampStateChanged(object sender, EventArgs e)
        {
            NotifySignalListener(LightingServiceHandler.LampState_LampStateChanged);
        }
    }
}
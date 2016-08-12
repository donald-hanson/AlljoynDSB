using System;
using System.Runtime.InteropServices;

namespace AllJoyn.Dsb
{
        /// <summary>
        /// Enumerated list of values QStatus can return
        /// </summary>
        /// 
        public enum AllJoynStatusCode : uint
        {
            Ok = 0x0 /**< Success. */,
            Fail = 0x1 /**< Generic failure. */,
            UtfConversionFailed = 0x2 /**< Conversion between UTF bases failed. */,
            BufferTooSmall = 0x3 /**< Not enough space in buffer for operation. */,
            OsError = 0x4 /**< Underlying OS has indicated an error. */,
            OutOfMemory = 0x5 /**< Failed to allocate memory. */,
            SocketBindError = 0x6 /**< Bind to IP address failed. */,
            InitFailed = 0x7 /**< Initialization failed. */,
            WouldBlock = 0x8 /**< An I/O attempt on non-blocking resource would block */,
            NotImplemented = 0x9 /**< Feature not implemented */,
            Timeout = 0xa /**< Operation timed out */,
            SOCK_OTHER_END_CLOSED = 0xb /**< Other end closed the socket */,
            BadArgument1 = 0xc /**< Function call argument 1 is invalid */,
            BadArgument2 = 0xd /**< Function call argument 2 is invalid */,
            BadArgument3 = 0xe /**< Function call argument 3 is invalid */,
            BadArgument4 = 0xf /**< Function call argument 4 is invalid */,
            BadArgument5 = 0x10 /**< Function call argument 5 is invalid */,
            BadArgument6 = 0x11 /**< Function call argument 6 is invalid */,
            BadArgument7 = 0x12 /**< Function call argument 7 is invalid */,
            BadArgument8 = 0x13 /**< Function call argument 8 is invalid */,
            InvalidAddress = 0x14 /**< Address is NULL or invalid */,
            InvalidData = 0x15 /**< Generic invalid data error */,
            ReadError = 0x16 /**< Generic read error */,
            WriteError = 0x17 /**< Generic write error */,
            OpenFailed = 0x18 /**< Generic open failure */,
            ParseError = 0x19 /**< Generic parse failure */,
            EndOfData = 0x1A /**< Generic EOD/EOF error */,
            ConnectionRefused = 0x1B /**< Connection was refused because no one is listening */,
            BadArgumentCount = 0x1C /**< Incorrect number of arguments given to function call */,
            Warning = 0x1D /**< Generic warning */,
            EOF = 0x1E /**< End of file */,
            Deadlock = 0x1F /**< Operation would cause deadlock */,
            COMMON_ERRORS = 0x1000 /**< Error code block for the Common subsystem. */,
            STOPPING_THREAD = 0x1001 /**< Operation interrupted by ERThread stop signal. */,
            ALERTED_THREAD = 0x1002 /**< Operation interrupted by ERThread alert signal. */,
            XML_MALFORMED = 0x1003 /**< Cannot parse malformed XML */,
            AUTH_FAIL = 0x1004 /**< Authentication failed */,
            AUTH_USER_REJECT = 0x1005 /**< Authentication was rejected by user */,
            NO_SUCH_ALARM = 0x1006 /**< Attempt to reference non-existent timer alarm */,
            TIMER_FALLBEHIND = 0x1007 /**< A timer thread is missing scheduled alarm times */,
            SSL_ERRORS = 0x1008 /**< Error code block for SSL subsystem */,
            SSL_INIT = 0x1009 /**< SSL initialization failed. */,
            SSL_CONNECT = 0x100a /**< Failed to connect to remote host using SSL */,
            SSL_VERIFY = 0x100b /**< Failed to verify identity of SSL destination */,
            EXTERNAL_THREAD = 0x100c /**< Operation not supported on external thread wrapper */,
            CRYPTO_ERROR = 0x100d /**< Non-specific error in the crypto subsystem */,
            CRYPTO_TRUNCATED = 0x100e /**< Not enough room for key */,
            CRYPTO_KEY_UNAVAILABLE = 0x100f /**< No key to return */,
            BAD_HOSTNAME = 0x1010 /**< Cannot lookup hostname */,
            CRYPTO_KEY_UNUSABLE = 0x1011 /**< Key cannot be used */,
            EMPTY_KEY_BLOB = 0x1012 /**< Key blob is empty */,
            CORRUPT_KEYBLOB = 0x1013 /**< Key blob is corrupted */,
            INVALID_KEY_ENCODING = 0x1014 /**< Encoded key is not valid */,
            DEAD_THREAD = 0x1015 /**< Operation not allowed thread is dead */,
            THREAD_RUNNING = 0x1016 /**< Cannot start a thread that is already running */,
            THREAD_STOPPING = 0x1017 /**< Cannot start a thread that is already stopping */,
            BAD_STRING_ENCODING = 0x1018 /**< Encoded string did not have the expected format or contents */,
            CRYPTO_INSUFFICIENT_SECURITY = 0x1019 /**< Crypto algorithm parameters do not provide sufficient security */,
            CRYPTO_ILLEGAL_PARAMETERS = 0x101a /**< Crypto algorithm parameter value is illegal */,
            CRYPTO_HASH_UNINITIALIZED = 0x101b /**< Cryptographic hash function must be initialized */,
            THREAD_NO_WAIT = 0x101c /**< Thread cannot be blocked by a WAIT or SLEEP call */,
            TIMER_EXITING = 0x101d /**< Cannot add an alarm to a timer that is exiting */,
            INVALID_GUID = 0x101e /**< String is not a hex encoded GUID string */,
            THREADPOOL_EXHAUSTED = 0x101f /**< A thread pool has reached its specified concurrency */,
            THREADPOOL_STOPPING = 0x1020 /**< Cannot execute a closure on a stopping thread pool */,
            INVALID_STREAM = 0x1021 /**< Attempt to reference non-existent stream entry */,
            TIMER_FULL = 0x1022 /**< Attempt to reference non-existent stream entry */,
            IODISPATCH_STOPPING = 0x1023 /**< Cannot execute a read or write command on an IODispatch thread because it is stopping. */,
            SLAP_INVALID_PACKET_LEN = 0x1024 /**< Length of SLAP packet is invalid. */,
            SLAP_HDR_CHECKSUM_ERROR = 0x1025 /**< SLAP packet header checksum error. */,
            SLAP_INVALID_PACKET_TYPE = 0x1026 /**< Invalid SLAP packet type. */,
            SLAP_LEN_MISMATCH = 0x1027 /**< Calculated length does not match the received length. */,
            SLAP_PACKET_TYPE_MISMATCH = 0x1028 /**< Packet type does not match reliability bit. */,
            SLAP_CRC_ERROR = 0x1029 /**< SLAP packet CRC error. */,
            SLAP_ERROR = 0x102A /**< Generic SLAP error. */,
            SLAP_OTHER_END_CLOSED = 0x102B /**< Other end closed the SLAP connection */,
            TIMER_NOT_ALLOWED = 0x102C /**< Timer EnableReentrancy call not allowed */,
            NONE = 0xffff /**< No error code to report */,
            BUS_ERRORS = 0x9000 /**< Error code block for ALLJOYN wire protocol */,
            BUS_READ_ERROR = 0x9001 /**< Error attempting to read */,
            BUS_WRITE_ERROR = 0x9002 /**< Error attempting to write */,
            BUS_BAD_VALUE_TYPE = 0x9003 /**< Read an invalid value type */,
            BUS_BAD_HEADER_FIELD = 0x9004 /**< Read an invalid header field */,
            BUS_BAD_SIGNATURE = 0x9005 /**< Signature was badly formed */,
            BUS_BAD_OBJ_PATH = 0x9006 /**< Object path contained an illegal character */,
            BUS_BAD_MEMBER_NAME = 0x9007 /**< A member name contained an illegal character */,
            BUS_BAD_INTERFACE_NAME = 0x9008 /**< An interface name contained an illegal character */,
            BUS_BAD_ERROR_NAME = 0x9009 /**< An error name contained an illegal character */,
            BUS_BAD_BUS_NAME = 0x900a /**< A bus name contained an illegal character */,
            BUS_NAME_TOO_LONG = 0x900b /**< A name exceeded the permitted length */,
            BUS_BAD_LENGTH = 0x900c /**< Length of an array was not a multiple of the array element size */,
            BUS_BAD_VALUE = 0x900d /**< Parsed value in a message was invalid (for example: boolean > 1)  */,
            BUS_BAD_HDR_FLAGS = 0x900e /**< Unknown header flags */,
            BUS_BAD_BODY_LEN = 0x900f /**< Body length was to long or too short */,
            BUS_BAD_HEADER_LEN = 0x9010 /**< Header length was to long or too short */,
            BUS_UNKNOWN_SERIAL = 0x9011 /**< Serial number in a method response was unknown */,
            BUS_UNKNOWN_PATH = 0x9012 /**< Path in a method call or signal was unknown */,
            BUS_UNKNOWN_INTERFACE = 0x9013 /**< Interface in a method call or signal was unknown */,
            BUS_ESTABLISH_FAILED = 0x9014 /**< Failed to establish a connection */,
            BUS_UNEXPECTED_SIGNATURE = 0x9015 /**< Signature in message was not what was expected */,
            BUS_INTERFACE_MISSING = 0x9016 /**< Interface header field is missing */,
            BUS_PATH_MISSING = 0x9017 /**< Object path header field is missing */,
            BUS_MEMBER_MISSING = 0x9018 /**< Member header field is missing */,
            BUS_REPLY_SERIAL_MISSING = 0x9019 /**< Reply-Serial header field is missing */,
            BUS_ERROR_NAME_MISSING = 0x901a /**< Error Name header field is missing */,
            BUS_INTERFACE_NO_SUCH_MEMBER = 0x901b /**< Interface does not have the requested member */,
            BUS_NO_SUCH_OBJECT = 0x901c /**< Object does not exist */,
            BUS_OBJECT_NO_SUCH_MEMBER = 0x901d /**< Object does not have the requested member (on any interface) */,
            BUS_OBJECT_NO_SUCH_INTERFACE = 0x901e /**< Object does not have the requested interface */,
            BUS_NO_SUCH_INTERFACE = 0x901f /**< Requested interface does not exist */,
            BUS_MEMBER_NO_SUCH_SIGNATURE = 0x9020 /**< Member exists but does not have the requested signature */,
            BUS_NOT_NUL_TERMINATED = 0x9021 /**< A string or signature was not NUL terminated */,
            BUS_NO_SUCH_PROPERTY = 0x9022 /**< No such property for a GET or SET operation  */,
            BUS_SET_WRONG_SIGNATURE = 0x9023 /**< Attempt to set a property value with the wrong signature */,
            BUS_PROPERTY_VALUE_NOT_SET = 0x9024 /**< Attempt to get a property whose value has not been set */,
            BUS_PROPERTY_ACCESS_DENIED = 0x9025 /**< Attempt to set or get a property failed due to access rights */,
            BUS_NO_TRANSPORTS = 0x9026 /**< No physical message transports were specified */,
            BUS_BAD_TRANSPORT_ARGS = 0x9027 /**< Missing or badly formatted transports args specified */,
            BUS_NO_ROUTE = 0x9028 /**< Message cannot be routed to destination */,
            BUS_NO_ENDPOINT = 0x9029 /**< An endpoint with given name cannot be found */,
            BUS_BAD_SEND_PARAMETER = 0x902a /**< Bad parameter in send message call */,
            BUS_UNMATCHED_REPLY_SERIAL = 0x902b /**< Serial number in method call reply message did not match any method calls */,
            BUS_BAD_SENDER_ID = 0x902c /**< Sender identifier is invalid */,
            BUS_TRANSPORT_NOT_STARTED = 0x902d /**< Attempt to send on a transport that has not been started */,
            BUS_EMPTY_MESSAGE = 0x902e /**< Attempt to deliver an empty message */,
            BUS_NOT_OWNER = 0x902f /**< A bus name operation was not permitted because sender does not own name */,
            BUS_SET_PROPERTY_REJECTED = 0x9030 /**< Application rejected a request to set a property */,
            BUS_CONNECT_FAILED = 0x9031 /**< Connection failed */,
            BUS_REPLY_IS_ERROR_MESSAGE = 0x9032 /**< Response from a method call was an ERROR message */,
            BUS_NOT_AUTHENTICATING = 0x9033 /**< Not in an authentication conversation */,
            BUS_NO_LISTENER = 0x9034 /**< A listener is required to implement the requested function */,
            BUS_NOT_ALLOWED = 0x9036 /**< The operation attempted is not allowed */,
            BUS_WRITE_QUEUE_FULL = 0x9037 /**< Write failed because write queue is full */,
            BUS_ENDPOINT_CLOSING = 0x9038 /**< Operation not permitted on endpoint in process of closing */,
            BUS_INTERFACE_MISMATCH = 0x9039 /**< Received two conflicting definitions for the same interface */,
            BUS_MEMBER_ALREADY_EXISTS = 0x903a /**< Attempt to add a member to an interface that already exists */,
            BUS_PROPERTY_ALREADY_EXISTS = 0x903b /**< Attempt to add a property to an interface that already exists */,
            BUS_IFACE_ALREADY_EXISTS = 0x903c /**< Attempt to add an interface to an object that already exists */,
            BUS_ERROR_RESPONSE = 0x903d /**< Received an error response to a method call */,
            BUS_BAD_XML = 0x903e /**< XML data is improperly formatted */,
            BUS_BAD_CHILD_PATH = 0x903f /**< The path of a child object is incorrect given its parent's path */,
            BUS_OBJ_ALREADY_EXISTS = 0x9040 /**< Attempt to add a RemoteObject child that already exists */,
            BUS_OBJ_NOT_FOUND = 0x9041 /**< Object with given path does not exist */,
            BUS_CANNOT_EXPAND_MESSAGE = 0x9042 /**< Expansion information for a compressed message is not available */,
            BUS_NOT_COMPRESSED = 0x9043 /**< Attempt to expand a message that is not compressed */,
            BUS_ALREADY_CONNECTED = 0x9044 /**< Attempt to connect to a bus which is already connected */,
            BUS_NOT_CONNECTED = 0x9045 /**< Attempt to use a bus attachment that is not connected to a router */,
            BUS_ALREADY_LISTENING = 0x9046 /**< Attempt to listen on a bus address which is already being listened on */,
            BUS_KEY_UNAVAILABLE = 0x9047 /**< The request key is not available */,
            BUS_TRUNCATED = 0x9048 /**< Insufficient memory to copy data */,
            BUS_KEY_STORE_NOT_LOADED = 0x9049 /**< Accessing the key store before it is loaded */,
            BUS_NO_AUTHENTICATION_MECHANISM = 0x904a /**< There is no authentication mechanism */,
            BUS_BUS_ALREADY_STARTED = 0x904b /**< Bus has already been started */,
            BUS_BUS_NOT_STARTED = 0x904c /**< Bus has not yet been started */,
            BUS_KEYBLOB_OP_INVALID = 0x904d /**< The operation requested cannot be performed using this key blob */,
            BUS_INVALID_HEADER_CHECKSUM = 0x904e /**< Invalid header checksum in an encrypted message */,
            BUS_MESSAGE_NOT_ENCRYPTED = 0x904f /**< Security policy requires the message to be encrypted */,
            BUS_INVALID_HEADER_SERIAL = 0x9050 /**< Serial number in message header is invalid */,
            BUS_TIME_TO_LIVE_EXPIRED = 0x9051 /**< Message time-to-live has expired */,
            BUS_HDR_EXPANSION_INVALID = 0x9052 /**< Something is wrong with a header expansion */,
            BUS_MISSING_COMPRESSION_TOKEN = 0x9053 /**< Compressed headers require a compression token */,
            BUS_NO_PEER_GUID = 0x9054 /**< There is no GUID for this peer */,
            BUS_MESSAGE_DECRYPTION_FAILED = 0x9055 /**< Message decryption failed */,
            BUS_SECURITY_FATAL = 0x9056 /**< A fatal security failure */,
            BUS_KEY_EXPIRED = 0x9057 /**< An encryption key has expired */,
            BUS_CORRUPT_KEYSTORE = 0x9058 /**< Key store is corrupt */,
            BUS_NO_CALL_FOR_REPLY = 0x9059 /**< A reply only allowed in response to a method call */,
            BUS_NOT_A_COMPLETE_TYPE = 0x905a /**< Signature must be a single complete type */,
            BUS_POLICY_VIOLATION = 0x905b /**< Message does not meet policy restrictions */,
            BUS_NO_SUCH_SERVICE = 0x905c /**< Service name is unknown */,
            BUS_TRANSPORT_NOT_AVAILABLE = 0x905d /**< Transport cannot be used due to underlying mechanism disabled by OS */,
            BUS_INVALID_AUTH_MECHANISM = 0x905e /**< Authentication mechanism is not valid */,
            BUS_KEYSTORE_VERSION_MISMATCH = 0x905f /**< Key store has wrong version number */,
            BUS_BLOCKING_CALL_NOT_ALLOWED = 0x9060 /**< A synchronous method call from within handler is not permitted. */,
            BUS_SIGNATURE_MISMATCH = 0x9061 /**< MsgArg(s) do not match signature. */,
            BUS_STOPPING = 0x9062 /**< The bus is stopping. */,
            BUS_METHOD_CALL_ABORTED = 0x9063 /**< The method call was aborted. */,
            BUS_CANNOT_ADD_INTERFACE = 0x9064 /**< An interface cannot be added to an object that is already registered. */,
            BUS_CANNOT_ADD_HANDLER = 0x9065 /**< A method handler cannot be added to an object that is already registered. */,
            BUS_KEYSTORE_NOT_LOADED = 0x9066 /**< Key store has not been loaded */,
            BUS_NO_SUCH_HANDLE = 0x906b /**< Handle is not in the handle table */,
            BUS_HANDLES_NOT_ENABLED = 0x906c /**< Passing of handles is not enabled for this connection */,
            BUS_HANDLES_MISMATCH = 0x906d /**< Message had more handles than expected */,
            BUS_NO_SESSION = 0x906f /**< Session id is not valid */,
            BUS_ELEMENT_NOT_FOUND = 0x9070 /**< Dictionary element was not found */,
            BUS_NOT_A_DICTIONARY = 0x9071 /**< MsgArg was not an array of dictionary elements */,
            BUS_WAIT_FAILED = 0x9072 /**< Wait failed */,
            BUS_BAD_SESSION_OPTS = 0x9074 /**< Session options are bad or incompatible */,
            BUS_CONNECTION_REJECTED = 0x9075 /**< Incoming connection rejected */,
            DBUS_REQUEST_NAME_REPLY_PRIMARY_OWNER = 0x9076 /**< RequestName reply: Name was successfully obtained */,
            DBUS_REQUEST_NAME_REPLY_IN_QUEUE = 0x9077 /**< RequestName reply: Name is already owned, request for name has been queued */,
            DBUS_REQUEST_NAME_REPLY_EXISTS = 0x9078 /**< RequestName reply: Name is already owned and DO_NOT_QUEUE was specified in request */,
            DBUS_REQUEST_NAME_REPLY_ALREADY_OWNER = 0x9079 /**< RequestName reply: Name is already owned by this endpoint */,
            DBUS_RELEASE_NAME_REPLY_RELEASED = 0x907a /**< ReleaseName reply: Name was released */,
            DBUS_RELEASE_NAME_REPLY_NON_EXISTENT = 0x907b /**<  ReleaseName reply: Name does not exist */,
            DBUS_RELEASE_NAME_REPLY_NOT_OWNER = 0x907c /**< ReleaseName reply: Request to release name that is not owned by this endpoint */,
            DBUS_START_REPLY_ALREADY_RUNNING = 0x907e /**< StartServiceByName reply: Service is already running */,
            ALLJOYN_BINDSESSIONPORT_REPLY_ALREADY_EXISTS = 0x9080 /**< BindSessionPort reply: SessionPort already exists */,
            ALLJOYN_BINDSESSIONPORT_REPLY_FAILED = 0x9081 /**< BindSessionPort reply: Failed */,
            ALLJOYN_JOINSESSION_REPLY_NO_SESSION = 0x9083 /**< JoinSession reply: Session with given name does not exist */,
            ALLJOYN_JOINSESSION_REPLY_UNREACHABLE = 0x9084 /**< JoinSession reply: Failed to find suitable transport */,
            ALLJOYN_JOINSESSION_REPLY_CONNECT_FAILED = 0x9085 /**< JoinSession reply: Connect to advertised address */,
            ALLJOYN_JOINSESSION_REPLY_REJECTED = 0x9086 /**< JoinSession reply: The session creator rejected the join req */,
            ALLJOYN_JOINSESSION_REPLY_BAD_SESSION_OPTS = 0x9087 /**< JoinSession reply: Failed due to session option incompatibilities */,
            ALLJOYN_JOINSESSION_REPLY_FAILED = 0x9088 /**< JoinSession reply: Failed for unknown reason */,
            ALLJOYN_LEAVESESSION_REPLY_NO_SESSION = 0x908a /**< LeaveSession reply: Session with given name does not exist */,
            ALLJOYN_LEAVESESSION_REPLY_FAILED = 0x908b /**< LeaveSession reply: Failed for unspecified reason */,
            ALLJOYN_ADVERTISENAME_REPLY_TRANSPORT_NOT_AVAILABLE = 0x908c /**< AdvertiseName reply: The specified transport is unavailable for advertising */,
            ALLJOYN_ADVERTISENAME_REPLY_ALREADY_ADVERTISING = 0x908d /**< AdvertiseName reply: This endpoint is already advertising this name */,
            ALLJOYN_ADVERTISENAME_REPLY_FAILED = 0x908e /**< AdvertiseName reply: Advertise failed */,
            ALLJOYN_CANCELADVERTISENAME_REPLY_FAILED = 0x9090 /**< CancelAdvertiseName reply: Advertise failed */,
            ALLJOYN_FINDADVERTISEDNAME_REPLY_TRANSPORT_NOT_AVAILABLE = 0x9091 /**< FindAdvertisedName reply: The specified transport is unavailable for discovery */,
            ALLJOYN_FINDADVERTISEDNAME_REPLY_ALREADY_DISCOVERING = 0x9092 /**< FindAdvertisedName reply: This endpoint is already discovering this name */,
            ALLJOYN_FINDADVERTISEDNAME_REPLY_FAILED = 0x9093 /**< FindAdvertisedName reply: Failed */,
            ALLJOYN_CANCELFINDADVERTISEDNAME_REPLY_FAILED = 0x9095 /**< CancelFindAdvertisedName reply: Failed */,
            BUS_UNEXPECTED_DISPOSITION = 0x9096 /**< An unexpected disposition was returned and has been treated as an error */,
            BUS_INTERFACE_ACTIVATED = 0x9097 /**< An InterfaceDescription cannot be modified once activated */,
            ALLJOYN_UNBINDSESSIONPORT_REPLY_BAD_PORT = 0x9098 /**< UnbindSessionPort reply: SessionPort does not exist */,
            ALLJOYN_UNBINDSESSIONPORT_REPLY_FAILED = 0x9099 /**< UnbindSessionPort reply: Failed */,
            ALLJOYN_BINDSESSIONPORT_REPLY_INVALID_OPTS = 0x909a /**< BindSessionPort reply: SessionOpts are invalid */,
            ALLJOYN_JOINSESSION_REPLY_ALREADY_JOINED = 0x909b /**< JoinSession reply: Caller has already joined the session */,
            BUS_SELF_CONNECT = 0x909c /**< Received BusHello from self */,
            BUS_SECURITY_NOT_ENABLED = 0x909d /**< Security is not enabled for this bus attachment */,
            BUS_LISTENER_ALREADY_SET = 0x909e /**< A listener has already been set */,
            BUS_PEER_AUTH_VERSION_MISMATCH = 0x909f /**< Incompatible peer authentication version numbers */,
            ALLJOYN_SETLINKTIMEOUT_REPLY_NOT_SUPPORTED = 0x90a0 /**< Local router does not support SetLinkTimeout */,
            ALLJOYN_SETLINKTIMEOUT_REPLY_NO_DEST_SUPPORT = 0x90a1 /**< SetLinkTimeout not supported by destination */,
            ALLJOYN_SETLINKTIMEOUT_REPLY_FAILED = 0x90a2 /**< SetLinkTimeout failed */,
            ALLJOYN_ACCESS_PERMISSION_WARNING = 0x90a3 /**< No permission to use Wifi */,
            ALLJOYN_ACCESS_PERMISSION_ERROR = 0x90a4 /**< No permission to access peer service */,
            BUS_DESTINATION_NOT_AUTHENTICATED = 0x90a5 /**< Cannot send a signal to a destination that is not authenticated */,
            BUS_ENDPOINT_REDIRECTED = 0x90a6 /**< Endpoint was redirected to another address */,
            BUS_AUTHENTICATION_PENDING = 0x90a7 /**< Authentication of remote peer is pending */,
            BUS_NOT_AUTHORIZED = 0x90a8 /**< Operation was not authorized */,
            PACKET_BUS_NO_SUCH_CHANNEL = 0x90a9 /**< Received packet for unknown channel */,
            PACKET_BAD_FORMAT = 0x90aa /**< Received packet with incorrect header information */,
            PACKET_CONNECT_TIMEOUT = 0x90ab /**< Timed out waiting for connect response */,
            PACKET_CHANNEL_FAIL = 0x90ac /**< Failed to create new comm channel */,
            PACKET_TOO_LARGE = 0x90ad /**< Message too large for use with packet based transport */,
            PACKET_BAD_PARAMETER = 0x90ae /**< Invalid PacketEngine control packet received */,
            PACKET_BAD_CRC = 0x90af /**< Packet has invalid CRC */,
            RENDEZVOUS_SERVER_DEACTIVATED_USER = 0x90cb /**< Rendezvous Server has deactivated the current user. Register with the Rendezvous Server to continue. */,
            RENDEZVOUS_SERVER_UNKNOWN_USER = 0x90cc /**< Rendezvous Server does not recognize the current user. Register with the Rendezvous Server to continue. */,
            UNABLE_TO_CONNECT_TO_RENDEZVOUS_SERVER = 0x90cd /**< Unable to connect to the Rendezvous Server */,
            NOT_CONNECTED_TO_RENDEZVOUS_SERVER = 0x90ce /**< Not connected to the Rendezvous Server */,
            UNABLE_TO_SEND_MESSAGE_TO_RENDEZVOUS_SERVER = 0x90cf /**< Unable to send message to the Rendezvous Server */,
            INVALID_RENDEZVOUS_SERVER_INTERFACE_MESSAGE = 0x90d0 /**< Invalid Rendezvous Server interface message */,
            INVALID_PERSISTENT_CONNECTION_MESSAGE_RESPONSE = 0x90d1 /**< Invalid message response received over the Persistent connection with the Rendezvous Server */,
            INVALID_ON_DEMAND_CONNECTION_MESSAGE_RESPONSE = 0x90d2 /**< Invalid message response received over the On Demand connection with the Rendezvous Server */,
            INVALID_HTTP_METHOD_USED_FOR_RENDEZVOUS_SERVER_INTERFACE_MESSAGE = 0x90d3 /**< Invalid HTTP method type used for Rendezvous Server interface message */,
            RENDEZVOUS_SERVER_ERR500_INTERNAL_ERROR = 0x90d4 /**< Received a HTTP 500 status code from the Rendezvous Server. This indicates an internal error in the Server */,
            RENDEZVOUS_SERVER_ERR503_STATUS_UNAVAILABLE = 0x90d5 /**< Received a HTTP 503 status code from the Rendezvous Server. This indicates unavailability of the Server error state */,
            RENDEZVOUS_SERVER_ERR401_UNAUTHORIZED_REQUEST = 0x90d6 /**< Received a HTTP 401 status code from the Rendezvous Server. This indicates that the client is unauthorized to send a request to the Server. The Client login procedure must be initiated. */,
            RENDEZVOUS_SERVER_UNRECOVERABLE_ERROR = 0x90d7 /**< Received a HTTP status code indicating unrecoverable error from the Rendezvous Server. The connection with the Server should be re-established. */,
            RENDEZVOUS_SERVER_ROOT_CERTIFICATE_UNINITIALIZED = 0x90d8 /**< Rendezvous Server root ceritificate uninitialized. */,
            BUS_NO_SUCH_ANNOTATION = 0x90d9 /**< No such annotation for a GET or SET operation  */,
            BUS_ANNOTATION_ALREADY_EXISTS = 0x90da /**< Attempt to add an annotation to an interface or property that already exists */,
            SOCK_CLOSING = 0x90db /**< Socket close in progress */,
            NO_SUCH_DEVICE = 0x90dc /**< A referenced device cannot be located */,
            P2P = 0x90dd /**< An error occurred in a Wi-Fi Direct helper method call */,
            P2P_TIMEOUT = 0x90de /**< A timeout occurred in a Wi-Fi Direct helper method call */,
            P2P_NOT_CONNECTED = 0x90df /**< A required Wi-Fi Direct network connection does not exist */,
            BAD_TRANSPORT_MASK = 0x90e0 /**< Exactly one mask bit was not set in the provided TransportMask */,
            PROXIMITY_CONNECTION_ESTABLISH_FAIL = 0x90e1 /**< Fail to establish P2P proximity connection */,
            PROXIMITY_NO_PEERS_FOUND = 0x90e2 /**< Cannot find proximity P2P peers */,
            BUS_OBJECT_NOT_REGISTERED = 0x90e3 /**< Operation not permitted on unregistered bus object */,
            P2P_DISABLED = 0x90e4 /**< Wi-Fi Direct is disabled on the device */,
            P2P_BUSY = 0x90e5 /**< Wi-Fi Direct resources are in busy state */,
            BUS_INCOMPATIBLE_DAEMON = 0x90e6 /**< The router version is too old to be used by this client */,
            P2P_NO_GO = 0x90e7 /**< Attempt to execute a Wi-Fi Direct GO-related operation while STA */,
            P2P_NO_STA = 0x90e8 /**< Attempt to execute a Wi-Fi Direct STA-related operation while GO */,
            P2P_FORBIDDEN = 0x90e9 /**< Attempt to execute a forbidden Wi-Fi Direct operation */,
            ALLJOYN_ONAPPSUSPEND_REPLY_FAILED = 0x90ea /**< OnAppSuspend reply: Failed */,
            ALLJOYN_ONAPPSUSPEND_REPLY_UNSUPPORTED = 0x90eb /**< OnAppSuspend reply: Unsupported operation */,
            ALLJOYN_ONAPPRESUME_REPLY_FAILED = 0x90ec /**< OnAppResume reply: Failed */,
            ALLJOYN_ONAPPRESUME_REPLY_UNSUPPORTED = 0x90ed /**< OnAppResume reply: Unsupported operation */,
            BUS_NO_SUCH_MESSAGE = 0x90ee /**< Message not found */,
            ALLJOYN_REMOVESESSIONMEMBER_REPLY_NO_SESSION = 0x90ef /**< RemoveSessionMember reply: Specified session Id with this endpoint was not found */,
            ALLJOYN_REMOVESESSIONMEMBER_NOT_BINDER = 0x90f0 /**< RemoveSessionMember reply: Endpoint is not the binder of session */,
            ALLJOYN_REMOVESESSIONMEMBER_NOT_MULTIPOINT = 0x90f1 /**< RemoveSessionMember reply: Session is not multipoint */,
            ALLJOYN_REMOVESESSIONMEMBER_NOT_FOUND = 0x90f2 /**< RemoveSessionMember reply: Specified session member was not found */,
            ALLJOYN_REMOVESESSIONMEMBER_INCOMPATIBLE_REMOTE_DAEMON = 0x90f3 /**< RemoveSessionMember reply: The remote router does not support this feature */,
            ALLJOYN_REMOVESESSIONMEMBER_REPLY_FAILED = 0x90f4 /**< RemoveSessionMember reply: Failed for unspecified reason */,
            BUS_REMOVED_BY_BINDER = 0x90f5 /**< The session member was removed by the binder */,
            BUS_MATCH_RULE_NOT_FOUND = 0x90f6 /**< The match rule was not found */,
            ALLJOYN_PING_FAILED = 0x90f7 /**< Ping failed */,
            ALLJOYN_PING_REPLY_UNREACHABLE = 0x90f8 /**< Name pinged is unreachable */,
            UDP_MSG_TOO_LONG = 0x90f9 /**< The message is too long to transmit over the UDP transport */,
            UDP_DEMUX_NO_ENDPOINT = 0x90fa /**< Tried to demux the callback but found no endpoint for the connection */,
            UDP_NO_NETWORK = 0x90fb /**< Not listening on network implied by IP address */,
            UDP_UNEXPECTED_LENGTH = 0x90fc /**< Request for more bytes than are in the underlying datagram */,
            UDP_UNEXPECTED_FLOW = 0x90fd /**< The data flow type of the endpoint has an unexpected value */,
            UDP_DISCONNECT = 0x90fe /**< Unexpected disconnect occurred */,
            UDP_NOT_IMPLEMENTED = 0x90ff /**< Feature not implemented for the UDP transport */,
            UDP_NO_LISTENER = 0x9100 /**< Discovery started with no listener to receive callbacks */,
            UDP_STOPPING = 0x9101 /**< Attempt to use UDP when transport stopping */,
            ARDP_BACKPRESSURE = 0x9102 /**< ARDP is applying backpressure -- send window is full */,
            UDP_BACKPRESSURE = 0x9103 /**< UDP is applying backpressure to ARDP -- queue is full */,
            ARDP_INVALID_STATE = 0x9104 /**< Current ARDP state does not allow attempted operation */,
            ARDP_TTL_EXPIRED = 0x9105 /**< Time-To-Live of ARDP segment has expired */,
            ARDP_PERSIST_TIMEOUT = 0x9106 /**< Remote endpoint stopped consuming data -- send window is full */,
            ARDP_PROBE_TIMEOUT = 0x9107 /**< ARDP link timeout */,
            ARDP_REMOTE_CONNECTION_RESET = 0x9108 /**< Remote endpoint disconected: sent RST */,
            UDP_BUSHELLO = 0x9109 /**< UDP Transport is unable to complete an operation relating to a BusHello Message */,
            UDP_MESSAGE = 0x910a /**< UDP Transport is unable to complete an operation on an AllJoyn Message */,
            UDP_INVALID = 0x910b /**< UDP Transport detected invalid data or parameters from network */,
            UDP_UNSUPPORTED = 0x910c /**< UDP Transport does not support the indicated operation or type */,
            UDP_ENDPOINT_STALLED = 0x910d /**< UDP Transport has detected an endpoint that is not terminating correctly */,
            ARDP_INVALID_RESPONSE = 0x910e /**< ARDP Transport detected invalid message data that causes disconnect */,
            ARDP_INVALID_CONNECTION = 0x910f /**< ARDP connection not found */,
            UDP_LOCAL_DISCONNECT = 0x9110 /**< UDP Transport connection (intentionally) disconnected on local side */,
            UDP_EARLY_EXIT = 0x9111 /**< UDP Transport connection aborted during setup */,
            UDP_LOCAL_DISCONNECT_FAIL = 0x9112 /**< UDP Transport local connection disconnect failure */,
            ARDP_DISCONNECTING = 0x9113 /**< ARDP connection is being shut down */,
            ALLJOYN_PING_REPLY_INCOMPATIBLE_REMOTE_ROUTING_NODE = 0x9114 /**< Remote routing node does not implement Ping */,
            ALLJOYN_PING_REPLY_TIMEOUT = 0x9115 /**< Ping call timeout */,
            ALLJOYN_PING_REPLY_UNKNOWN_NAME = 0x9116 /**< Name not found currently or part of any known session */,
            ALLJOYN_PING_REPLY_FAILED = 0x9117 /**< Generic Ping call error */,
            TCP_MAX_UNTRUSTED = 0x9118 /**< The maximum configured number of Thin Library connections has been reached */,
            ALLJOYN_PING_REPLY_IN_PROGRESS = 0x9119 /**< A ping request for same name is already in progress */,
            LANGUAGE_NOT_SUPPORTED = 0x911a /**< The language requested is not supported */,
            ABOUT_FIELD_ALREADY_SPECIFIED = 0x911b /**< A field using the same name is already specified. */,
            UDP_NOT_DISCONNECTED = 0x911c /**< A UDP stream was found to be connected during teardown */,
            UDP_ENDPOINT_NOT_STARTED = 0x911d /**< Attempt to send on a UDP endpoint that is not started */,
            UDP_ENDPOINT_REMOVED = 0x911e /**< Attempt to send on a UDP endpoint that has been removed */,
            ARDP_VERSION_NOT_SUPPORTED = 0x911f /**< Specified version of ARDP Protocol is not supported */,
            CONNECTION_LIMIT_EXCEEDED = 0x9120 /**< Connection rejected due to configured connection limits */,
            ARDP_WRITE_BLOCKED = 0x9121 /**< ARDP cannot write to UDP socket (queue is full) */,
            PERMISSION_DENIED = 0x9122 /**< Permission denied */,
            ABOUT_DEFAULT_LANGUAGE_NOT_SPECIFIED = 0x9123 /**< Default language must be specified before setting a localized field */,
            ABOUT_SESSIONPORT_NOT_BOUND = 0x9124 /**< Unable to announce session port that is not bound to the BusAttachment */,
            ABOUT_ABOUTDATA_MISSING_REQUIRED_FIELD = 0x9125 /**< The AboutData is missing a required field. */,
            ABOUT_INVALID_ABOUTDATA_LISTENER = 0x9126 /**< The AboutDataListener returns invalid data. Most likely cause: the announced data does not match with non-announced data. */,
            BUS_PING_GROUP_NOT_FOUND = 0x9127 /**< Ping group did not exist */,
            BUS_REMOVED_BY_BINDER_SELF = 0x9128 /**< The self-joined session member was removed by the binder */,
            INVALID_CONFIG = 0x9129 /**< Invalid configuration item or combination of items detected */,
            ABOUT_INVALID_ABOUTDATA_FIELD_VALUE = 0x912a /**< General error indicating the value given for an About Data field is invalid. */,
            ABOUT_INVALID_ABOUTDATA_FIELD_APPID_SIZE = 0x912b /**< Error indicating the AppId field is not a 128-bit bite array. */,
            BUS_TRANSPORT_ACCESS_DENIED = 0x912c /**< The transport denied the connection attempt because the application doesn't have the required permissions. */,
            INVALID_CERTIFICATE = 0x912d /**< Invalid certificate */,
            CERTIFICATE_NOT_FOUND = 0x912e /**< Certificate not found */,
            DUPLICATE_CERTIFICATE = 0x912f /**< Duplicate Certificate found */,
            UNKNOWN_CERTIFICATE = 0x9130 /**< Unknown Certificate */,
            MISSING_DIGEST_IN_CERTIFICATE = 0x9131 /**< Missing digest in certificate */,
            DIGEST_MISMATCH = 0x9132 /**< Digest mismatch */,
            DUPLICATE_KEY = 0x9133 /**< Duplicate key found */,
            NO_COMMON_TRUST = 0x9134 /**< No common trust anchor found */,
            MANIFEST_NOT_FOUND = 0x9135 /**< Permission manifest not found */,
            INVALID_CERT_CHAIN = 0x9136 /**< Invalid certificate chain */,
            NO_TRUST_ANCHOR = 0x9137 /**< No trust anchor */,
            INVALID_APPLICATION_STATE = 0x9138 /**< Invalid application state */,
            FEATURE_NOT_AVAILABLE = 0x9139 /**< Feature is not available */,
            KEY_STORE_ALREADY_INITIALIZED = 0x913a /**< Key store is already initialized */,
            KEY_STORE_ID_NOT_YET_SET = 0x913b /**< Key store ID is not yet set */,
            POLICY_NOT_NEWER = 0x913c /**< Installing permission policy not newer than existing policy */,
            MANIFEST_REJECTED = 0x913d /**< The manifest of the application was rejected. */,
            INVALID_CERTIFICATE_USAGE = 0x913e /**< The certificate extended key usage is not Alljoyn specific. */,
            INVALID_SIGNAL_EMISSION_TYPE = 0x913f /**< Attempt to send a signal with the wrong type. */
            
        }

//
    internal class AllJoynStatusCodeHelper
    {
        /// <summary>
        /// Convert a status code to a C string.
        /// </summary>
        /// <param name="status">Status code to be converted.</param>
        /// <returns>C string representation of the status code.</returns>
        [DllImport("MSAJApi.dll")]
        internal static extern IntPtr QCC_StatusText(AllJoynStatusCode status);

    }
}
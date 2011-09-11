////////////////////////////////////////////////////////////////////////////////
////	Best regards to														////
////	http://colonelpanic.net/2009/03/building-a-firefox-plugin-part-one/	////
////	for NPN and NPP struct												////
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using BaseExportDLL;

namespace BaseNPDLL
{
	public struct NPNetscapeFuncs
	{
		public ushort size;
		public ushort version; // Newer versions may have additional fields added to the end
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetURLUPP geturl; // Make a GET request for a URL either to the window or another stream
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_PostURLUPP posturl; // Make a POST request for a URL either to the window or another stream
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_RequestReadUPP requestread;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_NewStreamUPP newstream;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_WriteUPP write;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_DestroyStreamUPP destroystream;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_StatusUPP status;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_UserAgentUPP uagent;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_MemAllocUPP memalloc; // Allocates memory from the browser's memory space
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_MemFreeUPP memfree; // Frees memory from the browser's memory space
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_MemFlushUPP memflush;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_ReloadPluginsUPP reloadplugins;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetJavaEnvUPP getJavaEnv;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetJavaPeerUPP getJavaPeer;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetURLNotifyUPP geturlnotify; // Async call to get a URL
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_PostURLNotifyUPP posturlnotify; // Async call to post a URL
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetValueUPP getvalue; // Get information from the browser
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_SetValueUPP setvalue; // Set information about the plugin that the browser controls
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_InvalidateRectUPP invalidaterect;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_InvalidateRegionUPP invalidateregion;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_ForceRedrawUPP forceredraw;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetStringIdentifierUPP getstringidentifier; // Get a NPIdentifier for a given string
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetStringIdentifiersUPP getstringidentifiers;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetIntIdentifierUPP getintidentifier;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_IdentifierIsStringUPP identifierisstring;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_UTF8FromIdentifierUPP utf8fromidentifier; // Get a string from a NPIdentifier
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_IntFromIdentifierUPP intfromidentifier;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_CreateObjectUPP createobject; // Create an instance of a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_RetainObjectUPP retainobject; // Increment the reference count of a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_ReleaseObjectUPP releaseobject; // Decrement the reference count of a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_InvokeUPP invoke; // Invoke a method on a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_InvokeDefaultUPP invokeDefault; // Invoke the default method on a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_EvaluateUPP evaluate; // Evaluate javascript in the scope of a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetPropertyUPP getproperty; // Get a property on a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_SetPropertyUPP setproperty; // Set a property on a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_RemovePropertyUPP removeproperty; // Remove a property from a NPObject
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_HasPropertyUPP hasproperty; // Returns true if the given NPObject has the given property
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_HasMethodUPP hasmethod; // Returns true if the given NPObject has the given Method
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_ReleaseVariantValueUPP releasevariantvalue; // Release a MNVariant (free memory)
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_SetExceptionUPP setexception;
#if XP_UNIX
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPN_GetValueUPP getvalue;
#endif // XP_UNIX
	}

	public unsafe struct NPByteRange
	{
		public int offset;  /* negative offset = from the end */
		public uint length;
	    public NPByteRange* next;
	}
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_GetURLUPP(NPP* instance,sbyte* url,sbyte* window);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_PostURLUPP(NPP* instance,sbyte* url,sbyte* window,int len,sbyte* buf,bool file);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_RequestReadUPP(NPStream *stream,NPByteRange *rangeList);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_NewStreamUPP(NPP* instance, sbyte* mimeType,sbyte* window,NPStream** stream);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int NPN_WriteUPP(NPP* instance, NPStream *stream,int len,void* buffer);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_DestroyStreamUPP(NPP* instance,NPStream* stream, NPReason reason);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_StatusUPP(NPP* instance,string message);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate string NPN_UserAgentUPP(NPP* instance);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void* NPN_MemAllocUPP(uint size);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_MemFreeUPP(void* ptr);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate uint NPN_MemFlushUPP(uint size);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_ReloadPluginsUPP(bool reloadPages);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void* NPN_GetJavaEnvUPP();
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void* NPN_GetJavaPeerUPP(NPP* instance);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_GetURLNotifyUPP(NPP* instance,sbyte* url,sbyte* window,void *notifyData);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_PostURLNotifyUPP(NPP* instance,sbyte* url,sbyte* window,uint len,sbyte* buf,bool file,void *notifyData);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_GetValueUPP(NPP* instance, NPNVariable variable,void *ret_value);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPN_SetValueUPP(NPP* instance, NPPVariable variable, void *ret_alue);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_InvalidateRectUPP(NPP* instance,NPRect *rect);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_InvalidateRegionUPP(NPP* instance,IntPtr region);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_ForceRedrawUPP(NPP* instance);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate IntPtr NPN_GetStringIdentifierUPP(char* name);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_GetStringIdentifiersUPP(char** names,int nameCount,IntPtr* identifiers);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate IntPtr NPN_GetIntIdentifierUPP(int intid);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_IdentifierIsStringUPP(NPIdentifier identifier);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate char* NPN_UTF8FromIdentifierUPP(NPIdentifier identifier);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int NPN_IntFromIdentifierUPP(NPIdentifier identifier);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPObject* NPN_CreateObjectUPP(NPP* npp,NPClass* aClass);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPObject* NPN_RetainObjectUPP(NPObject *obj);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_ReleaseObjectUPP(NPObject *obj);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_InvokeUPP(NPP* npp,NPObject* obj,NPIdentifier methodName,NPVariant* args,uint argCount,NPVariant* result);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_InvokeDefaultUPP(NPP* npp,NPObject* obj,NPVariant* args,uint argCount,NPVariant* result);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_EvaluateUPP(NPP* npp,NPObject* obj,NPString* script,NPVariant* result);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_GetPropertyUPP(NPP* npp,NPObject* obj, NPIdentifier propertyName,NPVariant* result);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_SetPropertyUPP(NPP* npp,NPObject* obj, NPIdentifier propertyName,NPVariant* value);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_RemovePropertyUPP(NPP* npp,NPObject* obj, NPIdentifier propertyName);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_HasPropertyUPP(NPP* npp,NPObject* obj, NPIdentifier propertyName);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool NPN_HasMethodUPP(NPP* npp,NPObject* obj, NPIdentifier propertyName);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_ReleaseVariantValueUPP(NPVariant* variant);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPN_SetExceptionUPP(NPObject* obj,char* message);
}

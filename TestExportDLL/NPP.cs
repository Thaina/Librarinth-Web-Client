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
	public struct NPP
	{
		public IntPtr pdata;
		public readonly IntPtr ndata;
	}

	public unsafe struct NPSavedData
	{
		public int len;
		public IntPtr buffer;
	}
	public struct NPRect
	{
		public ushort top;
		public ushort left;
		public ushort bottom;
		public ushort right;
	}
	public struct NPWindow 
	{
		public IntPtr window;		/* Platform specific window handle */
		public uint	x;			/* Position of top left corner relative */
		public uint y; 			/*	to a netscape page.					*/
		public uint width;		/* Maximum window size */
		public uint height;
		public NPRect clipRect;	/* Clipping rectangle in port coordinates */
#if XP_UNIX
		public void* ws_info;	/* Platform-dependent additonal data */
#endif
		public Type type;
		public enum Type
		{
			Window	= 1,
			Drawable
		}
	}
	public unsafe struct NPStream
	{
		public void* pdata;		/* plug-in private data */
		public void* ndata;		/* netscape private data */
		public sbyte* url;
		public uint end;
		public uint lastmodified;
		public void* notifyData;
		public sbyte* headers;
	}
	public enum NPPVariable
	{
		PluginNameString = 1,
		PluginDescriptionString,
		NPPVpluginWindowBool,
		NPPVpluginTransparentBool,

		NPPVjavaClass,                /* Not implemented in WebKit */
		NPPVpluginWindowSize,         /* Not implemented in WebKit */
		NPPVpluginTimerInterval,      /* Not implemented in WebKit */

		NPPVpluginScriptableIID = 11, /* Not implemented in WebKit */

		/* 12 and over are available on Mozilla builds starting with 0.9.9 */
		NPPVjavascriptPushCallerBool = 12,  /* Not implemented in WebKit */
		NPPVpluginKeepLibraryInMemory = 13, /* Not implemented in WebKit */
		NPPVpluginNeedsXEmbed         = 14, /* Not implemented in WebKit */

		/* Get the NPObject for scripting the plugin. */
		NPPVpluginScriptableNPObject  = 15
	}
	public enum NPNVariable
	{
		Display = 1,
		AppContext,
		Window,
		JavascriptEnabled,
	}
	public enum NPReason
	{
		DONE	= 0,
		NETWORK_ERR	= 1,
		USER_BREAK	= 2,
	}

	public unsafe struct NPFullPrint
	{
		public byte pluginPrinted;	/* Set TRUE if plugin handled fullscreen printing*/
		public byte printOne;		/* TRUE if plugin should print one copy to default printer */
		public void* platformPrint;	/* Platform-specific printing info */
	}
	public unsafe struct NPEmbedPrint
	{
		public NPWindow window;
		public void* platformPrint;	/* Platform-specific printing info */
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct NPPrint
	{
		[FieldOffset(0)]
		Mode mode;						/* NP_FULL or NP_EMBED */
		[FieldOffset(sizeof(Mode))]
		NPFullPrint fullPrint;		/* if mode is NP_FULL */
		[FieldOffset(sizeof(Mode))]
		NPEmbedPrint embedPrint;		/* if mode is NP_EMBED */
	}
	public enum Mode : ushort
	{
		EMBED	= 1,
		FULL	= 2,
	}
	
	public struct NPPluginFuncs
	{
		public ushort size;
		public ushort version;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_New newp;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_Destroy destroy;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_SetWindow setwindow;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_NewStream newstream;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_DestroyStream destroystream;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_StreamAsFile asfile;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_WriteReady writeready;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_Write write;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_Print print;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_HandleEvent handleEvent;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_URLNotify urlnotify;
		public IntPtr javaClass; // Deprecated
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_GetValue getvalue;
		[MarshalAs(UnmanagedType.FunctionPtr)]public NPP_SetValue setvalue;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_New(sbyte* mimeType,NPP* instance,Mode mode,short argc,sbyte** argn,sbyte** argv,NPSavedData* saved);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_Destroy(NPP* instance,NPSavedData** save);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_SetWindow(NPP* instance,NPWindow* window);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_NewStream(NPP* instance,sbyte* mimeType,NPStream* stream,byte seekable,ushort* stype);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_DestroyStream(NPP* instance,NPStream* stream, NPReason reason);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int NPP_WriteReady(NPP* instance,NPStream* stream);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int NPP_Write(NPP* instance,NPStream* stream,int offset,int len,void* buffer);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPP_StreamAsFile(NPP* instance,NPStream* stream,sbyte* fname);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPP_Print(NPP* instance,NPPrint* platformPrint);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate short NPP_HandleEvent(NPP* instance,void* eventHandler);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void NPP_URLNotify(NPP* instance,sbyte* URL,NPReason reason, void* notifyData);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_GetValue(NPP* instance,NPPVariable variable, void *value);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate NPError NPP_SetValue(NPP* instance,NPNVariable variable, void *value);
}

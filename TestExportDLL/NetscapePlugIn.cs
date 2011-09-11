using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using BaseExportDLL;
using System.IO;

namespace BaseNPDLL
{
	public enum NPError : short
	{
		NO_ERROR	= 0,
		GENERIC_ERROR	= 1,
		INVALID_INSTANCE_ERROR	= 2,
		INVALID_FUNCTABLE_ERROR	= 3,
		MODULE_LOAD_FAILED_ERROR	= 4,
		OUT_OF_MEMORY_ERROR	= 5,
		INVALID_PLUGIN_ERROR	= 6,
		INVALID_PLUGIN_DIR_ERROR	= 7,
		INCOMPATIBLE_VERSION_ERROR	= 8,
		INVALID_PARAM	= 9,
		INVALID_URL	= 10,
		FILE_NOT_FOUND	= 11,
		NO_DATA	= 12,
		STREAM_NOT_SEEKABLE	= 13,
	}

	public sealed unsafe class NetscapePlugIn
	{
		static unsafe void urlnotify(NPP* instance,sbyte* URL,NPReason reason,void* notifyData)
		{
			File.AppendAllText(logfile,"urlnotify\n");

		}
		static unsafe short handleEvent(NPP* instance,void* eventHandler)
		{
			File.AppendAllText(logfile,"eventHandle\n");

			return 0;
		}
		static unsafe void print(NPP* instance,NPPrint* platformPrint)
		{
			File.AppendAllText(logfile,"print\n");

		}
		static unsafe int write(NPP* instance,NPStream* stream,int offset,int len,void* buffer)
		{
			File.AppendAllText(logfile,"write\n");

			return len;
		}
		static unsafe int writeready(NPP* instance,NPStream* stream)
		{
			File.AppendAllText(logfile,"writeready\n");

			return 0xFFFF;
		}
		static unsafe void asfile(NPP* instance,NPStream* stream,sbyte* fname)
		{
			File.AppendAllText(logfile,"asfile\n");
		}
		static unsafe NPError destroystream(NPP* instance,NPStream* stream,NPReason reason)
		{
			File.AppendAllText(logfile,"destroystream\n");

			return NPError.NO_ERROR;
		}
		static unsafe NPError newstream(NPP* instance,sbyte* mimeType,NPStream* stream,byte seekable,ushort* stype)
		{
			File.AppendAllText(logfile,"newstream\n");

			return NPError.NO_ERROR;
		}
		
		static unsafe NPError getvalue(NPP* instance,NPPVariable variable,void* value)
		{
			File.AppendAllText(logfile,"getvalue " + variable + " \n");

			return instances[instance->pdata].Key.getvalue(variable,value);
		}

		static unsafe NPError setvalue(NPP* instance,NPNVariable variable,void* value)
		{
			File.AppendAllText(logfile,"setvalue " + variable + " \n");

			return instances[instance->pdata].Key.setvalue(variable,value);
		}

		static unsafe NPError setwindow(NPP* instance,NPWindow* window)
		{
			if(window->window != IntPtr.Zero)
				ImportUser32.SetWndProc(window->window,instances[instance->pdata].Value);
			
			return NPError.NO_ERROR;
		}

		static unsafe NPError destroy(NPP* instance,NPSavedData** save)
		{
			instances[instance->pdata].Key.Dispose();
			instances.Remove(instance->pdata);
			instance->pdata	= IntPtr.Zero;

			File.AppendAllText(logfile,"Destroy " + instance->pdata + "\n");

			return NPError.NO_ERROR;
		}

		static readonly Dictionary<IntPtr,KeyValuePair<GLInstance,WindowProc>> instances	= new Dictionary<IntPtr,KeyValuePair<GLInstance,WindowProc>>();
		static unsafe NPError newp(sbyte* mimeType,NPP* instance,Mode mode,short argc,sbyte** argn,sbyte** argv,NPSavedData* saved)
		{
			var target	= new GLInstance();
			instance->pdata	= new IntPtr(target.GetHashCode());
			instances.Add(instance->pdata,new KeyValuePair<GLInstance,WindowProc>(target,target.WndProc));

			File.AppendAllText(logfile,"New " + instance->pdata + "\n");

			return NPError.NO_ERROR;
		}

		static IntPtr pNPNFuncs;
		internal static NPNetscapeFuncs NPNFuncs
		{ get { return (NPNetscapeFuncs)Marshal.PtrToStructure(pNPNFuncs,typeof(NPNetscapeFuncs)); } }

		static readonly string logfile	= @"C:\Users\Thaina\Desktop\logger.txt";
		static readonly NPPluginFuncs tmpNPPFuncs;
		static NetscapePlugIn()
		{
			if(File.Exists(logfile))
				File.Delete(logfile);
			
			tmpNPPFuncs.newp	= newp;
			tmpNPPFuncs.destroy	= destroy;
			tmpNPPFuncs.setwindow	= setwindow;
			tmpNPPFuncs.newstream	= newstream;
			tmpNPPFuncs.destroystream	= destroystream;
			tmpNPPFuncs.asfile	= asfile;
			tmpNPPFuncs.writeready	= writeready;
			tmpNPPFuncs.write	= write;
			tmpNPPFuncs.print	= print;
			tmpNPPFuncs.handleEvent	= handleEvent;
			tmpNPPFuncs.urlnotify	= urlnotify;
			tmpNPPFuncs.getvalue	= getvalue;
			tmpNPPFuncs.setvalue	= setvalue;
		}

		[DLLExport("NP_GetEntryPoints",CallingConvention.StdCall)]
		static unsafe NPError NP_GetEntryPoints(ref NPPluginFuncs nppFuncs)
		{
			if(nppFuncs.size < Marshal.SizeOf(nppFuncs))
				return NPError.INVALID_FUNCTABLE_ERROR;

			nppFuncs	= tmpNPPFuncs;

			return NPError.NO_ERROR;
		}

		[DLLExport("NP_Initialize",CallingConvention.StdCall)]
		static unsafe NPError NP_Initialize(ref NPNetscapeFuncs npnFuncPtr)
		{
			if(npnFuncPtr.size < (ushort)Marshal.SizeOf(npnFuncPtr))
				return NPError.INVALID_FUNCTABLE_ERROR;

			var npnFuncs	= npnFuncPtr;

			return NPError.NO_ERROR;
		}

		[DLLExport("NP_Shutdown",CallingConvention.StdCall)]
		static unsafe NPError NP_Shutdown()
		{
			return NPError.NO_ERROR;
		}
	}
}

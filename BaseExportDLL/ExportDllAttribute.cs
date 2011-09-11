using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace BaseExportDLL
{
    [AttributeUsage(AttributeTargets.Method)] 
    public class DLLExportAttribute : Attribute
    {
		public readonly string ExportName;
		public readonly string Convention;
		public DLLExportAttribute(string exportName) : this(exportName,CallingConvention.StdCall) { }
        public DLLExportAttribute(string exportName,CallingConvention callingConvention)
        {
            ExportName = exportName;
			switch(callingConvention)
			{
				case CallingConvention.Winapi:
				case CallingConvention.StdCall:
					Convention	= typeof(CallConvStdcall).FullName;
					break;
				case CallingConvention.FastCall:
					Convention	= typeof(CallConvFastcall).FullName;
					break;
				case CallingConvention.ThisCall:
					Convention	= typeof(CallConvThiscall).FullName;
					break;
				case CallingConvention.Cdecl:
					Convention	= typeof(CallConvCdecl).FullName;
					break;

				default:
					throw new NotImplementedException();
			}
        }
    }
}

////////////////////////////////////////////////////////////////////////////////
////	From https://developer.mozilla.org/en/NPObject						////
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using BaseExportDLL;

namespace BaseNPDLL
{
	public struct NPIdentifier
	{
		IntPtr handle;
	}
	
	public unsafe struct NPString
	{
		public char* UTF8Characters;
		public uint UTF8Length;
	}
	
	public enum NPVariantType
	{
		Void,
		Null,
		Bool,
		Int32,
		Double,
		String,
		Object,
	}

	public unsafe struct NPVariant
	{
		NPVariantType type;
		byte startValue;
	}

	public struct NPClass
	{
		public uint structVersion;
		public IntPtr allocate;
		public IntPtr deallocate;
		public IntPtr invalidate;
		public IntPtr hasMethod;
		public IntPtr invoke;
		public IntPtr invokeDefault;
		public IntPtr hasProperty;
		public IntPtr getProperty;
		public IntPtr setProperty;
		public IntPtr removeProperty;
		public IntPtr enumerate;
		public IntPtr construct;
	}

	public unsafe delegate NPObject* NPAllocateFunctionPtr(NPP* npp,NPClass* npClass);
	public unsafe delegate void NPDeallocateFunctionPtr(NPObject *npobj);
	public unsafe delegate void NPInvalidateFunctionPtr(NPObject *npobj);
	public unsafe delegate bool NPHasMethodFunctionPtr(NPObject *npobj,NPIdentifier name);
	public unsafe delegate bool NPInvokeFunctionPtr(NPObject *npobj,NPIdentifier name,NPVariant* args,uint argCount,NPVariant* result);
	public unsafe delegate bool NPInvokeDefaultFunctionPtr(NPObject *npobj,NPVariant* args,uint argCount,NPVariant* result);
	public unsafe delegate bool NPHasPropertyFunctionPtr(NPObject* npobj,NPIdentifier name);
	public unsafe delegate bool NPGetPropertyFunctionPtr(NPObject* npobj,NPIdentifier name,NPVariant* result);
	public unsafe delegate bool NPSetPropertyFunctionPtr(NPObject* npobj,NPIdentifier name,NPVariant* value);
	public unsafe delegate bool NPRemovePropertyFunctionPtr(NPObject *npobj,NPIdentifier name);
	public unsafe delegate bool NPEnumerationFunctionPtr(NPObject *npobj,NPIdentifier** value,uint* count);
	public unsafe delegate bool NPConstructFunctionPtr(NPObject *npobj,NPVariant* args,uint argCount,NPVariant* result);
	public unsafe struct NPObject
	{
		public NPClass* npClass;
		public int referenceCount;
	}
}

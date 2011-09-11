using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using SlimMath;
using System.Windows.Forms;

namespace BaseNPDLL
{
	public unsafe abstract class BaseInstance : IDisposable
	{
		protected internal abstract unsafe NPError getvalue(NPPVariable variable,void* value);
		protected internal abstract unsafe NPError setvalue(NPNVariable variable,void* value);

		protected internal abstract int WndProc(IntPtr hwnd,WM msg,IntPtr wParam,IntPtr lParam);

		public abstract void Dispose();

		static readonly Dictionary<string,Type> instanceTypes	= new Dictionary<string,Type>();
		static BaseInstance()
		{
			var types	= Assembly.GetExecutingAssembly().GetTypes();
			types	= Array.FindAll(types,(Type type)
				=>!type.IsAbstract && !type.IsGenericType && type.IsSubclassOf(typeof(BaseInstance)));

			foreach(var type in types)
				instanceTypes.Add(type.Name,type);
		}
	}


	public unsafe class GLInstance : BaseInstance,CSGL.IClient
	{
		protected internal override unsafe NPError getvalue(NPPVariable variable,void* value)
		{
			return NPError.NO_ERROR;
		}

		protected internal override unsafe NPError setvalue(NPNVariable variable,void* value)
		{
			return NPError.NO_ERROR;
		}

		CSGL.Package glPackage;
		protected sealed internal override int WndProc(IntPtr hwnd,WM msg,IntPtr wParam,IntPtr lParam)
		{
			switch(msg)
			{
			case WM.PAINT:
				try
				{ CSGL.DoWork(this,hwnd,ref glPackage); }
				catch(Exception e)
				{ File.AppendAllText(@"C:\Users\Thaina\Desktop\logger.txt",e.ToString()); }
				return 0;
			default:
				return ImportUser32.DefWindowProc(hwnd,msg,wParam,lParam);
			}
		}
		
		bool created	= true;
		public bool Created { get { return created; } }
		public override void Dispose() { created	= false; }

		public PixelFormat PixelFormat
		{ get { return PixelFormat.Default; } }

		bool loaded	= false;
		float[] v = { -1/3f,-0.5f,0,0,1/3f,0,1/3f,-0.5f,0 };
		byte[] c = { 255,0,0,0,255,0,0,0,255 };
		public void Draw(CSGL gl)
		{
			if(!loaded)
			{
				loaded	= true;
			}

			var fade	= (Environment.TickCount / 2000f) % 2;
			var col	= new Color4(0.5f,fade < 1 ? (fade % 1) : 1 - (fade % 1),fade >= 1 ? (fade % 1) : 1 - (fade % 1),1);
			gl.Clear(col,1);

			gl.InitMatrix();

			gl.EnableVertex();
			gl.EnableColor();

			fixed(float* pV	= v)
				gl.VertexPointer(3,0,pV);
			fixed(byte* pC	= c)
				gl.ColorPointer(3,0,pC);

			gl.DrawArrays(CSGL.DrawMode.Triangles,0,3);

			gl.Finish();
		}
	}
}
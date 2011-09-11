using System;
using System.Runtime.InteropServices;

	unsafe class GDI
	{
		const string DLL	= "gdi32.dll";

		[DllImport(DLL,EntryPoint="GetPixelFormat",ExactSpelling=true)]
		internal static extern int GetPixelFormat(IntPtr HDC);
		[DllImport(DLL,EntryPoint="ChoosePixelFormat",ExactSpelling=true)]
		internal static extern int ChoosePixelFormat(IntPtr HDC,ref PixelFormat PFD);
		[DllImport(DLL,EntryPoint="DescribePixelFormat",ExactSpelling=true)]
		internal static extern int DescribePixelFormat(IntPtr HDC,int IndexPFD,UInt32 cjpfd,ref PixelFormat PFD);
		[DllImport(DLL,EntryPoint="SetPixelFormat",ExactSpelling=true)]
		internal static extern bool SetPixelFormat(IntPtr HDC,int IndexPFD,ref PixelFormat PFD);
	}
	unsafe class WGL
	{
		[DllImport("Kernel32.dll",EntryPoint="GetLastError")]
		internal static extern int GetLastError();

		[DllImport("kernel32.dll",SetLastError=true,CharSet=CharSet.Unicode)]
		internal static extern IntPtr LoadLibrary(string lpFileName);
		[DllImport("kernel32.dll",SetLastError=true,CharSet=CharSet.Ansi)]
		internal static extern IntPtr GetProcAddress(IntPtr hModule,string procName);
		[DllImport("kernel32.dll",SetLastError=true)]
		internal static extern bool FreeLibrary(IntPtr hModule);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("user32.dll")]
		public static extern bool ReleaseDC(IntPtr hWnd,IntPtr hDC);

		////////////////////////////////////////////////////////////////

		const string GL_DLL	= "opengl32.dll";

		[DllImport(GL_DLL,EntryPoint="wglCreateContext",ExactSpelling=true)]
		internal static extern uint CreateContext(IntPtr HDC);
		[DllImport(GL_DLL,EntryPoint="wglDeleteContext",ExactSpelling=true)]
		internal static extern bool DeleteContext(uint HRC);

		[DllImport(GL_DLL,EntryPoint="wglGetCurrentContext",ExactSpelling=true)]
		internal static extern uint GetCurrentContext();
		[DllImport(GL_DLL,EntryPoint="wglGetCurrentDC",ExactSpelling=true)]
		internal static extern IntPtr GetCurrentDC();

		[DllImport(GL_DLL,EntryPoint="wglMakeCurrent",ExactSpelling=true)]
		internal static extern bool MakeCurrent(IntPtr HDC,uint HRC);

		[DllImport(GL_DLL,EntryPoint="wglCopyContext",ExactSpelling=true)]
		internal static extern bool CopyContext(uint HRCSrc,uint HRCDst,uint Mask);

		[DllImport(GL_DLL,EntryPoint="wglGetDefaultProcAddress",ExactSpelling=true)]
		internal static extern IntPtr GetDefaultProcAddress(byte* lpszProc);
		[DllImport(GL_DLL,EntryPoint="wglGetProcAddress",ExactSpelling=true)]
		internal static extern IntPtr GetProcAddress(byte* lpszProc);

		[DllImport(GL_DLL,EntryPoint="wglSwapBuffers",ExactSpelling=true)]
		internal static extern bool SwapBuffers(IntPtr HDC);

		[DllImport(GL_DLL,EntryPoint="wglShareLists",ExactSpelling=true)]
		internal static extern bool ShareLists(uint HRCShare,uint HRCSrc);

		[DllImport(GL_DLL,EntryPoint="wglCreateLayerContext",ExactSpelling=true)]
		internal static extern IntPtr CreateLayerContext(IntPtr hDc,int level);
		[DllImport(GL_DLL,EntryPoint="wglDescribeLayerPlane",ExactSpelling=true)]
		internal static extern bool DescribeLayerPlane(IntPtr hDc,int pixelFormat,int layerPlane,UInt32 nBytes,PixelFormat* plpd);
		[DllImport(GL_DLL,EntryPoint="wglSetLayerPaletteEntries",ExactSpelling=true)]
		internal static extern int SetLayerPaletteEntries(IntPtr hdc,int iLayerPlane,int iStart,int cEntries,Int32* pcr);
		[DllImport(GL_DLL,EntryPoint="wglGetLayerPaletteEntries",ExactSpelling=true)]
		internal static extern int GetLayerPaletteEntries(IntPtr hdc,int iLayerPlane,int iStart,int cEntries,Int32* pcr);
		[DllImport(GL_DLL,EntryPoint="wglRealizeLayerPalette",ExactSpelling=true)]
		internal static extern bool RealizeLayerPalette(IntPtr hdc,int iLayerPlane,Boolean bRealize);

		[DllImport(GL_DLL,EntryPoint="wglSwapLayerBuffers",ExactSpelling=true)]
		internal static extern bool SwapLayerBuffers(IntPtr hdc,UInt32 fuFlags);
	}

	public struct PixelFormat
	{
		public ushort nSize;
		public ushort nVersion;
		public Flag dwFlags;
		public Type PixelType;
		public byte cColorBits;
		public byte cRedBits;
		public byte cRedShift;
		public byte cGreenBits;
		public byte cGreenShift;
		public byte cBlueBits;
		public byte cBlueShift;
		public byte cAlphaBits;
		public byte cAlphaShift;
		public byte cAccumBits;
		public byte cAccumRedBits;
		public byte cAccumGreenBits;
		public byte cAccumBlueBits;
		public byte cAccumAlphaBits;
		public byte cDepthBits;
		public byte cStencilBits;
		public byte cAuxBuffers;
		public Plane LayerType;
		public byte bReserved;
		public uint dwLayerMask;
		public uint dwVisibleMask;
		public uint dwDamageMask;
		// 40 bytes total

		public static PixelFormat Default
		{
			get
			{
				PixelFormat PF;

				PF.nSize 			= 40;
				PF.nVersion			= 1;
				PF.dwFlags 			= Flag.DrawToWindow | Flag.SupportOpenGL | Flag.DoubleBuffer | Flag.SwapCopy;
				PF.PixelType		= Type.RGBA;
				PF.cColorBits		= 32;
				PF.cRedBits			= 0;
				PF.cRedShift		= 0;
				PF.cGreenBits		= 0;
				PF.cGreenShift		= 0;
				PF.cBlueBits		= 0;
				PF.cBlueShift		= 0;
				PF.cAlphaBits		= 0;
				PF.cAlphaShift		= 0;
				PF.cAccumBits		= 0;
				PF.cAccumRedBits	= 0;
				PF.cAccumGreenBits	= 0;
				PF.cAccumBlueBits	= 0;
				PF.cAccumAlphaBits	= 0;
				PF.cDepthBits		= 16;
				PF.cStencilBits		= 0;
				PF.cAuxBuffers		= 0;
				PF.LayerType		= Plane.Main;
				PF.bReserved		= 0;
				PF.dwLayerMask		= 0;
				PF.dwVisibleMask	= 0;
				PF.dwDamageMask	= 0;

				return PF;
			}
		}

		[Flags]
		public enum Flag : uint
		{
			DoubleBuffer	= 0x00000001,
			Stereo			= 0x00000002,
			DrawToWindow	= 0x00000004,
			DrawToBitmap	= 0x00000008,

			SupportGDI		= 0x00000010,
			SupportOpenGL	= 0x00000020,
			GenericFormat	= 0x00000040,
			NeedPalette		= 0x00000080,

			NeedSystemPalette	= 0x00000100,
			SwapExchange		= 0x00000200,
			SwapCopy			= 0x00000400,
			SwapLayerBuffers	= 0x00000800,

			GenericAccellerated	= 0x00001000,
			SupportDirectDraw	= 0x00002000,
		}
		public enum Type : byte
		{
			RGBA		= 0,
			ColorIndex	= 1,
		}
		public enum Plane : sbyte
		{
			Main		=0,
			Overlay		=1,
			Underlay	=-1,
		}
	}
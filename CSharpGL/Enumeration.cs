using System;

public partial class CSGL
{
	public enum ShaderType : uint
	{
		Vertex	= VERTEX_SHADER,
		Fragment	= FRAGMENT_SHADER,
	}

	public enum Error : uint
	{
		None	= NO_ERROR,
		InvalidEnum	= INVALID_ENUM,
		InvalidValue	= INVALID_VALUE,
		InvalidOperation	= INVALID_OPERATION,
		StackOverflow	= STACK_OVERFLOW,
		StackUnderflow	= STACK_UNDERFLOW,
		OutOfMemory	= OUT_OF_MEMORY,
		//			TableTooLarge		=  TABLE_TOO_LARGE
	}

	public enum MatrixStackMode : uint
	{
		ModelView	= MODELVIEW,
		Projection	= PROJECTION,
		Texture	= TEXTURE,
	}

	public enum Facing : uint
	{
		Front	= FRONT,
		Back	= BACK,
		Both	= FRONT_AND_BACK,
	}

	public enum Rotation : uint
	{
		ClockWise	= CW,
		CounterClockWise	= CCW,
	}

	public enum RasterMode : uint
	{
		Point	= POINT,
		Line	= LINE,
		Fill	= FILL,
	}

	public enum HintTarget : uint
	{
		Fog	= FOG_HINT,
		LineSmooth	= LINE_SMOOTH_HINT,
		PointSmooth	= POINT_SMOOTH_HINT,
		PolygonSmooth	= POLYGON_SMOOTH_HINT,
		GenerateMipmap	= GENERATE_MIPMAP_HINT,
		TextureCompression	= TEXTURE_COMPRESSION_HINT,
		PerspectiveCorrection	= PERSPECTIVE_CORRECTION_HINT,
		FragmentShaderDerivative	= FRAGMENT_SHADER_DERIVATIVE_HINT,
	}
	public enum HintMode : uint
	{
		DontCare	= DONT_CARE,
		Fastest	= FASTEST,
		Nicest	= NICEST,
	}

	public enum Operation : uint
	{
		Accum	= ACCUM,
		Load	= LOAD,
		Add	= ADD,
		Multiply	= MULT,
		Return	= RETURN,
	}

	public enum Testing : uint
	{
		Never	= NEVER,
		Always	= ALWAYS,
		Less	= LESS,
		LessEqual	= LEQUAL,
		Greater	= GREATER,
		GreaterEqual	= GEQUAL,
		NotEqual	= NOTEQUAL,
	}

	public enum DrawMode : uint
	{
		Points	= POINTS,
		Lines	= LINES,
		LineStrip	= LINE_STRIP,
		LineLoop	= LINE_LOOP,
		Triangles	= TRIANGLES,
		TriangleStrip	= TRIANGLE_STRIP,
		TriangleFan	= TRIANGLE_FAN,
		Quads	= QUADS,
		QuadStrip	= QUAD_STRIP,
		Polygon	= POLYGON,
	}

	public struct Texture
	{
		public enum Target : uint
		{
			T1D	= TEXTURE_1D,
			T2D	= TEXTURE_2D,
			T3D	= TEXTURE_3D,
			CubeMap	= TEXTURE_CUBE_MAP,
			CubeMapNX	= TEXTURE_CUBE_MAP_NEGATIVE_X,
			CubeMapPX	= TEXTURE_CUBE_MAP_POSITIVE_X,
			CubeMapNY	= TEXTURE_CUBE_MAP_NEGATIVE_Y,
			CubeMapPY	= TEXTURE_CUBE_MAP_POSITIVE_Y,
			CubeMapNZ	= TEXTURE_CUBE_MAP_NEGATIVE_Z,
			CubeMapPZ	= TEXTURE_CUBE_MAP_POSITIVE_Z,
		}

		public enum Format : uint
		{
			RGB	= Open.GL.RGB,
			BGR	= Open.GL.BGR,
			RGBA	= Open.GL.RGBA,
			BGRA	= Open.GL.BGRA,
			Red	= RED,
			Green	= GREEN,
			Blue	= BLUE,
			Alpha	= ALPHA,
			Luminance	= LUMINANCE,
			LuminanceAlpha	= LUMINANCE_ALPHA,
		}
		public enum InternalFormat : uint
		{
			Alpha	= ALPHA,
			Alpha4	= ALPHA4,
			Alpha8	= ALPHA8,
			Alpha12	= ALPHA12,
			Alpha16	= ALPHA16,

			CompressedAlpha	= COMPRESSED_ALPHA,
			CompressedLuminance	= COMPRESSED_LUMINANCE,
			CompressedLuminanceAlpha	= COMPRESSED_LUMINANCE_ALPHA,
			CompressedIntensity	= COMPRESSED_INTENSITY,
			CompressedRGB	= COMPRESSED_RGB,
			CompressedRGBA	= COMPRESSED_RGBA,

			Depth	= DEPTH_COMPONENT,
			Depth16	= DEPTH_COMPONENT16,
			Depth24	= DEPTH_COMPONENT24,
			Depth32	= DEPTH_COMPONENT32,

			Luminance	= LUMINANCE,
			Luminance4	= LUMINANCE4,
			Luminance8	= LUMINANCE8,
			Luminance12	= LUMINANCE12,
			Luminance16	= LUMINANCE16,

			LuminanceAlpha	= LUMINANCE_ALPHA,
			Luminance4Alpha4	= LUMINANCE4_ALPHA4,
			Luminance6Alpha2	= LUMINANCE6_ALPHA2,
			Luminance8Alpha8	= LUMINANCE8_ALPHA8,
			Luminance12Alpha4	= LUMINANCE12_ALPHA4,
			Luminance12Alpha12	= LUMINANCE12_ALPHA12,
			Luminance16Alpha16	= LUMINANCE16_ALPHA16,

			Intensity	= INTENSITY,
			Intensity4	= INTENSITY4,
			Intensity8	= INTENSITY8,
			Intensity12	= INTENSITY12,
			Intensity16	= INTENSITY16,

			RGB	= Open.GL.RGB,
			R3G3B2	= Open.GL.R3_G3_B2,
			RGB4	= Open.GL.RGB4,
			RGB5	= Open.GL.RGB5,
			RGB8	= Open.GL.RGB8,
			RGB10	= Open.GL.RGB10,
			RGB12	= Open.GL.RGB12,
			RGB16	= Open.GL.RGB16,

			RGBA	= Open.GL.RGBA,
			RGBA2	= Open.GL.RGBA2,
			RGBA4	= Open.GL.RGBA4,
			RGBA8	= Open.GL.RGBA8,
			RGBA12	= Open.GL.RGBA12,
			RGBA16	= Open.GL.RGBA16,

			RGB5A1	= RGB5_A1,
			RGB10A2	= RGB10_A2,

			SRGB	= Open.GL.SRGB,
			SRGB8	= Open.GL.SRGB8,
			SRGBA	= SRGB_ALPHA,
			SRGBA8	= SRGB8_ALPHA8,

			SLuminance	= SLUMINANCE,
			SLuminance8	= SLUMINANCE8,
			SLuminanceAlpha	= SLUMINANCE_ALPHA,
			SLuminanceAlpha8	= SLUMINANCE8_ALPHA8,

			StencilIndex1	= 0x8D46,
			StencilIndex4	= 0x8D47,
			StencilIndex8	= 0x8D48,
			StencilIndex16	= 0x8D49,
		}

		public enum Type : uint
		{
			Float	= FLOAT,
			Bitmap	= BITMAP,

			UByte	= UNSIGNED_BYTE,
			UShort	= UNSIGNED_SHORT,
			UInt	= UNSIGNED_INT,
			Byte	= BYTE,
			Short	= SHORT,
			Int	= INT,

			RGB332	= UNSIGNED_BYTE_3_3_2,
			BGR233	= UNSIGNED_BYTE_2_3_3_REV,
			RGB565	= UNSIGNED_SHORT_5_6_5,
			BGR565	= UNSIGNED_SHORT_5_6_5_REV,
			RGBA4	= UNSIGNED_SHORT_4_4_4_4,
			ABGR4	= UNSIGNED_SHORT_4_4_4_4_REV,
			RGB5A1	= UNSIGNED_SHORT_5_5_5_1,
			BGR5A1	= UNSIGNED_SHORT_1_5_5_5_REV,
			RGBA8	= UNSIGNED_INT_8_8_8_8,
			ABGR8	= UNSIGNED_INT_8_8_8_8_REV,
			RGB10A2	= UNSIGNED_INT_10_10_10_2,
			BGR10A2	= UNSIGNED_INT_2_10_10_10_REV,
		}
	}

	public enum Function : uint
	{
		Zero	= ZERO,
		One	= ONE,
		SrcColor	= SRC_COLOR,
		DstColor	= DST_COLOR,
		SrcAlpha	= SRC_ALPHA,
		DstAlpha	= DST_ALPHA,
		InvSrcColor	= ONE_MINUS_SRC_COLOR,
		InvSrcAlpha	= ONE_MINUS_SRC_ALPHA,
		InvDstColor	= ONE_MINUS_DST_COLOR,
		InvDstAlpha	= ONE_MINUS_DST_ALPHA,
	}

	public enum Usage : uint
	{
		StreamDraw	= STREAM_DRAW,
		StreamRead	= STREAM_READ,
		StreamCopy	= STREAM_COPY,
		StaticDraw	= STATIC_DRAW,
		StaticRead	= STATIC_READ,
		StaticCopy	= STATIC_COPY,
		DynamicDraw	= DYNAMIC_DRAW,
		DynamicRead	= DYNAMIC_READ,
		DynamicCopy	= DYNAMIC_COPY,
	}

	[Flags]
	public enum ClearFlags : uint
	{
		Color	= COLOR_BUFFER_BIT,
		Depth	= DEPTH_BUFFER_BIT,
		Accum	= ACCUM_BUFFER_BIT,
		Stencil	= STENCIL_BUFFER_BIT,
	}

	public enum Material : uint
	{
		Ambient	= AMBIENT,
		Diffuse	= DIFFUSE,
		AmbientDiffuse	= AMBIENT_AND_DIFFUSE,
		Specular	= SPECULAR,
	}

	public enum DataType : uint
	{
		SByte	= BYTE,
		Byte	= UNSIGNED_BYTE,
		Short	= SHORT,
		UShort	= UNSIGNED_SHORT,
		Int	= INT,
		UInt	= UNSIGNED_INT,
		Float	= FLOAT,
		Double	= DOUBLE,
	}

	public enum Filter : uint
	{
		Nearest	= NEAREST,
		Linear	= LINEAR,
		NearestMipmapNearest	= NEAREST_MIPMAP_NEAREST,
		LinearMipmapNearest	= LINEAR_MIPMAP_NEAREST,
		NearestMipmapLinear	= NEAREST_MIPMAP_LINEAR,
		LinearMipmapLinear	= LINEAR_MIPMAP_LINEAR,
	}

	public enum Wrap : uint
	{
		Clamp	= CLAMP,
		EdgeClamp	= CLAMP_TO_EDGE,
		BorderClamp	= CLAMP_TO_BORDER,
		Repeat	= REPEAT,
		Mirror	= MIRRORED_REPEAT,
	}

	public enum InfoString : uint
	{
		Vender	= VENDOR,
		Version	= VERSION,
		Renderer	= RENDERER,
		Extensions	= EXTENSIONS,
		ShadingLanguageVersion	= SHADING_LANGUAGE_VERSION,
	}
}
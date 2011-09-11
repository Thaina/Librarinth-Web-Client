using System;

namespace Open
{
	unsafe partial class GL
	{
		public struct RenderBuffer
		{
			readonly uint handle;

			public enum Target
			{
				RENDERBUFFER	= 0x8D41,
			}
			public enum ParameterName
			{
				WIDTH	= 0x8D42,
				HEIGHT	= 0x8D43,
				INTERNAL_FORMAT	= 0x8D44,
				RED_SIZE	= 0x8D50,
				GREEN_SIZE	= 0x8D51,
				BLUE_SIZE	= 0x8D52,
				ALPHA_SIZE	= 0x8D53,
				DEPTH_SIZE	= 0x8D54,
				STENCIL_SIZE	= 0x8D55,
				SAMPLES	= 0x8CAB,
			}
		}
		public struct FrameBuffer
		{
			readonly uint handle;

			public enum Target
			{
				FRAMEBUFFER	= 0x8D40,
				READ_FRAMEBUFFER	= 0x8CA8,
				DRAW_FRAMEBUFFER	= 0x8CA9,
			}
			public enum Attachment
			{
				COLOR0	= 0x8CE0,
				COLOR1	= 0x8CE1,
				COLOR2	= 0x8CE2,
				COLOR3	= 0x8CE3,
				COLOR4	= 0x8CE4,
				COLOR5	= 0x8CE5,
				COLOR6	= 0x8CE6,
				COLOR7	= 0x8CE7,
				COLOR8	= 0x8CE8,
				COLOR9	= 0x8CE9,
				COLOR10	= 0x8CEA,
				COLOR11	= 0x8CEB,
				COLOR12	= 0x8CEC,
				COLOR13	= 0x8CED,
				COLOR14	= 0x8CEE,
				COLOR15	= 0x8CEF,
				DEPTH	= 0x8D00,
				STENCIL	= 0x8D20,
				DEPTH_STENCIL	= 0x821A,
			}
			public enum AttachmentParameter
			{
				SRGB	= 0x8C40,
				UNSIGNED_NORMALIZED	= 0x8C17,
				FRAMEBUFFER_DEFAULT	= 0x8218,
				INDEX	= 0x8222,
			}
			public enum AttachmentParameterName
			{
				OBJECT_TYPE	= 0x8CD0,
				OBJECT_NAME	= 0x8CD1,
				TEXTURE_LEVEL	= 0x8CD2,
				TEXTURE_CUBE_MAP_FACE	= 0x8CD3,
				TEXTURE_LAYER	= 0x8CD4,
				COLOR_ENCODING	= 0x8210,
				COMPONENT_TYPE	= 0x8211,
				RED_SIZE	= 0x8212,
				GREEN_SIZE	= 0x8213,
				BLUE_SIZE	= 0x8214,
				ALPHA_SIZE	= 0x8215,
				DEPTH_SIZE	= 0x8216,
				STENCIL_SIZE	= 0x8217,
			}
			public enum Status
			{
				Complete	= 0x8CD5,
				Undefined	= 0x8219,
				IncompleteAttachment	= 0x8CD6,
				MissingAttachment	= 0x8CD7,
				IncompleteMultisample	= 0x8D56,
				IncompleteDrawBuffer	= 0x8CDB,
				IncompleteReadBuffer	= 0x8CDC,
				Unsupport	= 0x8CDD,
			}
		}

		////////////////////////////////////////////////////////////////////////////////

		protected delegate bool glIsRenderbuffer(RenderBuffer renderbuffer);
		protected delegate void glBindRenderbuffer(RenderBuffer.Target target,RenderBuffer renderbuffer);
		protected delegate void glDeleteRenderbuffers(int n,RenderBuffer* renderbuffers);
		protected delegate void glGenRenderbuffers(int n,RenderBuffer* renderbuffers);

		protected delegate void glRenderbufferStorage(RenderBuffer.Target target,uint format,int width,int height);

		protected delegate void glRenderbufferStorageMultisample(RenderBuffer.Target target,int samples,
			uint format,int width,int height);

		protected delegate void glGetRenderbufferParameteriv(RenderBuffer.Target target
			,RenderBuffer.ParameterName pname,int* renderbufferParams);

		protected delegate bool glIsFramebuffer(FrameBuffer framebuffer);
		protected delegate void glBindFramebuffer(FrameBuffer.Target target,FrameBuffer framebuffer);
		protected delegate void glDeleteFramebuffers(int n,FrameBuffer* framebuffers);
		protected delegate void glGenFramebuffers(int n,FrameBuffer* framebuffers);

		protected delegate void glFramebufferTexture1D(FrameBuffer.Target target,FrameBuffer.Attachment attachment,
									uint textarget,uint texture,int level);
		protected delegate void glFramebufferTexture2D(FrameBuffer.Target target,FrameBuffer.Attachment attachment
			,uint textarget,uint texture,int level);
		protected delegate void glFramebufferTexture3D(FrameBuffer.Target target,FrameBuffer.Attachment attachment
			,uint textarget,uint texture,int level,int layer);
		protected delegate void glFramebufferTextureLayer(FrameBuffer.Target target,FrameBuffer.Attachment attachment
			,uint texture,int level,int layer);

		protected delegate void glFramebufferRenderbuffer(FrameBuffer.Target target,FrameBuffer.Attachment attachment
			,RenderBuffer.Target renderbuffertarget,RenderBuffer renderbuffer);

		protected delegate void glGetFramebufferAttachmentParameteriv(FrameBuffer.Target target
			,FrameBuffer.Attachment attachment,FrameBuffer.AttachmentParameterName pname,int* attachmentParams);

		protected delegate void glBlitFramebuffer(int srcX0,int srcY0,int srcX1,int srcY1
			,int dstX0,int dstY0,int dstX1,int dstY1,uint mask,uint filter);

		protected delegate FrameBuffer.Status glCheckFramebufferStatus(FrameBuffer.Target target);

		protected delegate void glGenerateMipmap(FrameBuffer.Target target);

		////////////////////////////////////////////////////////////////////////////////

		protected glIsRenderbuffer isRenderbuffer;
		protected glBindRenderbuffer bindRenderbuffer;
		protected glDeleteRenderbuffers deleteRenderbuffers;
		protected glGenRenderbuffers genRenderbuffers;

		protected glIsFramebuffer isFramebuffer;
		protected glBindFramebuffer bindFramebuffer;
		protected glDeleteFramebuffers deleteFramebuffers;
		protected glGenFramebuffers genFramebuffers;

		protected glFramebufferTexture1D framebufferTexture1D;
		protected glFramebufferTexture2D framebufferTexture2D;
		protected glFramebufferTexture3D framebufferTexture3D;

		protected glCheckFramebufferStatus checkFramebufferStatus;
		protected glFramebufferRenderbuffer framebufferRenderbuffer;

		protected glGetRenderbufferParameteriv getRenderbufferParameter;
		protected glGetFramebufferAttachmentParameteriv getFramebufferAttachmentParameter;
	}
}
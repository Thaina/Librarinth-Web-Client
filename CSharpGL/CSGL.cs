using System;

using SlimMath;
using System.Text;

public partial class CSGL : Open.GL<CSGL>
{
	public unsafe int GetValue(uint name)
	{
		int value;
		getIntegerv(name,&value);
		return value;
	}

	public void Finish()
	{
		flush();
		finish();
	}
	public void Flush()
	{
		flush();
	}
	public void Clear(Color4? color,float? depth,int? stencil = null)
	{
		var flags	= default(ClearFlags);
		if(color.HasValue)
		{
			var col	= color.Value;
			clearColor(col.R,col.G,col.B,col.A);
			flags	|= ClearFlags.Color;
		}

		if(depth.HasValue)
		{
			flags	|= ClearFlags.Depth;
			clearDepth(depth.Value);
		}
		if(stencil.HasValue)
		{
			flags	|= ClearFlags.Stencil;
			clearStencil(stencil.Value);
		}

		clear((uint)flags);
	}
}
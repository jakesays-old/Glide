////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Glide.DeviceSupport
{
	public abstract class Font
	{
		// Must keep in sync with CLR_GFX_Font::c_DefaultKerning
		public const int DefaultKerning = 1024;

		public abstract int Height { get; }

		public abstract int AverageWidth { get; }

		public abstract int MaxWidth { get; }

		public abstract int Ascent { get; }

		public abstract int Descent { get; }

		public abstract int InternalLeading { get; }

		public abstract int ExternalLeading { get; }


		public abstract int CharWidth(char c);

		public abstract void ComputeExtent(string text, out int width, out int height, int kerning);

		public abstract void ComputeTextInRect(string text, out int renderWidth, out int renderHeight, int xRelStart,
			int yRelStart, int availableWidth, int availableHeight, uint dtFlags);

		public void ComputeExtent(string text, out int width, out int height)
		{
			ComputeExtent(text, out width, out height, DefaultKerning);
		}

		public void ComputeTextInRect(string text, out int renderWidth, out int renderHeight)
		{
			ComputeTextInRect(text, out renderWidth, out renderHeight, 0, 0, 65536, 0,
				Bitmap.DT_IgnoreHeight | Bitmap.DT_WordWrap);
		}

		public void ComputeTextInRect(string text, out int renderWidth, out int renderHeight, int availableWidth)
		{
			ComputeTextInRect(text, out renderWidth, out renderHeight, 0, 0, availableWidth, 0,
				Bitmap.DT_IgnoreHeight | Bitmap.DT_WordWrap);
		}
	}
}
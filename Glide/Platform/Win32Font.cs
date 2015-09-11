using System;
using Microsoft.SPOT;
using Sd = System.Drawing;

namespace GHI.Glide.Platform
{
	public class Win32Font : Font
	{
		private readonly Sd.Font _nativeFont;

		internal Win32Font(Sd.Font nativeFont)
		{
			_nativeFont = nativeFont;
		}

		public override int Ascent
		{
			get { throw new NotImplementedException(); }
		}

		public override int AverageWidth
		{
			get { throw new NotImplementedException(); }
		}

		public override int Descent
		{
			get { throw new NotImplementedException(); }
		}

		public override int ExternalLeading
		{
			get { throw new NotImplementedException(); }
		}

		public override int Height
		{
			get { throw new NotImplementedException(); }
		}

		public override int InternalLeading
		{
			get { throw new NotImplementedException(); }
		}

		public override int MaxWidth
		{
			get { throw new NotImplementedException(); }
		}

		public override int CharWidth(char c)
		{
			throw new NotImplementedException();
		}

		public override void ComputeExtent(string text, out int width, out int height, int kerning)
		{
			var extent = ((Win32Bitmap) Device.Screen).Context.MeasureString(text, _nativeFont);
			width = (int) extent.Width;
			height = (int) extent.Height;
		}

		public override void ComputeTextInRect(string text, out int renderWidth, out int renderHeight, int xRelStart,
			int yRelStart, int availableWidth, int availableHeight, uint dtFlags)
		{
			throw new NotImplementedException();
		}
	}
}
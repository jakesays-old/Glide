using System;
using Font = Glide.DeviceSupport.Font;
using Sd = System.Drawing;

namespace Glide.Devices.Windows
{
	public class Win32Font : Font
	{
		internal Sd.Font NativeFont { get; }
		private readonly Win32Platform _platform;

		internal Win32Font(Sd.Font nativeFont, Win32Platform platform)
		{
			NativeFont = nativeFont;
			_platform = platform;
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
			get { return NativeFont.Height; }
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
			var extent = ((Win32Bitmap) _platform.Screen).Context.MeasureString(text, NativeFont);
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
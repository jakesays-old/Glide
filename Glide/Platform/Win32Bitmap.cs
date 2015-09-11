using System.Drawing.Imaging;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

using Sd = System.Drawing;

namespace GHI.Glide.Platform
{
	public class Win32Bitmap : Bitmap
	{
		private readonly Sd.Bitmap _nativeBitmap;

		internal Sd.Graphics Context { get; }

		public Win32Bitmap(int width, int height)
		{
			_nativeBitmap = new Sd.Bitmap(width, height, PixelFormat.Format32bppArgb);
			Context = Sd.Graphics.FromImage(_nativeBitmap);
		}

		internal Win32Bitmap(Sd.Bitmap nativeBitmap)
		{
			_nativeBitmap = nativeBitmap;
		}

		public override void Flush()
		{
		}

		public override void Flush(int x, int y, int width, int height)
		{
		}

		public override void Clear()
		{
			Context.Clear(Sd.Color.White);
		}

		public override bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height,
			uint dtFlags, Color color, Font font)
		{
			return false;
		}

		public override void SetClippingRectangle(int x, int y, int width, int height)
		{
		}

		public override int Width { get; }
		public override int Height { get; }

		public override void DrawEllipse(Color colorOutline, int thicknessOutline, int x, int y, int xRadius, int yRadius,
			Color colorGradientStart, int xGradientStart, int yGradientStart, Color colorGradientEnd, int xGradientEnd,
			int yGradientEnd, ushort opacity)
		{
		}

		public override void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity)
		{
		}

		public override void RotateImage(int angle, int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity)
		{
		}

		public override void MakeTransparent(Color color)
		{
		}

		public override void StretchImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity)
		{
		}

		public override void DrawLine(Color color, int thickness, int x0, int y0, int x1, int y1)
		{
		}

		public override void DrawRectangle(Color colorOutline, int thicknessOutline, int x, int y, int width, int height, int xCornerRadius,
			int yCornerRadius, Color colorGradientStart, int xGradientStart, int yGradientStart, Color colorGradientEnd,
			int xGradientEnd, int yGradientEnd, ushort opacity)
		{
		}

		public override void DrawText(string text, Font font, Color color, int x, int y)
		{
		}

		public override void SetPixel(int xPos, int yPos, Color color)
		{
		}

		public override Color GetPixel(int xPos, int yPos)
		{
			return Color.Black;
		}

		public override byte[] GetBitmap()
		{
			return new byte[] {};
		}

		public override void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc,
			int heightSrc, ushort opacity)
		{
		}

		public override void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity)
		{
		}

		public override void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder,
			int rightBorder, int bottomBorder, ushort opacity)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
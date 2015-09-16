using Sdd = System.Drawing.Drawing2D;
using Sdi = System.Drawing.Imaging;
using Bitmap = Glide.DeviceSupport.Bitmap;
using Color = Glide.DeviceSupport.Color;
using Font = Glide.DeviceSupport.Font;
using Sd = System.Drawing;

namespace Glide.Devices.Windows
{
	public class Win32Bitmap : Bitmap
	{
		internal Sd.Bitmap NativeBitmap { get; }

		internal Sd.Graphics Context { get; }

		private Win32Platform _platform;

		public Win32Bitmap(int width, int height)
		{
			Width = width;
			Height = height;
			NativeBitmap = new Sd.Bitmap(width, height, Sdi.PixelFormat.Format32bppArgb);
			Context = Sd.Graphics.FromImage(NativeBitmap);
		}

		internal Win32Bitmap(Sd.Bitmap nativeBitmap)
		{
			NativeBitmap = nativeBitmap;
			Width = nativeBitmap.Width;
			Height = nativeBitmap.Height;
		}

		public override void Flush()
		{
			Context.Flush(Sdd.FlushIntention.Flush);
		}

		public override void Flush(int x, int y, int width, int height)
		{
			Context.Flush(Sdd.FlushIntention.Flush);
		}

		public override void Clear()
		{
			Context.Clear(Sd.Color.White);
		}

		public override bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height,
			uint dtFlags, Color color, Font font)
		{
			var r = new Sd.RectangleF(x, y, width, height);
			Context.DrawString(text, ((Win32Font) font).NativeFont,
				new Sd.SolidBrush(color.ToWin32()), r);

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
			var width = xRadius * 2;
			var height = yRadius * 2;

            var pt1 = new Sd.PointF(xGradientStart, yGradientStart);
			var pt2 = new Sd.PointF(xGradientEnd, yGradientEnd);
			var fillBrush = new Sdd.LinearGradientBrush(pt1, pt2,
				colorGradientStart.ToWin32(opacity),
				colorGradientEnd.ToWin32(opacity));
			Context.FillEllipse(fillBrush, x, y, width, height);
			var pen = new Sd.Pen(colorOutline.ToWin32(), thicknessOutline);
			Context.DrawEllipse(pen, x, y, width, height);
		}

		public override void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, 
			int width, int height, ushort opacity)
		{
			var srcRect = new Sd.RectangleF(xSrc, ySrc, width, height);
			var dstRect = new Sd.RectangleF(xDst, yDst, width, height);
			Context.DrawImage(((Win32Bitmap) bitmap).NativeBitmap, dstRect, srcRect, Sd.GraphicsUnit.Pixel);
		}

		public override void RotateImage(int angle, int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity)
		{
		}

		public override void MakeTransparent(Color color)
		{
		}

		public override void StretchImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity)
		{
			var srcRect = new Sd.RectangleF(0, 0, bitmap.Width, bitmap.Height);
			var dstRect = new Sd.RectangleF(xDst, yDst, width, height);
			Context.DrawImage(((Win32Bitmap) bitmap).NativeBitmap, dstRect, srcRect, Sd.GraphicsUnit.Pixel);
		}

		public override void DrawLine(Color color, int thickness, int x0, int y0, int x1, int y1)
		{
			Context.DrawLine(new Sd.Pen(color.ToWin32(), thickness), x0, y0, x1, y1);
		}

		public override void DrawRectangle(Color colorOutline, int thicknessOutline, int x, int y, int width, int height, int xCornerRadius,
			int yCornerRadius, Color colorGradientStart, int xGradientStart, int yGradientStart, Color colorGradientEnd,
			int xGradientEnd, int yGradientEnd, ushort opacity)
		{
			var pt1 = new Sd.PointF(xGradientStart, yGradientStart);
			var pt2 = new Sd.PointF(xGradientEnd, yGradientEnd);
			if (pt1 == pt2 ||
				colorGradientStart == colorGradientEnd)
			{
				Context.FillRectangle(new Sd.SolidBrush(colorGradientStart.ToWin32()), x, y, width, height);
			}
			else
			{
				var fillBrush = new Sdd.LinearGradientBrush(pt1, pt2,
					colorGradientStart.ToWin32(opacity),
					colorGradientEnd.ToWin32(opacity));
				Context.FillRectangle(fillBrush, x, y, width, height);				
			}
			Context.DrawRectangle(new Sd.Pen(colorOutline.ToWin32()), x, y, width, height);
		}

		public override void DrawText(string text, Font font, Color color, int x, int y)
		{
			Context.DrawString(text, ((Win32Font) font).NativeFont, 
				new Sd.SolidBrush(color.ToWin32()), x, y);
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

		public override void Scale9Image(int xDst, int yDst, int widthDst, int heightDst,
			Bitmap bitmap, int leftBorder, int topBorder,
			int rightBorder, int bottomBorder, ushort opacity)
		{
			var srcBitmap = ((Win32Bitmap) bitmap).NativeBitmap;
			int widthSrc = srcBitmap.Width;
			int heightSrc = srcBitmap.Height;

			if (widthDst >= leftBorder &&
				heightDst >= topBorder)
			{
				int centerWidthSrc = widthSrc - (leftBorder + rightBorder);
				int centerHeightSrc = heightSrc - (topBorder + bottomBorder);
				int centerWidthDst = widthDst - (leftBorder + rightBorder);
				int centerHeightDst = heightDst - (topBorder + bottomBorder);

				//top-left

				//dst.left = xDst;
				//dst.top = yDst;
				//dst.right = dst.left + leftBorder - 1;
				//dst.bottom = dst.top + topBorder - 1;
				//src.left = 0;
				//src.top = 0;
				//src.right = src.left + leftBorder - 1;
				//src.bottom = src.top + topBorder - 1;

				var dst = new Sd.Rectangle(xDst, yDst, leftBorder, topBorder);
				var src = new Sd.Rectangle(0, 0, leftBorder, topBorder);
				Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);

				//top-right
				if (widthDst > leftBorder)
				{
					//dst.left = xDst + widthDst - rightBorder;
					//dst.top = yDst;
					//dst.right = dst.left + rightBorder - 1;
					//dst.bottom = dst.top + topBorder - 1;
					//src.left = widthSrc - rightBorder;
					//src.top = 0;
					//src.right = src.left + rightBorder - 1;
					//src.bottom = src.top + topBorder - 1;

					dst = new Sd.Rectangle(xDst + widthDst - rightBorder, yDst, rightBorder, topBorder);
					src = new Sd.Rectangle(widthSrc - rightBorder, 0, rightBorder, topBorder);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//bottom-left
				if (heightDst > topBorder)
				{
					//dst.left = xDst;
					//dst.top = yDst + heightDst - bottomBorder;
					//dst.right = dst.left + leftBorder - 1;
					//dst.bottom = dst.top + bottomBorder - 1;
					//src.left = 0;
					//src.top = heightSrc - bottomBorder;
					//src.right = src.left + leftBorder - 1;
					//src.bottom = src.top + bottomBorder - 1;

					dst = new Sd.Rectangle(xDst, yDst + heightDst - bottomBorder, leftBorder, bottomBorder);
					src = new Sd.Rectangle(0, heightSrc - bottomBorder, leftBorder, bottomBorder);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//bottom-right
				if (widthDst > leftBorder &&
					heightDst > topBorder)
				{
					//dst.left = xDst + widthDst - rightBorder;
					//dst.top = yDst + heightDst - bottomBorder;
					//dst.right = dst.left + rightBorder - 1;
					//dst.bottom = dst.top + bottomBorder - 1;
					//src.left = widthSrc - rightBorder;
					//src.top = heightSrc - bottomBorder;
					//src.right = src.left + rightBorder - 1;
					//src.bottom = src.top + bottomBorder - 1;

					dst = new Sd.Rectangle(xDst + widthDst - rightBorder, yDst + heightDst - bottomBorder,
						rightBorder, bottomBorder);
					src = new Sd.Rectangle(widthSrc - rightBorder, heightSrc - bottomBorder,
						rightBorder, bottomBorder);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//left
				if (centerHeightDst > 0)
				{
					//dst.left = xDst;
					//dst.top = yDst + topBorder;
					//dst.right = dst.left + leftBorder - 1;
					//dst.bottom = dst.top + centerHeightDst - 1;
					//src.left = 0;
					//src.top = topBorder;
					//src.right = src.left + leftBorder - 1;
					//src.bottom = src.top + centerHeightSrc - 1;

					dst = new Sd.Rectangle(xDst, yDst + topBorder, leftBorder, centerHeightDst);
					src = new Sd.Rectangle(0, topBorder, leftBorder, centerHeightSrc);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//top
				if (centerWidthDst > 0)
				{
					//dst.left = xDst + leftBorder;
					//dst.top = yDst;
					//dst.right = dst.left + centerWidthDst - 1;
					//dst.bottom = dst.top + topBorder - 1;
					//src.left = leftBorder;
					//src.top = 0;
					//src.right = src.left + centerWidthSrc - 1;
					//src.bottom = src.top + topBorder - 1;

					dst = new Sd.Rectangle(xDst + leftBorder, yDst, centerWidthDst, topBorder);
					src = new Sd.Rectangle(leftBorder, 0, centerWidthSrc, topBorder);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//right
				if (widthDst > leftBorder &&
					centerHeightDst > 0)
				{
					//dst.left = xDst + widthDst - rightBorder;
					//dst.top = yDst + topBorder;
					//dst.right = dst.left + rightBorder - 1;
					//dst.bottom = dst.top + centerHeightDst - 1;
					//src.left = widthSrc - rightBorder;
					//src.top = topBorder;
					//src.right = src.left + rightBorder - 1;
					//src.bottom = src.top + centerHeightSrc - 1;

					dst = new Sd.Rectangle(xDst + widthDst - rightBorder, yDst + topBorder,
						rightBorder, centerHeightDst);
					src = new Sd.Rectangle(widthSrc - rightBorder, topBorder,
						rightBorder, centerHeightSrc);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//bottom
				if (centerWidthDst > 0 && heightDst > topBorder)
				{
					//dst.left = xDst + leftBorder;
					//dst.top = yDst + heightDst - bottomBorder;
					//dst.right = dst.left + centerWidthDst - 1;
					//dst.bottom = dst.top + bottomBorder - 1;
					//src.left = leftBorder;
					//src.top = heightSrc - bottomBorder;
					//src.right = src.left + centerWidthSrc - 1;
					//src.bottom = src.top + bottomBorder - 1;

					dst = new Sd.Rectangle(xDst + leftBorder, yDst + heightDst - bottomBorder,
						centerWidthDst, bottomBorder);
					src = new Sd.Rectangle(leftBorder, heightSrc - bottomBorder,
						centerWidthSrc, bottomBorder);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}

				//center
				if (centerWidthDst > 0 && centerHeightDst > 0)
				{
					//dst.left = xDst + leftBorder;
					//dst.top = yDst + topBorder;
					//dst.right = dst.left + centerWidthDst - 1;
					//dst.bottom = dst.top + centerHeightDst - 1;
					//src.left = leftBorder;
					//src.top = topBorder;
					//src.right = src.left + centerWidthSrc - 1;
					//src.bottom = src.top + centerHeightSrc - 1;

					dst = new Sd.Rectangle(xDst + leftBorder, yDst + topBorder,
						centerWidthDst, centerHeightDst);
					src = new Sd.Rectangle(leftBorder, topBorder,
						centerWidthSrc, centerHeightSrc);
					Context.DrawImage(srcBitmap, dst, src, Sd.GraphicsUnit.Pixel);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (NativeBitmap != null)
			{
				NativeBitmap.Dispose();
			}
			if (Context != null)
			{
				Context.Dispose();
			}
		}
	}
}
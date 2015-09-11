using System;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Sd = System.Drawing;

namespace GHI.Glide.Platform
{
	/// <summary>
	/// Device abstraction - should be one of these per platform
	/// </summary>
	public static class Device
	{
		static Device()
		{
			var hardware = HardwareProvider.HwProvider;

			int maxWidth;
			int maxHeight;
			int bpp;
			int orientation;

			hardware.GetLCDMetrics(out maxWidth, out maxHeight, out bpp, out orientation);

			ScreenWidth = maxWidth;
			ScreenHeight = maxHeight;

			CenterX = (ScreenWidth - 1) / 2;
			CenterY = (ScreenHeight - 1) / 2;

			Screen = new Win32Bitmap(ScreenWidth, ScreenHeight);
		}

		public static int ScreenWidth { get; }

		public static int ScreenHeight { get; }

		public static int CenterX { get; private set; }

		public static int CenterY { get; private set; }

		public static Bitmap Screen { get; private set; }

		public static Bitmap CreateBitmap(int width, int height)
		{
			return new Win32Bitmap(width, height);
		}

		public static Bitmap LoadBitmap(string resourceName)
		{
			var nativeBitmap = (Sd.Bitmap) Resources.ResourceManager.GetObject(resourceName, Resources.Culture);
			return new Win32Bitmap(nativeBitmap);
		}

		public static Font GetFont(FontManager.FontType type)
		{
			int size;

			switch (type)
			{
				case FontManager.FontType.droid_reg08:
					size = 8;
					break;
				case FontManager.FontType.droid_reg09:
					size = 9;
					break;
				case FontManager.FontType.droid_reg10:
					size = 10;
					break;
				case FontManager.FontType.droid_reg11:
					size = 11;
					break;
				case FontManager.FontType.droid_reg12:
					size = 12;
					break;
				case FontManager.FontType.droid_reg14:
					size = 14;
					break;
				case FontManager.FontType.droid_reg18:
					size = 18;
					break;
				case FontManager.FontType.droid_reg24:
					size = 24;
					break;
				case FontManager.FontType.droid_reg32:
					size = 32;
					break;
				case FontManager.FontType.droid_reg48:
					size = 48;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}

			var font = new Sd.Font("Arial", size, Sd.FontStyle.Regular);
			return new Win32Font(font);
		}
	}
}
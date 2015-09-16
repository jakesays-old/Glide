using System;
using System.Globalization;
using System.Resources;
using Glide.DeviceSupport;
using Bitmap = Glide.DeviceSupport.Bitmap;
using Font = Glide.DeviceSupport.Font;
using Sd = System.Drawing;

namespace Glide.Devices.Windows
{
	public interface IWin32PlatformHost
	{
		void UpdateScreen();
		void UpdateScreen(int x, int y, int width, int height);
	}

	public class Win32Platform : IPlatform
	{
		private readonly ResourceManager _resources;
		private readonly CultureInfo _culture;
		private readonly Win32Bitmap _screen;
		private readonly IWin32PlatformHost _host;

		public Win32Platform(ResourceManager resources, CultureInfo culture,
			int screenWidth, int screenHeight, IWin32PlatformHost host)
		{
			_resources = resources;
			_culture = culture;
			_host = host;

			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;

			CenterX = (ScreenWidth - 1) / 2;
			CenterY = (ScreenHeight - 1) / 2;

			_screen = new Win32ScreenBitmap(ScreenWidth, ScreenHeight, host);
		}

		public void RenderScreen(Sd.Graphics g)
		{
			g.DrawImage(_screen.NativeBitmap, new Sd.PointF(0, 0));
		}

		public int ScreenWidth { get; }

		public int ScreenHeight { get; }

		public int CenterX { get; private set; }

		public int CenterY { get; private set; }

		public Bitmap Screen => _screen;

		public Bitmap CreateBitmap(int width, int height)
		{
			return new Win32Bitmap(width, height);
		}

		public Bitmap LoadBitmap(string resourceName)
		{
			var nativeBitmap = (Sd.Bitmap) _resources.GetObject(resourceName, _culture);
			return new Win32Bitmap(nativeBitmap);
		}

		public Font GetFont(int fontSize)
		{
			var font = new Sd.Font("Arial", fontSize, Sd.FontStyle.Regular);
			return new Win32Font(font, this);
		}
	}
}
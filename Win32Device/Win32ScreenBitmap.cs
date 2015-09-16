using System.Drawing.Imaging;

namespace Glide.Devices.Windows
{
	public class Win32ScreenBitmap : Win32Bitmap
	{
		private readonly IWin32PlatformHost _host;

		public Win32ScreenBitmap(int width, int height, IWin32PlatformHost host)
			: base(width, height)
		{
			_host = host;
		}

		internal Win32ScreenBitmap(System.Drawing.Bitmap nativeBitmap)
			: base(nativeBitmap)
		{
		}

		private static int counter;

		private void Save()
		{
			NativeBitmap.Save($@"C:\TestOutput\test{counter++}.png", ImageFormat.Png);
		}

		public override void Flush()
		{
			Save();
			_host.UpdateScreen();
		}

		public override void Flush(int x, int y, int width, int height)
		{
			Save();
			_host.UpdateScreen(x, y, width, height);
		}
	}
}
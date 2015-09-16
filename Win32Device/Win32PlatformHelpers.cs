using Glide.DeviceSupport;

namespace Glide.Devices.Windows
{
	internal static class Win32PlatformHelpers
	{
		public static System.Drawing.Color ToWin32(this Color value, int alpha = 255)
		{
			var r = ColorUtility.GetRValue(value);
			var g = ColorUtility.GetGValue(value);
			var b = ColorUtility.GetBValue(value);

			return System.Drawing.Color.FromArgb(alpha, r, g, b);
		}
	}
}
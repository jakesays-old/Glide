using Microsoft.SPOT.Presentation.Media;

namespace GHI.Glide.Platform
{
	internal static class Win32PlatformHelpers
	{
		public static System.Drawing.Color ToWin32(this Color value)
		{
			var r = ColorUtility.GetRValue(value);
			var g = ColorUtility.GetGValue(value);
			var b = ColorUtility.GetBValue(value);

			return System.Drawing.Color.FromArgb(255, r, g, b);
		}
	}
}
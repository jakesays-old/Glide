namespace Glide.DeviceSupport
{
	public interface IPlatform
	{
		int ScreenWidth { get; }

		int ScreenHeight { get; }

		int CenterX { get; }

		int CenterY { get; }

		Bitmap Screen { get; }

		Bitmap CreateBitmap(int width, int height);

		Bitmap LoadBitmap(string resourceName);

		Font GetFont(int fontSize);
	}
}
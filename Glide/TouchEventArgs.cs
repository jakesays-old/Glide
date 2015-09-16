using GHI.Glide.Geom;
using Glide.DeviceSupport;

namespace GHI.Glide
{
	/// <summary>
	/// Touch event arguments.
	/// </summary>
	public class TouchEventArgs
	{
		/// <summary>
		/// Indicates whether or not to continue processing the event.
		/// </summary>
		public bool Propagate = true;

		/// <summary>
		/// The point of contact.
		/// </summary>
		public Point Point;

		/// <summary>
		/// Creates a new TouchEventArgs.
		/// </summary>
		/// <param name="Touches">TouchInput</param>
		public TouchEventArgs(TouchInput[] Touches)
		{
			Point = new Point(Touches[0].X, Touches[0].Y);
		}

		/// <summary>
		/// Creates a new TouchEventArgs.
		/// </summary>
		/// <param name="point">Point</param>
		public TouchEventArgs(Point point)
		{
			Point = point;
		}

		/// <summary>
		/// Stops propagation.
		/// </summary>
		public void StopPropagation()
		{
			Propagate = false;
		}
	}
}
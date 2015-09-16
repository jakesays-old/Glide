using System;

namespace GHI.Glide
{
	/// <summary>
	/// Touch gesture event arguments.
	/// </summary>
	public class TouchGestureEventArgs
	{
		/// <summary>
		/// Indicates whether or not to continue processing the event.
		/// </summary>
		public bool Propagate = true;

		/// <summary>
		/// Time the event occured.
		/// </summary>
		public readonly DateTime Timestamp;

		/// <summary>
		/// X coordinate.
		/// </summary>
		/// <remarks>The X forms the center location of the gesture for multi-touch or the starting location for single touch.</remarks>
		public readonly int X;

		/// <summary>
		/// Y coordinate.
		/// </summary>
		/// <remarks>The Y forms the center location of the gesture for multi-touch or the starting location for single touch.</remarks>
		public readonly int Y;

		/// <summary>
		/// Indicates the gesture.
		/// </summary>
		public readonly TouchGesture Gesture;

		// 2 bytes for gesture-specific arguments.
		// TouchGesture.Zoom: Arguments = distance between fingers
		// TouchGesture.Rotate: Arguments = angle in degrees (0-360)

		/// <summary>
		/// Touch gesture arguments.
		/// </summary>
		public readonly ushort Arguments;

		/// <summary>
		/// Creates a new TouchGestureEventArgs.
		/// </summary>
		/// <param name="gesture">Touch gesture.</param>
		/// <param name="x">X-axis position.</param>
		/// <param name="y">Y-axis position.</param>
		/// <param name="arguments">Touch gesture arguments.</param>
		/// <param name="timestamp">Time the event occured.</param>
		public TouchGestureEventArgs(TouchGesture gesture, int x, int y, ushort arguments, DateTime timestamp)
		{
			Gesture = gesture;
			X = x;
			Y = y;
			Arguments = arguments;
			Timestamp = timestamp;
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
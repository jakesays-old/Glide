using System;

namespace Microsoft.SPOT.Touch
{
	public class TouchGestureEventArgs : EventArgs
	{
		public readonly DateTime Timestamp;

		public TouchGesture Gesture;

		///<note> X and Y form the center location of the gesture for multi-touch or the starting location for single touch </note>
		public int X;
		public int Y;

		/// <note>2 bytes for gesture-specific arguments.
		/// TouchGesture.Zoom: Arguments = distance between fingers
		/// TouchGesture.Rotate: Arguments = angle in degrees (0-360)
		/// </note>
		public ushort Arguments;

		public double Angle
		{
			get
			{
				return (double)(Arguments);
			}
		}
	}
}
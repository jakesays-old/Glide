using System;

namespace Microsoft.SPOT.Touch
{
	public class TouchScreenEventArgs : EventArgs
	{
		// Fields
		public TouchInput[] Touches;
		public DateTime TimeStamp;
		public object Target;
        
		// Methods
		public TouchScreenEventArgs(DateTime timestamp, TouchInput[] touches, object target)
		{
			this.Touches = touches;
			this.TimeStamp = timestamp;
			this.Target = target;
		}
        
		public void GetPosition(int touchIndex, out int x, out int y)
		{
			x = Touches[touchIndex].X;
			y = Touches[touchIndex].Y;
		}
	}
}
using System;

namespace Microsoft.SPOT.Touch
{
	public class TouchEvent : BaseEvent
	{
		public DateTime Time;
		public TouchInput[] Touches;
	}
}
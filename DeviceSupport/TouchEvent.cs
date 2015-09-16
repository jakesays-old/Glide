using System;

namespace Glide.DeviceSupport
{
	public class TouchEvent : BaseEvent
	{
		public DateTime Time;
		public TouchInput[] Touches;
	}
}
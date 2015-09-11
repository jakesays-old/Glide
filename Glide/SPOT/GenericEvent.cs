using System;

namespace Microsoft.SPOT
{
	public class GenericEvent : BaseEvent
	{
		public byte EventCategory;
		public uint EventData;
		public int X;
		public int Y;
		public DateTime Time;
	}
}
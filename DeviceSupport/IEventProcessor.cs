using System;

namespace Glide.DeviceSupport
{
	public interface IEventProcessor
	{
		/// <summary>
		/// IEventProcessor should return null if it cannot process an event,
		/// in that case next processor will be given an opportunity.
		/// </summary>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		/// <param name="time"></param>
		/// <returns></returns>
		BaseEvent ProcessEvent(uint data1, uint data2, DateTime time);
	}
}
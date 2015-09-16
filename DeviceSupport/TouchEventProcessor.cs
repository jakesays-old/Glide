using System;
using System.Runtime.CompilerServices;

namespace Glide.DeviceSupport
{
	internal class TouchEventProcessor : IEventProcessor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time);
	}
}
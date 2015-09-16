using System;

namespace Glide.DeviceSupport
{
	[Flags]
	public enum CollectionMode : int
	{
		InkOnly = 2,
		GestureOnly = 4,
		InkAndGesture = InkOnly | GestureOnly,
	}
}
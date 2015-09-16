using System;

namespace Glide.DeviceSupport
{
	[Flags]
	public enum CollectionMethod : int
	{
		Managed = 0,
		Native = 1,
	}
}
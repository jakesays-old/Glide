using System;

namespace Microsoft.SPOT.Touch
{
	[Flags]
	public enum TouchInputFlags : uint
	{
		None = 0x00,
		Primary = 0x0010,  //The Primary flag denotes the input that is passed to the single-touch Stylus events provided

		//no controls handle the Touch events.  This flag should be set on the TouchInput structure that represents
		//the first finger down as it moves around up to and including the point it is released.

		Pen = 0x0040,     //Hardware support is optional, but providing it allows for potentially richer applications.
		Palm = 0x0080,     //Hardware support is optional, but providing it allows for potentially richer applications.
	}
}
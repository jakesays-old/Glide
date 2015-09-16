namespace GHI.Glide
{
	/// <summary>
	/// The TouchGesture class defines gestures.
	/// </summary>
	public enum TouchGesture : uint
	{
		/// <summary>
		/// No Gesture
		/// </summary>
		/// <remarks>Can be used to represent an error gesture or unknown gesture.</remarks>
		NoGesture = 0,

		/// <summary>
		/// Begin
		/// </summary>
		/// <remarks>Used to identify the beginning of a Gesture Sequence; App can use this to highlight UIElement or some other sort of notification.</remarks>
		Begin = 1,

		/// <summary>
		/// End
		/// </summary>
		/// <remarks>Used to identify the end of a gesture sequence; Fired when last finger involved in a gesture is removed.</remarks>
		End = 2,

		/// <summary>
		/// Right
		/// </summary>
		Right = 3,

		/// <summary>
		/// Up Right
		/// </summary>
		UpRight = 4,

		/// <summary>
		/// Up
		/// </summary>
		Up = 5,

		/// <summary>
		///  Up Left
		/// </summary>
		UpLeft = 6,

		/// <summary>
		/// Left
		/// </summary>
		Left = 7,

		/// <summary>
		/// Down Left
		/// </summary>
		DownLeft = 8,

		/// <summary>
		/// Down
		/// </summary>
		Down = 9,

		/// <summary>
		/// Down Right
		/// </summary>
		DownRight = 10,

		/// <summary>
		/// Tap
		/// </summary>
		Tap = 11,

		/// <summary>
		/// Double Tap
		/// </summary>
		DoubleTap = 12,

		/// <summary>
		/// Zoom
		/// </summary>
		/// <remarks>Equivalent to your "Pinch" gesture.</remarks>
		Zoom = 114,

		/// <summary>
		/// Pan
		/// </summary>
		/// <remarks>Equivalent to your "Scroll" gesture.</remarks>
		Pan = 115,

		/// <summary>
		/// Rotate
		/// </summary>
		Rotate = 116,

		/// <summary>
		/// Two finger tap.
		/// </summary>
		TwoFingerTap = 117,
        
		/// <summary>
		/// Rollover
		/// </summary>
		Rollover = 118,

		/// <summary>
		/// Undefined
		/// </summary>
		/// <remarks>Additional touch gestures.</remarks>
		UserDefined = 200,
	}
}
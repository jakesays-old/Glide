using System;
using GHI.Glide.Geom;

namespace GHI.Glide
{
	/// <summary>
	/// Calibration Settings
	/// </summary>
	[Serializable]
	public sealed class CalibrationSettings
	{
		/// <summary>
		/// Calibration Points
		/// </summary>
		public Point[] Points { get; set; }

		/// <summary>
		/// Screen X Buffer
		/// </summary>
		public short[] SX { get; set; }

		/// <summary>
		/// Screen Y Buffer
		/// </summary>
		public short[] SY { get; set; }

		/// <summary>
		/// Uncalibrated X Buffer
		/// </summary>
		public short[] CX { get; set; }

		/// <summary>
		/// Uncalibrated Y Buffer
		/// </summary>
		public short[] CY { get; set; }
	}
}
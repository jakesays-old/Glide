using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Glide.Devices.Windows;

namespace WinFormsHost
{
	public partial class Display : Control
	{
		private Win32Platform _platform;

		public Display()
		{
			InitializeComponent();
		}

		public void Initialize(Win32Platform platform)
		{
			_platform = platform;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			var rect = new Rectangle(0, 0, Width - 1, Height - 1);
			pe.Graphics.DrawRectangle(Pens.Black, rect);

			_platform.RenderScreen(pe.Graphics);

			base.OnPaint(pe);
		}
	}
}

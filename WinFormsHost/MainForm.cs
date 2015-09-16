using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GHI.Glide;
using Glide.Devices.Windows;

namespace WinFormsHost
{
	public partial class MainForm : Form, IWin32PlatformHost
	{
		private readonly Win32Platform _platform;

		public MainForm()
		{
			InitializeComponent();

			loadButton.Click += LoadButtonOnClick;
			exitButton.Click += ExitButtonOnClick;

			_platform = new Win32Platform(Resources.ResourceManager, Resources.Culture,
				320, 240, this);

			deviceDisplay.Initialize(_platform);
			GHI.Glide.Glide.Start(_platform);
		}

		private void ExitButtonOnClick(object sender, EventArgs eventArgs)
		{
			Close();
		}

		private GHI.Glide.Display.Window _window;

		private void LoadButtonOnClick(object sender, EventArgs eventArgs)
		{
			const string xml =
@"<Glide Version='1.0.7'>
  <Window Name='instance115' Width='320' Height='240' BackColor='FFFFFF'>
    <TextBlock Name='instance372' X='0' Y='0' Width='100' Height='32' Alpha='255' Text='Hello' TextAlign='Left' TextVerticalAlign='Top' Font='4' FontColor='0' BackColor='000000' ShowBackColor='False'/>
    <TextBox Name='instance575' X='0' Y='36' Width='80' Height='32' Alpha='255' Text='' TextAlign='Left' Font='4' FontColor='000000'/>
    <Button Name='instance1350' X='89' Y='37' Width='80' Height='32' Alpha='255' Text='Press Me' Font='4' FontColor='000000' DisabledFontColor='808080' TintColor='000000' TintAmount='0'/>
  </Window>
</Glide>";

			const string xml2 =
@"<Glide Version='1.0.7'>
  <Window Name='instance115' Width='320' Height='240' BackColor='FFFFFF'>
    <TextBlock Name='instance372' X='0' Y='0' Width='100' Height='32' Alpha='255' Text='Hello' TextAlign='Left' TextVerticalAlign='Top' Font='4' FontColor='0' BackColor='000000' ShowBackColor='False'/>
    <TextBox Name='instance575' X='0' Y='36' Width='80' Height='32' Alpha='255' Text='' TextAlign='Left' Font='4' FontColor='000000'/>
    <Button Name='instance1350' X='89' Y='37' Width='80' Height='32' Alpha='255' Text='Press Me' Font='4' FontColor='000000' DisabledFontColor='808080' TintColor='000000' TintAmount='0'/>
    <ProgressBar Name='instance1815' X='5' Y='97' Width='80' Height='16' Alpha='255' Direction='Right' MaxValue='100' Value='0'/>
    <Slider Name='instance2349' X='52' Y='157' Width='200' Height='30' Alpha='255' Direction='horizontal' SnapInterval='10' TickInterval='10' TickColor='000000' KnobSize='20' Minimum='0' Maximum='100' Value='0'/>
    <CheckBox Name='instance2617' X='169' Y='98' Width='32' Height='32' Alpha='255' Checked='False'/>
  </Window>
</Glide>";

            if (_window != null)
			{
				_window.RenderedEvent -= WindowOnRenderedEvent;
				_window.Dispose();
			}
			GHI.Glide.Glide.MainWindow = GlideLoader.LoadWindow(xml2);
//			_window.RenderedEvent += WindowOnRenderedEvent;
//			_window.Visible = true;
	//		_window.Render();
		}

		private void WindowOnRenderedEvent(object sender)
		{
			deviceDisplay.Invalidate();
		}

		public void UpdateScreen()
		{
			deviceDisplay.Invalidate();
		}

		public void UpdateScreen(int x, int y, int width, int height)
		{
			deviceDisplay.Invalidate(new Rectangle(x, y, width, height));
		}
	}
}

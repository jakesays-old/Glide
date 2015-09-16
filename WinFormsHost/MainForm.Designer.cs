namespace WinFormsHost
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.deviceDisplay = new WinFormsHost.Display();
			this.loadButton = new System.Windows.Forms.ToolStripButton();
			this.exitButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadButton,
            this.exitButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(346, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// deviceDisplay
			// 
			this.deviceDisplay.Location = new System.Drawing.Point(12, 28);
			this.deviceDisplay.Name = "deviceDisplay";
			this.deviceDisplay.Size = new System.Drawing.Size(320, 240);
			this.deviceDisplay.TabIndex = 0;
			// 
			// loadButton
			// 
			this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
			this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(37, 22);
			this.loadButton.Text = "Load";
			// 
			// exitButton
			// 
			this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
			this.exitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(29, 22);
			this.exitButton.Text = "Exit";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 286);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.deviceDisplay);
			this.MaximumSize = new System.Drawing.Size(362, 325);
			this.MinimumSize = new System.Drawing.Size(362, 325);
			this.Name = "MainForm";
			this.Text = "Glide Test";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Display deviceDisplay;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton loadButton;
		private System.Windows.Forms.ToolStripButton exitButton;
	}
}


namespace CommandSender
{
	partial class MouseControlForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseControlForm));
			this.SuspendLayout();
			// 
			// MouseControlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1008, 730);
			this.Cursor = System.Windows.Forms.Cursors.Cross;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MouseControlForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mouse Control";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouseControlForm_FormClosing);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MouseControlForm_KeyPress);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_MouseClick);
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_MouseDoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_MouseDown);
			this.MouseEnter += new System.EventHandler(this.MouseControlForm_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.MouseControlForm_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_MouseUp);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseControlForm_Wheel);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
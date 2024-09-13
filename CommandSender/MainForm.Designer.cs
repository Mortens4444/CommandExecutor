namespace CommandSender
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.p_Main = new System.Windows.Forms.Panel();
            this.gb_Main = new System.Windows.Forms.GroupBox();
            this.lbl_Command = new System.Windows.Forms.Label();
            this.btn_MouseControl = new System.Windows.Forms.Button();
            this.tb_Application = new System.Windows.Forms.TextBox();
            this.btn_KillApplication = new System.Windows.Forms.Button();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.btn_VisitLink = new System.Windows.Forms.Button();
            this.btn_TaskMgr = new System.Windows.Forms.Button();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.btn_Notepad = new System.Windows.Forms.Button();
            this.btn_Paint = new System.Windows.Forms.Button();
            this.btn_Calc = new System.Windows.Forms.Button();
            this.btn_Regedit = new System.Windows.Forms.Button();
            this.btn_CommandPrompt = new System.Windows.Forms.Button();
            this.btn_ShutdownAbort = new System.Windows.Forms.Button();
            this.btn_Shutdown = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tb_VideoFile = new System.Windows.Forms.TextBox();
            this.lbl_StartVideo = new System.Windows.Forms.Label();
            this.lbl_Computer = new System.Windows.Forms.Label();
            this.cb_Computer = new System.Windows.Forms.ComboBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.tb_Command = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.p_Main.SuspendLayout();
            this.gb_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.gb_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(469, 189);
            this.p_Main.TabIndex = 0;
            // 
            // gb_Main
            // 
            this.gb_Main.Controls.Add(this.nudPort);
            this.gb_Main.Controls.Add(this.lbl_Command);
            this.gb_Main.Controls.Add(this.btn_MouseControl);
            this.gb_Main.Controls.Add(this.tb_Application);
            this.gb_Main.Controls.Add(this.btn_KillApplication);
            this.gb_Main.Controls.Add(this.tb_Link);
            this.gb_Main.Controls.Add(this.btn_VisitLink);
            this.gb_Main.Controls.Add(this.btn_TaskMgr);
            this.gb_Main.Controls.Add(this.btn_Restart);
            this.gb_Main.Controls.Add(this.btn_Notepad);
            this.gb_Main.Controls.Add(this.btn_Paint);
            this.gb_Main.Controls.Add(this.btn_Calc);
            this.gb_Main.Controls.Add(this.btn_Regedit);
            this.gb_Main.Controls.Add(this.btn_CommandPrompt);
            this.gb_Main.Controls.Add(this.btn_ShutdownAbort);
            this.gb_Main.Controls.Add(this.btn_Shutdown);
            this.gb_Main.Controls.Add(this.btn_Start);
            this.gb_Main.Controls.Add(this.tb_VideoFile);
            this.gb_Main.Controls.Add(this.lbl_StartVideo);
            this.gb_Main.Controls.Add(this.lbl_Computer);
            this.gb_Main.Controls.Add(this.cb_Computer);
            this.gb_Main.Controls.Add(this.btn_Send);
            this.gb_Main.Controls.Add(this.tb_Command);
            this.gb_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Main.Location = new System.Drawing.Point(0, 0);
            this.gb_Main.Name = "gb_Main";
            this.gb_Main.Size = new System.Drawing.Size(469, 189);
            this.gb_Main.TabIndex = 0;
            this.gb_Main.TabStop = false;
            // 
            // lbl_Command
            // 
            this.lbl_Command.AutoSize = true;
            this.lbl_Command.Location = new System.Drawing.Point(12, 47);
            this.lbl_Command.Name = "lbl_Command";
            this.lbl_Command.Size = new System.Drawing.Size(54, 13);
            this.lbl_Command.TabIndex = 22;
            this.lbl_Command.Text = "Command";
            // 
            // btn_MouseControl
            // 
            this.btn_MouseControl.Image = global::CommandSender.Properties.Resources.mouse_control;
            this.btn_MouseControl.Location = new System.Drawing.Point(186, 99);
            this.btn_MouseControl.Name = "btn_MouseControl";
            this.btn_MouseControl.Size = new System.Drawing.Size(23, 23);
            this.btn_MouseControl.TabIndex = 21;
            this.btn_MouseControl.UseVisualStyleBackColor = true;
            this.btn_MouseControl.Click += new System.EventHandler(this.Btn_MouseControl_Click);
            // 
            // tb_Application
            // 
            this.tb_Application.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Application.Location = new System.Drawing.Point(12, 158);
            this.tb_Application.Name = "tb_Application";
            this.tb_Application.Size = new System.Drawing.Size(415, 20);
            this.tb_Application.TabIndex = 20;
            this.tb_Application.Text = "firefox";
            // 
            // btn_KillApplication
            // 
            this.btn_KillApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_KillApplication.Image = global::CommandSender.Properties.Resources.kill_app;
            this.btn_KillApplication.Location = new System.Drawing.Point(433, 156);
            this.btn_KillApplication.Name = "btn_KillApplication";
            this.btn_KillApplication.Size = new System.Drawing.Size(23, 23);
            this.btn_KillApplication.TabIndex = 19;
            this.btn_KillApplication.UseVisualStyleBackColor = true;
            this.btn_KillApplication.Click += new System.EventHandler(this.Btn_KillApplication_Click);
            // 
            // tb_Link
            // 
            this.tb_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link.Location = new System.Drawing.Point(12, 131);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(415, 20);
            this.tb_Link.TabIndex = 18;
            this.tb_Link.Text = "www.facebook.hu";
            // 
            // btn_VisitLink
            // 
            this.btn_VisitLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_VisitLink.Image = global::CommandSender.Properties.Resources.visit_link;
            this.btn_VisitLink.Location = new System.Drawing.Point(433, 129);
            this.btn_VisitLink.Name = "btn_VisitLink";
            this.btn_VisitLink.Size = new System.Drawing.Size(23, 23);
            this.btn_VisitLink.TabIndex = 17;
            this.btn_VisitLink.UseVisualStyleBackColor = true;
            this.btn_VisitLink.Click += new System.EventHandler(this.Btn_VisitLink_Click);
            // 
            // btn_TaskMgr
            // 
            this.btn_TaskMgr.Image = global::CommandSender.Properties.Resources.TaskMgr;
            this.btn_TaskMgr.Location = new System.Drawing.Point(157, 99);
            this.btn_TaskMgr.Name = "btn_TaskMgr";
            this.btn_TaskMgr.Size = new System.Drawing.Size(23, 23);
            this.btn_TaskMgr.TabIndex = 15;
            this.btn_TaskMgr.UseVisualStyleBackColor = true;
            this.btn_TaskMgr.Click += new System.EventHandler(this.Btn_TaskMgr_Click);
            // 
            // btn_Restart
            // 
            this.btn_Restart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Restart.Image = global::CommandSender.Properties.Resources.restart;
            this.btn_Restart.Location = new System.Drawing.Point(404, 99);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(23, 23);
            this.btn_Restart.TabIndex = 14;
            this.btn_Restart.UseVisualStyleBackColor = true;
            this.btn_Restart.Click += new System.EventHandler(this.Btn_Restart_Click);
            // 
            // btn_Notepad
            // 
            this.btn_Notepad.Image = global::CommandSender.Properties.Resources.notepad;
            this.btn_Notepad.Location = new System.Drawing.Point(70, 99);
            this.btn_Notepad.Name = "btn_Notepad";
            this.btn_Notepad.Size = new System.Drawing.Size(23, 23);
            this.btn_Notepad.TabIndex = 13;
            this.btn_Notepad.UseVisualStyleBackColor = true;
            this.btn_Notepad.Click += new System.EventHandler(this.Btn_Notepad_Click);
            // 
            // btn_Paint
            // 
            this.btn_Paint.Image = global::CommandSender.Properties.Resources.paint;
            this.btn_Paint.Location = new System.Drawing.Point(99, 99);
            this.btn_Paint.Name = "btn_Paint";
            this.btn_Paint.Size = new System.Drawing.Size(23, 23);
            this.btn_Paint.TabIndex = 12;
            this.btn_Paint.UseVisualStyleBackColor = true;
            this.btn_Paint.Click += new System.EventHandler(this.Btn_Paint_Click);
            // 
            // btn_Calc
            // 
            this.btn_Calc.Image = global::CommandSender.Properties.Resources.calc;
            this.btn_Calc.Location = new System.Drawing.Point(41, 99);
            this.btn_Calc.Name = "btn_Calc";
            this.btn_Calc.Size = new System.Drawing.Size(23, 23);
            this.btn_Calc.TabIndex = 11;
            this.btn_Calc.UseVisualStyleBackColor = true;
            this.btn_Calc.Click += new System.EventHandler(this.Btn_Calc_Click);
            // 
            // btn_Regedit
            // 
            this.btn_Regedit.Image = global::CommandSender.Properties.Resources.regedit;
            this.btn_Regedit.Location = new System.Drawing.Point(128, 99);
            this.btn_Regedit.Name = "btn_Regedit";
            this.btn_Regedit.Size = new System.Drawing.Size(23, 23);
            this.btn_Regedit.TabIndex = 10;
            this.btn_Regedit.UseVisualStyleBackColor = true;
            this.btn_Regedit.Click += new System.EventHandler(this.Btn_Regedit_Click);
            // 
            // btn_CommandPrompt
            // 
            this.btn_CommandPrompt.Image = global::CommandSender.Properties.Resources.cmd;
            this.btn_CommandPrompt.Location = new System.Drawing.Point(12, 99);
            this.btn_CommandPrompt.Name = "btn_CommandPrompt";
            this.btn_CommandPrompt.Size = new System.Drawing.Size(23, 23);
            this.btn_CommandPrompt.TabIndex = 9;
            this.btn_CommandPrompt.UseVisualStyleBackColor = true;
            this.btn_CommandPrompt.Click += new System.EventHandler(this.Btn_CommandPrompt_Click);
            // 
            // btn_ShutdownAbort
            // 
            this.btn_ShutdownAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShutdownAbort.Image = global::CommandSender.Properties.Resources.abort;
            this.btn_ShutdownAbort.Location = new System.Drawing.Point(433, 99);
            this.btn_ShutdownAbort.Name = "btn_ShutdownAbort";
            this.btn_ShutdownAbort.Size = new System.Drawing.Size(23, 23);
            this.btn_ShutdownAbort.TabIndex = 8;
            this.btn_ShutdownAbort.UseVisualStyleBackColor = true;
            this.btn_ShutdownAbort.Click += new System.EventHandler(this.Btn_ShutdownAbort_Click);
            // 
            // btn_Shutdown
            // 
            this.btn_Shutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Shutdown.Image = global::CommandSender.Properties.Resources.shutdown;
            this.btn_Shutdown.Location = new System.Drawing.Point(375, 99);
            this.btn_Shutdown.Name = "btn_Shutdown";
            this.btn_Shutdown.Size = new System.Drawing.Size(23, 23);
            this.btn_Shutdown.TabIndex = 7;
            this.btn_Shutdown.UseVisualStyleBackColor = true;
            this.btn_Shutdown.Click += new System.EventHandler(this.Btn_Shutdown_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Start.Location = new System.Drawing.Point(375, 71);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(82, 23);
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // tb_VideoFile
            // 
            this.tb_VideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_VideoFile.Location = new System.Drawing.Point(90, 73);
            this.tb_VideoFile.Name = "tb_VideoFile";
            this.tb_VideoFile.Size = new System.Drawing.Size(279, 20);
            this.tb_VideoFile.TabIndex = 5;
            // 
            // lbl_StartVideo
            // 
            this.lbl_StartVideo.AutoSize = true;
            this.lbl_StartVideo.Location = new System.Drawing.Point(12, 76);
            this.lbl_StartVideo.Name = "lbl_StartVideo";
            this.lbl_StartVideo.Size = new System.Drawing.Size(58, 13);
            this.lbl_StartVideo.TabIndex = 4;
            this.lbl_StartVideo.Text = "Start video";
            // 
            // lbl_Computer
            // 
            this.lbl_Computer.AutoSize = true;
            this.lbl_Computer.Location = new System.Drawing.Point(12, 20);
            this.lbl_Computer.Name = "lbl_Computer";
            this.lbl_Computer.Size = new System.Drawing.Size(52, 13);
            this.lbl_Computer.TabIndex = 3;
            this.lbl_Computer.Text = "Computer";
            // 
            // cb_Computer
            // 
            this.cb_Computer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Computer.FormattingEnabled = true;
            this.cb_Computer.Location = new System.Drawing.Point(90, 17);
            this.cb_Computer.Name = "cb_Computer";
            this.cb_Computer.Size = new System.Drawing.Size(279, 21);
            this.cb_Computer.TabIndex = 2;
            // 
            // btn_Send
            // 
            this.btn_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Send.Location = new System.Drawing.Point(375, 41);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(82, 23);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // tb_Command
            // 
            this.tb_Command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Command.Location = new System.Drawing.Point(90, 44);
            this.tb_Command.Name = "tb_Command";
            this.tb_Command.Size = new System.Drawing.Size(279, 20);
            this.tb_Command.TabIndex = 0;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(375, 18);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(80, 20);
            this.nudPort.TabIndex = 23;
            this.nudPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 189);
            this.Controls.Add(this.p_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 228);
            this.MinimumSize = new System.Drawing.Size(322, 228);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command sender";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.p_Main.ResumeLayout(false);
            this.gb_Main.ResumeLayout(false);
            this.gb_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.GroupBox gb_Main;
		private System.Windows.Forms.Button btn_Send;
		private System.Windows.Forms.TextBox tb_Command;
		private System.Windows.Forms.Label lbl_Computer;
		private System.Windows.Forms.ComboBox cb_Computer;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.TextBox tb_VideoFile;
		private System.Windows.Forms.Label lbl_StartVideo;
		private System.Windows.Forms.Button btn_Shutdown;
		private System.Windows.Forms.Button btn_ShutdownAbort;
		private System.Windows.Forms.Button btn_CommandPrompt;
		private System.Windows.Forms.Button btn_Regedit;
		private System.Windows.Forms.Button btn_Paint;
		private System.Windows.Forms.Button btn_Calc;
		private System.Windows.Forms.Button btn_Notepad;
		private System.Windows.Forms.Button btn_Restart;
		private System.Windows.Forms.Button btn_TaskMgr;
		private System.Windows.Forms.Button btn_VisitLink;
		private System.Windows.Forms.TextBox tb_Link;
		private System.Windows.Forms.TextBox tb_Application;
		private System.Windows.Forms.Button btn_KillApplication;
		private System.Windows.Forms.Button btn_MouseControl;
		private System.Windows.Forms.Label lbl_Command;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown nudPort;
    }
}


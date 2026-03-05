namespace Clock
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
			this.labelTime = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.cbShowDate = new System.Windows.Forms.CheckBox();
			this.cbShowWeekday = new System.Windows.Forms.CheckBox();
			this.btnHideControls = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiTopmost = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiShowControls = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiShowDate = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiShowWeekday = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiFont = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiColor = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiForegroundColor = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiAlarms = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiAutostart = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.BackColor = System.Drawing.SystemColors.Highlight;
			this.labelTime.ContextMenuStrip = this.contextMenuStrip;
			this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTime.Location = new System.Drawing.Point(13, 13);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(258, 51);
			this.labelTime.TabIndex = 0;
			this.labelTime.Text = "Current time";
			this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// cbShowDate
			// 
			this.cbShowDate.AutoSize = true;
			this.cbShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowDate.Location = new System.Drawing.Point(22, 179);
			this.cbShowDate.Name = "cbShowDate";
			this.cbShowDate.Size = new System.Drawing.Size(132, 29);
			this.cbShowDate.TabIndex = 1;
			this.cbShowDate.Text = "Show date";
			this.cbShowDate.UseVisualStyleBackColor = true;
			// 
			// cbShowWeekday
			// 
			this.cbShowWeekday.AutoSize = true;
			this.cbShowWeekday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowWeekday.Location = new System.Drawing.Point(22, 215);
			this.cbShowWeekday.Name = "cbShowWeekday";
			this.cbShowWeekday.Size = new System.Drawing.Size(175, 29);
			this.cbShowWeekday.TabIndex = 2;
			this.cbShowWeekday.Text = "Show weekday";
			this.cbShowWeekday.UseVisualStyleBackColor = true;
			// 
			// btnHideControls
			// 
			this.btnHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnHideControls.Location = new System.Drawing.Point(22, 251);
			this.btnHideControls.Name = "btnHideControls";
			this.btnHideControls.Size = new System.Drawing.Size(240, 54);
			this.btnHideControls.TabIndex = 3;
			this.btnHideControls.Text = "Hide controls";
			this.btnHideControls.UseVisualStyleBackColor = true;
			this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon";
			this.notifyIcon.Visible = true;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTopmost,
            this.tsmiShowControls,
            this.toolStripSeparator1,
            this.tsmiShowDate,
            this.tsmiShowWeekday,
            this.toolStripSeparator2,
            this.tsmiFont,
            this.tsmiColor,
            this.toolStripSeparator3,
            this.tsmiAlarms,
            this.toolStripSeparator4,
            this.tsmiAutostart,
            this.toolStripSeparator5,
            this.tsmiClose});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 232);
			// 
			// tsmiTopmost
			// 
			this.tsmiTopmost.Name = "tsmiTopmost";
			this.tsmiTopmost.Size = new System.Drawing.Size(152, 22);
			this.tsmiTopmost.Text = "Topmost";
			// 
			// tsmiShowControls
			// 
			this.tsmiShowControls.Name = "tsmiShowControls";
			this.tsmiShowControls.Size = new System.Drawing.Size(152, 22);
			this.tsmiShowControls.Text = "Show controls";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmiShowDate
			// 
			this.tsmiShowDate.Name = "tsmiShowDate";
			this.tsmiShowDate.Size = new System.Drawing.Size(152, 22);
			this.tsmiShowDate.Text = "Show date";
			// 
			// tsmiShowWeekday
			// 
			this.tsmiShowWeekday.Name = "tsmiShowWeekday";
			this.tsmiShowWeekday.Size = new System.Drawing.Size(152, 22);
			this.tsmiShowWeekday.Text = "Show weekday";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmiFont
			// 
			this.tsmiFont.Name = "tsmiFont";
			this.tsmiFont.Size = new System.Drawing.Size(152, 22);
			this.tsmiFont.Text = "Font";
			// 
			// tsmiColor
			// 
			this.tsmiColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForegroundColor,
            this.tsmiBackgroundColor});
			this.tsmiColor.Name = "tsmiColor";
			this.tsmiColor.Size = new System.Drawing.Size(152, 22);
			this.tsmiColor.Text = "Color";
			// 
			// tsmiForegroundColor
			// 
			this.tsmiForegroundColor.Name = "tsmiForegroundColor";
			this.tsmiForegroundColor.Size = new System.Drawing.Size(180, 22);
			this.tsmiForegroundColor.Text = "Foreground color";
			// 
			// tsmiBackgroundColor
			// 
			this.tsmiBackgroundColor.Name = "tsmiBackgroundColor";
			this.tsmiBackgroundColor.Size = new System.Drawing.Size(180, 22);
			this.tsmiBackgroundColor.Text = "Background color";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmiAlarms
			// 
			this.tsmiAlarms.Name = "tsmiAlarms";
			this.tsmiAlarms.Size = new System.Drawing.Size(152, 22);
			this.tsmiAlarms.Text = "Alarms";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmiAutostart
			// 
			this.tsmiAutostart.Name = "tsmiAutostart";
			this.tsmiAutostart.Size = new System.Drawing.Size(152, 22);
			this.tsmiAutostart.Text = "Autostart";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmiClose
			// 
			this.tsmiClose.Name = "tsmiClose";
			this.tsmiClose.Size = new System.Drawing.Size(152, 22);
			this.tsmiClose.Text = "Close";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(281, 317);
			this.Controls.Add(this.btnHideControls);
			this.Controls.Add(this.cbShowWeekday);
			this.Controls.Add(this.cbShowDate);
			this.Controls.Add(this.labelTime);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Clock P_421";
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox cbShowDate;
		private System.Windows.Forms.CheckBox cbShowWeekday;
		private System.Windows.Forms.Button btnHideControls;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem tsmiTopmost;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowControls;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowDate;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowWeekday;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tsmiFont;
		private System.Windows.Forms.ToolStripMenuItem tsmiColor;
		private System.Windows.Forms.ToolStripMenuItem tsmiForegroundColor;
		private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem tsmiAlarms;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem tsmiAutostart;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem tsmiClose;
	}
}


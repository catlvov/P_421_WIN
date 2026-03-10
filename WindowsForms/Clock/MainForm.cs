using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		ColorDialog backgroundColorDialog;
		ColorDialog foregroundColorDialog;
		public MainForm()
		{
			InitializeComponent();
			SetVisibility(tsmiShowControls.Checked = false);
			backgroundColorDialog = new ColorDialog();
			foregroundColorDialog = new ColorDialog();

			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 25, 50);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked)
				labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
			if (cbShowWeekday.Checked)
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIcon.Text = labelTime.Text;
		}
		void SetVisibility(bool visible)
		{
			cbShowDate.Visible = visible;
			cbShowWeekday.Visible = visible;
			btnHideControls.Visible = visible;
			ShowInTaskbar = visible;
			FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			SetVisibility(tsmiShowControls.Checked = false);
		}

		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			SetVisibility(tsmiShowControls.Checked = true);
		}

		private void tsmiTopmost_CheckedChanged(object sender, EventArgs e) =>
			this.TopMost = tsmiTopmost.Checked;

		private void tsmiShowControls_CheckedChanged(object sender, EventArgs e) =>
			SetVisibility(tsmiShowControls.Checked);

		private void tsmiClose_Click(object sender, EventArgs e) => this.Close();

		private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) =>
			cbShowDate.Checked = tsmiShowDate.Checked;

		private void cbShowDate_CheckedChanged(object sender, EventArgs e) => 
			tsmiShowDate.Checked = cbShowDate.Checked;

		private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			cbShowWeekday.Checked = (sender as ToolStripMenuItem).Checked;

		private void cbShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowWeekday.Checked = (sender as CheckBox).Checked;

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!this.TopMost)
			{
				this.TopMost = true;
				this.TopMost = false;
			}
		}

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
				labelTime.BackColor = backgroundColorDialog.Color;
		}

		private void tsmiForegroundColor_Click(object sender, EventArgs e)
		{
			if (foregroundColorDialog.ShowDialog() == DialogResult.OK)
				labelTime.ForeColor = foregroundColorDialog.Color;
		}
	}
}

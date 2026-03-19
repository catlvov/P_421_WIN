using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO; //in/out 
using System.Diagnostics;

using Microsoft.Win32;
using System.Windows.Forms.VisualStyles;

namespace Clock
{
	public partial class MainForm : Form
	{
		ColorDialog backgroundColorDialog;
		ColorDialog foregroundColorDialog;
		FontDialog fontDialog;
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 25, 50);
			backgroundColorDialog = new ColorDialog();
			foregroundColorDialog = new ColorDialog();
			//fontDialog = new FontDialog(this);
			loadSettings();
			SetVisibility(tsmiShowControls.Checked);
		}

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
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
			//Get/Set-методами
			//Get (взять, получить)		- открывают доступ к закрытым переменым в классе на чтение (позволяют получить значение закрытой переменной).
			//Set (задать, установить)	- открывают доступ к закрытым переменным в классе на запись (позволяют задать значние закрытой переменной).
			//		Кроме того, Set-методы обеспечивают фильтрацию данных, т.е., предотвращают попадание некорректных значений в закрытые переменные.
			//В языке C#, Инкапсуляция так же реализуется при помощи Свойств (Properties).
			//Свойства (Properties) - это синтаксическая конструкция, которая объединяет в себе Get и Set метод, и позволяет их использовать,
			//						  как самую обычную открытую переменную.
		}


        private void tsmiFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                labelTime.Font = fontDialog.Font;
                fontDialog.Font = labelTime.Font;
            }
        }

        private void tsmiAutostart_CheckedChanged(object sender, EventArgs e)
		{
			string key_name = "Clock_P_421";
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (tsmiAutostart.Checked) rk.SetValue(key_name, Application.ExecutablePath);
			else rk.DeleteValue(key_name, false);
			rk.Dispose();
		}

        void SaveSettings()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"{Application.ExecutablePath}\\..\\..\\..\\Settings.ini");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"{this.Location.X}x{this.Location.Y}");
                writer.WriteLine(tsmiTopmost.Checked);
                writer.WriteLine(tsmiShowControls.Checked);
                writer.WriteLine(tsmiShowDate.Checked);
                writer.WriteLine(tsmiShowWeekday.Checked);
                writer.WriteLine(tsmiAutostart.Checked);

                if (labelTime.Font != null)
                {
                    writer.WriteLine(fontDialog.FontFile);
                    writer.WriteLine(fontDialog.NUDFontSize.Value);
                }
                else
                {
                    writer.WriteLine("Segoe UI"); 
                    writer.WriteLine(30);
                    writer.WriteLine(0);
                }

                writer.WriteLine(labelTime.BackColor.ToArgb());
                writer.WriteLine(labelTime.ForeColor.ToArgb());
            }
        }


        void loadSettings()
        {
            try
            {
                string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"{Application.ExecutablePath}\\..\\..\\..\\Settings.ini");


				if (!File.Exists(fileName))
                    return; 

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string[] pos = reader.ReadLine().Split('x');
                    this.Location = new Point(int.Parse(pos[0]), int.Parse(pos[1]));

                    tsmiTopmost.Checked = bool.Parse(reader.ReadLine());
                    tsmiShowControls.Checked = bool.Parse(reader.ReadLine());
                    tsmiShowDate.Checked = bool.Parse(reader.ReadLine());
                    tsmiShowWeekday.Checked = bool.Parse(reader.ReadLine());
                    tsmiAutostart.Checked = bool.Parse(reader.ReadLine());

                    try
                    {
                        fontDialog = new FontDialog(this, reader.ReadLine(), Convert.ToDecimal(reader.ReadLine()));
						labelTime.Font = fontDialog.Font;
                    }
                    catch
                    {
                        labelTime.Font = new Font("Segoe UI", 30);
                    }

                    labelTime.BackColor = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                    labelTime.ForeColor = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Ошибка загрузки настроек: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => SaveSettings();
    }
}
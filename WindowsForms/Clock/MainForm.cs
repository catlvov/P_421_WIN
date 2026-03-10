
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        private ColorDialog backgroundColorDialog;
        private ColorDialog foregroundColorDialog;
        private Font customClockFont;
        private const string AppName = "DigitalClock";

        public MainForm()
        {
            InitializeComponent();

            try
            {
                PrivateFontCollection privateFonts = new PrivateFontCollection();
                privateFonts.AddFontFile("C:\\Users\\catlvov\\Source\\Repos\\P_421_WIN\\WindowsForms\\Clock\\Fronts\\Warnationbold.ttf");

                if (privateFonts.Families.Length > 0)
                {
                    customClockFont = new Font(privateFonts.Families[0], 35f, FontStyle.Regular);
                    labelTime.Font = customClockFont;
                }
                else
                {
                    labelTime.Font = new Font("Arial", 35f, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки шрифта: {ex.Message}");
                labelTime.Font = new Font("Arial", 35f, FontStyle.Bold);
            }

            tsmiAutostart.Checked = IsAutostartEnabled();

            tsmiShowControls.Checked = true;
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

        private void btnHideControls_Click(object sender, EventArgs e) => SetVisibility(false);
        
        private void labelTime_DoubleClick(object sender, EventArgs e) => SetVisibility(tsmiShowControls.Checked = true);
        
        private void tsmiTopmost_CheckedChanged(object sender, EventArgs e) => this.TopMost = tsmiTopmost.Checked;

        private void tsmiShowControls_CheckedChanged(object sender, EventArgs e) => SetVisibility(tsmiShowControls.Checked);

        private void tsmiClose_Click(object sender, EventArgs e) => this.Close();
        private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) => cbShowWeekday.Checked = tsmiShowWeekday.Checked;
        private void cbShowWeekday_CheckedChanged(object sender, EventArgs e) => tsmiShowWeekday.Checked = cbShowWeekday.Checked;
        private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) => cbShowDate.Checked = tsmiShowDate.Checked;
        private void cbShowDate_CheckedChanged(object sender, EventArgs e) => tsmiShowDate.Checked = cbShowDate.Checked;

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                labelTime.BackColor = backgroundColorDialog.Color;
            }
        }

        private void tsmoForegroundColor_Click(object sender, EventArgs e)
        {
            if (foregroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                labelTime.ForeColor = foregroundColorDialog.Color;
            }
        }

        private void SetAutostart(bool enable)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey
                (
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
            true
                );

                if (enable)
                {
                    string appPath = Application.ExecutablePath;
                    key.SetValue(AppName, appPath);
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }

                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось настроить автозапуск: {ex.Message}");
            }
        }

        private bool IsAutostartEnabled()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey
                (
                     @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
                );
                string value = key.GetValue(AppName) as string;
                key.Close();
                return !string.IsNullOrEmpty(value);
            }
            catch
            {
                return false;
            }
        }
        private void cbAutostart_CheckedChanged(object sender, EventArgs e) => SetAutostart(tsmiAutostart.Checked);
        
    }
}
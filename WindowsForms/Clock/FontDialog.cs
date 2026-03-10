using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Xml.Serialization;

namespace Clock
{
    public partial class FontDialog : Form
    {
        MainForm parent;
        public FontDialog()
        {
            InitializeComponent();
            LoadFonts();
        }
        public FontDialog(MainForm parent) : this()
        {
            this.parent = parent;
           
        }

        private void ChooswFont_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X - this.Width, parent.Location.Y + 50);
        }
        void LoadFonts()
        {
            Console.WriteLine(Application.ExecutablePath); 
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fronts");
            Console.WriteLine(Directory.GetCurrentDirectory());
            // string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            LoadFronts(Directory.GetCurrentDirectory(), "*.ttf");
            LoadFronts(Directory.GetCurrentDirectory(), "*.otf");
        }
        void LoadFronts(string path,string format)
        {
            string[] files = Directory.GetFiles(path, format);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Split('\\').Last();
            }
            comboBoxFronts.Items.AddRange(files);
        }

        void ApplyFontExample()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(comboBoxFronts.SelectedItem.ToString());
            labelExample.Font = new Font(pfc.Families[0], (float)nudFrontSize.Value);
        }

        private void comboBoxFronts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontExample();
        }

        private void nudFrontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyFontExample();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

    }
}

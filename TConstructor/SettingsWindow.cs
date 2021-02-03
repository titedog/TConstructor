using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TConstructor.Properties;

namespace TConstructor
{
    public partial class SettingsWindow : Form
    {
        protected override void WndProc(ref Message m) //allows the form to be moved
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            var pb = pictureBox2;
            var toggleoff = TConstructor.Properties.Resources.baseline_toggle_off_black_18dp;
            var toggleon = TConstructor.Properties.Resources.baseline_toggle_on_black_18dp;

            bool experimentalMode = (bool)Settings.Default["ExperimentalMode"];
            if (experimentalMode == false)
            {
                pb.Image = new Bitmap(toggleoff);
            }
            else
            {
                pb.Image = new Bitmap(toggleon);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var pb = pictureBox2;
            var toggleoff = TConstructor.Properties.Resources.baseline_toggle_off_black_18dp;
            var toggleon = TConstructor.Properties.Resources.baseline_toggle_on_black_18dp;

            bool experimentalMode = (bool)Settings.Default["ExperimentalMode"];
            if(experimentalMode == false)
            {
                pb.Image = new Bitmap(toggleon);
                Settings.Default["ExperimentalMode"] = true;
            }
            else
            {
                pb.Image = new Bitmap(toggleoff);
                Settings.Default["ExperimentalMode"] = false;
            }
            Settings.Default.Save();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            new Form1().Show();
            this.Close();
        }
    }
}

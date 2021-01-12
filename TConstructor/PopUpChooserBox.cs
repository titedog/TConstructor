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
using System.Diagnostics;
using System.IO;

namespace TConstructor
{
    public partial class PopUpChooserBox : Form
    {
        public PopUpChooserBox(string title, string title1, string desc1, string chooseType, string tdesc, string tlabel, string wlabel, string wdesc2)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
            label1.Text = title;
            label2.Text = title1;
            label3.Text = desc1;
            if(chooseType == "mod_element")
            {
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                sword_desc.Text = "A weapon that deals damage.";
                sword_label.Text = "Weapon Element";
                tool_desc.Text = "A tool like a pickaxe or axe.";
                tool_label.Text = "Tool Element";
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox1.Visible = false;
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        protected override void WndProc(ref Message m) //allows the form to be moved
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void PopUpChooserBox_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox1, "Create Weapon Element"); //hover tooltip
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox3, "Create Tool Element"); //hover tooltip
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string element_type = "weapon";
            string form_title = "New Element - Weapon";
            string input_1_name = "Weapon Name";
            string input_1_desc = "This will show up as the name of the Weapon.";
            string input_2_desc = "Weapon Description (Optional)";
            string input_2_name = "This will show up in the description of the Weapon.";
            string input_3_desc = "Weapon Texture";
            string input_3_name = "This is a preview of what the texture of the Weapon will look like.";
            new AdvancedPopUpBox(form_title, input_1_name, input_1_desc, input_2_desc, input_2_name, input_3_name, input_3_desc, element_type).Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string element_type = "tool";
            string form_title = "New Element - Tool";
            string input_1_name = "Tool Name";
            string input_1_desc = "This will show up as the name of the Tool.";
            string input_2_desc = "Tool Description (Optional)";
            string input_2_name = "This will show up in the description of the Tool.";
            string input_3_desc = "Tool Texture";
            string input_3_name = "This is a preview of what the texture of the Tool will look like.";
            new AdvancedPopUpBox(form_title, input_1_name, input_1_desc, input_2_desc, input_2_name, input_3_name, input_3_desc, element_type).Show();
            this.Close();
        }
    }
}

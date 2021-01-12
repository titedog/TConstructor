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
    public partial class AdvancedPopUpBox : Form
    {
        //vars
        bool isImageLoaded;

        public AdvancedPopUpBox(string form_title, string input_1_name, string input_1_desc, string input_2_name, string input_2_desc, string input_3_name, string input_3_desc, string element_type)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
            label1.Text = form_title;
            label2.Text = input_1_name;
            label3.Text = input_1_desc;
            label4.Text = input_2_desc;
            label5.Text = input_2_name;
            label6.Text = input_3_name;
            label7.Text = input_3_desc;
            l1.Text = element_type; //l1 is a hidden label that stores the element type
            isImageLoaded = false; //on init this will be the variable that determines if the image display is empty or not
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

        private void AdvancedPopUpBox_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*png)|*.png";
            openFile.InitialDirectory = "C:";
            openFile.Title = "Open a File";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image_display_1.Image = new Bitmap(openFile.FileName);
                isImageLoaded = true;
            }
        }

        private void image_display_1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*png)|*.png";
            openFile.InitialDirectory = "C:";
            openFile.Title = "Open a File";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image_display_1.Image = new Bitmap(openFile.FileName);
                isImageLoaded = true;
            }
        }

        private void image_display_1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.image_display_1, "Select Element Texture"); //hover tooltip
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox3, "Select Element Texture"); //hover tooltip
        }

        private void addbox_Click(object sender, EventArgs e)
        {
            if(l1.Text == "weapon")
            {
                CreateWeapon();
            }
            else if (l1.Text == "tool")
            {
                CreateTool();
            }
        }

        public void CreateWeapon()
        {
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    if(isImageLoaded == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("You don't have an image for your " + l1.Text + "!", "Warning!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please do not leave empty fields!", "Warning!", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please do not leave empty fields!", "Warning!", MessageBoxButtons.OK);
            }
        }

        public void CreateTool()
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    if (isImageLoaded == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("You don't have an image for your " + l1.Text + "!", "Warning!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please do not leave empty fields!", "Warning!", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please do not leave empty fields!", "Warning!", MessageBoxButtons.OK);
            }
        }
    }
}

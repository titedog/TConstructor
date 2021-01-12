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
    public partial class WorkspaceManager : Form
    {
 

        public WorkspaceManager(string selectedItem)
        {
            InitializeComponent();
            workspace_label.Text = selectedItem;
        }

        protected override void WndProc(ref Message m) //allows the form to be moved
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        private void WorkspaceManager_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void addbox_Click(object sender, EventArgs e)
        {
            string title = "Create Element";
            string title1 = "Create a new mod Element";
            string desc1 = "Choose one of the options below to create a new element.";
            string chooseType = "mod_element";
            string wdesc2 = "A weapon that deals damage.";
            string wlabel = "Weapon Element";
            string tdesc = "A tool like a pickaxe or axe.";
            string tlabel = "Tool Element";
            new PopUpChooserBox(title, title1, desc1, chooseType, wdesc2, wlabel, tdesc, tlabel).Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string dir = @"C:\TConstructorWorkspaces\" + workspace_label.Text;
            // If directory does not exist, create it
            if (Directory.Exists(dir))
            {
                Process.Start(dir); //open workspace folder
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox3, "Open the Workspace directory"); //hover tooltip
        }

        private void addbox_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.addbox, "Add a new mod element"); //hover tooltip
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

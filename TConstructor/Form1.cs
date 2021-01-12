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
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;
using DiscordRPC;

namespace TConstructor
{
    public partial class Form1 : Form
    {
        //vars
        bool action;

        protected override void WndProc(ref Message m) //No idea how it works, but it allows a form with no formstyle to be moved
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        public Form1()
        {
            InitializeComponent(); //init form
        }

        private void Form1_Load(object sender, EventArgs e) //init form load
        {
            string dir = @"C:\TConstructorWorkspaces"; //directory for tconstructor workspaces
            // If directory does not exist, create it
            if (!Directory.Exists(dir)) //check if the directory exists-
            {
                Directory.CreateDirectory(dir); //-and if it doesn't then this code will create the directory
            }

            // [DEPRECATED FEATURE - properties.txt]
            // [REASON] Settings have been moved to the Properties file using the .NET framework instead of a txt file.
            //
            //if (!File.Exists(dir + @"\properties.txt")) //second check, checks if properties.txt exists
            //{
            //   //File.Create(@"C:\TConstructorWorkspaces\properties.txt"); //creates .txt file properties.txt - Don't use, because the writer below is what actually creates the file, and this code will cause a break error.
            //
            //    string[] lines ={
            //                "showWarnings=true",
            //                "more settings coming soon"
            //              };
            //
            //   File.WriteAllLines(@"C:\TConstructorWorkspaces\properties.txt", lines); //writer system - writes properties.txt (settings file)
            //}

            if (File.Exists(@"C:\TConstructorWorkspaces\workspaces.txt")) //this is a better check than using the code above which creates properties.txt
            {
                FileInfo fi = new FileInfo(@"C:\TConstructorWorkspaces\workspaces.txt");
                var size = fi.Length;
                if (size >= 1)
                {
                    action = true;
                }
                else
                {
                    action = false;
                }

                System.Threading.Thread.Sleep(100); //wait 1/10 a second between the form loading

                if (action == true)
                {
                    const Int32 BufferSize = 128; //buffer size
                    using (var fileStream = File.OpenRead(@"C:\TConstructorWorkspaces\workspaces.txt")) //use filestream to open properties.txt
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) //use StreamReader to repeat through each line
                    {
                        String line; //the current line being read
                        int indx = 0; //the index of the line being read
                        while ((line = streamReader.ReadLine()) != null) //detects when each line is being read
                        {
                            indx++;
                            listBox1.Items.Add(line); //add each line to the listbox to display all workspaces
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string title = "New Workspace";
            string input1 = "Modification Name";
            string input1desc = "This will show up as the modification name.";
            string input2 = "Author";
            string input2desc = "This will show up as the author of the modification.";
            string trigger = "new_mod";
            this.Hide();
            new PopUpBox(title, input1, input1desc, input2, input2desc, trigger).Show(); //this shows the PopUpBox for creating a new workspace
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); //this code is for the x button to close the entire application, including other open forms
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string dir = @"C:\TConstructorWorkspaces";
            // If directory does not exist, create it
            if (Directory.Exists(dir))
            {
                Process.Start(dir); //open workspace folder
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox3, "Open the Workspace Folder"); //hover tooltip
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox1, "Create a new Workspace"); //hover tooltip
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox4, "Delete the selected Workspace."); //hover tooltip
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem.ToString(); //selectedItem in listbox
            if(Directory.Exists(@"C:\TConstructorWorkspaces\" + selectedItem)) //check to make sure nobody has edited properties.txt
            {
                new WorkspaceManager(selectedItem).Show(); //open workspace
                this.Hide(); //hide Form1
            }
            else
            {
                string title = "Error!";
                string msg = @"Workspace """ + selectedItem + @""" does not exist!"; //warning message
                new NotificationBox(title, msg).Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }
    }
}

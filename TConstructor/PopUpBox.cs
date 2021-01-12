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
    public partial class PopUpBox : Form
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

        public PopUpBox(string title, string input1, string input1desc, string input2, string input2desc, string trigger)
        {
            InitializeComponent();
            label1.Text = title;
            label2.Text = input1;
            label3.Text = input1desc;
            label5.Text = input2;
            label4.Text = input2desc;
            
            if(trigger == "new_mod")
            {
                addbox.Visible = true;
            }
            else
            {
                addbox.Visible = false;
            }
        }

        private void PopUpBox_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addbox_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    string dir = @"C:\TConstructorWorkspaces";
                    // If directory does not exist, create it
                    if (Directory.Exists(dir))
                    {
                        string dir2 = @"C:\TConstructorWorkspaces\" + textBox1.Text;
                        // If directory does not exist, create it
                        if (!Directory.Exists(dir2))
                        {
                            Directory.CreateDirectory(dir2);
                            string displayText = "displayName = " + textBox1.Text;
                            string authorText = "author = " + textBox2.Text;
                            string[] line ={
                            displayText,
                            authorText,
                            "version = 0.1"
                          };

                            File.WriteAllLines(@"C:\TConstructorWorkspaces\" + textBox1.Text + @"\build.txt", line);

                            string dirText = textBox1.Text + " is a pretty cool mod, it does...this. Modify this file with a description of your mod. Made with TConstructor";
                            string[] line2 ={
                            dirText
                          };

                            File.WriteAllLines(@"C:\TConstructorWorkspaces\" + textBox1.Text + @"\description.txt", line2);


                            string asName = "    <AssemblyName>" + textBox1.Text + "</AssemblyName>";
                            string[] line3 ={
                            @"<?xml version=""1.0"" encoding=""utf-8""?>",
                            @"<Project Sdk=""Microsoft.NET.Sdk"">",
                            @"  <Import Project=""..\..\references\tModLoader.targets"" />",
                            @"  <PropertyGroup>",
                            asName,
                            @"    <TargetFramework>net45</TargetFramework>",
                            @"    <PlatformTarget>x86</PlatformTarget>",
                            @"    <LangVersion>7.3</LangVersion>",
                            @"  </PropertyGroup>",
                            @"  <Target Name=""BuildMod"" AfterTargets=""Build"">",
                            @"   <Exec Command=""&quot;$(tMLBuildServerPath) & quot; -build $(ProjectDir) - eac $(TargetPath) - define & quot;$(DefineConstants) & quot; -unsafe $(AllowUnsafeBlocks)"" />",
                            @"  </Target>",
                            @"  <ItemGroup>",
                            @"    <PackageReference Include=""tModLoader.CodeAssist"" Version=""0.1.*"" />",
                            @"  </ItemGroup>",
                            @"</Project>"
                          };

                            File.WriteAllLines(@"C:\TConstructorWorkspaces\" + textBox1.Text + @"\" + textBox1.Text + @".csproj", line3);

                            string np = "namespace " + textBox1.Text;
                            string[] line4 ={
                            "using Terraria.ModLoader;",
                            " ",
                            np,
                            "{",
                            "	public class " + textBox1.Text + " : Mod",
                            "	{",
                            "	}",
                            "}"

                          };

                            File.WriteAllLines(@"C:\TConstructorWorkspaces\" + textBox1.Text + @"\" + textBox1.Text + @".cs", line4);

                            string wn = textBox1.Text;
                            //File.AppendAllText(@"C:\TConstructorWorkspaces\properties.txt", wn); -old method that doesn't work, but i wanted to archive this
                            File.AppendAllText(@"C:\TConstructorWorkspaces\workspaces.txt", wn + Environment.NewLine); //this works fine. it appends to properties.txt

                            string n = textBox1.Text;
                            string[] line5 ={
                            n

                          };

                            File.WriteAllLines(@"C:\TConstructorWorkspaces\" + textBox1.Text + @"\" + @"tconstructor_properties.txt", line5);

                            string selectedItem = textBox1.Text;
                            new WorkspaceManager(selectedItem).Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please do not attempt to overwrite existing Workspace.", "Warning!", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Directory TConstructorWorkspaces is not found!", "Warning!", MessageBoxButtons.OK);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PlannerPath.GUI
{
    public partial class UploadTreeForm : Form
    {
        public UploadTreeForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);
        }

        //Button to choose the directory of the tree to be upload to DB
        private void uploadButtonClick(object sender, EventArgs e)
        {
            String MessageBoxTitle = "Upload Tree";

            if (txt_tree_directory.Text.Equals("") || !txt_tree_directory.Text.EndsWith(".xml") || !System.IO.File.Exists(txt_tree_directory.Text))
                MessageBox.Show("You must enter correct fields", MessageBoxTitle);
            else
            {
                var Engine = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "engine.exe",
                        Arguments = "upload " + txt_tree_directory.Text,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                // uploaded to DB using Engine
                Engine.Start();

                String Output = "";

                while (!Engine.StandardOutput.EndOfStream)
                {
                    Output = Output + Environment.NewLine + Engine.StandardOutput.ReadLine();
                }
                MessageBox.Show(Output, MessageBoxTitle);
            }
        }

        //Button to choose the directory of the tree
        private void chooseDirectoryClick(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.Filter = "XML files|*.xml";
            fbd.FilterIndex = 0;
            fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = fbd.ShowDialog();

            if(result == DialogResult.OK)
                this.txt_tree_directory.Text = fbd.FileName;
        }

    }
}

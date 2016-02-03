using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectONE.GUI
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
            Engine engine = new Engine();
            if (txt_tree_directory.Text.Equals(""))
                MessageBox.Show("You mast enter correct fields");
            else
                engine.uploadTree(txt_tree_directory.Text);

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

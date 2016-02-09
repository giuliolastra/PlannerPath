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
    public partial class MainPage : Form
    {
        
        public MainPage()
        {
            InitializeComponent();
            if (ConfigurationForm.ConfigFileExists() == false)
            {
                new ConfigurationForm().ShowDialog();
            }

            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);

            try {
                Icon notifyIcon1 = new System.Drawing.Icon(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)
                   + @"\icon.ico");
            }
            catch(System.IO.FileNotFoundException e)
            {
                Console.WriteLine("Icona non esistente " + e);
            }
        }

        //Button to open CreateTreeForm
        private void button1_Click(object sender, EventArgs e)
        {
            CreateTreeForm f = new CreateTreeForm();
            f.Visible = true;
            f.Activate();
        }

        //Button to open UploadTreeForm
        private void button2_Click(object sender, EventArgs e)
        {
            UploadTreeForm f = new UploadTreeForm();
            f.Visible = true;
            f.Activate();
        }

        //Button to open CalculusForm
        private void button3_Click(object sender, EventArgs e)
        {
            CalculusManagerForm f = new CalculusManagerForm();
            f.Visible = true;
            f.Activate();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}

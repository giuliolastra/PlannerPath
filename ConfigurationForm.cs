using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectONE.GUI
{
    public partial class ConfigurationForm : Form
    {
        private bool alreadyCalled; // true if save() already called from save() itself

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If configuration file already exists, returns username
        /// </summary>
        /// <returns>username if config file exists, null otherwise</returns>
        public static string GetUsername()
        {
            if (ConfigurationForm.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt");
            return lines[0].Replace("USERNAME: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns password
        /// </summary>
        /// <returns>password if config file exists, null otherwise</returns>
        public static string GetPassword()
        {
            if (ConfigurationForm.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt");
            return lines[1].Replace("PASSWORD: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns db name
        /// </summary>
        /// <returns>db name if config file exists, null otherwise</returns>
        public static string GetDBName()
        {
            if (ConfigurationForm.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt");
            return lines[2].Replace("DBNAME: ", "");
        }

        /// <summary>
        /// If configuration file already exists, returns server
        /// </summary>
        /// <returns>server if config file exists, null otherwise</returns>
        public static string GetServer()
        {
            if (ConfigurationForm.ConfigFileExists() == false)
                return null;

            string[] lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt");
            return lines[3].Replace("SERVER: ", "");
        }

        /// <summary>
        /// Returns true if configuration file already exists
        /// </summary>
        /// <returns></returns>
        public static bool ConfigFileExists()
        {
            return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt");
        }

        /// <summary>
        /// Save the following peaces of information: username, password, db name and server
        /// in a text file
        /// </summary>
        /// <returns>true if saving succeded</returns>
        private bool save(bool overwrite)
        {
            if (!overwrite && File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt"))
            {
                MessageBox.Show("Configuration file already exists");
                return false;
            }
            else
            {
                File.Delete((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt"));
            }

            string username = this.txt_username.Text;
            string password = this.txt_password.Text;
            string dbname = this.txt_dbname.Text;
            string server = this.txt_server.Text;

            try {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\config.txt"))
                {
                    file.WriteLine("USERNAME: " + username);
                    file.WriteLine("PASSWORD: " + password);
                    file.WriteLine("DBNAME: " + dbname);
                    file.WriteLine("SERVER: " + server);
                }
            }
            catch(System.IO.IOException e)
            {
                //We protect ourselves from infinite calls to save()
                if (!alreadyCalled)
                {
                    alreadyCalled = true;
                    //Try by deleting configuration file
                    return this.save(true);
                }
                else //disk full or infinite calls to save()
                {
                    alreadyCalled = false;
                    return false;
                }
            }

            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (this.txt_dbname.Text.Equals("") || this.txt_password.Text.Equals("") || this.txt_server.Text.Equals("") || this.txt_username.Text.Equals(""))
            {
                MessageBox.Show("Please insert all the required fields!");
                return;
            }

            if (this.save(this.checkbox_overwrite.Checked))
            {
                MessageBox.Show("Information saved");
                this.Close();
            }
            else
                MessageBox.Show("Information NOT saved");

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.txt_dbname.Text = "";
            this.txt_password.Text = "";
            this.txt_username.Text = "";
            this.txt_server.Text = "";
        }
    }
}

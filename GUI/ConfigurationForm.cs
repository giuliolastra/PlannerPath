using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectONE.GUI
{

    public partial class ConfigurationForm : Form
    {

        private bool alreadyCalled; // true if save() already called from save() itself

        public ConfigurationForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.SuspendLayout();
            // 
            // ConfigurationForm
            // 
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration Form";
            this.ResumeLayout(false);
        }


        /// <summary>
        /// Returns true if configuration file already exists
        /// </summary>
        /// <returns></returns>
        public static bool ConfigFileExists()
        {
            return File.Exists(Directory.GetCurrentDirectory() + @"\mssql.conf");
        }

        /// <summary>
        /// Save the following peaces of information: username, password, db name and server
        /// in a text file
        /// </summary>
        /// <returns>true if saving succeded</returns>
        private bool save(bool overwrite)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\mssql.conf"))
            {
                MessageBox.Show("Configuration file already exists");
                return false;
            }
            else
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\mssql.conf");
            }

            string username = this.txt_username.Text;
            string password = this.txt_password.Text;
            string dbname = this.txt_dbname.Text;
            string server = this.txt_server.Text;

            try
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(Directory.GetCurrentDirectory() + @"\mssql.conf"))
                {
                    file.WriteLine("USERNAME: " + username);
                    file.WriteLine("PASSWORD: " + password);
                    file.WriteLine("DBNAME: " + dbname);
                    file.WriteLine("SERVER: " + server);
                }
            }
            catch (System.IO.IOException e)
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

            //If Install DB is checked it installs the DB
            if (overwrite)
            {
                //Connessione to DB
                SqlConnector SqlConn = new SqlConnector();
                SqlConnection MyConnection = new SqlConnection("user id=" + SqlConn.Username + ";" +
                                               "password=" + SqlConn.Password + ";server=" + SqlConn.Server + ";" +
                                               "Trusted_Connection=yes;" +
                                               "database=" + SqlConn.Database + "; " +
                                               "connection timeout=30");
                try
                {
                    MyConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                //Installing the DB
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(this.InstallQuery, MyConnection);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (this.txt_dbname.Text.Equals("") || this.txt_server.Text.Equals("") || this.txt_username.Text.Equals(""))
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

        private String InstallQuery = @"
/* Creazione Tabella Vertex */
create table Vertex 
(   
    VertexUid uniqueidentifier,   
    Name varchar(100),   
    Type varchar(100),   
    Depth int,   
    PreviousEdgeUid uniqueidentifier,   
    CONSTRAINT [Vertex_pk] PRIMARY KEY CLUSTERED
    (   
        [VertexUid] ASC   
    )    
)   

/*creazione tabella Edge*/ 
create table Edge 
(  
    EdgeUid uniqueidentifier,   
    StartVertexUid uniqueidentifier,   
    EndVertexUid uniqueidentifier,   
    CONSTRAINT [Edge_pk] PRIMARY KEY CLUSTERED    
    (   
        [EdgeUid] ASC   
    )   
)   
   
/* Creazione Tabella AttrDef */   
create table AttrDef 
(   
    AttrDefUid uniqueidentifier,   
    Name varchar(50),   
    CONSTRAINT [AttrDef_pk] PRIMARY KEY CLUSTERED    
    (   
        [AttrDefUid] ASC   
    )   
)   
   
/*creazione tabella AttrUsage*/  
create table AttrUsage   
(   
    AttrUsageUid uniqueidentifier,   
    ObjectUid uniqueidentifier,   
    AttrDefUid uniqueidentifier ,  
    AttrValue varchar(1000),   
    CONSTRAINT [AttrUsage _pk] PRIMARY KEY CLUSTERED    
    (   
        [AttrUsageUid] ASC,   
        [ObjectUid] ASC   
    )
)   


/* Altering Tables  adding UIDs */

alter table Edge add  default (newsequentialid()) FOR EdgeUid   
   
alter table AttrDef add  default (newsequentialid()) FOR AttrDefUid   
   
alter table AttrUsage add  default (newsequentialid()) FOR AttrUsageUid   

/* Altering Tables adding Foreign Keys */

ALTER TABLE Edge  WITH CHECK ADD  CONSTRAINT [EndVertex_to_Edge] FOREIGN KEY([EndVertexUid])   
REFERENCES [Vertex] ([VertexUid])   
   
ALTER TABLE Edge  WITH CHECK ADD  CONSTRAINT [StartVertex_to_Edge] FOREIGN KEY([StartVertexUid])   
REFERENCES [Vertex] ([VertexUid])   

alter table Vertex add  default (newsequentialid()) FOR VertexUid 
ALTER TABLE Vertex  WITH CHECK ADD  CONSTRAINT [PreviousEdge_to_Vertex] FOREIGN KEY([PreviousEdgeUid])   
REFERENCES [Edge] ([EdgeUid])   

ALTER TABLE Vertex  WITH CHECK ADD  CONSTRAINT [Vertex_to_PreviousEdge] FOREIGN KEY([PreviousEdgeUid])   
REFERENCES [Edge] ([EdgeUid])            
        ";
    }
}

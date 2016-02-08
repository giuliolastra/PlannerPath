using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    class ResetSQL
    {
        SqlConnection MyConnection;
        public ResetSQL()
        {
            //Connessione to DB
            this.MyConnection = new SqlConnection("user id=Administrator;" +
                                          "password=password;server=(localdb)\\MSSQLLocalDB;" +
                                          "Trusted_Connection=yes;" +
                                          "database=master; " +
                                          "connection timeout=30");
            try
            {
                this.MyConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Vertex", this.MyConnection);
                myReader = myCommand.ExecuteReader();
                Console.WriteLine();
                while (myReader.Read())
                {   
                    Console.Write(myReader["Name"].ToString() + " ");
                }

                    myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Reset completato!");
        }
    }
}

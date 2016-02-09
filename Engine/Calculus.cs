using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    class Calculus
    {
        SqlConnection MyConnection;

        public Calculus()
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
                Console.WriteLine("Impossibile aprire la connessione: "+e.ToString());
            }
            Console.WriteLine("Connection State: " + this.MyConnection.ToString());
            Console.WriteLine("State: " + this.MyConnection.State.ToString());
        }

        public String PathCalculus(String type, String vertexA, String vertexB)
        {
            int depthA = 0;
            int depthB = 0;
            String VertexUIDA = "";
            String VertexUIDB = "";
           

            //Blocco try catch per vedere la depth del vertexA
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT VertexUid, Depth FROM Vertex WHERE Type = '"+type+"' AND Name = '"+vertexA+"';", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                   int.TryParse(myReader["Depth"].ToString(), out depthA);

                    //myReader analizza la query e la ridà sporca, allora si fa il cast con toString().
                    //Ridà quindi VertexUid come stringa

                    VertexUIDA = myReader["VertexUid"].ToString();
                    Console.WriteLine(vertexA + ": " + VertexUIDA);
                    break;
                }

                myCommand = null;
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore su Vertex A: "+e.ToString());
            }

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT VertexUid, Depth FROM Vertex WHERE Type = '" + type + "' AND Name = '" + vertexB + "';", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int.TryParse(myReader["Depth"].ToString(), out depthB);

                    //myReader analizza la query e la ridà sporca, allora si fa il cast con toString().
                    //Ridà quindi VertexUid come stringa

                    VertexUIDB = myReader["VertexUid"].ToString();
                    Console.WriteLine(vertexB + ": " + VertexUIDB);
                    break;
                }

                myCommand = null;
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore su Vertex B: "+e.ToString());
            }

            // Inizializzo vertex UID e ci assegno il vertice che si trova più in profondità
            String VertexUID = "";
            String VertexName = "";
                        
            if (depthA > depthB)
            {
                VertexUID = VertexUIDA;
                VertexName = vertexA;
            }
            else
            {
                VertexUID = VertexUIDB;
                VertexName = vertexB;
            }
            
            Console.WriteLine("*** VertexUID: " + VertexUID);

            String EdgeUID = getEdgeUIDFromVertex(VertexUID);
            // Conto gli attributi per inizializzare ResultCollector
            int AttributeNumber = getAttributeSize(VertexUID) + getAttributeSize(EdgeUID);
            
            //ResultCollector result = new ResultCollector(AttributeNumber);
            ResultCollector result = new ResultCollector(AttributeNumber+1);

            //Adding first vertex to VertexNameList
            result.addVertexName(VertexName);
            

            //Qui inizia l'iterazione per poter sommare tutti gli attributi.
            int depthDiff = Math.Abs(depthA - depthB);

            for (int i = 0; i < depthDiff; ++i) 
            {

                String AttrName = "";
                int AttrValue = 0;
                
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT AD.AttrDefUid, AD.Name, AU.AttrValue FROM AttrDef AD, AttrUsage AU WHERE AU.ObjectUid = '" + VertexUID + "' AND AU.AttrDefUid = AD.AttrDefUid; ", this.MyConnection);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        int.TryParse(myReader["AttrValue"].ToString(), out AttrValue);
                        //myReader analizza la query e la ridà sporca, allora si fa il cast con toString().
                        //Ridà quindi VertexUid come stringa

                        AttrName = myReader["Name"].ToString();
                        //Console.WriteLine(vertexUID);
                        if (i == 0)
                        {
                            result.addNewAttribute(AttrName, AttrValue);
                        }
                        else
                        {
                            result.addAttribute(AttrName, AttrValue);

                        }
                    }

                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                
                EdgeUID = getEdgeUIDFromVertex(VertexUID);

                //if (i < depthDiff - 1)
                //{
                    try
                    {
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand("SELECT AD.AttrDefUid, AD.Name, AU.AttrValue FROM AttrDef AD, AttrUsage AU WHERE AU.ObjectUid = '" + EdgeUID + "' AND AU.AttrDefUid = AD.AttrDefUid; ", this.MyConnection);
                        myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            int.TryParse(myReader["AttrValue"].ToString(), out AttrValue);
                            //myReader analizza la query e la ridà sporca, allora si fa il cast con toString().
                            //Ridà quindi VertexUid come stringa

                            AttrName = myReader["Name"].ToString();
                        //Console.WriteLine(vertexUID);
                        if (i == 0)
                        {
                            result.addNewAttribute(AttrName, AttrValue);
                        }
                        else result.addAttribute(AttrName, AttrValue);
                        }

                        myReader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    

                //}

                VertexUID = getVertexUIDFromEdge(EdgeUID);
                VertexName = getVertexName(VertexUID);
                result.addVertexName(VertexName);
            }

            return result.toString();
        }

        private String getEdgeUIDFromVertex(String VertexUID)
        {
            String EdgeUID  = "";
            // Vedere l'edge collegato
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Vertex WHERE VertexUid = '" + VertexUID + "'", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    EdgeUID = myReader["PreviousEdgeUid"].ToString();
                    break;
                }
                
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore EdgeUID From Vertex: "+e.ToString());
            }
            Console.WriteLine("getEdgeUIDFromVertex() -> VertexUID: " + VertexUID + " - EdgeUID: " + EdgeUID);
            return EdgeUID;

        }
        private String getVertexUIDFromEdge(String EdgeUID)
        {
            String VertexUID = "";
            // Vedere l'edge collegato
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Edge WHERE EdgeUid = '" + EdgeUID + "'", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    VertexUID = myReader["StartVertexUid"].ToString();
                    break;
                }

                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("getVertexUIDFromEdge() -> EdgeUID: " + EdgeUID + " - VertexUID: " + VertexUID);
            return VertexUID;

        }
        private String getVertexName(String VertexUID)
        {
            String VertexName = "";
            // Vedere l'edge collegato
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT Name FROM Vertex WHERE VertexUid = convert(uniqueidentifier, '" + VertexUID + "') ", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    VertexName = myReader["Name"].ToString();
                    break;
                }

                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("getVertexName() -> "+VertexName);
            return VertexName;

        }
        private int getAttributeSize(String UID)
        {
            Console.WriteLine("getAttributeSize() -> UID: "+UID);
            int AttributeNumber = 0;

            // Vedere l'attributo di un vertex
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT COUNT(distinct AU.AttrValue) AS AttrNumber FROM AttrDef AD, AttrUsage AU WHERE AU.ObjectUid = '" + UID + "' AND AU.AttrDefUid = AD.AttrDefUid; ", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int.TryParse(myReader["AttrNumber"].ToString(), out AttributeNumber);
                }

                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return AttributeNumber;
        }
    }
}

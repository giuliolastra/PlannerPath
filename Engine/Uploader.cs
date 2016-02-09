using System;
using System.Data.SqlClient;
using System.Xml;

public class Uploader
{
    String TreeFile;
    Attr[] Attributes;
    String Type;
    String SplitSize;
    String Depth;
    SqlConnection MyConnection;

    public Uploader()
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
		catch(Exception e)
		{
		    Console.WriteLine(e.ToString());
		}
        //Console.WriteLine("Connection State: " + this.MyConnection.ToString());
        //Console.WriteLine("State: " + this.MyConnection.State.ToString());
    }

    public void SaveToDB(String treeFile) {

    	//Aggiungo il path del file al parametri della classe.
    	this.TreeFile = treeFile;        

        //Console.WriteLine("Tree File: " + treeFile);
        //Inizializzo l'oggetto xmlTree che contiene tutto il file.
        XmlDocument xmlTree = new XmlDocument();

        //Carico il file albero.
        xmlTree.Load(treeFile);

        //Depth per il nodo
        int depth = 0;

        //Apro il nodo "Informations" e ne estrapolo le info (Type, SplitSize e Depth).
        XmlNode InfoNode = xmlTree.DocumentElement.SelectSingleNode("Informations");
        this.Type = InfoNode.SelectSingleNode("Type").InnerText;
        this.SplitSize = InfoNode.SelectSingleNode("SplitSize").InnerText;
        this.Depth = InfoNode.SelectSingleNode("Depth").InnerText;

        // Stampa di Debug
        //Console.WriteLine("Type: " + this.Type);
        //Console.WriteLine("SplitSize: " + this.SplitSize);
        //Console.WriteLine("Depth: " + this.Depth);

        // Genero l'array con gli Attributi.
        XmlNodeList AttrList = InfoNode.SelectSingleNode("Attributes").SelectNodes("Attribute");
        this.Attributes = new Attr[AttrList.Count];

        //Popolo l'array e faccio query per inserimento in AttrDef
        for (int j = 0; j < AttrList.Count; j++) {

            this.Attributes[j] = new Attr(AttrList.Item(j).SelectSingleNode("Type").InnerText, AttrList.Item(j).SelectSingleNode("Name").InnerText);
            String AttrDefUID = "";

            //Inserisco nel DB gli attributi
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("INSERT INTO AttrDef OUTPUT Inserted.AttrDefUid VALUES (newid(), '" + Attributes[j].Name+"');", this.MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AttrDefUID = myReader["AttrDefUid"].ToString();

                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            this.Attributes[j].AttributeUID = AttrDefUID;
            
        }
        
        // Ottengo il Vertice Root.
        XmlNode RootVertex = xmlTree.DocumentElement.SelectSingleNode("Vertex");
     
        //Vertex Name
        String VertexName = RootVertex.SelectSingleNode("Name").InnerText;

        String vertexUID = "";

        try
		{
		    SqlDataReader myReader = null;
		    SqlCommand    myCommand = new SqlCommand("INSERT INTO Vertex (VertexUid, Name, Type, Depth) OUTPUT Inserted.VertexUid VALUES (newid(), '"+VertexName+"', '"+this.Type+"', "+depth+");", 
		                                             this.MyConnection);
		    myReader = myCommand.ExecuteReader();

		    while(myReader.Read())
		    {
		        vertexUID = myReader["VertexUid"].ToString();
		        Console.WriteLine("-> " + VertexName + ": " + vertexUID);
                
		    }

		    myReader.Close();
		}
		catch (Exception e)
		{
		    Console.WriteLine(e.ToString());
		}

        XmlNode AttributesNode = RootVertex.SelectSingleNode("Attributes");

        //Adding Vertex Attributes to DB
        for (int i = 0; i < Attributes.Length; i++) {

            XmlNode SingleAttr = AttributesNode.SelectSingleNode(Attributes[i].Name);
            
            if(SingleAttr != null)
            {
                Console.WriteLine(i + ". " + Attributes[i].Name + "(" + Attributes[i].Type + ") : " + SingleAttr);
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("INSERT INTO AttrUsage VALUES (newid(), '"+ vertexUID + "', '" + Attributes[i].AttributeUID + "', '" + SingleAttr.InnerText + "')", this.MyConnection);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            else
            {
                Console.WriteLine("Null found");
            }
        }

        this.SaveToDB(vertexUID, RootVertex, depth + 1);

    }
    
    private void SaveToDB(String RootUid, XmlNode RootVertex, int depth) {

    	// inizio ricorsione
        int intSplitSize = 0;
        int.TryParse(this.SplitSize, out intSplitSize);

        for (int i = 0; i < intSplitSize; i++)
        {
            //Questo trova l'edge al livello attuale
            XmlNode EdgeNode = RootVertex.SelectSingleNode("Edge[" + (i + 1) + "]");

            if (EdgeNode != null)
            {

                ////Console.WriteLine(EdgeNode.SelectSingleNode("Name").InnerText);

                String EdgeUID = "";
                //Inserting Edge
                try
                {
                    SqlDataReader myReader = null;
                    //Inserting Edge into Edge Table
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Edge (EdgeUid, StartVertexUid) OUTPUT Inserted.EdgeUid VALUES (newid(), '" + RootUid + "');", this.MyConnection);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        // Returning EdgeUid with trigger
                        EdgeUID = myReader["EdgeUid"].ToString();
                        //Console.WriteLine(EdgeNode.SelectSingleNode("Name").InnerText+" -- " + EdgeUID);
                        
                    }
                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                XmlNode AttributesNode = EdgeNode.SelectSingleNode("Attributes");

                //Adding Edge Attributes to DB
                for (int j = 0; j < Attributes.Length; j++)
                {

                    XmlNode SingleAttr = AttributesNode.SelectSingleNode(Attributes[j].Name);
                    if (SingleAttr != null)
                    {
                        try
                        {
                            SqlDataReader myReader = null;
                            SqlCommand myCommand = new SqlCommand("INSERT INTO AttrUsage VALUES (newid(), '" + EdgeUID + "', '" + Attributes[j].AttributeUID + "', '" + SingleAttr.InnerText + "')", this.MyConnection);
                            myReader = myCommand.ExecuteReader();

                            myReader.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                    }
                }

                //Analizzo il Vertice collegato all'Edge appena inserito e lo inserisco nel DB
                XmlNode SubVertex = EdgeNode.SelectSingleNode("Vertex");
                ////Console.WriteLine("\t" + SubVertex.SelectSingleNode("Name").InnerText);

                String VertexName = SubVertex.SelectSingleNode("Name").InnerText;
                String VertexUid = "";

                try
                {
                    SqlDataReader myReader = null;
                    //Insert Vertex into Vertex table
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Vertex OUTPUT Inserted.VertexUid VALUES (newid(), '" + VertexName + "', '" + this.Type + "', " + depth + ", '" + EdgeUID + "') ; ", this.MyConnection);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        VertexUid = myReader["VertexUid"].ToString();
                        Console.WriteLine("-> " + VertexName + ": " + VertexUid);
                        
                    }
                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                // Aggiorno la tabella edge collegandoci il vertice appena inserito.
                try
                {
                    //UPDATE Edge WHERE EdgeUid = C#VALUE SET EndVertexUid = EndVertexUid passato da c# WHERE  EdgeUid = PreviousEdgeUid passato da c#; 
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("UPDATE Edge SET EndVertexUid = '" + VertexUid + "' WHERE  EdgeUid = '" + EdgeUID + "';", this.MyConnection);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                AttributesNode = SubVertex.SelectSingleNode("Attributes");

                //Adding Vertex Attributes to DB
                for (int j = 0; j < Attributes.Length; j++)
                {

                    XmlNode SingleAttr = AttributesNode.SelectSingleNode(Attributes[j].Name);
                    if (SingleAttr != null)
                    {
                        try
                        {
                            SqlDataReader myReader = null;
                            SqlCommand myCommand = new SqlCommand("INSERT INTO AttrUsage VALUES (newid(), '" + VertexUid + "', '" + Attributes[j].AttributeUID + "', '" + SingleAttr.InnerText + "')", this.MyConnection);
                            myReader = myCommand.ExecuteReader();

                            myReader.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                    }
                }

                this.SaveToDB(VertexUid, SubVertex, depth + 1);
            }


        }
        Console.WriteLine("*** FINE CICLO FOR. SPLIT SIZE: " + intSplitSize + " ***");
    }
}

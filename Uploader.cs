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

    public bool SaveToDB(String treeFile) {

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

        //Popolo l'array
        for (int j = 0; j < AttrList.Count; j++) {

            this.Attributes[j] = new Attr(AttrList.Item(j).SelectSingleNode("Type").InnerText, AttrList.Item(j).SelectSingleNode("Name").InnerText);
            ////Console.WriteLine("Attributo " + j+": "+Attributes[j].Name + " - "+ Attributes[j].Type);
        
        }
        
        // Ottengo il Vertice Root.
        XmlNode RootVertex = xmlTree.DocumentElement.SelectSingleNode("Vertex");
     

        //Query <-- //INSERT INTO Vertex VALUES (newid(), 'pippo', 'pluto', 2, PreviousEdgeUid passato da c#);
        String tempName = RootVertex.SelectSingleNode("Name").InnerText;


        //Stampa di Debug
        //Console.WriteLine(tempName);

        String vertexUID = "";

        try
		{
		    SqlDataReader myReader = null;
		    SqlCommand    myCommand = new SqlCommand("INSERT INTO Vertex (VertexUid, Name, Type, Depth) VALUES (newid(), '"+tempName+"', '"+this.Type+"', "+depth+");", 
		                                             this.MyConnection);
		    myReader = myCommand.ExecuteReader();

		    while(myReader.Read())
		    {
		        vertexUID = myReader["vertexUid"].ToString();
		        //Console.WriteLine(vertexUID);
		    }

		    myReader.Close();
		}
		catch (Exception e)
		{
		    Console.WriteLine(e.ToString());
		}
        return SaveToDB(vertexUID,RootVertex,depth+1);
        
    }
    
    private bool SaveToDB(String RootUid, XmlNode RootVertex, int depth) {

    	// inizio ricorsione
    	bool ok = false;

        for (int i = 0; i < int.Parse(this.SplitSize); i++)
        {
            //Questo trova l'edge al livello attuale
            XmlNode EdgeNode = RootVertex.SelectSingleNode("Edge[" + (i + 1) + "]");
            
            if(EdgeNode != null) {
	            
	            ////Console.WriteLine(EdgeNode.SelectSingleNode("Name").InnerText);

	  	        String EdgeUID = "";

	            //Inserting Edge
				try
				{
				    SqlDataReader myReader = null;
				    //INSERT INTO Edge (EdgeUid, StartVertexUid)  VALUES (newid(), StartVertexUid passato da c#); 
				    SqlCommand myCommand = new SqlCommand("INSERT INTO Edge (EdgeUid, StartVertexUid)  VALUES (newid(), '"+RootUid+"');", this.MyConnection);
				    myReader = myCommand.ExecuteReader();

				    while(myReader.Read())
				    {
				        EdgeUID = myReader["EdgeUid"].ToString();
				        //Console.WriteLine(EdgeUID);
				    }
				    myReader.Close();
				}
				catch (Exception e)
				{
				    Console.WriteLine(e.ToString());
				}

				//Analizzo il Vertice collegato all'Edge appena inserito e lo inserisco nel DB

				XmlNode SubVertex = EdgeNode.SelectSingleNode("Vertex");
	            ////Console.WriteLine("\t" + SubVertex.SelectSingleNode("Name").InnerText);

	            String tempName = RootVertex.SelectSingleNode("Name").InnerText;
				String VertexUid = "";
				
				try
				{
				    SqlDataReader myReader = null;
				    //INSERT INTO Vertex VALUES (newid(), 'pippo', 'pluto', 2, PreviousEdgeUid passato da c#); 
				    SqlCommand myCommand = new SqlCommand("INSERT INTO Vertex VALUES (newid(), '"+tempName+"', '"+this.Type+"', "+depth+", '"+EdgeUID+"'); ", this.MyConnection);
				    myReader = myCommand.ExecuteReader();

				    while(myReader.Read())
				    {
				        VertexUid = myReader["VertexUid"].ToString();
				        //Console.WriteLine(VertexUid);
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
					SqlCommand myCommand = new SqlCommand("UPDATE Edge SET EndVertexUid = '"+VertexUid+" WHERE  EdgeUid = '"+EdgeUID+"';", this.MyConnection);

				}
				catch (Exception e)
				{
				    Console.WriteLine(e.ToString());
				}

	            ok = this.SaveToDB(VertexUid,SubVertex,depth+1);
        	} else {
        		return ok;
        	}
        }
        return true;
    }
}

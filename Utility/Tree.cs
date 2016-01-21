using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectONE.Utility
{
    /*
     * Represents a tree, with SplitSize child-Vertexs and Depth levels.
     * This tree is complete and each Vertex and edge have some well defined attributes.
     * This tree can be either auto-generated or build manually from scratch.
     */

    class Tree {

        public Vertex root { get; set; }
        public String type { get; set; } //Name of the tree
        int SplitSize { get; set; }
        int Depth { get; set; }
        LinkedList<Attribute> VertexAttributes { get; set; } //list of attributes that Vertexs have
        LinkedList<Attribute> EdgeAttributes { get; set; } //list of attributes that Vertexs have
        XmlTextWriter fileWriter;
        String XMLPath;

        public String getXMLPath() {
            Console.WriteLine(this.XMLPath);
            return this.XMLPath;
        }

        public Tree(int splitSize, int depth) {
            this.SplitSize = splitSize;
            this.Depth = depth;
            this.VertexAttributes = null;
            this.EdgeAttributes = null;
        }

        public Tree(int depth, int splitSize, LinkedList<Attribute> vertexAttributes, LinkedList<Attribute> edgeAttributes) {
            this.SplitSize = splitSize;
            this.Depth = depth;
            this.VertexAttributes = vertexAttributes;
            this.EdgeAttributes = edgeAttributes;
        }

        public Tree(int depth, int splitSize, LinkedList<Attribute> vertexAttributes, LinkedList<Attribute> edgeAttributes,Vertex v) {
            this.SplitSize = splitSize;
            this.Depth = depth;
            this.VertexAttributes = vertexAttributes;
            this.EdgeAttributes = edgeAttributes;
            this.root = v;
            
        }

        public Tree(int Depth, int SplitSize, LinkedList<Attribute> VertexAttributes, LinkedList<Attribute> EdgeAttributes, bool random) { 

            this.Depth = Depth;
            this.SplitSize = SplitSize;
            this.VertexAttributes = VertexAttributes;
            this.EdgeAttributes = EdgeAttributes;
            if(random) {
                this.root = new Vertex(GetRandomAttributes(true, VertexAttributes, EdgeAttributes).ToArray());
                this.randomGenerateTree();
            }
        }

        public Tree(int D,int S,LinkedList<Attribute> VA,LinkedList<Attribute> EA,String t,Vertex cV, XmlTextWriter fW) {

            this.Depth = D;
            this.SplitSize = S;
            this.VertexAttributes = VA;
            this.EdgeAttributes = EA;
            this.type = t;
            this.root = cV;
            this.fileWriter = fW;

        }


        public void randomGenerateTree() {

            for (int j = 0; j < this.SplitSize && this.Depth > 0; j++) {
                    
                Vertex childVertex = new Vertex(GetRandomAttributes(true, VertexAttributes, EdgeAttributes).ToArray(), new LinkedList<Edge>(), root.Depth+1);
                this.root.append(new Edge(this.root, childVertex, GetRandomAttributes(false, VertexAttributes, EdgeAttributes)));
                    Tree subTree = new Tree(this.Depth-1,this.SplitSize,this.VertexAttributes,this.EdgeAttributes,childVertex);
                    subTree.randomGenerateTree();
                    //Console.WriteLine(j+". Depth: "+this.Depth+" - SplitSize: "+this.SplitSize);
            }

        }


        public bool ToFile(String path) {

            String fileName = this.type;

            //Write general information
            if (!System.IO.Directory.Exists(path))
                return false;


            if (fileName.EndsWith(".xml") == false)
                fileName += ".xml";

            String completepath = "";

            if (path.EndsWith("/") == false && path.EndsWith("\\") == false)
            {
                completepath = path + "\\" + fileName;
                this.XMLPath = completepath;
                Console.WriteLine("Sono in tree ed il path e':"+this.XMLPath);
            }
            else {
                completepath = path + fileName;
                this.XMLPath = completepath;
                Console.WriteLine("Sono in tree ed il path e':"+this.XMLPath);
            }

            this.XMLPath = completepath;

            this.fileWriter = new XmlTextWriter(completepath, Encoding.ASCII);
            this.fileWriter.Formatting = Formatting.Indented;
            this.fileWriter.Indentation = 4;

            //Inizio File XML
            this.fileWriter.WriteStartDocument();
            this.fileWriter.WriteStartElement("Tree");

            this.fileWriter.WriteStartElement("Informations");
            this.fileWriter.WriteElementString("Type", this.type);
            this.fileWriter.WriteElementString("SplitSize", this.SplitSize.ToString());
            this.fileWriter.WriteElementString("Depth", this.Depth.ToString());


                //Stampa Attributi vertici (elenco nome+tipo)
                this.fileWriter.WriteStartElement("Attributes");

                    foreach (Attribute a in this.VertexAttributes)
                    {
                        this.fileWriter.WriteStartElement("Attribute");
                        this.fileWriter.WriteElementString("Type", a.type.ToString());
                        this.fileWriter.WriteElementString("Name", a.Name);
                        this.fileWriter.WriteEndElement(); //Attribute
                    }

                    //Stampa Attributi edge (elenco nome+tipo)
                    foreach (Attribute a in this.EdgeAttributes)
                    {
                        this.fileWriter.WriteStartElement("Attribute");
                        this.fileWriter.WriteElementString("Type", a.type.ToString());
                        this.fileWriter.WriteElementString("Name", a.Name);
                        this.fileWriter.WriteEndElement(); //Attribute
                    }

                    this.fileWriter.WriteEndElement(); //Attributes
                    this.fileWriter.WriteEndElement(); //GeneralInformations
                

            this.fileWriter = this.generateTreeXML();

            this.fileWriter.WriteEndElement(); //Tree
            this.fileWriter.WriteEndDocument();
            this.fileWriter.Close();

            return true;
        }


        private XmlTextWriter generateTreeXML() {

            if (this.root == null)
                return this.fileWriter;

            if (this.root.OutgoingEdges == null)
                return this.fileWriter;

            return this.generateTreeXML(true);

        }

        private XmlTextWriter generateTreeXML(bool first) {

            if (this.root == null)
                return this.fileWriter;

            if (this.root.OutgoingEdges == null)
                return this.fileWriter;

            //Prima esecuzione
            if (first) {
            
                this.fileWriter.WriteStartElement("Vertex");
                this.fileWriter.WriteElementString("Name", root.Name.ToString());
                this.fileWriter.WriteElementString("Depth", root.Depth.ToString());

                //Console.WriteLine("Io sono il primo: "+root.Name);
                
                this.fileWriter.WriteStartElement("Attributes");
                    foreach (Attribute a in root.Attributes)
                    {
                        this.fileWriter.WriteElementString(a.Name,
                            a.type == Attribute.AttributeType.STRING ?
                            a.value_string : a.value_int.ToString());
                    }
                    this.fileWriter.WriteEndElement(); //Attribute
                
                
                this.fileWriter = this.generateTreeXML(false);
                this.fileWriter.WriteEndElement(); //Vertex
            
            } else {

                foreach (Edge e in this.root.OutgoingEdges) {

                    this.fileWriter.WriteStartElement("Edge");

                    this.fileWriter.WriteElementString("Name", e.Name.ToString());
                    this.fileWriter.WriteStartElement("Attributes");

                        foreach (Attribute a in e.Attributes)
                        {
                            this.fileWriter.WriteElementString(a.Name,
                                a.type == Attribute.AttributeType.STRING ?
                                a.value_string : a.value_int.ToString());
                        }

                    this.fileWriter.WriteEndElement(); //Attributes
                    

                    this.fileWriter.WriteStartElement("Vertex");
                    this.fileWriter.WriteElementString("Name", e.Bottom.Name.ToString());
                    this.fileWriter.WriteElementString("Depth", e.Bottom.Depth.ToString());
                    
                                  
                    this.fileWriter.WriteStartElement("Attributes");

                        foreach (Attribute a in e.Bottom.Attributes)
                        {
                            this.fileWriter.WriteElementString(a.Name,
                                a.type == Attribute.AttributeType.STRING ?
                                a.value_string : a.value_int.ToString());
                        }

                    this.fileWriter.WriteEndElement(); //Attributes
                    
    
                    Tree subtree = new Tree(this.Depth-1,this.SplitSize,this.VertexAttributes,this.EdgeAttributes,this.type,e.Bottom,fileWriter);

                    //Console.WriteLine(e.Top.Name+" -> "+e.Name+" -> "+subtree.root.Name);

                    this.fileWriter = subtree.generateTreeXML(false);

                    this.fileWriter.WriteEndElement(); //Vertex
                    this.fileWriter.WriteEndElement(); //Edge

                }
            }

            return this.fileWriter;
        }


        public bool isEmpty() {
            return root == null;
        }
        

        private static LinkedList<Attribute> GetRandomAttributes(bool forVertex, LinkedList<Attribute> vertattrs, LinkedList<Attribute> edgeattrs) {
            
            //if attributes list not set => do nothing
            if (forVertex) {
                if (vertattrs == null)
                    return null;
            } else {
                if (edgeattrs == null)
                    return null;
            }

            LinkedList<Attribute> attr = new LinkedList<Attribute>();
            
            foreach (Attribute a in forVertex ? vertattrs : edgeattrs) {

                Attribute copy = a.Clone(); //well yes, it's needed indeed
                attr.AddLast(copy.generate());
            
            }
            return attr;

        }
    }
}
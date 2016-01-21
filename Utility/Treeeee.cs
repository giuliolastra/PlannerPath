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
    class Tree
    {
        public Vertex root { get; set; }
        public String type { get; set; } //Name of the tree
        int SplitSize { get; set; } //how many childs a Vertex has
        int Depth { get; set; } //levels of the tree
        LinkedList<Attribute> VertexAttributes { get; set; } //list of attributes that Vertexs have
        LinkedList<Attribute> EdgeAttributes { get; set; } //list of attributes that Vertexs have

        /// <summary>
        /// Constructs a tree with the following parameters
        /// </summary>
        /// <param name="splitSize">splitsize of the tree</param>
        /// <param name="depth">depth of the tree</param>
        /// <param name="vertexAttributes">attributes of each vertex</param>
        /// <param name="edgeAttributes">attributes of each edge</param>
        public Tree(int splitSize, int depth, LinkedList<Attribute> vertexAttributes, LinkedList<Attribute> edgeAttributes)
        {
            this.SplitSize = splitSize;
            this.Depth = depth;
            this.VertexAttributes = vertexAttributes;
            this.EdgeAttributes = edgeAttributes;
        }

        /// <summary>
        /// Constructs a new tree, with a given splitsize and depth.
        /// Note: vertex and edge attributes are set to null, so you have to set them manually
        /// </summary>
        /// <param name="splitSize"></param>
        /// <param name="depth"></param>
        public Tree(int splitSize, int depth)
        {
            this.SplitSize = splitSize;
            this.Depth = depth;
            this.VertexAttributes = null;
            this.EdgeAttributes = null;
        }



        /// <summary>
        /// returns true if this tree is empty (ie no Vertex nor edge is contained)
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// Deallocates this tree.
        /// </summary>
        public void clear()
        {
            root = null;
        }

        private void edgesToXML(XmlWriter writer, Vertex curvertex)
        {
            if (curvertex == null)
                return;

            if (curvertex.OutgoingEdges == null || curvertex.OutgoingEdges.Count == 0)
                return;

            foreach (Edge e in curvertex.OutgoingEdges)
            {
                writer.WriteStartElement("Edge");
                writer.WriteElementString("Name", e.Name.ToString());
                writer.WriteStartElement("Attributes");
                foreach (Attribute a in e.Attributes)
                {
                    writer.WriteElementString(a.Name,
                        a.type == Attribute.AttributeType.STRING ?
                        a.value_string : a.value_int.ToString());
                }
                writer.WriteEndElement(); //Attributes
                this.vertexToXML(writer, e.Bottom);
                writer.WriteEndElement(); //Vertex
                writer.WriteEndElement(); //Edge
            }
        }

        /// <summary>
        /// Prints the cur vertex to XML
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="cur">node to be printed</param>
        private void vertexToXML(XmlWriter writer, Vertex cur)
        {
            if (this.root == null)
                return;

            writer.WriteStartElement("Vertex");
            writer.WriteElementString("Name", cur.Name.ToString());
            writer.WriteElementString("Depth", cur.Level.ToString());
            writer.WriteStartElement("Attributes");
            foreach (Attribute a in cur.Attributes)
            {
                writer.WriteElementString(a.Name,
                    a.type == Attribute.AttributeType.STRING ?
                    a.value_string : a.value_int.ToString());
            }
            writer.WriteEndElement(); //Attributes
        }

        /// <summary>
        /// Writes the xml with vertexes printed in preorder
        /// </summary>
        /// <param name="writer"></param>
        private void preorderXML_vertexes(XmlWriter writer)
        {
            if (this.root == null)
                return;

            if (this.root.OutgoingEdges == null)
                return;

            this.vertexToXML(writer, this.root);
            this.edgesToXML(writer, this.root);
            writer.WriteEndElement(); //Vertex

            foreach (Edge e in this.root.OutgoingEdges)
            {
                Tree subtree = new Tree(SplitSize, Depth - 1, VertexAttributes, EdgeAttributes);
                subtree.root = e.Bottom;
                subtree.preorderXML_vertexes(writer);
            }
        }

        private void generateTree(XmlWriter writer)
        {
            Tree subtree = new Tree(SplitSize, Depth, VertexAttributes, EdgeAttributes);
            subtree.root = e.Bottom;
            subtree.generateTree(writer, true);
        }

        private void generateTree(XmlWriter writer, bool first)
        {
            if (this.root == null)
                return;

            if (this.root.OutgoingEdges == null)
                return;

            //Prima esecuzione
            if (first)
            {
                this.vertexToXML(writer, this.root);
            }
            else {

                //Seconda esecuzione
                for (int i = 0; i < this.splitsize; i++)
                {
                    for (int j = 0; j < this.depth; j++)
                    {
                        this.edgesToXML(writer, this.root);
                        this.vertexToXML(writer, this.root);
                    }
                }

                for (int i = 0; i < this.splitSize; i++)
                {
                    for (int j = 0; j < this.depth; j++)
                    {
                        writer.WriteEndElement(); //Vertex
                    }
                }
            }

            writer.WriteEndElement(); //Vertex

            foreach (Edge e in this.root.OutgoingEdges)
            {
                Tree subtree = new Tree(SplitSize, Depth - 1, VertexAttributes, EdgeAttributes);
                subtree.root = e.Bottom;
                subtree.generateTree(writer, first);
            }
        }

        /// <summary>
        /// Writes this tree to file, using preorder
        /// </summary>
        /// <returns>true on success</returns>
        public bool ToFile(String path)
        {
            //Write general information
            if (!System.IO.Directory.Exists(path))
                return false;

            if (this.type.EndsWith(".xml") == false)
                this.type += ".xml";

            if (path.EndsWith("/") == false && path.EndsWith("\\") == false)
            {
                String completepath = path + "\\" + this.type;
            }
            else {
                String completepath = path + this.type;
            }


            using (XmlTextWriter writer = new XmlTextWriter(completepath, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                //Inizio xml
                writer.WriteStartDocument();
                writer.WriteStartElement("Tree");
                writer.WriteStartElement("Information");
                writer.WriteElementString("Type", this.type);
                writer.WriteElementString("SplitSize", this.SplitSize.ToString());
                writer.WriteElementString("Depth", this.Depth.ToString());
                //Fine stampa info albero

                //Stampa Attributi vertici (elenco nome+tipo)
                writer.WriteStartElement("VertexesAttributes");
                foreach (Attribute a in this.VertexAttributes)
                {
                    writer.WriteStartElement("Attribute");
                    writer.WriteElementString("Type", a.type.ToString());
                    writer.WriteElementString("Name", a.Name);
                    writer.WriteEndElement(); //Attribute
                }
                writer.WriteEndElement(); //VertexesAttributes

                //Stampa Attributi edge (elenco nome+tipo)
                writer.WriteStartElement("EdgesAttributes");
                foreach (Attribute a in this.EdgeAttributes)
                {
                    writer.WriteStartElement("Attribute");
                    writer.WriteElementString("Type", a.type.ToString());
                    writer.WriteElementString("Name", a.Name);
                    writer.WriteEndElement(); //Attribute
                }

                writer.WriteEndElement(); //VertexesAttributes
                writer.WriteEndElement(); //Information

                this.generateTree();

                writer.WriteEndElement(); //Tree
                writer.WriteEndDocument();
                writer.Close();
            }

            return true;
        }

        /// <summary>
        /// writes this tree to database, sending a request to the Engine.
        /// </summary>
        /// <returns>true on success</returns>
        public bool ToDatabase()
        {
            return false;
        }

        public override String ToString()
        {
            return this.preorder();
        }

        /// <summary>
        /// Generates random attributes, either for a vertex or for an edge.
        /// </summary>
        /// <param name="forVertex">true if attribute list is for a Vertex</param>
        /// <param name="vertattrs">list of attributes of vertexes</param>
        /// <param name="edgeattrs">list of attributes of edges</param>
        /// <returns>a list of random attributes for either a vertex or for an edge</returns>
        private static LinkedList<Attribute> GetRandomAttributes(bool forVertex, LinkedList<Attribute> vertattrs, LinkedList<Attribute> edgeattrs)
        {
            if (forVertex) //if attributes list not set => do nothing
            {
                if (vertattrs == null)
                    return null;
            }
            else
            {
                if (edgeattrs == null)
                    return null;
            }

            LinkedList<Attribute> attr = new LinkedList<Attribute>();
            foreach (Attribute a in forVertex ? vertattrs : edgeattrs)
            {
                Attribute copy = a.Clone(); //well yes, it's needed indeed
                attr.AddLast(copy.generate());
            }
            return attr;
        }

        /// <summary>
        /// Counts Vertexs in this tree. For test
        /// </summary>
        /// <returns></returns>
        public int countVertexs()
        {
            int n = 1;
            if (root.OutgoingEdges == null)
                return n;

            foreach (Edge e in root.OutgoingEdges)
            {
                Tree subtree = new Tree(SplitSize, Depth - 1, VertexAttributes, EdgeAttributes);
                subtree.root = e.Bottom;
                n += subtree.countVertexs();
            }
            return n;
        }

        /// <summary>
        /// Generates a random tree with a given splitsize, depth and list of attributes for either vertexes and for edges.
        /// </summary>
        /// <param name="EdgeAttributes">List of attributes of each edge in the future tree</param>
        /// <param name="VertexAttributes">List of attributes of each vertex in the future tree</param>
        /// <returns>a random tree</returns>
        public static Tree getRandomTree(int Depth, int SplitSize, LinkedList<Attribute> VertexAttributes, LinkedList<Attribute> EdgeAttributes)
        { //generate per level: each Vertex gets its childs
            //Console.WriteLine("depth: " + Depth + "; splitsize: " + SplitSize);
            Tree tree = new Tree(SplitSize, Depth, VertexAttributes, EdgeAttributes);
            Vertex root = new Vertex(1, GetRandomAttributes(true, VertexAttributes, EdgeAttributes).ToArray());
            tree.root = root;
            Queue<Vertex> stack = new Queue<Vertex>();
            stack.Enqueue(tree.root);
            Vertex curVertex;
            int n = 2;
            for (int l = 1; l < Depth; l++)
            {
                curVertex = stack.Dequeue();
                //Console.WriteLine("curVertex:" + curVertex);
                for (int s = 0; s < SplitSize; s++)
                {
                    Vertex childVertex = new Vertex(n++, GetRandomAttributes(true, VertexAttributes, EdgeAttributes).ToArray(), new LinkedList<Edge>(), l);
                    if (l != Depth - 1)
                    {
                        stack.Enqueue(childVertex);
                        //Console.WriteLine("childVx: " + childVertex.ToString());
                    }
                    curVertex.append(new Edge(n, curVertex, childVertex, GetRandomAttributes(false, VertexAttributes, EdgeAttributes)));
                }
            }
            return tree;
        }
    }

}

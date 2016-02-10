using System;
using System.Collections.Generic;

namespace ProjectONE.Utility
{
    /// <summary>
    /// Represents an edge of the tree, with its random-generable attributes.
    /// An edge connects two Vertexs.
    /// </summary>
    class Edge
    {
        public LinkedList<Attribute> Attributes; //instance attributes for this edge
        public Vertex Top { get; set; }
        public Vertex Bottom { get; set; }
        public String Name { get; set; }
        public static int progID = 0;

        public int getProgID() {
            return progID;
        }

        public Edge(Vertex top, Vertex bottom)
        {
            progID++;
            this.Name = "edge" + progID;
            this.Top = top;
            this.Bottom = bottom;
        }

        public Edge(Vertex top, Vertex btm, LinkedList<Attribute> attr) : this(top, btm)
        {
            this.Attributes = attr;
        }

        public Edge(Vertex top, Vertex btm, Attribute attr) : this(top, btm)
        {
            Attributes = new LinkedList<Attribute>();
            Attributes.AddLast(attr);
        }

        public override string ToString()
        {
            String s = this.Name.ToString() + ":";

            if (Attributes == null)
                return s;

            foreach (Attribute a in Attributes)
                s += "\n\t" + a.ToString();
            return s;
        }

    }
}

using System;
using System.Collections.Generic;

namespace PlannerPath.Utility
{
    /// <summary>
    /// Represents a Vertex of the tree, with its random-generable attributes and edges.
    /// A Vertex has a name, [splitSize] outgoing edges and only one incoming edge.
    /// </summary>
    class Vertex
    {
        public Attribute[] Attributes { get; set; } //instance attributes, already generated
        public LinkedList<Edge> OutgoingEdges { get; set; } //vertici uscenti dal nodo
        public String Name { get; set; } //name of the Vertex
        public int Depth { get; set; } //level of this Vertex

        public static int progID = 0;

        public int getProgID() {
            return progID;
        }

        public Vertex(Attribute[] attr) : this()
        {
            this.Attributes = attr;
        }

        public Vertex()
        {   
            progID++;
            this.Name = "vertex" + progID;
            this.OutgoingEdges = new LinkedList<Edge>();
        }

        public Vertex(Attribute[] attr, LinkedList<Edge> edges, int d) : this(attr)
        {
            this.OutgoingEdges = edges;
            this.Depth = d;
        }

        public Vertex(Attribute attr) : this()
        {
            this.Attributes = new Attribute[1];
            this.Attributes[0] = attr;
        }

        public void append(Edge edge)
        {
            this.OutgoingEdges.AddLast(edge);
        }

        public override string ToString()
        {
            String s = Name.ToString() + ":";
            foreach (Attribute a in Attributes)
                s += "\n\t" + a.ToString();
            return s;
        }
    }
}

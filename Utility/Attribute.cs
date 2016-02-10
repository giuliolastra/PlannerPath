﻿using System;

namespace ProjectONE.Utility
{
    /*
     * Represents an attribute (for example PTime = 8). It is attached to a Vertex or to an edge.
     * An attribute can be a string, an int or a double. Int has a range.
     * The custumer requests that they must be auto-generated.
     */
    public class Attribute
    {
        public enum AttributeType { STRING, INT };
        public String Name { get; set; }
        public AttributeType type { get; }
        public int upperbound { get; set; } //only set if type is int
        public int lowerbound { get; set; } //only set if type is int
        public int value_int { get; set; } //value of the attribute. only needed if type is int
        public string value_string { get; set; } //value of the attribute. only needed if type is string

        /**
         * Note: if t = STRING => lb and ub are excluded automatically
         */
        public Attribute(String name, AttributeType t, int lb, int ub)
        {
            this.Name = name;
            this.type = t;
            if (t != AttributeType.STRING)
            {
                this.upperbound = ub;
                this.lowerbound = lb;
            }
        }

        //Needed for test. Attribute with fixed value
        public Attribute(String name, AttributeType t, string value)
        {
            this.Name = name;
            this.type = t;
            switch (t)
            {
                case AttributeType.INT:
                    this.value_int = int.Parse(value);
                    break;
                case AttributeType.STRING:
                    this.value_string = value;
                    break;
            }
        }

        public override string ToString()
        {
            string ris = Name + ": ";
            switch (type)
            {
                case AttributeType.INT:
                    ris += value_int + "\t[" + (int)lowerbound + ";" + (int)upperbound + "]";
                    break;
                case AttributeType.STRING:
                    ris += value_string;
                    break;
            }
            return ris;
        }

        /*
         * Clones an attribute, ie returns a new instance of Attribute with the same fields.
         */
        public Attribute Clone()
        {
            return new Attribute(Name, type, this.lowerbound, this.upperbound);
        }

        /**
         * generates a random attribute, taking into account its desidered type = {string,double,int}
         */
        public Attribute generate()
        {
            MyRandom r = new MyRandom();
            switch (type)
            {
                case AttributeType.STRING:
                    string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    value_string = a[(int)r.Next(49)].ToString();
                    value_string += a[(int)r.Next(6, 26)];
                    value_string += a[(int)r.Next(9, 18)];
                    value_string += a[(int)r.Next(25, 48)];
                    break;
                case AttributeType.INT:
                    value_int = (int)r.Next(this.lowerbound, this.upperbound);
                    break;
            }
            return this;
        }

    }

}
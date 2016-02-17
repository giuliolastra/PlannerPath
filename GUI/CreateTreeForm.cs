using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PlannerPath.GUI
{
    public partial class CreateTreeForm : Form
    {
        private LinkedList<PlannerPath.Utility.Attribute> verattr { get; set; }
        private LinkedList<PlannerPath.Utility.Attribute> edgeattr { get; set; }

        public CreateTreeForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);
            this.verattr = new LinkedList<PlannerPath.Utility.Attribute>();
            this.edgeattr = new LinkedList<PlannerPath.Utility.Attribute>();
        }


        //button + pressed (vertex ProjectONE.Utility.Attributes)
        private void PlusVertexAttributeClicked(object sender, EventArgs e)
        {
            InputForm i = new InputForm("vertex", this);
            i.Visible = true;
            i.Activate();
        }

        /// <summary>
        /// Adds a new attribute to vertexes
        /// </summary>
        /// <param name="a"></param>
        public void AppendVertexAttribute(PlannerPath.Utility.Attribute a)
        {
            if (this.verattr == null)
                this.verattr = new LinkedList<PlannerPath.Utility.Attribute>();
            this.verattr.AddLast(a);
        }

        /// <summary>
        /// Adds a new attribute to edges
        /// </summary>
        /// <param name="a"></param>
        private void AppendEdgeAttribute(PlannerPath.Utility.Attribute a)
        {
            //Console.WriteLine(a.ToString());
            if (this.edgeattr == null)
                this.edgeattr = new LinkedList<PlannerPath.Utility.Attribute>();
            this.edgeattr.AddLast(a);
        }

        /*
         * Permette di fare comunicare la finestra d'inserimento attributo con questa.
         * I parametri sono, in ordine, {vertex, edge}, il nome dell'attributo, il tipo {string, double, int} e i due estremi del range.
         */
        public void passParams(String type, String nomeattr, String cbsel, String range0, String range1)
        {
            if (type.Equals("vertex"))
            {
                String newattribute = nomeattr +(cbsel.Equals("String") ? "" : " - [" + range0 + ";" + range1 + "] (" + cbsel + ")");
                foreach (string e in this.listbox_vertexattr.Items)
                {
                    if (e.StartsWith(nomeattr))
                    {
                        MessageBox.Show("Attribute already inserted");
                        return;
                    }
                }

                this.listbox_vertexattr.Items.Add(newattribute);
                switch (cbsel)
                {
                    case "String":
                        this.AppendVertexAttribute(new PlannerPath.Utility.Attribute(nomeattr, PlannerPath.Utility.Attribute.AttributeType.STRING, 0, 0));
                        break;
                    case "Integer":
                        this.AppendVertexAttribute(new PlannerPath.Utility.Attribute(nomeattr, PlannerPath.Utility.Attribute.AttributeType.INT, int.Parse(range0), int.Parse(range1)));
                        break;
                 }
            }
            else
            {
                String newattribute = nomeattr + (cbsel.Equals("String") ? "" : " - [" + range0 + ";" + range1 + "] (" + cbsel + ")");
                foreach (string e in this.listbox_edgeattr.Items)
                {
                    if (e.StartsWith(nomeattr))
                    {
                        MessageBox.Show("Attribute already inserted");
                        return;
                    }
                }

                this.listbox_edgeattr.Items.Add(nomeattr + (cbsel.Equals("String") ? "" : " - [" + range0 + ";" + range1 + "] (" + cbsel + ")"));
                switch (cbsel)
                {
                    case "String":
                        this.AppendEdgeAttribute(new PlannerPath.Utility.Attribute(nomeattr, PlannerPath.Utility.Attribute.AttributeType.STRING, 0, 0));
                        break;
                    case "Integer":
                        this.AppendEdgeAttribute(new PlannerPath.Utility.Attribute(nomeattr, PlannerPath.Utility.Attribute.AttributeType.INT, int.Parse(range0), int.Parse(range1)));
                        break;
                }
            }
        }

        //button - pressed (vertex attributes)
        private void MinusVertexAttributeClicked(object sender, EventArgs e)
        {
            if(this.listbox_vertexattr.SelectedIndex != -1)
                this.listbox_vertexattr.Items.RemoveAt(this.listbox_vertexattr.SelectedIndex);
        }

        //button + pressed (edge attributes)
        private void PlusEdgeAttributeClicked(object sender, EventArgs e)
        {
            InputForm i = new InputForm("edge", this);
            i.Visible = true;
            i.Activate();
        }

        //button - pressed (edge attributes)
        private void MinusEdgeAttributeClicked(object sender, EventArgs e)
        {
            if(this.listbox_edgeattr.SelectedIndex != -1)
                this.listbox_edgeattr.Items.RemoveAt(this.listbox_edgeattr.SelectedIndex);
        }

        //button for Create Tree and control consinstency of data
        private void generateTree(object sender, EventArgs e)
        {
            int splitsize, depth;
            if (int.TryParse(txt_split_size.Text, out splitsize) && int.TryParse(txt_depth.Text, out depth))
            {   
                //if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && listbox_edgeattr.Items.Count != 0 && listbox_vertexattr.Items.Count != 0)
                if (txt_tree_name.Text.Length != 0 && txt_destination_folder.Text.Length != 0)
                {
                    if (splitsize >= 1 && depth >= 1)
                    {
                        new CreateTreeControl(depth, splitsize, this.verattr, this.edgeattr, this.txt_destination_folder.Text, txt_tree_name.Text);
                        return;
                    }
                }
            }
            MessageBox.Show("Please insert correct parameters");
        }

        //Choose button. Shows a FolderBrowserDialog
        private void chooseDirectory(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if(result == DialogResult.OK)
                this.txt_destination_folder.Text = fbd.SelectedPath;
        }
        
    }
}

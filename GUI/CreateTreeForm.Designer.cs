namespace ProjectONE.GUI
{
    partial class CreateTreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTreeForm));
            this.txt_tree_name = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txt_destination_folder = new System.Windows.Forms.TextBox();
            this.txt_depth = new System.Windows.Forms.TextBox();
            this.txt_split_size = new System.Windows.Forms.TextBox();
            this.btn_create_tree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listbox_vertexattr = new System.Windows.Forms.ListBox();
            this.listbox_edgeattr = new System.Windows.Forms.ListBox();
            this.btn_plus_vertex = new System.Windows.Forms.Button();
            this.btn_plus_edge = new System.Windows.Forms.Button();
            this.btn_minus_vertex = new System.Windows.Forms.Button();
            this.btn_minus_edge = new System.Windows.Forms.Button();
            this.btn_choose_ct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_tree_name
            // 
            this.txt_tree_name.Location = new System.Drawing.Point(110, 45);
            this.txt_tree_name.Name = "txt_tree_name";
            this.txt_tree_name.Size = new System.Drawing.Size(240, 20);
            this.txt_tree_name.TabIndex = 0;
            // 
            // txt_destination_folder
            // 
            this.txt_destination_folder.Location = new System.Drawing.Point(110, 71);
            this.txt_destination_folder.Name = "txt_destination_folder";
            this.txt_destination_folder.Size = new System.Drawing.Size(159, 20);
            this.txt_destination_folder.TabIndex = 1;
            // 
            // txt_depth
            // 
            this.txt_depth.Location = new System.Drawing.Point(275, 100);
            this.txt_depth.Name = "txt_depth";
            this.txt_depth.Size = new System.Drawing.Size(75, 20);
            this.txt_depth.TabIndex = 4;
            // 
            // txt_split_size
            // 
            this.txt_split_size.Location = new System.Drawing.Point(110, 100);
            this.txt_split_size.Name = "txt_split_size";
            this.txt_split_size.Size = new System.Drawing.Size(75, 20);
            this.txt_split_size.TabIndex = 3;
            // 
            // btn_create_tree
            // 
            this.btn_create_tree.Location = new System.Drawing.Point(179, 148);
            this.btn_create_tree.Name = "btn_create_tree";
            this.btn_create_tree.Size = new System.Drawing.Size(90, 32);
            this.btn_create_tree.TabIndex = 5;
            this.btn_create_tree.Text = "Create tree";
            this.btn_create_tree.UseVisualStyleBackColor = true;
            this.btn_create_tree.Click += new System.EventHandler(this.generateTree);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tree Name (Type)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SplitSize";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Depth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Vertex attributes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Edge attributes";
            // 
            // listbox_vertexattr
            // 
            this.listbox_vertexattr.FormattingEnabled = true;
            this.listbox_vertexattr.Location = new System.Drawing.Point(374, 45);
            this.listbox_vertexattr.Name = "listbox_vertexattr";
            this.listbox_vertexattr.Size = new System.Drawing.Size(150, 82);
            this.listbox_vertexattr.TabIndex = 12;
            // 
            // listbox_edgeattr
            // 
            this.listbox_edgeattr.FormattingEnabled = true;
            this.listbox_edgeattr.Location = new System.Drawing.Point(374, 148);
            this.listbox_edgeattr.Name = "listbox_edgeattr";
            this.listbox_edgeattr.Size = new System.Drawing.Size(150, 82);
            this.listbox_edgeattr.TabIndex = 13;
            // 
            // btn_plus_vertex
            // 
            this.btn_plus_vertex.Location = new System.Drawing.Point(530, 48);
            this.btn_plus_vertex.Name = "btn_plus_vertex";
            this.btn_plus_vertex.Size = new System.Drawing.Size(20, 23);
            this.btn_plus_vertex.TabIndex = 14;
            this.btn_plus_vertex.Text = "+";
            this.btn_plus_vertex.UseVisualStyleBackColor = true;
            this.btn_plus_vertex.Click += new System.EventHandler(this.PlusVertexAttributeClicked);
            // 
            // btn_plus_edge
            // 
            this.btn_plus_edge.Location = new System.Drawing.Point(530, 153);
            this.btn_plus_edge.Name = "btn_plus_edge";
            this.btn_plus_edge.Size = new System.Drawing.Size(20, 23);
            this.btn_plus_edge.TabIndex = 15;
            this.btn_plus_edge.Text = "+";
            this.btn_plus_edge.UseVisualStyleBackColor = true;
            this.btn_plus_edge.Click += new System.EventHandler(this.PlusEdgeAttributeClicked);
            // 
            // btn_minus_vertex
            // 
            this.btn_minus_vertex.Location = new System.Drawing.Point(530, 74);
            this.btn_minus_vertex.Name = "btn_minus_vertex";
            this.btn_minus_vertex.Size = new System.Drawing.Size(20, 23);
            this.btn_minus_vertex.TabIndex = 16;
            this.btn_minus_vertex.Text = "-";
            this.btn_minus_vertex.UseVisualStyleBackColor = true;
            this.btn_minus_vertex.Click += new System.EventHandler(this.MinusVertexAttributeClicked);
            // 
            // btn_minus_edge
            // 
            this.btn_minus_edge.Location = new System.Drawing.Point(530, 182);
            this.btn_minus_edge.Name = "btn_minus_edge";
            this.btn_minus_edge.Size = new System.Drawing.Size(20, 23);
            this.btn_minus_edge.TabIndex = 17;
            this.btn_minus_edge.Text = "-";
            this.btn_minus_edge.UseVisualStyleBackColor = true;
            this.btn_minus_edge.Click += new System.EventHandler(this.MinusEdgeAttributeClicked);
            // 
            // btn_choose_ct
            // 
            this.btn_choose_ct.Location = new System.Drawing.Point(275, 71);
            this.btn_choose_ct.Name = "btn_choose_ct";
            this.btn_choose_ct.Size = new System.Drawing.Size(75, 23);
            this.btn_choose_ct.TabIndex = 2;
            this.btn_choose_ct.Text = "Choose";
            this.btn_choose_ct.UseVisualStyleBackColor = true;
            this.btn_choose_ct.Click += new System.EventHandler(this.chooseDirectory);
            // 
            // CreateTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 261);
            this.Controls.Add(this.btn_minus_edge);
            this.Controls.Add(this.btn_minus_vertex);
            this.Controls.Add(this.btn_plus_edge);
            this.Controls.Add(this.btn_plus_vertex);
            this.Controls.Add(this.listbox_edgeattr);
            this.Controls.Add(this.listbox_vertexattr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_create_tree);
            this.Controls.Add(this.txt_split_size);
            this.Controls.Add(this.txt_depth);
            this.Controls.Add(this.txt_destination_folder);
            this.Controls.Add(this.txt_tree_name);
            this.Controls.Add(this.btn_choose_ct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTreeForm";
            this.Text = "Create Tree";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_tree_name;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txt_destination_folder;
        private System.Windows.Forms.TextBox txt_depth;
        private System.Windows.Forms.TextBox txt_split_size;
        private System.Windows.Forms.Button btn_create_tree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listbox_vertexattr;
        private System.Windows.Forms.ListBox listbox_edgeattr;
        private System.Windows.Forms.Button btn_plus_vertex;
        private System.Windows.Forms.Button btn_plus_edge;
        private System.Windows.Forms.Button btn_minus_vertex;
        private System.Windows.Forms.Button btn_minus_edge;
        private System.Windows.Forms.Button btn_choose_ct;
    }
}
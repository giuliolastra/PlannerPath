namespace ProjectONE.GUI
{
    partial class CalculusManagerForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_perform_calculus = new System.Windows.Forms.Button();
            this.txt_vertice_b = new System.Windows.Forms.TextBox();
            this.lbl_certice_b = new System.Windows.Forms.Label();
            this.txt_vertice_a = new System.Windows.Forms.TextBox();
            this.txt_tree_type = new System.Windows.Forms.TextBox();
            this.lbl_vertice_a = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_perform_calculus
            // 
            this.btn_perform_calculus.Location = new System.Drawing.Point(51, 120);
            this.btn_perform_calculus.Name = "btn_perform_calculus";
            this.btn_perform_calculus.Size = new System.Drawing.Size(104, 23);
            this.btn_perform_calculus.TabIndex = 3;
            this.btn_perform_calculus.Text = "Perform Calculus";
            this.btn_perform_calculus.UseVisualStyleBackColor = true;
            this.btn_perform_calculus.Click += new System.EventHandler(this.performCalculusButtonClick);
            // 
            // txt_vertice_b
            // 
            this.txt_vertice_b.Location = new System.Drawing.Point(115, 79);
            this.txt_vertice_b.Name = "txt_vertice_b";
            this.txt_vertice_b.Size = new System.Drawing.Size(80, 20);
            this.txt_vertice_b.TabIndex = 2;
            // 
            // lbl_certice_b
            // 
            this.lbl_certice_b.AutoSize = true;
            this.lbl_certice_b.Location = new System.Drawing.Point(145, 63);
            this.lbl_certice_b.Name = "lbl_certice_b";
            this.lbl_certice_b.Size = new System.Drawing.Size(50, 13);
            this.lbl_certice_b.TabIndex = 19;
            this.lbl_certice_b.Text = "Vertice B";
            // 
            // txt_vertice_a
            // 
            this.txt_vertice_a.Location = new System.Drawing.Point(15, 79);
            this.txt_vertice_a.Name = "txt_vertice_a";
            this.txt_vertice_a.Size = new System.Drawing.Size(80, 20);
            this.txt_vertice_a.TabIndex = 1;
            // 
            // txt_tree_type
            // 
            this.txt_tree_type.Location = new System.Drawing.Point(15, 25);
            this.txt_tree_type.Name = "txt_tree_type";
            this.txt_tree_type.Size = new System.Drawing.Size(180, 20);
            this.txt_tree_type.TabIndex = 0;
            // 
            // lbl_vertice_a
            // 
            this.lbl_vertice_a.AutoSize = true;
            this.lbl_vertice_a.Location = new System.Drawing.Point(12, 63);
            this.lbl_vertice_a.Name = "lbl_vertice_a";
            this.lbl_vertice_a.Size = new System.Drawing.Size(50, 13);
            this.lbl_vertice_a.TabIndex = 16;
            this.lbl_vertice_a.Text = "Vertice A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tree Identifier (Type)";
            // 
            // CalculusManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 159);
            this.Controls.Add(this.btn_perform_calculus);
            this.Controls.Add(this.txt_vertice_b);
            this.Controls.Add(this.lbl_certice_b);
            this.Controls.Add(this.txt_vertice_a);
            this.Controls.Add(this.txt_tree_type);
            this.Controls.Add(this.lbl_vertice_a);
            this.Controls.Add(this.label1);
            this.Name = "CalculusManagerForm";
            this.Text = "Calculus Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_perform_calculus;
        private System.Windows.Forms.TextBox txt_vertice_b;
        private System.Windows.Forms.Label lbl_certice_b;
        private System.Windows.Forms.TextBox txt_vertice_a;
        private System.Windows.Forms.TextBox txt_tree_type;
        private System.Windows.Forms.Label lbl_vertice_a;
        private System.Windows.Forms.Label label1;
    }
}
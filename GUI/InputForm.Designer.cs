namespace PlannerPath.GUI
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.txt_nome_attributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_tipo_attributo = new System.Windows.Forms.ComboBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_range1 = new System.Windows.Forms.TextBox();
            this.txt_range2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_nome_attributo
            // 
            this.txt_nome_attributo.Location = new System.Drawing.Point(95, 10);
            this.txt_nome_attributo.Name = "txt_nome_attributo";
            this.txt_nome_attributo.Size = new System.Drawing.Size(177, 20);
            this.txt_nome_attributo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name attribute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type attribute";
            // 
            // cmb_tipo_attributo
            // 
            this.cmb_tipo_attributo.FormattingEnabled = true;
            this.cmb_tipo_attributo.Location = new System.Drawing.Point(95, 44);
            this.cmb_tipo_attributo.Name = "cmb_tipo_attributo";
            this.cmb_tipo_attributo.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipo_attributo.TabIndex = 3;
            this.cmb_tipo_attributo.SelectionChangeCommitted += new System.EventHandler(this.cmb_tipo_attributo_SelectionChangeCommitted);
            this.cmb_tipo_attributo.TextUpdate += new System.EventHandler(this.cmb_tipo_attributo_TextUpdate);
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(95, 115);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 4;
            this.btn_insert.Text = "Insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Range from";
            // 
            // txt_range1
            // 
            this.txt_range1.Location = new System.Drawing.Point(95, 77);
            this.txt_range1.Name = "txt_range1";
            this.txt_range1.Size = new System.Drawing.Size(54, 20);
            this.txt_range1.TabIndex = 1;
            // 
            // txt_range2
            // 
            this.txt_range2.Location = new System.Drawing.Point(177, 77);
            this.txt_range2.Name = "txt_range2";
            this.txt_range2.Size = new System.Drawing.Size(54, 20);
            this.txt_range2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "to";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 154);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_range2);
            this.Controls.Add(this.txt_range1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.cmb_tipo_attributo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nome_attributo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nome_attributo;
        private System.Windows.Forms.ComboBox cmb_tipo_attributo;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_range1;
        private System.Windows.Forms.TextBox txt_range2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
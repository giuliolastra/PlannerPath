namespace ProjectONE.GUI
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.btn_new_tree = new System.Windows.Forms.Button();
            this.btn_upload_tree = new System.Windows.Forms.Button();
            this.btn_perform_calculus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_new_tree
            // 
            this.btn_new_tree.Location = new System.Drawing.Point(104, 24);
            this.btn_new_tree.Name = "btn_new_tree";
            this.btn_new_tree.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_new_tree.Size = new System.Drawing.Size(75, 23);
            this.btn_new_tree.TabIndex = 0;
            this.btn_new_tree.Text = "New Tree";
            this.btn_new_tree.UseVisualStyleBackColor = true;
            this.btn_new_tree.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_upload_tree
            // 
            this.btn_upload_tree.Location = new System.Drawing.Point(104, 64);
            this.btn_upload_tree.Name = "btn_upload_tree";
            this.btn_upload_tree.Size = new System.Drawing.Size(75, 23);
            this.btn_upload_tree.TabIndex = 1;
            this.btn_upload_tree.Text = "Upload Tree";
            this.btn_upload_tree.UseVisualStyleBackColor = true;
            this.btn_upload_tree.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_perform_calculus
            // 
            this.btn_perform_calculus.Location = new System.Drawing.Point(92, 103);
            this.btn_perform_calculus.Name = "btn_perform_calculus";
            this.btn_perform_calculus.Size = new System.Drawing.Size(100, 23);
            this.btn_perform_calculus.TabIndex = 2;
            this.btn_perform_calculus.Text = "Perform Calculus";
            this.btn_perform_calculus.UseVisualStyleBackColor = true;
            this.btn_perform_calculus.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 168);
            this.Controls.Add(this.btn_perform_calculus);
            this.Controls.Add(this.btn_upload_tree);
            this.Controls.Add(this.btn_new_tree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_new_tree;
        private System.Windows.Forms.Button btn_upload_tree;
        private System.Windows.Forms.Button btn_perform_calculus;
    }
}
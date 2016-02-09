namespace ProjectONE.GUI
{
    partial class UploadTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadTreeForm));
            this.btn_choose_ut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tree_directory = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_choose_ut
            // 
            this.btn_choose_ut.Location = new System.Drawing.Point(197, 26);
            this.btn_choose_ut.Name = "btn_choose_ut";
            this.btn_choose_ut.Size = new System.Drawing.Size(75, 23);
            this.btn_choose_ut.TabIndex = 0;
            this.btn_choose_ut.Text = "Choose";
            this.btn_choose_ut.UseVisualStyleBackColor = true;
            this.btn_choose_ut.Click += new System.EventHandler(this.chooseDirectoryClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tree directory";
            // 
            // txt_tree_directory
            // 
            this.txt_tree_directory.Location = new System.Drawing.Point(15, 28);
            this.txt_tree_directory.Name = "txt_tree_directory";
            this.txt_tree_directory.Size = new System.Drawing.Size(176, 20);
            this.txt_tree_directory.TabIndex = 2;
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(197, 55);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.uploadButtonClick);
            // 
            // UploadTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.txt_tree_directory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_choose_ut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadTreeForm";
            this.Text = "Upload Tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_choose_ut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tree_directory;
        private System.Windows.Forms.Button btn_upload;
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectONE.GUI
{
    public partial class CalculusManagerForm : Form
    {
        public CalculusManagerForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);
        }

        private void performCalculusButtonClick(object sender, EventArgs e)
        {
            if (txt_tree_type.Text.Equals("") || txt_vertice_a.Text.Equals("") || txt_vertice_b.Text.Equals(""))
                MessageBox.Show("You mast enter correct fields");
            else
                new CalculusManagerControl(txt_tree_type.Text, txt_vertice_a.Text, txt_vertice_b.Text);
        }
    }
}

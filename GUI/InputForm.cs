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
    public partial class InputForm : Form
    {
        String type;
        CreateTreeForm CreateTreeForm;

        public InputForm(String t, CreateTreeForm f1ref)
        {
            InitializeComponent();
            comboBox1.Items.Add("String");
            comboBox1.Items.Add("Integer");
            comboBox1.SelectedIndex = 0;
            type = t;
            this.CreateTreeForm = f1ref;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedText != "String")
            {
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
        }

        //insert attribute
        private void button1_Click(object sender, EventArgs e)
        {
            bool problem = false;
            if (!comboBox1.SelectedItem.ToString().Equals("String"))
            {
                int temp1, temp2;

                if (int.TryParse(textBox2.Text, out temp1) && int.TryParse(textBox3.Text, out temp2)) //both the values of the range are inserted?
                {
                    if (temp1 <= temp2) //range: n1 <= n2?
                    {
                        this.CreateTreeForm.passParams(this.type, textBox1.Text, comboBox1.SelectedItem.ToString(), ((int)temp1).ToString(), ((int)temp2).ToString());
                    }
                    else
                        problem = true;
                }
                else
                    problem = true;
                if(problem)
                    MessageBox.Show("Please insert appropriate attributes");
                return;
            }
            //attribute is of type string
            this.CreateTreeForm.passParams(this.type, textBox1.Text, comboBox1.SelectedItem.ToString(), "", "");
        }
    }
}

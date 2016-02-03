using System;
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
            cmb_tipo_attributo.Items.Add("String");
            cmb_tipo_attributo.Items.Add("Integer");
            cmb_tipo_attributo.SelectedIndex = 0;
            type = t;
            this.CreateTreeForm = f1ref;
        }

        //insert attribute and control consinstency of data
        private void button1_Click(object sender, EventArgs e)
        {
            bool problem = false;
                if (!cmb_tipo_attributo.SelectedItem.ToString().Equals("String"))
                {
                    int temp1, temp2;

                    if (int.TryParse(txt_range1.Text, out temp1) && int.TryParse(txt_range2.Text, out temp2)) //both the values of the range are inserted?
                    { 
                        if (temp1 <= temp2) //range: n1 <= n2?
                                               
                            this.CreateTreeForm.passParams(this.type, txt_nome_attributo.Text, cmb_tipo_attributo.SelectedItem.ToString(), ((int)temp1).ToString(), ((int)temp2).ToString()); 
                        else
                            problem = true;
                    }
                }
            else { 
                problem = true;
                    if(problem)
                        MessageBox.Show("Please insert appropriate attributes");
                    return;
                }
            //attribute is of type string
            this.CreateTreeForm.passParams(this.type, txt_nome_attributo.Text, cmb_tipo_attributo.SelectedItem.ToString(), "", "");
        }

        //control values in combobox
        private void cmb_tipo_attributo_TextUpdate(object sender, EventArgs e)
        {
            if (cmb_tipo_attributo.Text!= "String" && cmb_tipo_attributo.Text != "Integer")
            {
                txt_range1.Enabled = false;
                txt_range2.Enabled = false;
            }
            else
            {
                txt_range1.Enabled = true;
                txt_range2.Enabled = true;
            }
        }

        //coltrol values in combobox
        private void cmb_tipo_attributo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_tipo_attributo.SelectedText != "String" || cmb_tipo_attributo.SelectedText != "Integer")
            {
                txt_range1.Enabled = true;
                txt_range2.Enabled = true;
            }
            else
            {
                txt_range1.Enabled = false;
                txt_range2.Enabled = false;
            }
        }
    }
}

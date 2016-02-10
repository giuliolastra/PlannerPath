using System;
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
            cmb_tipo_attributo.Items.Add("Integer");
            cmb_tipo_attributo.Items.Add("String");
            cmb_tipo_attributo.SelectedIndex = 0;
            type = t;
            this.CreateTreeForm = f1ref;
        }

        //insert attribute and control consinstency of data
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_nome_attributo.Text.Equals(""))
            {
                MessageBox.Show("You must enter a name for this attribute", "Input Form");
                return;
            }

                if (!cmb_tipo_attributo.SelectedItem.ToString().Equals("String")) //attribute of type Integer
                {
                    int temp1, temp2;

                    if(txt_range1.Text.Equals("") || txt_range2.Text.Equals(""))
                    {
                        MessageBox.Show("You must enter upper and lowerbound", "Input Form");
                        return;
                    }

                    if (int.TryParse(txt_range1.Text, out temp1) && int.TryParse(txt_range2.Text, out temp2)) //both the values of the range are inserted?
                    {
                        if (temp1 <= temp2) //range: n1 <= n2?

                            this.CreateTreeForm.passParams(this.type, txt_nome_attributo.Text, cmb_tipo_attributo.SelectedItem.ToString(), ((int)temp1).ToString(), ((int)temp2).ToString());
                        else
                        {
                            MessageBox.Show("You must enter correctly lower and upperbound", "Input Form");
                            return;
                        }
                    }
                }
            else { //attribute of type String
                this.CreateTreeForm.passParams(this.type, txt_nome_attributo.Text, cmb_tipo_attributo.SelectedItem.ToString(), "", "");
            }
        }

        //control values in combobox. Id est, you cannot write "Double", "integer", "hello world" and so on. Only "String" or "Integer"
        private void cmb_tipo_attributo_TextUpdate(object sender, EventArgs e)
        {
            txt_range1.Enabled = true;
            txt_range2.Enabled = true;
            cmb_tipo_attributo.SelectedIndex = 0;
        }

        //control values in combobox
        private void cmb_tipo_attributo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cmb_tipo_attributo.SelectedText.Equals("Integer")) //if current attribute is of type string
            {
                txt_range1.Enabled = true;
                txt_range2.Enabled = true;
            }
            else //...or of type integer
            {
                txt_range1.Enabled = false;
                txt_range2.Enabled = false;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlannerPath.GUI
{
    public partial class CalculusManagerForm : Form
    {
        public CalculusManagerForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, (Screen.FromControl(this).Bounds.Height - this.Height) / 2);
        }

        internal static void returnSum(string info)
        {
            MessageBox.Show(info, "Calculus Manager");
        }

        /*control consinstency of data CalculusManagerFrom*/
        private void performCalculusButtonClick(object sender, EventArgs e)
        {
            if (txt_tree_type.Text.Equals("") || txt_vertice_a.Text.Equals("") || txt_vertice_b.Text.Equals(""))
                MessageBox.Show("You mast enter correct fields", "Calculus Manager");
            else
                new CalculusManagerControl(txt_tree_type.Text, txt_vertice_a.Text, txt_vertice_b.Text);
        }
    }
}

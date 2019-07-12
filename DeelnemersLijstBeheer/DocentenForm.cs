using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeelnemersLijstBeheer
{
    public partial class DocentenForm : Form
    {
        public string docent { get; set; }
        public DocentenForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DocentenInvulForm docentenInvul = new DocentenInvulForm();
            docentenInvul.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DocentenWeergevenForm docentenWeergeven = new DocentenWeergevenForm(this);
            docentenWeergeven.Show();
        }

        private void DocentenForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var docent = ctx.Docentenen;
                foreach (var item in docent)
                {
                    listBox1.Items.Add(item.Naam);
                }
            }
        }
        public string GetSelectedItem()
        {
            string selected = listBox1.SelectedItem.ToString();

            return selected;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            docent = GetSelectedItem();
        }
    }
}

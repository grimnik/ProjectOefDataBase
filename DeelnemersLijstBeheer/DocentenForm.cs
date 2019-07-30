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
            string selected = null;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ;
            }
            else
            {

                selected = listBox1.SelectedItem.ToString();
            }

            return selected;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            docent = GetSelectedItem();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DocentenAanpassenForm docentenAanpassen = new DocentenAanpassenForm(this);
            docentenAanpassen.ShowDialog();
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var doc = ctx.Docentenen.FirstOrDefault(x => x.Naam == docent);
                ctx.Docentenen.Remove(doc);
                ctx.SaveChanges();
            }
        }
    }
}

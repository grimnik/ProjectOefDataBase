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
    public partial class OpleidingForm : Form
    {
        public string opleiding { get; set; }
        public OpleidingForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            OpleidinginvulForm opleidingForm = new OpleidinginvulForm();
            opleidingForm.ShowDialog();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            OpleidingWeergevenForm opleidingWeergeven = new OpleidingWeergevenForm(this);
            opleidingWeergeven.ShowDialog();
        }
        private void OpleidingForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleiding = ctx.OpleidingsInfos;
                foreach (var item in opleiding)
                {
                    listBox1.Items.Add(item.Opleiding);
                }
            }
        }
        public string GetSelectedItem()
        {
            string selected = null;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                selected = listBox1.SelectedItem.ToString();
            }

            return selected;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            opleiding = GetSelectedItem();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            OpleidingAanpassenForm aanpassenForm = new OpleidingAanpassenForm(this);
            aanpassenForm.ShowDialog();
            this.Close();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleid = ctx.OpleidingsInfos.FirstOrDefault(x => x.Opleiding == opleiding);
                ctx.OpleidingsInfos.Remove(opleid);
                ctx.SaveChanges();
            }
        }
    }
}

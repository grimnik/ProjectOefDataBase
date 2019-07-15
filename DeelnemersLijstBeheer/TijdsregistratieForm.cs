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
    public partial class TijdsregistratieForm : Form
    {
        public string tijd { get; set; }
        public TijdsregistratieForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TijdsRegistratieWeergevenForm weergevenForm = new TijdsRegistratieWeergevenForm();
            weergevenForm.ShowDialog();
        }

        private void TijdsregistratieForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var tijdsreg = ctx.TijdRegistraties;
                foreach (var item in tijdsreg)
                {
                    listBox1.Items.Add(item.DateTime);
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
            tijd = GetSelectedItem();
        }
    }
}

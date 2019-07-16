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
    public partial class VakantieDagenForm : Form
    {
        public string vakantie { get; set; }
        public VakantieDagenForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            VakantieInvulForm vakantieInvul = new VakantieInvulForm();
            vakantieInvul.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            VakantieWeergevenForm vakantieWeergeven = new VakantieWeergevenForm(this);
            vakantieWeergeven.ShowDialog();
        }

        private void VakantieDagenForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var vakantie = ctx.NietOpleidingsDagens;
                foreach (var item in vakantie)
                {
                    listBox1.Items.Add(item.Datum);
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
            vakantie = GetSelectedItem();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            VakantieAanpassenForm vakantieAanpassen = new VakantieAanpassenForm(this);
            vakantieAanpassen.ShowDialog();
            this.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var vak = ctx.NietOpleidingsDagens.FirstOrDefault(x => x.Datum == Convert.ToDateTime(vakantie));
                ctx.NietOpleidingsDagens.Remove(vak);
                ctx.SaveChanges();
            }
        }
    }
}

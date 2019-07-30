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
        public DateTime tijd { get; set; }
        public TijdsregistratieForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TijdsRegistratieWeergevenForm weergevenForm = new TijdsRegistratieWeergevenForm(this);
            weergevenForm.ShowDialog();
        }

        private void TijdsregistratieForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var tijdsreg = ctx.TijdRegistraties;
                foreach (var item in tijdsreg)
                {
                    listBox1.Items.Add(item.DateTime.Date + item.DateTime.TimeOfDay);
                }
            }
        }
        public DateTime GetSelectedItem()
        {
            
            DateTime selected = Convert.ToDateTime(listBox1.SelectedItem);
            return selected;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string temp = "";
            tijd = GetSelectedItem();
            using (var ctx = new OpleidingDatabaseContext())
            {
                var naam = ctx.TijdRegistraties.Where(t => t.DateTime == tijd).Select(d => d.Deelnemers.Naam).ToList();
                foreach (var item in naam)
                {
                    item.ToString();
                    if (item == temp)
                    {
                        continue;
                    }
                    else
                    {
                      

                        listBox2.Items.Clear();
                        
                        temp = item;
                        listBox2.Items.Add(item);
                    }

                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var tijdnotatie = ctx.TijdRegistraties.FirstOrDefault(t => t.DateTime == tijd);
                ctx.TijdRegistraties.Remove(tijdnotatie);
                ctx.SaveChanges();
            }
        }
    }
}

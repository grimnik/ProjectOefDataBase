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
    public partial class DeelnemersWeergevenForm : Form
    {
            
        public DeelnemersWeergevenForm()
        {
            InitializeComponent();
        }

        private void DeelnemersWeergevenForm_Load(object sender, EventArgs e)
        {

            using (DeelnemersForm deelnemers = new DeelnemersForm())
            {
                string deelnemer;
                using(var ctx = new OpleidingDatabaseContext())
                {
                    deelnemer = deelnemers.GetSelectedItem();

                    string id = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c =>  c.Id).ToString();
                    string naam = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.Naam).ToString();
                    string geb = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.GeboorteDatum).ToString();
                    string woon = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.WoonPlaats).ToString();
                    string badge = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.BadgeNummer).ToString();
                    label10.Text = id;
                    label9.Text = naam;
                    label8.Text = geb;
                    label7.Text = woon;
                    label6.Text = badge;
                    

                }
            }
            
        }
    }
}

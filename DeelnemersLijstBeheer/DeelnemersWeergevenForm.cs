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

        DeelnemersForm deelnemers;
        private string deelnemer;

        private void SetDeelnemer(string value)
        {
            deelnemer = value;
        }

        public DeelnemersWeergevenForm(DeelnemersForm deelnemersForm)
        {
            InitializeComponent();
            deelnemers = deelnemersForm;

            SetDeelnemer(deelnemers.deelnemer);
        }

        private void DeelnemersWeergevenForm_Load(object sender, EventArgs e)
        {



            string deelnemer = deelnemers.deelnemer;
            using (var ctx = new OpleidingDatabaseContext())
            {
                var deel = ctx.Deelnemers.Where(c => c.Naam == deelnemer)
                                         .Select(c => c.Id + ";" + c.Naam + ";" + c.GeboorteDatum + ";" + c.WoonPlaats
                                         + ";" + c.BadgeNummer).ToList();
                foreach (var item in deel)
                {
                    string[] lines = item.Split(';');
                    label10.Text = lines[0];
                    label9.Text = lines[1];
                    label8.Text = lines[2];
                    label7.Text = lines[3]; 
                    label6.Text = lines[4];
                }

            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            deelnemers.Show();
        }
    }
}

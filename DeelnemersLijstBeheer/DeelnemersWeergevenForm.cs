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

        //private string GetDeelnemer()
        //{
        //    return deelnemer;
        //}

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
                using(var ctx = new OpleidingDatabaseContext())
                {
                    

                    var id = ctx.Deelnemers.Where(c => c.Naam == deelnemer) // kan zowiezo beter
                        .Select(c =>  c.Id).FirstOrDefault();
                    var naam = ctx.Deelnemers.Where(c => c.Naam == deelnemer)
                        .Select(c => c.Naam).FirstOrDefault();
                    var geb = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.GeboorteDatum).FirstOrDefault();
                    var woon = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.WoonPlaats).FirstOrDefault();
                    var badge = ctx.Deelnemers.Where(n => n.Naam == deelnemer)
                        .Select(c => c.BadgeNummer).FirstOrDefault();
                    label10.Text = id.ToString();
                    label9.Text = naam;
                    label8.Text = geb.Year.ToString();
                    label7.Text = woon;
                    label6.Text = badge.ToString();
                    

                }
            
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            deelnemers.Show();
        }
    }
}

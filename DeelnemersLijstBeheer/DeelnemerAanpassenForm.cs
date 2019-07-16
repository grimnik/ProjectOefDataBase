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
    
    public partial class DeelnemerAanpassenForm : Form
    {
        Deelnemers deelnemers;
        DeelnemersForm DeelnemersForm;
        private string deelnemer { get; set; }
        //private void SetDeelnemer(string value)
        //{
        //    deelnemer = value;
        //}
        public DeelnemerAanpassenForm(DeelnemersForm deelnemersForm)
        {
            InitializeComponent();
            DeelnemersForm = deelnemersForm;
            //SetDeelnemer(DeelnemersForm.deelnemer);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && dateTimePicker1 != null && textBox3.Text != "" && textBox4.Text != "")
            {
                
                 deelnemer = DeelnemersForm.deelnemer;
                using (var ctx = new OpleidingDatabaseContext())
                {
                    deelnemers = ctx.Deelnemers.Where(c => c.Naam == deelnemer)
                                             .FirstOrDefault<Deelnemers>();
                    //ctx.SaveChanges();
                
                deelnemers.Naam = textBox1.Text;
                deelnemers.GeboorteDatum = Convert.ToDateTime(dateTimePicker1.Text);
                deelnemers.WoonPlaats = textBox3.Text;
                deelnemers.BadgeNummer = int.Parse(textBox4.Text);
                
                    ctx.Entry(deelnemers).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                
            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeelnemerAanpassenForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                comboBox1.Text = ctx.OpleidingsInfos.Find(1).Opleiding.ToString();
            }
        }
    }
}

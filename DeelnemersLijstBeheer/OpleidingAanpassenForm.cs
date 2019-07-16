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
    public partial class OpleidingAanpassenForm : Form
    {
        OpleidingsInfo Opleidingen;
        OpleidingForm OpleidingForm;

        private string opleiding { get; set; }
        public OpleidingAanpassenForm(OpleidingForm opleidingForm)
        {
            OpleidingForm = opleidingForm;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dateTimePicker1 != null && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && dateTimePicker1 != null && dateTimePicker2 != null)
            {
                opleiding = OpleidingForm.opleiding;
                using (var ctx = new OpleidingDatabaseContext())
                {
                    Opleidingen = ctx.OpleidingsInfos.Where(o => o.Opleiding == opleiding).FirstOrDefault<OpleidingsInfo>();

                    Opleidingen.Instelling = textBox1.Text;
                    Opleidingen.Opleiding = textBox2.Text;
                    Opleidingen.ContactPersoon = textBox3.Text;
                    Opleidingen.OpleidingsPlaats = textBox4.Text;
                    Opleidingen.RefOpleidingsPlaats = textBox5.Text;
                    Opleidingen.OeNummer = int.Parse(textBox6.Text);
                    Opleidingen.OpleidingsCode = int.Parse(textBox7.Text);
                    Opleidingen.StartDatum = Convert.ToDateTime(dateTimePicker1.Text);
                    Opleidingen.EindDatum = Convert.ToDateTime(dateTimePicker2.Text);
                    ctx.Entry(Opleidingen).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

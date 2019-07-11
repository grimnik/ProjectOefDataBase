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
    public partial class OpleidinginvulForm : Form
    {

        public OpleidinginvulForm()
        {
            InitializeComponent();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && textBox5.Text != "" && dateTimePicker1.Text != "" && dateTimePicker2.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {

                using (var ctx = new OpleidingDatabaseContext())
                {
                    var OpleidingVar = ctx.OpleidingsInfos.Add(new OpleidingsInfo
                    {
                        Instelling = textBox1.Text,
                        Opleiding = textBox2.Text,
                        ContactPersoon = textBox3.Text,
                        OpleidingsPlaats = textBox4.Text,
                        RefOpleidingsPlaats = textBox5.Text,
                        OeNummer = int.Parse(textBox6.Text),
                        OpleidingsCode = int.Parse(textBox7.Text),
                        StartDatum = Convert.ToDateTime(dateTimePicker1.Text),
                        EindDatum = Convert.ToDateTime(dateTimePicker2.Text)

                    });
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

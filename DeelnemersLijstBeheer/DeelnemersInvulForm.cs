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
    public partial class DeelnemersInvulForm : Form
    {
        public DeelnemersInvulForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dateTimePicker1 != null && textBox3.Text != "" && textBox4.Text != "" )
            {
                using(var ctx = new OpleidingDatabaseContext())
                {
                    var DeelnemersVar = ctx.Deelnemers.Add(new Deelnemers
                    {
                        Naam = textBox1.Text,
                        GeboorteDatum = DateTime.Parse(dateTimePicker1.Text),
                        WoonPlaats = textBox3.Text,
                        BadgeNummer = int.Parse(textBox4.Text)

                    });
                }
            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class VakantieInvulForm : Form
    {
        public VakantieInvulForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != null && textBox1.Text != "")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var VakantieVar = ctx.NietOpleidingsDagens.Add(new NietOpleidingsDagen
                    {
                        Datum = DateTime.Parse(dateTimePicker1.Text),
                        Voormiddag = checkBox1.Checked,
                        Namiddag = checkBox2.Checked,
                        OpleidingsId = int.Parse(textBox1.Text)
                    });
                    ctx.SaveChanges();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

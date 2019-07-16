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
            if (textBox1.Text != "" && dateTimePicker1 != null && textBox3.Text != "" && textBox4.Text != ""&& comboBox1.SelectedValue != null )
            {
                
                using(var ctx = new OpleidingDatabaseContext())
                {
                    var Opleiding = ctx.OpleidingsInfos.ToList();
                    


                    var DeelnemersVar = ctx.Deelnemers.Add(new Deelnemers(Opleiding)
                    {
                        Naam = textBox1.Text,
                        GeboorteDatum = DateTime.Parse(dateTimePicker1.Text),
                        WoonPlaats = textBox3.Text,
                        BadgeNummer = int.Parse(textBox4.Text)
                        
                    });
                    
                    ctx.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeelnemersInvulForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                comboBox1.Text = ctx.OpleidingsInfos.Find(1).Opleiding.ToString();
            }
        }
    }
}

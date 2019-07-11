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
    public partial class DocentenInvulForm : Form
    {
        public DocentenInvulForm()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var opleiding = ctx.OpleidingsInfos.ToList();
                    var DocentenVar = ctx.Docentenen.Add(new Docenten(opleiding)
                    {
                        Naam = textBox1.Text,
                        Bedrijf = textBox2.Text
                    });
                    ctx.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocentenInvulForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                comboBox1.Text = ctx.OpleidingsInfos.Find(1).Opleiding.ToString();
            }
        }
    }
}

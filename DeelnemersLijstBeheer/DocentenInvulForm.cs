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
                var selected = comboBox1.SelectedText;
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var opleiding = ctx.OpleidingsInfos.Where(x=> x.Opleiding == selected).ToList();
                    var DocentenVar = ctx.Docentenen.Add(new Docenten(opleiding)
                    {
                        Naam = textBox1.Text,
                        Bedrijf = textBox2.Text
                    });
                    
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

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidName(textBox1.Text, out errorMsg))
            {
                e.Cancel = true;
                textBox1.Select(0, textBox1.Text.Length);

                this.errorProvider1.SetError(textBox1, errorMsg);
            }
        }
        private bool ValidName(string name, out string errorMessage)
        {
            if (name.Length == 0)
            {
                errorMessage = "Name is required.";
                return false;
            }
            if (name.All(char.IsLetter))
            {
                errorMessage = "";
                return true;
            }
            errorMessage = "Name can only contain letters";
            return false;
        }

        private void TextBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidBedrijf(textBox2.Text, out errorMsg))
            {
                e.Cancel = true;
                textBox2.Select(0, textBox2.Text.Length);

                this.errorProvider1.SetError(textBox2, errorMsg);
            }
        }
        private bool ValidBedrijf(string bedrijf, out string errorMessage)
        {
            if (bedrijf.Length == 0)
            {
                errorMessage = "Bedrijf name required.";
                return false;
            }
            if (bedrijf.All(char.IsLetter))
            {
                errorMessage = "";
                return true;
            }
            errorMessage = "Bedrijf can only contain letters";
            return false;
        }

        private void TextBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }
    }
}

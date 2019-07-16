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
    public partial class VakantieAanpassenForm : Form
    {
        NietOpleidingsDagen VakantieDag;
        VakantieDagenForm VakantieDagenForm;
        private string vakantie { get; set; }
        public VakantieAanpassenForm(VakantieDagenForm vakantieDagenForm)
        {
            InitializeComponent();
            VakantieDagenForm = vakantieDagenForm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != null && textBox1.Text != "")
            {
                vakantie = VakantieDagenForm.vakantie;
                using (var ctx = new OpleidingDatabaseContext())
                {
                    VakantieDag = ctx.NietOpleidingsDagens.Where(v => v.Datum == Convert.ToDateTime(vakantie)).FirstOrDefault<NietOpleidingsDagen>();
                    VakantieDag.Datum = DateTime.Parse(dateTimePicker1.Text);
                        VakantieDag.Voormiddag = checkBox1.Checked;
                        VakantieDag.Namiddag = checkBox2.Checked;
                        VakantieDag.OpleidingsId = int.Parse(textBox1.Text);
                    ctx.Entry(VakantieDag).State = System.Data.Entity.EntityState.Modified;
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

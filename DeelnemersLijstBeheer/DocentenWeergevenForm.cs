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
    public partial class DocentenWeergevenForm : Form
    {
        DocentenForm DocentenForm;
        private string docent;
        private void SetDocent(string value)
        {
            docent = value;
        }
        public DocentenWeergevenForm(DocentenForm docentenForm)
        {
            InitializeComponent();
            DocentenForm = docentenForm;
            SetDocent(DocentenForm.docent);
        }

        private void DocentenWeergevenForm_Load(object sender, EventArgs e)
        {
            string deelnemer = DocentenForm.docent;
            using(var ctx = new OpleidingDatabaseContext())
            {
                var id = ctx.Docentenen.Where(c => c.Naam == docent)
                    .Select(c => c.Id).FirstOrDefault();
                var naam = ctx.Docentenen.Where(c => c.Naam == docent)
                    .Select(c => c.Naam).FirstOrDefault();
                var bedrijf = ctx.Docentenen.Where(c => c.Naam == docent)
                    .Select(c => c.Bedrijf).FirstOrDefault();
                label10.Text = id.ToString();
                label9.Text = naam;
                label8.Text = bedrijf;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            DocentenForm.Show();
        }
    }
}

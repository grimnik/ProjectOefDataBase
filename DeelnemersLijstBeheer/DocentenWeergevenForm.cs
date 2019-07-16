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
                var deel = ctx.Docentenen.Where(c => c.Naam == docent)
                                         .Select(c => c.Id + ";" + c.Naam + ";" + c.Bedrijf).ToList();
                foreach (var item in deel)
                {
                    string[] value = item.Split(';');
                    label10.Text = value[0];
                    label9.Text = value[1];
                    label8.Text = value[2];
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            DocentenForm.Show();
        }
    }
}

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
    public partial class DocentenAanpassenForm : Form
    {
        Docenten Docenten;
        DocentenForm DocentenForm;
        ICollection<OpleidingsInfo> Opleiding;


        private string Docent { get; set; }

        public DocentenAanpassenForm(DocentenForm docentenForm)
        {

            InitializeComponent();
            DocentenForm = docentenForm;
            //comboBox1.Items.AddRange()
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2 != null && comboBox1 != null)
            {
                Docent = DocentenForm.docent;

                using (var ctx = new OpleidingDatabaseContext())
                {
                    Docenten = ctx.Docentenen.Where(d => d.Naam == Docent).FirstOrDefault<Docenten>();
                    Opleiding = ctx.OpleidingsInfos.Where(o => o.Opleiding == comboBox1.SelectedText).ToList();
                    Docenten.Naam = textBox1.Text;
                    Docenten.Bedrijf = textBox2.Text;
                    Docenten.OpleidingsInfo = Opleiding;
                    ctx.SaveChanges();
                }

            }

        }

        private void DocentenAanpassenForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleidingen = ctx.OpleidingsInfos.ToArray();
                foreach (var item in opleidingen)
                {

                    comboBox1.Items.Add(item.Opleiding);
                }
            }
        }
    }
}

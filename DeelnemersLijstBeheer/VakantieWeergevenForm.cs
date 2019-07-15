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
    public partial class VakantieWeergevenForm : Form
    {
        VakantieDagenForm vakantieDagen;
        private string vakantieDag;

        private void SetVakantie(string value)
        {
            vakantieDag = value;
        }
        public VakantieWeergevenForm(VakantieDagenForm vakantieDagenForm)
        {
            InitializeComponent();
            vakantieDagen = vakantieDagenForm;
            SetVakantie(vakantieDagen.vakantie);
        }

        private void VakantieWeergevenForm_Load(object sender, EventArgs e)
        {
            DateTime vakantie = Convert.ToDateTime(vakantieDagen.vakantie);
            using (var ctx = new OpleidingDatabaseContext())
            {
                var vakant = ctx.NietOpleidingsDagens.Where(v => v.Datum == vakantie)
                    .Select(v => v.Id + ";" + v.Datum + ";" + v.Voormiddag + ";" + v.Namiddag).ToList();
                foreach (var item in vakant)
                {
                    string[] lines = item.Split(';');

                    label10.Text = lines[0];
                    label9.Text = lines[1];
                    label8.Text = lines[2];
                    label7.Text = lines[3];
                }
            }
        }
    }
}

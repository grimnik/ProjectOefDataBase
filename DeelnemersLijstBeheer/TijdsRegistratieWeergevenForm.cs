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
    public partial class TijdsRegistratieWeergevenForm : Form
    {
        TijdsregistratieForm Tijdsregistratie;
        DateTime Tijd;
        private void SetTijd(DateTime value)
        {
            Tijd = Convert.ToDateTime(value);
        }
        public TijdsRegistratieWeergevenForm(TijdsregistratieForm tijdsregistratieForm)
        {
            InitializeComponent();
            Tijdsregistratie = tijdsregistratieForm;
            SetTijd(Tijdsregistratie.tijd);
        }

        private void TijdsRegistratieWeergevenForm_Load(object sender, EventArgs e)
        {
            DateTime tijd =  Convert.ToDateTime(Tijdsregistratie.tijd);
            using(var ctx = new OpleidingDatabaseContext())
            {
                var tijden = ctx.TijdRegistraties.Where(t => t.DateTime == tijd)
                                                 .Select(t => t.Id +";"+ t.DateTime +";" + t.Deelnemers.Naam ).ToList();
                foreach (var item in tijden)
                {
                    string[] lines = item.Split(';');
                    label8.Text = lines[0];
                    label7.Text = lines[1];
                    label6.Text = lines[2];
                }
            }
        }
    }
}

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
    public partial class OpleidingForm : Form
    {
        public OpleidingForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpleidinginvulForm opleidingForm = new OpleidinginvulForm();
            opleidingForm.ShowDialog();

            

           
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleidingvar = ctx.OpleidingsInfos.Select(o => new
                {
                    
                    o.Instelling,
                    o.Opleiding,
                    o.ContactPersoon,
                    o.OpleidingsPlaats,
                    o.RefOpleidingsPlaats,
                    o.StartDatum,
                    o.EindDatum
                });
                foreach (var item in opleidingvar)
                {
                    Console.WriteLine( item.Instelling + " - " +
                        item.Opleiding +" - "+ item.ContactPersoon +" - "+ item.OpleidingsPlaats +" - "+
                        item.RefOpleidingsPlaats +" - "+ item.StartDatum + " - " + item.EindDatum);
                }
            }
        }
    }
}

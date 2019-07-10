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


            //Console.WriteLine("Geef de opleidingsinstelling op");
            //string instelling = Console.ReadLine();
            //Console.WriteLine("Geef de naam van de opleiding");
            //string opleiding = Console.ReadLine();
            //Console.WriteLine("Geef de contact peroon");
            //string contact = Console.ReadLine();
            //Console.WriteLine("Geef de plaats van de opleiding");
            //string plaats = Console.ReadLine();
            //Console.WriteLine("Geef de ref van de opleidingsplaats");
            //string refplaats = Console.ReadLine();
            //Console.WriteLine("Geef de start datum");
            //DateTime start = Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine("Geef de eind datum");
            //DateTime eind = Convert.ToDateTime(Console.ReadLine());

            //using (var ctx = new OpleidingDatabaseContext())
            //{
            //    var OpleidingVar = ctx.OpleidingsInfos.Add(new OpleidingsInfo
            //    {
            //        Instelling = instelling,
            //        Opleiding = opleiding,
            //        ContactPersoon = contact,
            //        OpleidingsPlaats = plaats,
            //        RefOpleidingsPlaats = refplaats,
            //        StartDatum = start,
            //        EindDatum = eind

            //    });
            //}
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleidingvar = ctx.OpleidingsInfos.Select(o => new
                {
                    o.Id,
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
                    Console.WriteLine(item.Id + " - " + item.Instelling + " - " +
                        item.Opleiding +" - "+ item.ContactPersoon +" - "+ item.OpleidingsPlaats +" - "+
                        item.RefOpleidingsPlaats +" - "+ item.StartDatum + " - " + item.EindDatum);
                }
            }
        }
    }
}

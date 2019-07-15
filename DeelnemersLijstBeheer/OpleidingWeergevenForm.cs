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
    public partial class OpleidingWeergevenForm : Form
    {
        OpleidingForm OpleidingForm;
        private string Opleiding;
        private void SetOpleiding(string value)
        {
            Opleiding = value;
        }
        public OpleidingWeergevenForm(OpleidingForm opleidingForm)
        {
            InitializeComponent();
            OpleidingForm = opleidingForm;
            SetOpleiding(OpleidingForm.opleiding);
        }

        private void OpleidingWeergevenForm_Load(object sender, EventArgs e)
        {
            string opleiding = OpleidingForm.opleiding;
            using (var ctx = new OpleidingDatabaseContext())
            {
                var opleidingInfo = ctx.OpleidingsInfos.Where(o => o.Opleiding == opleiding)
                                                       .Select(o =>o.Id+ ";"+ o.Instelling+ ";" + o.Opleiding +";"+ o.ContactPersoon+";" + o.OpleidingsPlaats+";"+ o.RefOpleidingsPlaats
                                                       + ";" + o.OeNummer + ";" + o.OpleidingsCode + ";" + o.StartDatum + ";" + o.EindDatum).ToList();
                
                
                foreach (var value in opleidingInfo)
                {
                    string[] lines = value.Split(';');
                    label20.Text = lines[0];
                    label19.Text = lines[1];
                    label18.Text = lines[2];
                    label17.Text = lines[3];
                    label16.Text = lines[4];
                    label11.Text = lines[5];
                    label12.Text = lines[6];
                    label13.Text = lines[7];
                    label14.Text = lines[8];
                    label15.Text = lines[9];
                    
                }
            }
        }
    }
}

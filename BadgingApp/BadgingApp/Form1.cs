using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeelnemersLijstBeheer;


namespace BadgingApp
{
    public partial class Form1 : Form
    {
        DateTime time = new DateTime();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = DateTime.Now;
            label1.Text = time.ToString();
            label2.Text = "Kies een opleiding";
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (KiesOpleidingForm Form = new KiesOpleidingForm())
            {

                if (Form.ShowDialog() == DialogResult.OK)
                {
                    label2.Text = Form.PickedOpleiding;
                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "BADGE IN")
            {

                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(1);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    button2.Text = "BADGE OUT";
                    ctx.SaveChanges();

                }
            }
            else if (button2.Text == "BADGE OUT")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(1);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    ctx.SaveChanges();
                    button2.Text = "BADGE IN";
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "BADGE IN")
            {

                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(2);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    button3.Text = "BADGE OUT";
                    ctx.SaveChanges();

                }
            }
            else if (button3.Text == "BADGE OUT")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(2);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    ctx.SaveChanges();
                    button3.Text = "BADGE IN";
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "BADGE IN")
            {

                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(3);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    button4.Text = "BADGE OUT";
                    ctx.SaveChanges();
                    
                }
            }
            else if (button4.Text == "BADGE OUT")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(3);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    ctx.SaveChanges();
                    button4.Text = "BADGE IN";
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "BADGE IN")
            {

                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(4);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    button5.Text = "BADGE OUT";
                    ctx.SaveChanges();

                }
            }
            else if (button5.Text == "BADGE OUT")
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var Deelnemer = ctx.Deelnemers.Find(4);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                    {
                        OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time
                    });
                    ctx.SaveChanges();
                    button5.Text = "BADGE IN";
                }
            }
        }
    }
}

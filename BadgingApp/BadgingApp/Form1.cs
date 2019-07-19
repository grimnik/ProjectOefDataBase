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
            using (var ctx = new OpleidingDatabaseContext())
            {
                for (int i = 1; i < 4; i++)
                {
                    if (ctx.Deelnemers.Find(i) != null)
                    {
                        Deelnemers Deelnemer = ctx.Deelnemers.Find(i);
                        MakeLabel(i, Deelnemer);
                        var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(Deelnemer)
                        {
                            OpleidingsInfo = Deelnemer.OpleidingsInfo.FirstOrDefault(),
                            DateTime = time
                        });
                    }
                    else
                    {
                        break;
                    }
                }
                ctx.SaveChanges();
            }
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
                UserBadged(label3);
                button2.Text = "BADGE OUT";
            }
            else if (button2.Text == "BADGE OUT")
            {
                UserBadged(label3);
                button2.Text = "BADGE IN";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "BADGE IN")
            {
                UserBadged(label4);
                button3.Text = "BADGE OUT";
            }
            else if (button3.Text == "BADGE OUT")
            {
                UserBadged(label4);
                button3.Text = "BADGE IN";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "BADGE IN")
            {
                UserBadged(label5);
                button4.Text = "BADGE OUT";
            }
            else if (button4.Text == "BADGE OUT")
            {
                UserBadged(label5);
                button4.Text = "BADGE IN";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "BADGE IN")
            {
                UserBadged(label6);
                button5.Text = "BADGE OUT";

            }
            else if (button5.Text == "BADGE OUT")
            {
                UserBadged(label6);
                button5.Text = "BADGE IN";
            }
        }
        public void MakeLabel(int teller, Deelnemers deelnemers)
        {
            switch (teller)
            {
                case 1:
                    label3.Text = deelnemers.Naam;
                    break;
                case 2:
                    label4.Text = deelnemers.Naam;
                    break;
                case 3:
                    label5.Text = deelnemers.Naam;
                    break;
                case 4:
                    label6.Text = deelnemers.Naam;
                    break;
                default:
                    break;
            }
        }
        public void UserBadged(Label label)
        {
            if (label2.Text == "Kies een opleiding")
            {
                MessageBox.Show("Kies een opleiding", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (var ctx = new OpleidingDatabaseContext())
                {
                    var deelnemers = ctx.Deelnemers.FirstOrDefault(d => d.Naam == label.Text);
                    var TijdReg = ctx.TijdRegistraties.Add(new Tijdregistraties(deelnemers)
                    {
                        OpleidingsInfo = deelnemers.OpleidingsInfo.FirstOrDefault(),
                        DateTime = time

                    });
                    ctx.SaveChanges();
                }
            }
        }
    }
}

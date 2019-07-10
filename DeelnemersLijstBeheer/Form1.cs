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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpleidingForm opleidingForm = new OpleidingForm();
            opleidingForm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DeelnemersForm deelnemers = new DeelnemersForm();
            deelnemers.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            VakantieDagenForm vakantieDagen = new VakantieDagenForm();
            vakantieDagen.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DocentenForm docenten = new DocentenForm();
            docenten.ShowDialog();
        }
    }
}

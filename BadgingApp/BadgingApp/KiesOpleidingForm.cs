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
    public partial class KiesOpleidingForm : Form
    {
        string selected { get; set; }
        public KiesOpleidingForm()
        {
            InitializeComponent();
        }

        private void KiesOpleidingForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                selected = ctx.OpleidingsInfos.Find(1).Opleiding.ToString();
                comboBox1.Text = selected;
            }
        }
        public string PickedOpleiding
        {
            get { return comboBox1.Text = selected ;  }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}


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
        public KiesOpleidingForm()
        {
            InitializeComponent();
        }

        private void KiesOpleidingForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext())
            {
                comboBox1.Text = ctx.OpleidingsInfos.Find(1).Opleiding.ToString();
            }
        }
        public string PickedOpleiding
        {
            get { return comboBox1.SelectedValue.ToString();  }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}


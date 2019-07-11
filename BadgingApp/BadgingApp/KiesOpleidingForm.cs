using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadgingApp
{
    public partial class KiesOpleidingForm : Form
    {
        public string OpleidingPicked
        {
            get { return comboBox1.SelectedText;  }
        }
        public KiesOpleidingForm()
        {
            InitializeComponent();
        }

        private void KiesOpleidingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'opleidingDataSet.OpleidingsInfoes' table. You can move, or remove it, as needed.
            this.opleidingsInfoesTableAdapter.Fill(this.opleidingDataSet.OpleidingsInfoes);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

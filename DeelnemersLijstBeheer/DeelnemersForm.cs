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
    public partial class DeelnemersForm : Form
    {
        public DeelnemersForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Wat is de naam van de deeln);
            using (var ctx = new OpleidingDatabaseContext())
            {
                var deelnemerVar = new Deelnemers()
                {

                };
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeelnemersLijstBeheer
{

    public partial class DeelnemersForm : Form
    {

        public string deelnemer { get; set; }
        public DeelnemersForm()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            DeelnemersInvulForm deelnemersInvul = new DeelnemersInvulForm();
            deelnemersInvul.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            DeelnemersWeergevenForm deelnemersWeergeven = new DeelnemersWeergevenForm(this);

            deelnemersWeergeven.Show();
            //deelnemer = GetSelectedItem();
        }

        private void DeelnemersForm_Load(object sender, EventArgs e)
        {


            using (var ctx = new OpleidingDatabaseContext())
            {
                var deelnemer = ctx.Deelnemers;
                foreach (var item in deelnemer)
                {
                    listBox1.Items.Add(item.Naam);
                }
            }

        }
        public string GetSelectedItem()
        {
            string selected = listBox1.SelectedItem.ToString();

            return selected;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            deelnemer = GetSelectedItem();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DeelnemerAanpassenForm aanpassenForm = new DeelnemerAanpassenForm(this);
            aanpassenForm.ShowDialog();
            this.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var ctx = new OpleidingDatabaseContext()) 
            {
                var deel = ctx.Deelnemers.FirstOrDefault(x => x.Naam == deelnemer);
                ctx.Deelnemers.Remove(deel);
                
                ctx.SaveChanges();
            }

        }
    }
}

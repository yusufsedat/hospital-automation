using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sql
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaForm hastaForm = new HastaForm();
            hastaForm.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            personel2 personel2 = new personel2();
            personel2.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sql
{
    public partial class personel2 : Form
    {
        public personel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)


        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saglikpers saglikpers = new saglikpers();
            saglikpers.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            digerpersonel personel = new digerpersonel();
            personel.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Personel pers = new Personel();
            pers.Show();

        }
    }
}

using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sql
{
    public partial class maas : Form
    {
        public maas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maas_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(Convert.ToInt32("1"));
            comboBox1.Items.Add(Convert.ToInt32("2"));
            comboBox1.Items.Add(Convert.ToInt32("3"));
            comboBox1.Items.Add(Convert.ToInt32("4"));
            comboBox1.Items.Add(Convert.ToInt32("5"));
            comboBox1.Items.Add(Convert.ToInt32("6"));
            comboBox1.Items.Add(Convert.ToInt32("7"));
            comboBox1.Items.Add(Convert.ToInt32("8"));
            comboBox1.Items.Add(Convert.ToInt32("9"));
            comboBox1.Items.Add(Convert.ToInt32("10"));

            //baglanti.Open();
            //string sorgu = "select* from personel";
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            //DataTable ds = new DataTable();
            //da.Fill(ds);
            //comboBox2.DisplayMember = "adsoyad";
            //comboBox2.ValueMember = "personelno";
            //comboBox2.DataSource = ds;
            //baglanti.Close();

        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbhastane; username=postgres; password=123456");


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into maas(ucretno,calisilansaat,saatlikucret) values (@p1,@p2,@p3); ", baglanti);
            //NpgsqlCommand komut2 = new NpgsqlCommand("insert into personel(personelno) values (@p5); ", baglanti);


            
            
                komut1.Parameters.AddWithValue("@p1", int.Parse(txtucretno.Text));
                komut1.Parameters.AddWithValue("@p3", int.Parse(ucrettxt.Text));
                komut1.Parameters.AddWithValue("@p2", Convert.ToInt32( comboBox1.SelectedItem));
                

                                
                komut1.ExecuteNonQuery();
                MessageBox.Show("Eklendi");



            int ucret, saat, sonuc;

            ucret = Convert.ToInt32(ucrettxt.Text);
            saat = Convert.ToInt32(comboBox1.SelectedItem);

            sonuc = ucret * saat;

            sonuc *= 30;


            label4.Text = sonuc.ToString();








            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

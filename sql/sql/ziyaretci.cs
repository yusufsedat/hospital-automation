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
    public partial class ziyaretci : Form
    {
        public ziyaretci()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbhastane; username=postgres; password=123456");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select*from ziyaretci ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into ziyaretci (ziyaretcino,adsoyad) values (@p1,@p2); ", baglanti);
            try
            {
                komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut1.Parameters.AddWithValue("@p2", textBox2.Text);
                komut1.ExecuteNonQuery();
                MessageBox.Show("Eklendi");


            }


            catch (Exception hata)
            {
                MessageBox.Show("Hata var\n");
            }

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from ziyaretci where ziyaretcino=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ziyaretci silindi.", "Bilgi", MessageBoxButtons.OK);
        }
    }
}

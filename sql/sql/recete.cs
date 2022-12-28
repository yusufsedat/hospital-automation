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
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbhastane; user ID=postgres; password=123456");

        private void recete_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select* from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable ds = new DataTable();
            da.Fill(ds);
            comboBox2.DisplayMember = "adsoyad";
            comboBox2.ValueMember = "hastano";
            comboBox2.DataSource = ds;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter dad = new NpgsqlDataAdapter("select*from ilac", baglanti);
            DataTable dt = new DataTable();
            dad.Fill(dt);
            comboBox1.DisplayMember = "ilacadi";
            comboBox1.ValueMember = "ilacno";
            comboBox1.DataSource = dt;
            baglanti.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into recete(receteno,ilac,hasta) values (@p1,@p2,@p3); ", baglanti);
            try
            {
                komut1.Parameters.AddWithValue("@p1", int.Parse(recetetxt.Text));
                komut1.Parameters.AddWithValue("@p2", comboBox1.SelectedValue);
                komut1.Parameters.AddWithValue("@p3", comboBox2.SelectedValue);
                komut1.ExecuteNonQuery();
                MessageBox.Show("Eklendi");

               
            }


            catch (Exception hata)
            {
                MessageBox.Show("Hata var\n");
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "select recete.receteno,ilac.ilacadi,hasta.adsoyad from recete inner join ilac on recete.ilac=ilac.ilacno inner join hasta on recete.hasta=hasta.hastano";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from recete where recete.hasta=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Recete silindi.", "Bilgi", MessageBoxButtons.OK);
        }
    }
}

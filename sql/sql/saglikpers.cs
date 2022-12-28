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
    public partial class saglikpers : Form
    {
        public saglikpers()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbhastane; username=postgres; password=123456");


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select saglikpersoneli.personelno,saglikpersoneli.meslek,personel.adsoyad,personel.yas,personel.cinsiyet,personel.calismadurumu,sehir.ad as sehir,bolum.bolumadi as bolum from saglikpersoneli inner join personel on personel.personelno=saglikpersoneli.personelno inner join sehir on personel.sehir=sehir.plaka inner join bolum on personel.bolum=bolum.bolumno ORDER BY personelno ASC ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void saglikpers_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select* from sehir";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable ds = new DataTable();
            da.Fill(ds);
            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "plaka";
            comboBox1.DataSource = ds;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter dad = new NpgsqlDataAdapter("select*from bolum", baglanti);
            DataTable dt = new DataTable();
            dad.Fill(dt);
            comboBox2.DisplayMember = "bolumadi";
            comboBox2.ValueMember = "bolumno";
            comboBox2.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into personel(personelno,adsoyad,yas,cinsiyet,calismadurumu,sehir,bolum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7); ", baglanti);

            
                komut1.Parameters.AddWithValue("@p1", int.Parse(perstxt.Text));
                komut1.Parameters.AddWithValue("@p2", adtxt.Text);
                komut1.Parameters.AddWithValue("@p3", yastxt.Text);
                komut1.Parameters.AddWithValue("@p4", cinstxt.Text);
                komut1.Parameters.AddWithValue("@p6", comboBox1.SelectedValue);
                komut1.Parameters.AddWithValue("@p5", calismatxt.Text);
                komut1.Parameters.AddWithValue("@p7", comboBox2.SelectedValue);
               

              
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into saglikpersoneli(personelno,meslek) values (@p8,@p9) ; ", baglanti);
            
            komut2.Parameters.AddWithValue("@p8", int.Parse(perstxt.Text));
            komut2.Parameters.AddWithValue("@p9", meslektxt.Text);
            

            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();

            MessageBox.Show("Eklendi");
            baglanti.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try


            {
                NpgsqlCommand komut2 = new NpgsqlCommand("delete from saglikpersoneli where personelno=@p1 ", baglanti);
                NpgsqlCommand komut3 = new NpgsqlCommand("delete from personel where personelno=@p2 ", baglanti);

                komut3.Parameters.AddWithValue("@p2", int.Parse(perstxt.Text));
                komut2.Parameters.AddWithValue("@p1", int.Parse(perstxt.Text));
                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery();
                MessageBox.Show("Personel silindi.", "Bilgi", MessageBoxButtons.OK);

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());


            }
           

            baglanti.Close();
            
        }
    }
}

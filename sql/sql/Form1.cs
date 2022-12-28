using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql
{
    public partial class HastaForm : Form
    {
        public HastaForm()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbhastane; username=postgres; password=123456");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select* from personel";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable ds = new DataTable();
            da.Fill(ds);
            comboBox1.DisplayMember = "adsoyad";
            comboBox1.ValueMember = "personelno";
            comboBox1.DataSource = ds;
           

            string sorgu2 = "select* from ziyaretci";
            NpgsqlDataAdapter dad = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataTable dss = new DataTable();
            dad.Fill(dss);
            comboBox2.DisplayMember = "adsoyad";
            comboBox2.ValueMember = "ziyaretcino";
            comboBox2.DataSource = dss;
            

            string sorgu3 = "select* from tedavi ";
            NpgsqlDataAdapter dar = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataTable dsa = new DataTable();
            dar.Fill(dsa);
            comboBox3.DisplayMember = "ad";
            comboBox3.ValueMember = "tedavino";
            comboBox3.DataSource = dsa;
            

            string sorgu4 = "select* from bolum order by bolumno ASC";
            NpgsqlDataAdapter daa = new NpgsqlDataAdapter(sorgu4, baglanti);
            DataTable dsq = new DataTable();
            daa.Fill(dsq);
            comboBox4.DisplayMember = "bolumadi";
            comboBox4.ValueMember = "bolumno";
            comboBox4.DataSource = dsq;
            


            NpgsqlDataAdapter dat = new NpgsqlDataAdapter("select*from oda where bolum=" + Convert.ToInt32( comboBox4.SelectedValue), baglanti);
            DataTable dsw = new DataTable();
            dat.Fill(dsw);
            comboBox5.DisplayMember = "odano";
            comboBox5.ValueMember = "odano";
            comboBox5.DataSource = dsw;

            baglanti.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select hasta.hastano,hasta.adsoyad,hasta.yas,hasta.cinsiyet,hasta.hastalik,hasta.saglikdurum,oda,bolum.bolumadi,personel.adsoyad as personeladsoyad, ziyaretci.adsoyad as ziyaretciadsoyad,tedavi.ad as tedavi from hasta inner join bolum on hasta.bolum=bolum.bolumno inner join personel on hasta.ilgilenenpersonel=personel.personelno inner join ziyaretci on hasta.ziyaretci=ziyaretci.ziyaretcino inner join tedavi on hasta.tedavi=tedavi.tedavino";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hasta(hastano,adsoyad,yas,cinsiyet,hastalik,saglikdurum,oda,bolum,ilgilenenpersonel,ziyaretci,tedavi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11); ", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txtHasta.Text));
            komut1.Parameters.AddWithValue("@p2", txtAd.Text);
            komut1.Parameters.AddWithValue("@p3", txtYas.Text);
            komut1.Parameters.AddWithValue("@p4", txtCins.Text);
            komut1.Parameters.AddWithValue("@p5", txtHastalik.Text);
            komut1.Parameters.AddWithValue("@p6", txtdurum.Text);
            komut1.Parameters.AddWithValue("@p7", Convert.ToInt32((comboBox5.SelectedValue)));
            komut1.Parameters.AddWithValue("@p8", Convert.ToInt32((comboBox4.SelectedValue)));
            komut1.Parameters.AddWithValue("@p9", Convert.ToInt32((comboBox1.SelectedValue)));
            komut1.Parameters.AddWithValue("@p10", Convert.ToInt32((comboBox3.SelectedValue)));
            komut1.Parameters.AddWithValue("@p11", Convert.ToInt32((comboBox2.SelectedValue)));


            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            recete recete = new recete();
            recete.Show();


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from hasta where hastano=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtHasta.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hasta silindi.","Bilgi",MessageBoxButtons.OK);


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("update hasta set hastalik=@p5,saglikdurum=@p6,oda=@p7,bolum=@p8,ilgilenenpersonel=@p9,ziyaretci=@p10,tedavi=@p11 where hastano=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtHasta.Text));
            komut2.Parameters.AddWithValue("@p5", txtHastalik.Text);
            komut2.Parameters.AddWithValue("@p6", txtdurum.Text);
            komut2.Parameters.AddWithValue("@p7", Convert.ToInt32((comboBox5.SelectedValue)));
            komut2.Parameters.AddWithValue("@p8", Convert.ToInt32((comboBox4.SelectedValue)));
            komut2.Parameters.AddWithValue("@p9", Convert.ToInt32((comboBox1.SelectedValue)));
            komut2.Parameters.AddWithValue("@p10", Convert.ToInt32((comboBox3.SelectedValue)));
            komut2.Parameters.AddWithValue("@p11", Convert.ToInt32((comboBox2.SelectedValue)));


            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ziyaretci ziyaretci = new ziyaretci();
            ziyaretci.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int srg = int.Parse(txtHasta.Text);

            string sorgu = "select hasta.hastano,hasta.adsoyad,hasta.yas,hasta.cinsiyet,hasta.hastalik,hasta.saglikdurum,oda,bolum.bolumadi,personel.adsoyad as personeladsoyad, ziyaretci.adsoyad as ziyaretciadsoyad,tedavi.ad as tedavi from hasta inner join bolum on hasta.bolum=bolum.bolumno inner join personel on hasta.ilgilenenpersonel=personel.personelno inner join ziyaretci on hasta.ziyaretci=ziyaretci.ziyaretcino inner join tedavi on hasta.tedavi=tedavi.tedavino where hastano="+srg;

            
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sorgu, baglanti);

            DataSet ds = new DataSet();

            adap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();
        }
    }
}

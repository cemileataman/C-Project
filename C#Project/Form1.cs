using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace C_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-QC46GK8\\SQLEXPRESS;Initial Catalog=OgrenciProje;Integrated Security=True");
        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * from OgrenciListesi", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ogrenciProjeDataSet1.OgrenciListesi' table. You can move, or remove it, as needed.
          

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.ogrenciListesiTableAdapter.Fill(this.ogrenciProjeDataSet1.OgrenciListesi);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into OgrenciListesi (Ad,SoyAd,TC,Telefon,Sifre,Cinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTc.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Delete from OgrenciListesi Where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", Txtid.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Update OgrenciListesi set Ad=@p1,Soyad=@p2,TC=@p3,Telefon =@p4,Sifre=@p5,Cinsiyet=@p6 where id=@p7", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", MskTc.Text);
            komut2.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p7", Txtid.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            CmbCinsiyet.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
    }
}

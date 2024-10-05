using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void temizle ()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMaas.Text = "";
            txtJob.Text = "";
            txtid.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        SqlConnection sql = new SqlConnection("Data Source=emre\\MSSQLSERVER01;Initial Catalog=Personel;Integrated Security=True;Encrypt=False");
        private void button5_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand komutupdate = new SqlCommand("Update PersonelDB Set  PerAd = @u1 ,PerSoyad = @u2, PerMaas = @u3, PerDurum = @u4 ,PerMeslek = @u5 where Perid = @u6  ", sql);
            komutupdate.Parameters.AddWithValue("@u1", txtAd.Text);
            komutupdate.Parameters.AddWithValue("@u2", txtSoyad.Text);
            komutupdate.Parameters.AddWithValue("@u3", txtMaas.Text);
            komutupdate.Parameters.AddWithValue("@u4", label9.Text);
            komutupdate.Parameters.AddWithValue("@u5", txtJob.Text);
            komutupdate.Parameters.AddWithValue("@u6", txtid.Text);
            komutupdate.ExecuteNonQuery();
            


            sql.Close();
            MessageBox.Show("Personel Bilgi Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelDataSet1.PersonelDB' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelDBTableAdapter.Fill(this.personelDataSet1.PersonelDB);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personelDBTableAdapter.Fill(this.personelDataSet1.PersonelDB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand komut = new SqlCommand("insert into PersonelDB (PerAd,PerSoyad,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5)",sql);
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtMaas.Text);
            komut.Parameters.AddWithValue("@p4", label8.Text);
            komut.Parameters.AddWithValue("@p5", txtJob.Text);
            komut.ExecuteNonQuery();
            sql.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = 1.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = 0.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtJob.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            if (label9.Text == "True")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand komutsil = new SqlCommand("Delete from PersonelDB where Perid= @k1",sql);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();

            sql.Close();
        }
    }
}

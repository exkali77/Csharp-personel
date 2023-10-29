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

namespace Personel_Tablo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection balanti = new SqlConnection("Data Source = DESKTOP-EASQMRG\\SQLEXPRESS;Initial Catalog = PersonsDatabase; Integrated Security = True");

        void Delet()
        {
            TSoyad.Text = "";
            TAd.Text = "";
            cseir.Text = "";
            Tstatu.Text = "";
            mass.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personsDatabaseDataSet.Table_PersonsDatabes' table. You can move, or remove it, as needed.
           

        }

        private void listins_Click(object sender, EventArgs e)
        {
            this.table_PersonsDatabesTableAdapter.Fill(this.personsDatabaseDataSet.Table_PersonsDatabes);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            balanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_PersonsDatabes(PerAd,PerSoyad,perSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",balanti);
            komut.Parameters.AddWithValue("@p1", TAd.Text);
            komut.Parameters.AddWithValue("@p2", TSoyad.Text);
            komut.Parameters.AddWithValue("@p4",mass.Text);
            komut.Parameters.AddWithValue("@p3", cseir.Text);
            komut.Parameters.AddWithValue("@p5", Tstatu.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            balanti.Close();
            MessageBox.Show("personel ekle");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                label8.Text = "true";
            } 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked==false)
            {
                label8.Text = "False";
            }
        }

        private void cseir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            balanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Table_PersonsDatabes where ID_Persons=@k1",balanti);
            komutsil.Parameters.AddWithValue("@k1", ID.Text);
            komutsil.ExecuteNonQuery();
            balanti.Close();
            MessageBox.Show("Silindi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            ID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
           cseir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mass.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            Tstatu.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton2.Checked = true;
            }
            if (label8.Text=="False")
            {
                radioButton1.Checked = true;
            }
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            Delet();
        }

        private void Upgrete_Click(object sender, EventArgs e)
        {
            balanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Upgrete Table_PersonsDatabes Set PerAd=@a1,PerSoyad=@a2,perSehir=@a3 , PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where ID_Persons=@a7", balanti);
            komutguncelle.Parameters.AddWithValue("@a1", TAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cseir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mass.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", Tstatu.Text);
            komutguncelle.Parameters.AddWithValue("@a7", ID.Text);
            komutguncelle.ExecuteNonQuery();
            balanti.Close();
            MessageBox.Show("Güncellendi");
        }
    }
}

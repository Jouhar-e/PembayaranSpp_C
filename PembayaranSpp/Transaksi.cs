using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PembayaranSpp
{
    public partial class Transaksi : UserControl
    {

        public Transaksi()
        {
            InitializeComponent();
        }

        Module md = new Module();
        string id;
        public string idpetugas;

        public void awal()
        {
            dataGridView1.DataSource = md.getData("SELECT * FROM siswa WHERE siswa LIKE '%" + textBox1.Text + "%'");
            md.clearForm(groupBox2);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Siswa";
            dataGridView1.Columns[2].HeaderText = "Kelas";
            dataGridView1.Columns[3].HeaderText = "Jurusan";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            id = "0";
        }

        void buka()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lSiswa.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                buka();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            awal();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            md.onlyNumber(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                md.pesan("Data Masih Kosong");
            }
            else
            {
                string sql = "INSERT INTO pembayaran VALUES ('" + idpetugas + "','" + id + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString("MMMM") + "','" + dateTimePicker2.Value.ToString("yyyy") + "','" + dateTimePicker3.Value.ToString("yyyy/MM/dd") + "')";
                //md.pesan(sql);
                if (md.dialogForm("Apakah Transaksi Sudah Benar?"))
                {
                    md.exc(sql);
                    md.pesan("Transaksi Berhasil");
                    awal();
                    }
            }
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            awal();
        }
    }
}

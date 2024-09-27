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

namespace PembayaranSpp
{
    public partial class MasterSiswa : UserControl
    {
        public MasterSiswa()
        {
            InitializeComponent();
        }

        Module md = new Module();
        string id, sql;
        bool aksi = true;

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
            groupBox3.Enabled = true;
            id = "0";
            aksi = true;
        }

        void buka()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buka();
            md.clearForm(groupBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                MessageBox.Show("Pilih Data Terlebih Dahulu");
            }
            else
            {
                aksi = false;
                buka();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            awal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                MessageBox.Show("Pilih Data Terlebih Dahulu");
            }
            else
            {
                if (md.dialogForm("Apakah Anda ingin menghapus data " + textBox2.Text))
                {
                    sql = "DELETE FROM siswa WHERE idsiswa = " + id;
                    //md.pesan(sql);
                    md.exc(sql);
                    md.pesan("Berhasil Dihapus");
                    awal();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (md.adaKosong(groupBox2))
            {
                MessageBox.Show("Data masih kosong");
            }
            else
            {
                if (aksi)
                {
                    sql = "INSERT INTO siswa VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    //md.pesan(sql);
                    md.exc(sql);
                    md.pesan("Berhasil Ditambahkan");
                    awal();
                }
                else
                {
                    sql = "UPDATE siswa SET siswa = '" + textBox2.Text + "',kelas = '" + textBox3.Text + "',jurusan = '" + textBox4.Text + "'WHERE idsiswa = " + id;
                    //md.pesan(sql);
                    md.exc(sql);
                    md.pesan("Berhasil Diubah");
                    awal();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void MasterSiswa_Load(object sender, EventArgs e)
        {
            awal();
        }
    }
}

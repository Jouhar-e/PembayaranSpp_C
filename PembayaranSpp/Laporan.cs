using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PembayaranSpp
{
    public partial class Laporan : UserControl
    {
        public Laporan()
        {
            InitializeComponent();
        }

        Module md = new Module();

        public void awal()
        {
            string sql = "SELECT idpembayaran, siswa, kelas, jurusan, petugas, jumlahbayar, bulan, tahun, tglbayar FROM vpembayaran WHERE siswa LIKE '%" + textBox1.Text + "%' OR petugas LIKE '%" + textBox1.Text + "%' ORDER BY tglbayar ASC";
            //md.pesan(sql);
            dataGridView1.DataSource = md.getData(sql);
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Siswa";
            dataGridView1.Columns[2].HeaderText = "Kelas";
            dataGridView1.Columns[3].HeaderText = "Jurusan";
            dataGridView1.Columns[4].HeaderText = "Petugas";
            dataGridView1.Columns[5].HeaderText = "Jumlah Bayar";
            dataGridView1.Columns[6].HeaderText = "Bulan Yang Di Bayar";
            dataGridView1.Columns[7].HeaderText = "Tahun Yang Di Bayar";
            dataGridView1.Columns[8].HeaderText = "Tanggal Bayar";
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application xlaapp;
                Microsoft.Office.Interop.Excel.Workbook xlworkbook;
                Microsoft.Office.Interop.Excel.Worksheet xlworksheet;
                object missvalue = System.Reflection.Missing.Value;
                int i;
                int j;

                xlaapp = new Microsoft.Office.Interop.Excel.Application();
                xlworkbook = xlaapp.Workbooks.Add(missvalue);
                xlworksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlworkbook.Sheets["sheet1"];

                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        for (int k = 1; k <= dataGridView1.Columns.Count; k++)
                        {
                            xlworksheet.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;
                            xlworksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                        }
                    }
                }

                xlworksheet.SaveAs(saveFileDialog1.FileName);
                xlworkbook.Close();
                xlaapp.Quit();

                ReleaseObject(xlaapp);
                ReleaseObject(xlworkbook);
                ReleaseObject(xlworksheet);

                MessageBox.Show("Ekspor Berhasil");
            }
        }
    }
}

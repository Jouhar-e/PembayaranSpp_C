using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PembayaranSpp.LoginControl;

namespace PembayaranSpp
{
    public partial class Form1 : Form
    {

        MasterControl mc = new MasterControl();
        Beranda br = new Beranda();
        Transaksi tr = new Transaksi();
        LoginControl lg = new LoginControl();
        Laporan lp = new Laporan();
        Module md = new Module();
        Ucoba coba = new Ucoba();

        public string idpetugas = "0";

        public Form1()
        {
            InitializeComponent();
            lg.DataSent += MyUserControl1_DataSent;
        }

        private void MyUserControl1_DataSent(object sender, DataEventArgs e)
        {
            // Tampilkan data yang diterima
            //MessageBox.Show("Data diterima dari UserControl: " + data);

            // Bisa juga menyimpan data ke kontrol lain di Form
            idpetugas = e.Data1;
            tr.idpetugas = e.Data1;
            br.lPetugas.Text = e.Data2;

            //untuk menampikan sidebar dan beranda
            groupBox1.Visible = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(br);
            br.Dock = DockStyle.Fill;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(mc);
            mc.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(br);
            br.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(lg);
            lg.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(tr);
            tr.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(lp);
            lp.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (md.dialogForm("Apakah Anda Yakin Ingin Keluar?"))
            {
                idpetugas = "0";
                groupBox1.Visible = false;
                panel2.Controls.Clear();
                panel2.Controls.Add(lg);
                lg.Dock = DockStyle.Fill;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(coba);
            coba.Dock = DockStyle.Fill; 
        }

   
    }
}

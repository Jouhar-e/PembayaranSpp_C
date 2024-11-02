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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        Module md = new Module();   
        Form1 fm = new Form1();
        Beranda br = new Beranda();

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM petugas WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
            //md.pesan(md.getCount(sql) + "");

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                md.pesan("Username atau Password kosong");
            }
            else
            {
                if (md.getCount(sql) > 0)
                {
                    md.pesan("Login Berhasil");
                    fm.idpetugas = md.getValue(sql, "idpetugas");
                    br.lPetugas.Text = md.getValue(sql, "petugas");
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                }
                else
                {
                    md.pesan("Username atau Password salah");
                }
            }
        }
    }
}

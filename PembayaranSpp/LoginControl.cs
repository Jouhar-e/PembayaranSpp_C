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
    public partial class LoginControl : UserControl
    {

        public event EventHandler<DataEventArgs> DataSent;
        Module md = new Module();

        public LoginControl()
        {
            InitializeComponent();
        }

        string data1;
        string data2;

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
                    data1 = md.getValue(sql, "idpetugas");
                    data2 = md.getValue(sql, "petugas");
                    textBox1.Clear();
                    textBox2.Clear();
                    DataSent?.Invoke(this, new DataEventArgs(data1, data2));
                }
                else
                {
                    md.pesan("Username atau Password salah");
                }
            }

        }

        public class DataEventArgs : EventArgs
        {
            public string Data1 { get; }
            public string Data2 { get; }

            public DataEventArgs(string data1, string data2)
            {
                Data1 = data1;
                Data2 = data2;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

    }
}

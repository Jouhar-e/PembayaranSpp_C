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
    public partial class MasterControl : UserControl
    {
        MasterPetugas mp = new MasterPetugas();
        MasterSiswa ms = new MasterSiswa();

        public MasterControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(mp);
            mp.Dock = DockStyle.Fill;
        }

        private void MasterControl_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(mp);
            mp.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ms);
            ms.Dock = DockStyle.Fill;
        }
    }
}

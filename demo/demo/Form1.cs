using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seminarDataSet.thongtin' table. You can move, or remove it, as needed.
            this.thongtinTableAdapter.Fill(this.seminarDataSet.thongtin);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thongtinTableAdapter.Update(seminarDataSet.thongtin);
            this.thongtinTableAdapter.Fill(this.seminarDataSet.thongtin);
        }
    }
}

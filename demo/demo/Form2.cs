using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=TIENSY-PC;Initial Catalog=Seminar;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataAdapter da;
        public Form2()
        {
            InitializeComponent();
            loadlistview();
            LoadDataGrid();
        }
        public void loadlistview()
        {
            con.Open();
            cmd = new SqlCommand("Select * from thongtin", con);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            dt = ds.Tables["Table"];
            int i = 0;
          
            foreach (DataRow dr in dt.Rows)
            {
                listView1.Items.Add(dr["MaNV"].ToString());
                listView1.Items[i].SubItems.Add(dr["Ten"].ToString());
                listView1.Items[i].SubItems.Add(dr["Diachi"].ToString());
                i++;


            }
        }


        public void LoadDataGrid()
        {
            con.Open();
            cmd = new SqlCommand("Select * from thongtin", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                textBox1.Text = items.SubItems[0].Text;
                textBox2.Text = items.SubItems[1].Text;
                textBox3.Text = items.SubItems[2].Text;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}

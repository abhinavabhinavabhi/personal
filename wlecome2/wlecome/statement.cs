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

namespace wlecome
{
    public partial class statement : Form
    { int cust;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        public statement(int cust_id)
        {
            cust = cust_id;
            InitializeComponent();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [transaction] where cust_id='"+cust_id+"' order by trn_id desc", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd.CommandText, con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashbord ds = new dashbord(cust);
            ds.ShowDialog();
        }
    }
}

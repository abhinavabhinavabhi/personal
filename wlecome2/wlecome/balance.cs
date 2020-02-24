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
    public partial class balance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id;
        public balance(int cus)
        {
            cust_id = cus;
            InitializeComponent();
        }

        private void balance_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from account,customer where account.cust_id='" + cust_id + "' and account.cust_id=customer.cust_id", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    accno.Text = Convert.ToString(reader["acc_no"]);
                    cust.Text = Convert.ToString(reader["cust_id"]);
                    bal.Text = Convert.ToString(reader["balance"]);
                    name.Text = Convert.ToString(reader["cust_name"]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashbord ds = new dashbord(cust_id);
            this.Hide();
            ds.ShowDialog();
        }
    }
}

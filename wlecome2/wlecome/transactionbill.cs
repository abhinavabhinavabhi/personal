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
    public partial class transactionbill : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        
        int amt, cust_id;
        string name;
        public transactionbill(int a,int cust,string nam)
        {
            
            InitializeComponent();
            amt = a;
            MessageBox.Show("transaction sucsess");
            name = nam;
            cname.Text = name;
            cust_id = cust;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select TOP 1 * from [transaction] where cust_id='"+cust_id+"' order by trn_id desc";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    tran.Text = Convert.ToString(reader["trn_id"]);
                    dat.Text = Convert.ToString(reader["date"]);
                    wamt.Text = Convert.ToString(reader["amount"]);


                }

            }
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from account where cust_id='" + cust_id + "'";
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {

                    balance.Text = Convert.ToString(reader["balance"]);
                    accno.Text = Convert.ToString(reader["acc_no"]);


                }

            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            login l = new login();
            this.Hide();
            l.ShowDialog();
        }

        private void transactionbill_Load(object sender, EventArgs e)
        {
            
        }
    }
}

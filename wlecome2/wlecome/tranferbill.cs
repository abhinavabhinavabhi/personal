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
    public partial class tranferbill : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id, accno;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.ShowDialog();
        }

        public tranferbill(int cust,int acc )
        {
            cust_id = cust;
            accno = acc;
            InitializeComponent();
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from account where cust_id='" + cust_id + "'", con);
            using (SqlDataReader rd = cmd.ExecuteReader())
            {if (rd.Read())
                {


                    label11.Text = Convert.ToString(rd["balance"]);
                    label14.Text = Convert.ToString(cust_id);
                    label9.Text = Convert.ToString(accno);
                    label8.Text = Convert.ToString(rd["acc_no"]);
                }
            }
            SqlCommand cmd1 = new SqlCommand("select top 1 * from [transaction] where cust_id='" + cust_id + "' order by trn_id desc", con);
            using (SqlDataReader rd1 = cmd1.ExecuteReader())
            {
                if (rd1.Read())
                {
                    label6.Text = Convert.ToString(rd1["trn_id"]);
                    label7.Text = Convert.ToString(rd1["date"]);
                    label10.Text = Convert.ToString(rd1["amount"]);

                }
            }
            con.Close();




        }
    }
}

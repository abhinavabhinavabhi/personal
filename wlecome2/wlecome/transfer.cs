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
    public partial class transfer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id;
        int accno = 0;
        int amd = 0;
        public transfer(int cust)
        {
            cust_id = cust;
            InitializeComponent();
        }

        private void transfer_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int balance = 0;
            string acctype = null;
            try
            {


                amd = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("invalid amound");
                textBox2.Clear();

            }
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from account where cust_id='" + cust_id + "'", con);
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if(rd.Read())
                {
                    balance = Convert.ToInt32(rd["balance"]);
                    acctype = Convert.ToString(rd["acc_type"]);
                }
            }
            var time = DateTime.Now;
            string dt = time.ToString("dd:MM:yyyy hh:mm");
            if(balance>=amd)
            {
                SqlCommand cmd2 = new SqlCommand("insert into [transaction] (date,amount,cust_id) values('" + dt + "','" + amd + "','" + cust_id + "')",con);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("update account set balance=balance-'"+amd+"' where cust_id='"+cust_id+"'", con);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("update account set balance=balance+'" + amd + "' where acc_no='" + accno+ "'", con);
                cmd4.ExecuteNonQuery();
                MessageBox.Show("transfer sucess");
                this.Hide();
                tranferbill tf = new tranferbill(cust_id, accno);
                tf.ShowDialog();

            }
            else
            {
                MessageBox.Show("Insufficent balance");
                textBox2.Clear();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==textBox3.Text)
            {
                try
                {


                    accno = Convert.ToInt32(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("enter valid account number");
                }
            }
            else
            {
                MessageBox.Show("account number didnt matched");
                textBox3.Clear();
                textBox1.Clear();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from account where acc_no='" + accno + "'",con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd.CommandText, con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if(dt.Rows.Count==1)
            {
                groupBox1.Hide();
            }
            else
            {
                MessageBox.Show("invalid account n.o");
                textBox1.Clear();
                textBox3.Clear();
            }
            con.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashbord ds = new dashbord(cust_id);
            ds.ShowDialog();

        }
    }
}

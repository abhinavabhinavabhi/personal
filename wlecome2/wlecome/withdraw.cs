using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Data.SqlClient;

namespace wlecome
{
    public partial class withdraw : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id;
        System.Timers.Timer t;
        int s=0;
        public withdraw(int cust)
        {
            InitializeComponent();
            label2.Hide();
            cust_id = cust;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("enter valid amount");
                textBox1.Clear();
            }
            if (s == 0)
            {
                MessageBox.Show("enter amount");
                textBox1.Clear();
            }
            else if(s>40000)
            {
                MessageBox.Show("atm limit crossed");
                textBox1.Clear();
            }
            else
            {

                if ((s % 100) == 0)
                {
                    label2.Show();
                   t= new System.Timers.Timer(1000);
                    t.Elapsed += T_Elapsed;
                    t.AutoReset = false;
                    t.Enabled = true;




                }
                else
                {
                    MessageBox.Show("ATM conatain only denominations of 100");
                    textBox1.Clear();

                }
            }
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            withdrawamt(s);
        }
        public void withdrawamt(int s)
        {
            int balance = 0;
            string name = null;
            var time = DateTime.Now;
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            string dt = time.ToString("dd/MM/yyyy:::hh:mm:ss");
            cmd1.CommandText = "insert into [transaction] (date,amount,cust_id) values('" + dt + "','" + s + "','" + cust_id + "')";
            cmd1.ExecuteNonQuery();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from account,customer where customer.cust_id=account.cust_id and customer.cust_id='" + cust_id + "' ";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    balance = Convert.ToInt32(reader["balance"]);
                    name = Convert.ToString(reader["cust_name"]);



                }

            }
            con.Close();
            if (balance < s)
            {
                label2.Hide();
                MessageBox.Show("Insufficient balance");
                textBox1.Clear();
            }
            else
            {
                con.Open();
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                int newb = balance - s;
                cmd3.CommandText = "update account set balance='" + newb + "' where cust_id='" + cust_id + "'";
                cmd3.ExecuteNonQuery();
                con.Close();
                transactionbill tr = new transactionbill(s, cust_id, name);
                this.Hide();
                tr.ShowDialog();
            }
        }

        private void withdraw_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashbord ds = new dashbord(cust_id);
            ds.ShowDialog();

        }
    }
}

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
    public partial class pinchange : Form
    { int cust_id;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        public pinchange(int cust)
        {
            cust_id = cust;
            InitializeComponent();
            groupBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int passw = 0;
            int pas=0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select password from customer where cust_id='" + cust_id + "'";
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                if(read.Read())
                {
                    passw = Convert.ToInt32(read["password"]);
                    
                }
            }
            con.Close();
            try
            {
                pas = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("enter vaid password");
                textBox1.Clear();
            }
            if(passw==pas)
            {
                button1.Hide();
                groupBox1.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Password");
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text==textBox3.Text)
            {
                int password=0;
                try
                {
                    password = Convert.ToInt32(textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("password should contain only number");
                }
                if (password.ToString().Length >= 4)
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update customer set password='" + password + "' where cust_id='" + cust_id + "'";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Password changed please logout");
                    con.Close();
                    this.Close();
                    login l = new login();
                    l.ShowDialog();
                }
                else
                {
                    MessageBox.Show("password should be more than 3 number");
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("password not matched");
                textBox2.Clear();
                textBox3.Clear();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            dashbord d = new dashbord(cust_id);
            d.ShowDialog();

        }
    }
}

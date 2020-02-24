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
    public partial class deposit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id, amd = 0;
        string name;
        public deposit(int cus)
        {
            InitializeComponent();
            cust_id = cus;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            dashbord d = new dashbord(cust_id);
            d.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                amd = Convert.ToInt32(textBox1.Text);
            }
            catch(Exception e1)
            {
                MessageBox.Show("invalid input"); 
                
            }
            if (amd>0)
            {
                if (amd % 100 == 0)
                {
                    if (amd <= 40000)
                    {
                        con.Open();
                        var date = DateTime.Now;
                        string dat = date.ToString("dd/MM/yyyy:::hh:mm:ss");
                        SqlCommand cmd1 = new SqlCommand("insert into [transaction] (date,amount,cust_id) values('" + dat + "','" + amd + "','" + cust_id + "')", con);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmd = new SqlCommand("update account set balance=balance+'" + amd + "' where cust_id='" + cust_id + "'", con);
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand("select cust_name from customer where cust_id='" + cust_id + "'", con);
                        using (SqlDataReader red = cmd2.ExecuteReader())
                        {
                            if (red.Read())
                            {
                                name = Convert.ToString(red["cust_name"]);
                            }
                        }

                        con.Close();
                        this.Hide();
                        transactionbill tr = new transactionbill(amd, cust_id, name);
                        
                        tr.ShowDialog();


                    }
                    else
                    {
                        MessageBox.Show("enter amount below 40000");
                        textBox1.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("ATM can accept notes of 100 500 2000 only");
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("enter valid amount");
                textBox1.Clear();
            }
        }
    }
}

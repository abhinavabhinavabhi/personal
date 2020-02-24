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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'atmdatabaseDataSet.customer' table. You can move, or remove it, as needed.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter d;
             DataTable dt;
           con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer where cust_id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("check input");
                textBox1.Clear();
                textBox2.Clear();

            }
            d = new SqlDataAdapter(cmd.CommandText, con);
                dt = new DataTable();
            try
            {
                d.Fill(dt);
            }
            catch
            {
               
                textBox1.Clear();
                textBox2.Clear();
            }
           
                con.Close();


                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("passowrd mached");
                    this.Close();
                int id = int.Parse(textBox1.Text);
                    dashbord ds = new dashbord(id);
                    ds.ShowDialog();

                }
                else
                {
                    MessageBox.Show("incorrect password");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            
           
        }

       
    }
}

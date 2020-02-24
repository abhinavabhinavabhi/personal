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
using System.Threading;

namespace wlecome
{ 
    public partial class fastcash : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project\wlecome\wlecome\atmdatabase.mdf;Integrated Security=True");
        int cust_id;
        int amd;
       
        public fastcash(int cust)
        {
            cust_id = cust;
            InitializeComponent();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fastcash_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                amd = 100;
                radioButton1.Checked = false;
               
                this.Hide();
                withdraw w = new withdraw(cust_id);
                w.withdrawamt(amd);

            }
           else if(radioButton2.Checked)
            {
                amd = 500;
                radioButton2.Checked = false;
                this.Close();
                withdraw w = new withdraw(cust_id);

                Thread th = new Thread(() => w.withdrawamt(amd));
                th.Start();
               
            }
           else if(radioButton3.Checked)
            {
                amd = 1000;
                radioButton3.Checked = false;
                this.Close();
                withdraw w = new withdraw(cust_id);
                w.withdrawamt(amd);
            }
           else if(radioButton4.Checked)
            {
                amd = 10000;
                radioButton4.Checked = false;
                this.Close();
                withdraw w = new withdraw(cust_id);
                w.withdrawamt(amd);
            }
            else
            {
                MessageBox.Show("Select the amount");
            }
        }
        public void sum()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            dashbord ds = new dashbord(cust_id);
            ds.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

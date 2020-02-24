using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wlecome
{
    public partial class dashbord : Form
    {
        int cust_id;
        public dashbord( int id)
        {
            cust_id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw(cust_id);
            this.Close();
            w.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            balance b = new balance(cust_id);
            this.Close();
            b.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fastcash fs = new fastcash(cust_id);
            this.Close();
            fs.ShowDialog();

        }

        private void dashbord_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            pinchange pi = new pinchange(cust_id);
            pi.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            deposit d = new deposit(cust_id);
            d.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            transfer tr = new transfer(cust_id);
            tr.ShowDialog();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            statement s = new statement(cust_id);
            s.ShowDialog();
        }
    }
}

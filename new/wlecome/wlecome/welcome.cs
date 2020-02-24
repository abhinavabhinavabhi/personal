using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
namespace wlecome
{
    public partial class welcome : Form
    {
        System.Timers.Timer tim = new System.Timers.Timer(3000);
        
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            tim = new System.Timers.Timer(3000);
            tim.Elapsed += Tim_Elapsed;
            tim.AutoReset = false;
            tim.Enabled = true;
            
           
        }

        private  void Tim_Elapsed(object sender, ElapsedEventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            
            login l = new login();
            
            this.Hide();
            l.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

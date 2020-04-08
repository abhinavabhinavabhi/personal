using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace ChatClient
{
    public partial class Form1 : Form
    {
        public static string username = null;
        public static Socket client;
        string readdata = null;

        public Form1()
        {
            InitializeComponent();
            grouptext.Hide();
            personaltext.Hide();
            send.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            byte[] send = new byte[1024];
            send = Encoding.ASCII.GetBytes(personaltext.Text+"$");
            client.Send(send, 0, send.Length, 0);
            personaltext.Text = "";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            if (username.Length < 2)
            {
                textBox1.Focus();
                MessageBox.Show("Enter correct username ");
                return;
            }
            else
            {


                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = host.AddressList[0];

                client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint end = new IPEndPoint(ip, 8008);
                client.Connect(end);
                byte[] userbyte = new byte[1024];
                userbyte = Encoding.ASCII.GetBytes(textBox1.Text+"$");
                client.Send(userbyte, 0, userbyte.Length, 0);
                groupBox1.Hide();
                grouptext.Show();
                personaltext.Show();
                send.Show();
                Thread clientmsg = new Thread(getmess);
                clientmsg.Start();

            }

        }
        public void getmess()
        {
            while (true)
            {
                byte[] msgs = new byte[1024];
                client.Receive(msgs, 0, msgs.Length, 0);
                string recmsg = Encoding.ASCII.GetString(msgs);
                readdata = "  " + recmsg;
                msg();

            }
        }

        public void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                grouptext.Text = grouptext.Text + Environment.NewLine + " " + readdata;
            }

        }

    }
}

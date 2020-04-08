using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
namespace server
{

    class Program
    {

        public static Hashtable clientlist = new Hashtable();

        static void Main(string[] args)
        {
            int counter = 0;


            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8008);
            Socket sck = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sck.Bind(localEndPoint);
            sck.Listen(100);
            Socket acc;
            Console.WriteLine("server started");
            while (true)
            {
                counter += 1;
                acc = sck.Accept();
                byte[] bytesFrom = new byte[1025];
                string username = null;
                string msg= null;
                acc.Receive(bytesFrom, 0, bytesFrom.Length, 0);
                username = Encoding.ASCII.GetString(bytesFrom);
                username = username.Substring(0, username.IndexOf("$"));
                clientlist.Add(username, acc);
                broadcast(username+" joined", username, true);
                Console.WriteLine(username + "joined"); ;
                handleclient handle = new handleclient();
                handle.startclient(acc, counter,username);


            }
            //sck.Close();
            //acc.Close();
            //Console.ReadKey();

        }

        public static void broadcast(string msg, string username, bool req)
        {
            foreach (DictionaryEntry clients in clientlist)
            {
                Socket client = (Socket)clients.Value;
                byte[] sendmsgbyte = new byte[1024];
                if (req == true)
                {
                    Console.WriteLine(msg+"mesage");
                    sendmsgbyte = Encoding.ASCII.GetBytes(msg);
                }
                else
                {
                    Console.WriteLine(msg);
                    sendmsgbyte = Encoding.ASCII.GetBytes(username + " : " + msg);
                }
                client.Send(sendmsgbyte, 0, sendmsgbyte.Length, 0);
            }
        }
    }

    class handleclient
    {
        Socket user;
        int counter;
        String username;
        public void startclient(Socket user, int counter,string username)
        {
            this.user = user;
            this.counter = counter;
            this.username = username;
            Thread userthread = new Thread(dochat);
            userthread.Start();

        }

        private void dochat()
        {
            int requestcount = 0;

            string datatfromclient = null;

            //string serverresponse = null;
            //string rcount = null;

            while (true)
            {
                try
                {
                    requestcount += 1;
                    byte[] bytefrom = new byte[1024];
                    //byte[] sendbyte = new byte[1024];
                    user.Receive(bytefrom, 0, bytefrom.Length, 0);
                    datatfromclient = Encoding.Default.GetString(bytefrom);
                    datatfromclient = datatfromclient.Substring(0, datatfromclient.IndexOf("$"));
                    Program.broadcast(datatfromclient, username, false);
                    Console.WriteLine("  from client (" + counter + ") user : "+username+" msg :" + datatfromclient);

                    //rcount = Convert.ToString(requestcount);
                    //serverresponse = "server to client (" + counter + ") " + rcount;
                    //sendbyte = Encoding.Default.GetBytes(serverresponse);
                    //user.Send(sendbyte, 0, sendbyte.Length, 0);

                    //Console.WriteLine(serverresponse);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error:" + e.Message);
                    break;
                }

            }
            user.Close();

        }
    }
}

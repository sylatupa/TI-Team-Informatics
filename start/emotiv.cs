using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;  //TI added

namespace Working_Memory_Battery_and_Sensor_Input
{
    class emotiv
    {
        string hostname = "localhost";
        int port = 7575;
        public void get_tcp()
        {
            //connect to server and get intput/output stream
            //TcpClient client = new TcpClient(hostname, port);
            IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            TcpListener myList = new TcpListener(ipAd, 7574);
            //myList.Start();
            
            //Socket s = myList.AcceptSocket();
            // Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
            Console.WriteLine("Connection accepted from ");
            Console.WriteLine("Connection accepted from ");
            Console.WriteLine("Connection accepted from ");

            while (true)
            {
                //TcpClient client = myList.AcceptTcpClient();
                TcpClient tcpClient = myList.AcceptTcpClient();
                // Read the data stream from the client. 
                byte[] bytes = new byte[256];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                SocketHelper helper = new SocketHelper();
                helper.processMsg(tcpClient, stream, bytes);


            }
            
            /*
            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));
             * 
             */ 
        }

    }
}

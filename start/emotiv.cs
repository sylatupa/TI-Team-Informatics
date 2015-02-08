using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;  //TI added

namespace Working_Memory_Battery_and_Sensor_Input
{
    class emotiv
    {
        string hostname = "localhost";
        int port = 7575;
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
 
        public void get_tcp()
        {
            IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            TcpListener myList = new TcpListener(ipAd, 7474);
            //IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            myList.Start();
            while (true)
            {
                Console.WriteLine("here");
                Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(ipAd);
                socket.Listen(myList);
                //TcpClient tcpClient = myList.AcceptTcpClient();
                Console.WriteLine(socket.ToString());
                byte[] bytes = new byte[256];
                Console.WriteLine("here");
                //NetworkStream stream = tcpClient.GetStream();
                //stream.Read(bytes, 0, bytes.Length);
                Console.WriteLine(bytes);
            }
        }
 
    }
}
/*

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.ObjectInputStream;
import java.net.InetAddress;
import java.net.Socket;

public class TCPclient {
    public static void main(String[] args) throws IOException {

    Socket client = null;
    BufferedReader input = null;
    stop = false;
    Object measureLocal;
    try {  
      client = new Socket(InetAddress.getByName(Ip), port);
      input = new BufferedReader(new InputStreamReader(client.getInputStream()));
      client.setSoTimeout(SO_TIMEOUT);
    } catch (Exception ex) {
      stop = true;
    }
    // loop
    while (!stop) {
      try {
        //
        measureLocal = input.readLine();
        //
      } catch (Exception sce) {
        break;
      }
      if (measureLocal == null) {
        stop = true;
      } else { 
         // HERE YOU CAN DO SOMETHING WITH THE VALUE….
      }
      try {
        Thread.sleep(delay);
      } catch (Exception ex) {
      }
    }
    try {      
      if (input!=null) input.close();
      if (client!=null) client.close();
    } catch (Exception e) {  

    } 
    
  }
}
*/
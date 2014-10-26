using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;  //TI added
using main_HA;
using main_WMB;
using gui_and_visualization;

namespace main {
    public class Main
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// This in how the application starts -- its called from the MainWindow.xaml.cs file
        /// </summary>
        Main_wmb main_wmb = new Main_wmb();
        // Socket information for initialization and testing
        //Socket server = new Socket();
        int ip = 0;
        int port = 0;

        public void main() {
            main_wmb.main_wmb();
            send_socket_test();

        }
 
    public void send_socket_test()
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        
            //connect to server and get intput/output stream
    /*
        TcpClient client = new TcpClient(string ip, int port);
    NetworkStream stream = client.GetStream();
    //send a string to the server
    ASCIIEncoding Enc = new ASCIIEncoding();
    string s = "message";
    byte[] buffer = Enc.GetBytes(s);
    stream.Write(buffer, 0, buffer.Length);
    stream.Flush();
        try
        {
            // Blocks until send returns. 
            int byteCount = server.Send(msg, SocketFlags.None);
            Console.WriteLine("Sent {0} bytes.", byteCount);

            // Get reply from the server.
            byteCount = server.Receive(bytes, SocketFlags.None);
            if (byteCount > 0)
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
        //send a string through the socket
     */
    }
    public void get_socket_test()
    {
        //get a string through the socket and set the charts

    }
    

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;  //TI added

//namespace main {
    public class main
    {
        // Socket information for initialization and testing
        //Socket server = new Socket()
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        int ip = 0;
        int port = 0;
        public main() {
            Console.WriteLine("main is here");
        }
        // PUT ALL GLOBAL FUNCTIONS HERE
    public void write_black_box_socket (string socketString) {
        //take black box data and write to log
    }
    public DateTime write_current_time(string socketString)
    {
        //take black box data and write to log
        return DateTime.Now;
    }
    public void write_pre_game_survey()
    {
        //accept all the form arguments and write to log
    }
    public void write_post_game_survey()
    {
        //accept all the form arguments and write to log
    }
    public void send_socket_test()
    {
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


//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;  //TI added

namespace Working_Memory_Battery_and_Sensor_Input
{
    class PAD
    {
        public double P;
        public double A;
        public double D;

    }

    class emotiv
    {
        List<PAD> pad_list = new List<PAD>();
        public string new_line = null;
        public string[] strArr = null;
        

        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
        public void get_tcp()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("127.0.0.1", 7474);
                while (true)
                {
                    Stream stm = tcpclnt.GetStream();
                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(bb[i]));
                        new_line += Convert.ToChar(bb[i]).ToString();
                    }
                    Console.WriteLine(new_line.Length.ToString());
                    char[] splitchar = { ',' };
                    strArr = new_line.Split(splitchar);
                    PAD pad = new PAD();
                    Console.WriteLine(strArr.Length);
                    
                    pad.P = Convert.ToDouble(strArr[1]);
                    pad.A = Convert.ToDouble(strArr[2]);
                    pad.D= Convert.ToDouble(strArr[3]);
                    pad_list.Add(pad);

                    Console.WriteLine(pad_list.Count.ToString());
                }
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }

}

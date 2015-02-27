using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;  //TI added
using gui_and_visualization;

namespace Working_Memory_Battery_and_Sensor_Input
{
    public class PAD
    {
        public double P;
        public double A;
        public double D;
        public double T; //time
    }

    public class emotiv
    {
        public bool reading = true;
        public List<PAD> pad_list = new List<PAD>();
        public string new_line = null;
        public string[] strArr = null;
        public byte[] bb = null;  //byte array doesnt need to be public
        public string incoming_data = ""; //added from notes 
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();

        public double p_avg;
        public double a_avg;
        public double d_avg;

        public double p_max;
        public double a_max;
        public double d_max;

        public double p_min;
        public double a_min;
        public double d_min;

        public visualization public_emotiv_visual;

        public void pad_stat_descr()
        {
          //  Console.WriteLine("all data: " + incoming_data);
            try
            {
                incoming_data = incoming_data.Replace("\n", "");
                string[] by_the_second_data = incoming_data.Split(Environment.NewLine.ToCharArray());
                double[] p = new double[by_the_second_data.Length];
                double[] a = new double[by_the_second_data.Length];
                double[] d = new double[by_the_second_data.Length];
                int i = 0;

                char[] splitchar = { ',' };
                foreach (string data_row in by_the_second_data)
                {
                    try
                    {
                        string[] strArr = data_row.Split(splitchar);
                        //Console.WriteLine("data row: " + data_row + " " + " rowLength: " + strArr.Length);
                        p[i] = Convert.ToDouble(strArr[1].Trim());
                        a[i] = Convert.ToDouble(strArr[2].Trim());
                        d[i] = Convert.ToDouble(strArr[3].Trim());
                        i++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bad line of data: " + data_row);

                    }

                }
                p_avg = p.Average();
                a_avg = a.Average();
                d_avg = d.Average();

                p_max = p.Max();
                a_max = a.Max();
                d_max = d.Max();

                p_min = p.Min();
                a_min = a.Min();
                d_min = d.Min();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no data, but keep playing");
            }

        }
        async public void get_tcp()
        {
            string ip_addr = "127.0.0.1";
            int port = 7474;
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(ip_addr, port);
                Stream stm = tcpclnt.GetStream();
                int wait = 0;
                while (reading)
                {
                    wait--;
                    bb = new byte[100];
                    int k = await stm.ReadAsync(bb, 0, 100);
                    string sample_data = null;
                    for (int i = 0; i < k; i++)
                    {
                        incoming_data += Convert.ToChar(bb[i]).ToString();
                        sample_data += Convert.ToChar(bb[i]).ToString();
                    }

                    if (wait <= 0)
                    {
                        wait = 20;
                        try
                        {

                            sample_data = sample_data.Replace("\n", "");
                            
                            string[] by_the_second_data = sample_data.Split(Environment.NewLine.ToCharArray());
                            Console.WriteLine("sample data: " + by_the_second_data[0].ToString());
                            char[] splitchar = { ',' };
                            string[] strArr = by_the_second_data[0].Split(splitchar);
                            public_emotiv_visual.move(new double[3] { Convert.ToDouble(strArr[1].Trim()) * 100, Convert.ToDouble(strArr[2].Trim()) * 100, Convert.ToDouble(strArr[3].Trim()) * 100 });
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        sample_data = null;
                    }

                }
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error.... " + e.StackTrace);
            }
        }

        public void set_visualization(visualization emotiv_visuals) {
            public_emotiv_visual = emotiv_visuals;
             }
    }

}

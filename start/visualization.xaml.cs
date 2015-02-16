using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Working_Memory_Battery_and_Sensor_Input
{
    /// <summary>
    /// Interaction logic for visualization.xaml
    /// </summary>
    public partial class visualization : Page
    {
        Random number = new Random();
        public visualization()
        {
            InitializeComponent();
         //   set_bar_movement();
        }
        public void move(double[] data)
        {
            //Console.WriteLine("moving data : " + data.ToString());
            bar_Attention.Height = data[1];
            bar_Dominance.Height = data[2];
                bar_Pleasure.Height = data[0];
        }

        public async void set_bar_movement()
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(700);
                bar_Attention.Height = (int)number.Next(0, 100);
                bar_Dominance.Height = (int)number.Next(0, 100);
                bar_Pleasure.Height = (int)number.Next(0, 100);
            }
        }
}}

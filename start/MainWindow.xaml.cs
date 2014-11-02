using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gui_and_visualization;
//using main; //TI main functions
namespace Working_Memory_Battery_and_Sensor_Input
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// This calls main
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Main main = new Main();
            main.main();
            Console.WriteLine("Starting Main");
            set_button_grid(10);
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

            /*NavigationService n = new NavigationService();
            n.Navigate(new Uri("SelectionPage.xaml", UriKind.Relative));
            n.Navigate(new Uri("Introduction.xaml", UriKind.Relative));
            n.Navigate(typeof(Introduction));
             * */
        }
        string current_player1 = "", current_player2 = "";
        int p1 = 0, p2 = 0;

        public void Form1()
        {
            //   InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }


        private void set_button_grid(int size)
        {
            Console.WriteLine("Starting set button grid");
            custom_button[,] buttonArray = new custom_button[size, size];
            for (int i = 0; i < size; i++)
            
            {
                for (int j = 0; j < size; j++)
                
                {
                    custom_button button1 = new custom_button();

                    button1.Height = 45;
                    button1.Width = 45;
                    button1.Background = Brushes.CornflowerBlue;
                    button1.Content = 'X';
                    button1.Name = "button" + i.ToString() + "button" + j.ToString();

                    button1.Content = i.ToString() +","+ j.ToString();
                    button1.x = i;
                    button1.y = j;
                    buttonArray[i,j] = button1;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine("i: " + i + " j: " + j);
                    Console.WriteLine("row: " + buttonArray[i, j].x + " col: " + buttonArray[i, j].y);

                    //stackpanel_button.Children.Add(buttonArray[i, j]);
                    
                    buttonArray[i, j].SetValue(Grid.RowProperty, buttonArray[i, j].x);
                    buttonArray[i, j].SetValue(Grid.ColumnProperty, buttonArray[i, j].y);
                    
                    grid_button.Children.Add(buttonArray[i, j]);
                    
                    Grid.SetRow(buttonArray[i, j], buttonArray[i, j].x);
                    Grid.SetColumn(buttonArray[i, j], buttonArray[i, j].y);
                    
                }
            }
            

        }

    }
}

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
    class cooridinate
    {
        public int x;
        public int y;
    }

    public partial class MainWindow : Window
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// This calls main
        /// </summary>
        /// 
        custom_button[,] buttonArray;
        cooridinate[] random_pattern;
        cooridinate[] random_user_pattern;

        string current_player1 = "", current_player2 = "";
        int p1 = 0, p2 = 0;

        public MainWindow()
        {
            InitializeComponent();
            Main main = new Main();
            main.main();
            Console.WriteLine("Starting Main");
            set_button_grid(10);
            get_random_pattern(10, 5);
            set_random_pattern();
            set_user_random_pattern();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            Console.WriteLine(nav.ToString());
            //nav.Navigate(new Uri("Introduction.xaml", UriKind.RelativeOrAbsolute));           // NavigationService n = new NavigationService();
            //n.Navigate(new Uri("SelectionPage.xaml", UriKind.Relative));
            //n.Navigate(new Uri("Introduction.xaml", UriKind.Relative));
            //n.Navigate(typeof(Introduction));

        }

        private void set_button_grid(int size)
        {
            Console.WriteLine("Starting set button grid");
            buttonArray = new custom_button[size, size];
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

                    button1.Content = i.ToString() + "," + j.ToString();
                    button1.x = i;
                    button1.y = j;
                    buttonArray[i, j] = button1;
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

        Random number;

        private cooridinate[] get_random_pattern(int size, int number_dots)
        {
            number = new Random();

            random_pattern = new cooridinate[number_dots];
            random_user_pattern = new cooridinate[number_dots];
            for (int i = 0; i < number_dots; i++)
            {
                cooridinate coord = new cooridinate();
                cooridinate coord2 = new cooridinate();
                coord.x = (int)number.Next(0, size);
                coord.y = (int)number.Next(0, size);
                random_pattern[i] = coord;
                coord2.x = (int)number.Next(0, size);
                coord2.y = (int)number.Next(0, size);
                random_user_pattern[i] = coord2;
            }
            return random_pattern;
        }
        public void set_random_pattern()
        {
            for (int i = 0; i < random_pattern.Length; i++)
            {
                buttonArray[random_pattern[i].x, random_pattern[i].y].Background = Brushes.Yellow;
            }
        }
        public void set_user_random_pattern()
        {
            for (int i = 0; i < random_user_pattern.Length; i++)
            {
                buttonArray[random_user_pattern[i].x, random_user_pattern[i].y].Background = Brushes.Green;
            }
        }
    }


}

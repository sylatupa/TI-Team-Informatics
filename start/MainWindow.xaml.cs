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

    public class cooridinate
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
        public custom_button[,] buttonArray;
        public cooridinate[] random_pattern;
        public cooridinate[] random_user_pattern;
        Random num = new Random();
        Random number = new Random();
        string current_player1 = "", current_player2 = "";
        int p1 = 0, p2 = 0;

        public MainWindow()
        {
            int size = 10;
            int number_dots = 5;
            InitializeComponent();
            Main main = new Main();
            main.main();
            Console.WriteLine("Starting Main");
            custom_button[,] button_array = set_button_grid(size);
            random_pattern = get_random_pattern(size, number_dots);
            random_user_pattern = get_random_pattern(size, number_dots);
            set_random_pattern(random_pattern, "1");
            set_random_pattern(random_user_pattern, "2");
            set_bar_movement();
            Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
            //{pleasure, arrousal, dominace};
            int[] engagement = { 1, 1, 1 };
            int[] boredom = { -1, -1, -1 };
            int[] frustration = { -1, 1, -1 };
            int[] meditation = { 1, -1, 1 };
            int[] agreement = { 1, -1, -1 };
            int[] concentrating = { 1, -1, 1 };
            int[] disagreement = { -1, 1, 1 };
            int[] interested = { 1, 1, -1 };

            dictionary.Add("engagement", engagement);
            dictionary.Add("boredom", boredom);
            dictionary.Add("frustration", frustration);
            dictionary.Add("meditation", meditation);
            dictionary.Add("agreement", agreement);
            dictionary.Add("concentrating", concentrating);
            dictionary.Add("disagreement", disagreement);
            dictionary.Add("interested", interested);
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            grid_button.Visibility = Visibility.Hidden;
        }

        private custom_button[,] set_button_grid(int size)
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
                    //button1.Content = i.ToString() + "," + j.ToString();
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
                    buttonArray[i, j].SetValue(Grid.RowProperty, buttonArray[i, j].x);
                    buttonArray[i, j].SetValue(Grid.ColumnProperty, buttonArray[i, j].y);
                    grid_button.Children.Add(buttonArray[i, j]);
                    Grid.SetRow(buttonArray[i, j], buttonArray[i, j].x);
                    Grid.SetColumn(buttonArray[i, j], buttonArray[i, j].y);
                }
            }
            return buttonArray;
        }
        private cooridinate[] get_random_pattern(int size, int number_dots)
        {
            
            cooridinate[] dot_pattern = new cooridinate[number_dots];
            for (int i = 0; i < number_dots; i++)
            {
                cooridinate coord = new cooridinate();
                cooridinate coord2 = new cooridinate();
                coord.x = (int)num.Next(0, size);
                coord.y = (int)num.Next(0, size);
                dot_pattern[i] = coord;
            }
            
            return dot_pattern;
        }
        public void set_random_pattern(cooridinate[] coords, string color)
        {
           if (color == "1") {
            for (int i = 0; i < coords.Length; i++)
            {
                buttonArray[coords[i].x, coords[i].y].Background = Brushes.Green;
            }
           }
           if (color == "2") {
            for (int i = 0; i < coords.Length; i++)
            {
                buttonArray[coords[i].x, coords[i].y].Background = Brushes.Yellow;
            }
           }
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
        public void show_bar_graph(object sender, RoutedEventArgs e)
        {
            if (grid_bar_graph.Visibility == Visibility.Hidden)
            {
                grid_bar_graph.Visibility = Visibility.Visible;
            }
            else
            {
                grid_bar_graph.Visibility = Visibility.Hidden;
            }

        }
    }


}

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
//using main; //TI main functions
namespace Working_Memory_Battery_and_Sensor_Input
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// This calls main
        /// </summary>
        Introduction page_introduction = new Introduction();
        public Game page_game = new Game();
        survey page_survey = new survey();
        visualization page_visualization = new visualization();

        public MainWindow()
        {
            InitializeComponent();
            Main main = new Main();
            main.main();
            //Console.WriteLine("Starting Main");
            set_button_navigation(this, new RoutedEventArgs());
            get_intro_page(this, new RoutedEventArgs());
            // the ask game 
            // else introduction, survey
            // else get survey
        }
        public void get_intro_page(object sender, RoutedEventArgs e)
        {
            page_introduction.set_mainwindow(this);
            if (cp_mainwindow.Children.Contains(page_introduction.cp_introduction))
            {
                cp_mainwindow.Children.Remove(page_introduction.cp_introduction);
            }
            else
            {
                cp_mainwindow.Children.Clear();
                page_introduction.Content = null;
                cp_mainwindow.Children.Add(page_introduction.cp_introduction);
            }
        }
        public void get_survey_page(object sender, RoutedEventArgs e)
        {
            page_survey.set_mainwindow(this);
            if (cp_mainwindow.Children.Contains(page_survey.cp_survey))
            {
                cp_mainwindow.Children.Remove(page_survey.cp_survey);
            }
            else
            {
                cp_mainwindow.Children.Clear();
                page_survey.Content = null;
                cp_mainwindow.Children.Add(page_survey.cp_survey);
            }
        }
        public void get_game_page(object sender, RoutedEventArgs e)
        {
            page_game.set_mainwindow(this);
            
            if (cp_mainwindow.Children.Contains(page_game.cp_game))
            {
                cp_mainwindow.Children.Clear();
            }
            else
            {
                cp_mainwindow.Children.Clear();
                page_game.Content = null;
                cp_mainwindow.Children.Add(page_game.cp_game);
                Console.WriteLine("Mains Start Game");
                page_game.run_game();
            }
                    }
        public void get_visualization(object sender, RoutedEventArgs e)
        {
            if (cp_mainwindow_footer.Children.Contains(page_visualization.cp_visualization))
            {
                cp_mainwindow_footer.Children.Remove(page_visualization.cp_visualization);
            }
            else
            {
                cp_mainwindow.Children.Clear();
                page_visualization.Content = null;
                cp_mainwindow_footer.Children.Add(page_visualization.cp_visualization);
            }
        }
        public void set_button_navigation(object sender, RoutedEventArgs e)
        {
            if (cp_mainwindow_navigation.Visibility != Visibility.Collapsed)
            {
                cp_mainwindow_navigation.Visibility = Visibility.Collapsed;
                //            cp_mainwindow_navigation.Children.Remove(button_navigation);
                //              button_navigation.Template = button_template1.Template;
                //                cp_mainwindow.Children.Add(button_navigation);
            }
            else
            {
                cp_mainwindow_navigation.Visibility = Visibility.Visible;
                //          cp_mainwindow.Children.Remove(button_navigation);
                //        cp_mainwindow_navigation.Children.Add(button_navigation);
            }
        }
    }
}




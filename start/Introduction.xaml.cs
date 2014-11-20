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
using System.Xml.Linq;
//using main; //TI Main Functions

namespace Working_Memory_Battery_and_Sensor_Input
{

    public partial class Introduction : Page
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// 
        /// </summary>
        public int has_introduction = 0;
        public bool complete = false;
        MainWindow thisMainWindow;
        public Introduction()
        {
            InitializeComponent();
        }
        public void set_mainwindow(MainWindow mw)
        {
            thisMainWindow = mw;
        }
        private void button_click_pre_game_no(object sender, RoutedEventArgs e)
        {
            cp_pregame_intro_intro.Visibility = Visibility.Hidden;
            cp_pregame_intro.Visibility = Visibility.Visible;

        }
        private void button_click_pre_game_yes(object sender, RoutedEventArgs e)
        {
            cp_pregame_intro_intro.Visibility = Visibility.Hidden;
            
            XDocument doc = XDocument.Load(@"users.xml");
            var persons = from p in doc.Root.Elements("user").Elements("name") select p.Value;
            this.ddl.ItemsSource = persons;
            cp_pregame_select_user.Visibility = Visibility.Visible;
        }
        private void button_click_user_next(object sender, RoutedEventArgs e)
        {
            thisMainWindow.get_game_page(null, new RoutedEventArgs());
        }
        private void button_click_user_prev(object sender, RoutedEventArgs e)
        {
            thisMainWindow.cp_mainwindow.Children.Clear();
            thisMainWindow.get_intro_page(null, new RoutedEventArgs());

 

        }
        private void button_click_pre_game_next(object sender, RoutedEventArgs e)
        {
            cp_pregame_intro_intro.Visibility = Visibility.Hidden;
            cp_pregame_intro.Visibility = Visibility.Visible;

            thisMainWindow.get_survey_page(null, new RoutedEventArgs());
        }


    }
}

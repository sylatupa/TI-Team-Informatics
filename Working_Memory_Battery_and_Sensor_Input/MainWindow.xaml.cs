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
using main; //TI main functions


namespace Working_Memory_Battery_and_Sensor_Input
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            main main = new main();

            InitializeComponent();

            main.set_socket_test();
          //  main.
            
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService n = NavigationService.GetNavigationService();
            //this.NavigationService.Navigate(new Uri("SelectionPage.xaml", UriKind.Relative));
            //n.Navigate(new Uri("Introduction.xaml", UriKind.Relative));
           
            // this.Frame.Navigate(typeof(Introduction));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
//using main; //TI Main Functions

namespace Working_Memory_Battery_and_Sensor_Input
{
    public class surveyObject
    {
        public string age;
        public string gender;
        public string ethnicity;
        public string reason;
        public string game;
        public string sleep;
        public string name;
    }
    public partial class survey : Page
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// 
        /// </summary>
        Game thisGame;
        surveyObject thisSurvey;
        MainWindow thisMainWindow;
        
        public survey()
        {
            thisSurvey = new surveyObject();
            InitializeComponent();
            
        }
        public void button_submit_survey(object sender, RoutedEventArgs e)
        {
            thisMainWindow.get_game_page(null, new RoutedEventArgs());
            if (!File.Exists("users.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("users.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Users");
                 //   writer.WriteStartElement("User");

                    //        writer.WriteElementString("ID", employee.Id.ToString());
                    //      writer.WriteElementString("FirstName", employee.FirstName);
                    //    writer.WriteElementString("LastName", employee.LastName);
                    //  writer.WriteElementString("Salary", employee.Salary.ToString());

                   // writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            XDocument doc = XDocument.Load("users.xml");
            XElement school = doc.Element("Users");
            school.Add(new XElement("user",
                       new XElement("age", thisSurvey.age),
                       new XElement("ethnicity", thisSurvey.ethnicity),
                       new XElement("gender", thisSurvey.gender),
                       new XElement("name", thisSurvey.name),
                       new XElement("reason", thisSurvey.reason),
                       new XElement("name", (DateTime.Now).ToString("yyyyMMddHHmmssffff")),
                       new XElement("sleep", thisSurvey.sleep)));
            doc.Save("users.xml"); 
           
        }
        /*
        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            thisSurvey.name = name.Text;
            Console.WriteLine(name.Text);
        }
        */
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton thisSender = (RadioButton)sender;
            Console.WriteLine(thisSender.GroupName.ToString());
            switch (thisSender.GroupName.ToString())
            {
                case "gender":
                    {
                        thisSurvey.gender = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                case "ethnicity":
                    {
                        thisSurvey.ethnicity = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                case "age":
                    {
                        thisSurvey.age = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                case "reason":
                    {
                        thisSurvey.reason = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                case "game":
                    {
                        thisSurvey.game = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                case "sleep":
                    {
                        thisSurvey.sleep = (thisSender.Content as TextBlock).Text;
                        break;
                    }
                default: break;

            }

        }
        public void set_mainwindow(MainWindow mw)
        {
            thisMainWindow = mw;
        }

    }
}

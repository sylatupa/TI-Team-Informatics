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
using gui_and_visualization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Working_Memory_Battery_and_Sensor_Input
{
    public class LevelData
    {
        public int size;
        public int number_dots;
        public int show_button_duration;
        public LevelData(int sz, int dots, int dur)
        {
            this.size = sz;
            this.number_dots = dots;
            this.show_button_duration = dur;
        }
    }

    public class cooridinate
    {
        public int x;
        public int y;
    }
    public class Game_object
    {
        public int game_number;
        public string user_string = "";
        public DateTime game_start;
        public DateTime game_end;
        public TimeSpan game_play_duration;
        public float user_game_score;
        public DateTime last_clicked;
        public DateTime current_click;
        public float seconds_since_last_clicked;

        public int size;
        public int number_dots;
        public int show_button_duration;
        public List<float> answers_to_selections_distances = new List<float>();
    }
    public partial class Game : Page
    {
        public Random num = new Random();
        public Random number = new Random();
        public custom_button[,] button_array;
        public MainWindow thisMainWindow;
        List<cooridinate> answers;
        List<cooridinate> selections;
        public bool game_started;
        public int number_dots_clicked;
        public int current_level_number = 2;
        public LevelData level1;
        public LevelData level2;
        public LevelData level3;
        public LevelData current_level;
        public List<LevelData> level_data_array;

        Dictionary<string, int[]> dictionary;
        int[] engagement = { 1, 1, 1 };
        int[] boredom = { -1, -1, -1 };
        int[] frustration = { -1, 1, -1 };
        int[] meditation = { 1, -1, 1 };
        int[] agreement = { 1, -1, -1 };
        int[] concentrating = { 1, -1, 1 };
        int[] disagreement = { -1, 1, 1 };
        int[] interested = { 1, 1, -1 };

        public Game()
        {
            InitializeComponent();
            dictionary = new Dictionary<string, int[]>();
            //{pleasure, arrousal, dominace};
            dictionary.Add("engagement", engagement);
            dictionary.Add("boredom", boredom);
            dictionary.Add("frustration", frustration);
            dictionary.Add("meditation", meditation);
            dictionary.Add("agreement", agreement);
            dictionary.Add("concentrating", concentrating);
            dictionary.Add("disagreement", disagreement);
            dictionary.Add("interested", interested);
            game_started = false;
            answers = new List<cooridinate>();
            selections = new List<cooridinate>();

            level1 = new LevelData(5, 3, 4444);
            level2 = new LevelData(6, 4, 4444);
            level3 = new LevelData(7, 5, 4444);
            level_data_array = new List<LevelData>();
            level_data_array.Add(level3);
            level_data_array.Add(level2);
            level_data_array.Add(level1);

        }
        public Game_object thisGame;
        public void run_game()
        {
            current_level_number--;
            current_level = level_data_array[current_level_number];
            number_dots_clicked = 0;

            button_next_game.Visibility = Visibility.Hidden;

            thisGame = new Game_object();
            thisGame.size = current_level.size;
            thisGame.number_dots = current_level.number_dots;
            thisGame.show_button_duration = current_level.show_button_duration;
            game_started = true;
            button_array = get_button_array(thisGame.size);
            set_playing_grid_properties(thisGame.size, button_array);
            answers = get_random_coordinate_array(thisGame.size, thisGame.number_dots);
            set_random_pattern(answers, "1", button_array);
            clear_random_pattern(answers, button_array, thisGame.show_button_duration);
            thisGame.game_start = DateTime.Now;
            thisGame.game_number = (int)number.Next(0, 999999);
            Console.WriteLine("here");
        }
        private void click_game_event(object sender, RoutedEventArgs e)
        {
            number_dots_clicked += 1;
            if (number_dots_clicked < thisGame.number_dots)
            {
                custom_button new_button = sender as custom_button;
                button_array[new_button.x, new_button.y].Template = Control_Template.Template;
                cooridinate new_coord = new cooridinate();
                new_coord.x = new_button.x;
                new_coord.y = new_button.y;
                selections.Add(new_coord);
                Console.WriteLine("Click: " + number_dots_clicked + " of " + thisGame.number_dots);
            }
            else
            {
                Console.WriteLine("Click: " + number_dots_clicked + " of " + thisGame.number_dots);
                custom_button new_button = sender as custom_button;
                button_array[new_button.x, new_button.y].Template = Control_Template.Template;
                cooridinate new_coord = new cooridinate();
                new_coord.x = new_button.x;
                new_coord.y = new_button.y;
                selections.Add(new_coord);
                thisGame.user_game_score = rowbasedMinEuclideanDistance(answers, selections);
                thisGame.game_end = DateTime.Now;
                thisGame.game_play_duration = thisGame.game_start - thisGame.game_end;
                set_game_data();
                button_next_game.Visibility = Visibility.Visible;
            }
        }
        private void click_next_game_event(object sender, RoutedEventArgs e)
        {
            clear_random_pattern(selections, button_array, 2222);
            clear_buttons(button_array);
            run_game();
        }
        private void show_buttons_for_user(custom_button[,] buttonArray)
        {
            for (int i = 0; i < thisGame.size; i++)
            {
                for (int j = 0; j < thisGame.size; j++)
                {
                    buttonArray[i, j].Template = plain_button.Template;
                    button_array[i, j].Visibility = Visibility.Visible;
                }
            }
        }
        private void set_playing_grid_properties(int size, custom_button[,] buttonArray)
        {
            Console.WriteLine(button_array.ToString() + "Setting buttonArray with size: " + size);
            // takes size of grid and the button array
            for (int i = 0; i < size; i++)
            {
                // adds defs for the grid on the page
                ColumnDefinition col1 = new ColumnDefinition();
                RowDefinition row1 = new RowDefinition();
                row1.Height = GridLength.Auto;
                col1.Width = GridLength.Auto;
                grid_button.RowDefinitions.Add(row1);
                grid_button.ColumnDefinitions.Add(col1);
                for (int j = 0; j < size; j++)
                {
                    // makes button array from the random coordinates
                    buttonArray[i, j].SetValue(Grid.RowProperty, buttonArray[i, j].x);
                    buttonArray[i, j].SetValue(Grid.ColumnProperty, buttonArray[i, j].y);
                    buttonArray[i, j].Click += new RoutedEventHandler(this.click_game_event);
                    grid_button.Children.Add(buttonArray[i, j]); // add button
                    Grid.SetRow(buttonArray[i, j], buttonArray[i, j].x);
                    Grid.SetColumn(buttonArray[i, j], buttonArray[i, j].y);
                }
            }
        }
        public async void clear_random_pattern(List<cooridinate> coords, custom_button[,] buttonArray, int show_button_duration)
        {
            await Task.Delay(show_button_duration);
            foreach (cooridinate coord in coords)
            {
                buttonArray[coord.x, coord.y].Visibility = Visibility.Hidden;
            }
            show_buttons_for_user(button_array);
        }
        public void clear_buttons(custom_button[,] buttonArray)
        {
            foreach (custom_button button in buttonArray)
            {
                grid_button.Children.Remove(button);
            }
        }
        List<float> distances = new List<float>();
        public float minimumDistance = 99;
        public float rowbasedMinEuclideanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            List<List<cooridinate>> answerPairing = new List<List<cooridinate>>();
            //float minimumDistance = distances[0];
            int selectionIndex = 0;
            if (answers.Count == 0)
            {
                return 0;
            }
            foreach (cooridinate selection in selections)
            {
                List<cooridinate> answerPair = new List<cooridinate>();
                answerPair.Add(answers[0]);
                answerPair.Add(selection);
                answerPairing.Add(answerPair);
                //Console.WriteLine("Selection: " + selection);
            }
            foreach (List<cooridinate> pair in answerPairing)
            {
                distances.Add(computeEuclideanDistance(pair[0], pair[1]));
                Console.WriteLine("Distance: " + computeEuclideanDistance(pair[0], pair[1]) + " between: " + pair[0].x + " " + pair[0].y + " " + pair[1].x + " " + pair[1].y);
            }
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < minimumDistance)
                {
                    minimumDistance = distances[i];
                    selectionIndex = i;
                }
            }
            answers.RemoveAt(0);
            //selections
            //selections.RemoveAt(selectionIndex);
            Console.WriteLine("selection index: " + selectionIndex);
            //thisGame.answers_to_selections_distances
            Console.WriteLine("Min Distance: " + minimumDistance);
            thisGame.answers_to_selections_distances.Add(minimumDistance);
            return minimumDistance + rowbasedMinEuclideanDistance(answers, selections);
        }
        private custom_button[,] get_button_array(int size)
        {
            //builds the complete button grid, but hides each button
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
                    button1.Content = " ";
                    button1.Name = "button" + i.ToString() + "button" + j.ToString();
                    //button1.Content = i.ToString() + "," + j.ToString();
                    button1.x = i;
                    button1.y = j;
                    button1.Visibility = Visibility.Hidden;
                    buttonArray[i, j] = button1;
                    //button1.control_template = UIElement.
                }
            }
            return buttonArray;
        }
        private List<cooridinate> get_random_coordinate_array(int size, int number_dots)
        {
            List<cooridinate> dot_pattern = new List<cooridinate>();
            for (int i = 0; i < number_dots; i++)
            {
                cooridinate coord = new cooridinate();
                cooridinate coord2 = new cooridinate();
                coord.x = (int)num.Next(0, size);
                coord.y = (int)num.Next(0, size);
                dot_pattern.Add(coord);
                //Console.WriteLine(coord.x + " " + coord.y);
            }
            return dot_pattern;
        }
        public void set_random_pattern(List<cooridinate> coords, string color, custom_button[,] buttonArray)
        {
            Console.WriteLine("set_random_pattern");
            if (color == "1")
            {
                foreach (cooridinate coord in coords)
                {
                    Console.WriteLine(coord.x + " " + coord.y);
                    buttonArray[coord.x, coord.y].Template = Control_Template.Template;
                    buttonArray[coord.x, coord.y].Background = Brushes.Green;
                    buttonArray[coord.x, coord.y].Visibility = Visibility.Visible;
                }
            }
        }
        public int rowbasedMinManhattanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            int minimumDistance = Convert.ToInt32(distances[0]);
            int selectionIndex = 0;
            List<List<cooridinate>> answerPairing = new List<List<cooridinate>>();
            if (answers.Count == 0)
            {
                return 0;
            }
            foreach (cooridinate selection in selections)
            {
                List<cooridinate> answerPair = new List<cooridinate>();
                answerPair.Add(answers[0]);
                answerPair.Add(selection);
                answerPairing.Add(answerPair);
            }
            foreach (List<cooridinate> pair in answerPairing)
            {
                distances.Add(computeManhattanDistance(pair[0], pair[1]));
            }
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < minimumDistance)
                {
                    minimumDistance = Convert.ToInt32(distances[i]);
                    selectionIndex = i;
                }
            }
            answers.RemoveAt(0);
            selections.RemoveAt(selectionIndex);
            return minimumDistance + rowbasedMinManhattanDistance(answers, selections);
        }
        public float computeEuclideanDistance(cooridinate answer, cooridinate selection)
        {
            int xDist = (int)(Math.Abs(selection.x - answer.x));
            int yDist = (int)(Math.Abs(selection.y - answer.y));
            float hypotenuse = (float)(Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2)));
            return hypotenuse;
        }
        public int computeManhattanDistance(cooridinate answer, cooridinate selection)
        {
            int xDist = (int)(Math.Abs(selection.x - answer.x));
            int yDist = (int)(Math.Abs(selection.y - answer.y));
            return xDist + yDist;
        }
        public void set_mainwindow(MainWindow mw)
        {
            thisMainWindow = mw;
        }

        public void set_game_data()
        {

            if (!File.Exists("games.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("games.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("games");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            XDocument doc = XDocument.Load("games.xml");
            XElement game = doc.Element("games");
            game.Add(new XElement("game",
                     new XElement("game_number", thisGame.game_number),
                     new XElement("game_start", thisGame.game_start),
                     new XElement("user_string", thisGame.user_string),
                     new XElement("user_game_scores"),
                     new XElement("game_end", thisGame.game_end),
                     new XElement("number_dots", thisGame.number_dots),
                     new XElement("size", thisGame.size),
                       new XElement("game_play_duration", thisGame.game_play_duration)));
            /*
            foreach (float score in thisGame.answers_to_selections_distances)
            {
                game.Element("user_game_scores")..Add( new XElement("Child", new XElement("score",
                         new XElement("user_game_score", thisGame.user_game_score))));
            }
            */
            doc.Save("games.xml");
        }
    }
}
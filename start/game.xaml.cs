﻿using System;
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
        public float user_game_score_euc;
        public float user_game_score_man;

        public float user_game_score_euc_combo;
        public float user_game_score_man_combo;

        public float P_Max;
        public float P_Min;
        public float P_Avg;
        public float A_Max;
        public float A_Min;
        public float A_Avg;
        public float D_Max;
        public float D_Min;
        public float D_Avg;
        public DateTime last_clicked;
        public DateTime current_click;
        public float seconds_since_last_clicked;
        public int size;
        public int number_dots;
        public int show_button_duration;
        public List<float> answers_to_selections_distances = new List<float>();
        public emotiv emotiv = new emotiv();

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
        public bool initialize_game = true;

        public int game_score_band;
        public string emotion;

        public int grid_size_default = 5;
        public int dot_number_default = 4;

        public int number_dots_clicked;
        public int current_level_number;
        public LevelData level1;
        public LevelData level2;
        public LevelData level3;
        public LevelData level4;
        public LevelData level5;
        public LevelData current_level;
        public double game_series_p;
        public double game_series_a;
        public double game_series_d;

        public int game_series_number = 0;
        public int game_series_count = 3;

        public List<LevelData> level_data_array;
        public Game_object thisGame;
        Dictionary<string, int[]> dictionary;

        public visualization public_this_vis;
        public survey thisSurvey;

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

            // (size,dots, and, duration ms) 
            // heres the levels that are created, 

            number_dots_clicked = 0;
        }
        public void set_visualization(visualization this_vis)
        {
            public_this_vis = this_vis;
        }

        public void run_game()
        {
            Console.WriteLine("Running Game");
            Console.WriteLine("Current Level Number: " + current_level_number);
            //page_visulization.window.
            //this is the training level
            //current level number is set to the length of the level data array
            //game_series_number is set to 0 for the first series (the training level), then it counts to 3

            Console.WriteLine("init game  init game  init game  init game  init game  init game  " + current_level_number);

            if (game_series_number == 0 && initialize_game == true)
            {
                initialize_game = false;
                game_series_number++;
                 
                level1 = new LevelData(6, 4, 3000);
                level2 = new LevelData(6, 4, 3000);
                level3 = new LevelData(6, 4, 3000);
                level4 = new LevelData(6, 4, 3000);
                level5 = new LevelData(6, 4, 3000);
                level_data_array = new List<LevelData>();
                level_data_array.Add(level5);
                level_data_array.Add(level4);
                level_data_array.Add(level3);
                level_data_array.Add(level2);
                level_data_array.Add(level1);
                current_level_number = level_data_array.Count;

            }
            else if (game_series_number > 0 && initialize_game == true) {
                //initialize  non-training games
                if (thisGame.user_game_score_euc_combo < 1)
                {
                    game_score_band = 2;
                }
                else if (thisGame.user_game_score_euc_combo < 3)
                {
                    game_score_band = 1;
                }
                else 
                {
                    game_score_band = 0;
                }

                if (game_series_p > 0 && game_series_a > 0 && game_series_d > 0)
                {
                    emotion = "engagement";
                }
                else if (game_series_p < 0 && game_series_a < 0 && game_series_d < 0)
                {
                    emotion = "boredom";
                }
                else if (game_series_p < 0 && game_series_a > 0 && game_series_d < 0)
                {
                    emotion = "frustration";
                }
                else if (game_series_p > 0 && game_series_a < 0 && game_series_d > 0)
                {
                    emotion = "meditation";
                }
                else if (game_series_p > 0 && game_series_a < 0 && game_series_d < 0)
                {
                    emotion = "concentrating";
                }
                else if (game_series_p > 0 && game_series_a < 0 && game_series_d > 0)
                {
                    emotion = "disagreement";
                }
                else if (game_series_p > 0 && game_series_a > 0 && game_series_d < 0)
                {
                    emotion = "interested";
                }
                else if (game_series_p < 0 && game_series_a < 0 && game_series_d < 0)
                {
                    emotion = "na";
                    Console.WriteLine(" no emotion score ");
                }

                if (game_score_band == 0)
                {
                    grid_size_default--;
                    dot_number_default--;
                }
                else if (game_score_band == 3)
                {
                    grid_size_default++;
                    dot_number_default++;
                }
                else if (game_score_band == 2 &&
                    (emotion == "engagement" ||
                    emotion == "frustration" ||
                    emotion == "meditation" ||
                    emotion == "disagreement"))
                {
                    //do nothing stay at the same grid size and dot number
                }
                else if (game_score_band == 2 &&
                    (emotion == "boredom" ||
                    emotion == "frustrated" ||
                    emotion == "agreement" ||
                    emotion == "concentrating" ||
                    emotion == "interested"
                    ))
                {
                    grid_size_default++;
                    dot_number_default++;
                }
                else
                {
                    // do nothing. somoehow missed all the cases
                    Console.WriteLine("Somehow missed all the cases of the game change  blocks");
                }

                

                initialize_game = false;
                level1 = new LevelData(grid_size_default, dot_number_default, 3000);
                level2 = new LevelData(grid_size_default, dot_number_default, 3000);
                level3 = new LevelData(grid_size_default, dot_number_default, 3000);
                level4 = new LevelData(grid_size_default, dot_number_default, 3000);
                level5 = new LevelData(grid_size_default, dot_number_default, 3000);
                level_data_array = new List<LevelData>();
                level_data_array.Add(level5);
                level_data_array.Add(level4);
                level_data_array.Add(level3);
                level_data_array.Add(level2);
                level_data_array.Add(level1);
                current_level_number = level_data_array.Count;

            }

           if (0 < current_level_number)
           {
               current_level_number--;
               current_level = level_data_array[current_level_number];
               number_dots_clicked = 0;

               button_next_game.Visibility = Visibility.Hidden;

               thisGame = new Game_object();

               thisGame.size = current_level.size;
               thisGame.number_dots = current_level.number_dots;
               thisGame.show_button_duration = current_level.show_button_duration;

               set_textblock_game_data(thisGame.size, number_dots_clicked, thisGame.user_game_score_euc, thisGame.user_game_score_man, thisGame.user_game_score_euc_combo, thisGame.user_game_score_man_combo, thisGame.show_button_duration);
               button_array = get_button_array(thisGame.size);
               set_playing_grid_properties(thisGame.size, button_array);
               answers = get_random_coordinate_array(thisGame.size, thisGame.number_dots);
               set_random_pattern(answers, "1", button_array);
               clear_random_pattern(answers, button_array, thisGame.show_button_duration);
               thisGame.game_start = DateTime.Now;
               thisGame.game_number = (int)number.Next(0, 999999);
               thisGame.emotiv.set_visualization(public_this_vis);
               thisGame.emotiv.get_tcp();

               game_series_p += thisGame.emotiv.p_avg;
               game_series_a += thisGame.emotiv.a_avg;
               game_series_d += thisGame.emotiv.d_avg;
           }
         else
            {
                game_series_p = game_series_p / level_data_array.Count;
                game_series_a = game_series_a / level_data_array.Count;
                game_series_d = game_series_d / level_data_array.Count;
                Console.WriteLine("game series avg P: " + game_series_p);
                Console.WriteLine("game series avg A:" + game_series_a);
                Console.WriteLine("game series avg D: " + game_series_d);

                current_level_number = level_data_array.Count;
                //game_series_number = 0;
                run_game();
            }

        }

        public void set_textblock_game_data(int size, int this_number_dots, float user_game_score_euc, float user_game_score_man, float user_game_score_euc_combo, float user_game_score_man_combo, int show_button_duration)
        {
            textblock_game_data.Text = "";
            textblock_game_data.Text += "   | Buttons Visable for:  " + (show_button_duration / 1000).ToString() + " seconds";
            textblock_game_data.Text += "   | Size: " + size.ToString() + "X" + size.ToString() + " Grid";
            textblock_game_data.Text += "   | Dots:  " + this_number_dots.ToString() + "/" + thisGame.number_dots.ToString() + " |";
            if (this_number_dots < thisGame.number_dots)
            {
            }
            else
            {
                textblock_game_data.Text += "\n | Manhattan Score A:  " + (user_game_score_man / thisGame.number_dots).ToString();
                textblock_game_data.Text += "   | Manhattan Score B:  " + (user_game_score_man_combo / thisGame.number_dots).ToString();
                textblock_game_data.Text += "\n   | Euclidean Score A:  " + (user_game_score_euc / thisGame.number_dots).ToString() + " |";
                textblock_game_data.Text += "   | Euclidean Score B:  " + (user_game_score_euc_combo / thisGame.number_dots).ToString() + " |";
            }
        }

        public float rowbasedMinManhattanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            List<float> distances = new List<float>();
            List<List<cooridinate>> answerPairing = new List<List<cooridinate>>();
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
            }
            foreach (List<cooridinate> pair in answerPairing)
            {
                distances.Add(computeManhattanDistance(pair[0], pair[1]));
            }
            float minimumDistance = distances[0];
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
        public float rowbasedMinEuclideanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            List<float> distances = new List<float>();
            List<List<cooridinate>> answerPairing = new List<List<cooridinate>>();
            int selectionIndex = 0;
            if (answers.Count == 0)
            {
                Console.WriteLine("Answer Count is zero");
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
                //  Console.WriteLine("Distance: " + computeEuclideanDistance(pair[0], pair[1]) + " between: " + pair[0].x + " " + pair[0].y + " " + pair[1].x + " " + pair[1].y);
            }
            float minimumDistance = distances[0];
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
            if (selectionIndex < selections.Count)
            {
                selections.RemoveAt(selectionIndex);
            }
            //Console.WriteLine("selection index: " + selectionIndex);
            //thisGame.answers_to_selections_distances
            //thisGame.answers_to_selections_distances.Add(minimumDistance);
            return minimumDistance + rowbasedMinEuclideanDistance(answers, selections);
        }
        public void set_game_data()
        {

            thisGame.emotiv.reading = false;
            thisGame.emotiv.pad_stat_descr();
            Console.WriteLine("AVG, MIN, MAX");
            Console.WriteLine("P: " + thisGame.emotiv.p_avg + " " + thisGame.emotiv.p_min + " " + thisGame.emotiv.p_max);
            Console.WriteLine("A: " + thisGame.emotiv.a_avg + " " + thisGame.emotiv.a_min + " " + thisGame.emotiv.a_max);
            Console.WriteLine("D: " + thisGame.emotiv.d_avg + " " + thisGame.emotiv.d_min + " " + thisGame.emotiv.d_max);
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
                new XElement("user_string", thisSurvey.thisSurvey.name),
                new XElement("game_number", thisGame.game_number),
                new XElement("game_duration", thisGame.show_button_duration),


                     new XElement("number_dots", thisGame.number_dots),
                     new XElement("size", thisGame.size),
                     new XElement("user_game_score_euc", thisGame.user_game_score_euc),
                     new XElement("user_game_score_man", thisGame.user_game_score_man),
                     new XElement("user_game_score_euc_combo", thisGame.user_game_score_euc_combo),
                     new XElement("user_game_score_man_combo", thisGame.user_game_score_man_combo),


                     new XElement("p_avg", thisGame.emotiv.p_avg),
            new XElement("p_min", thisGame.emotiv.p_min),
                new XElement("p_max", thisGame.emotiv.p_max),
            new XElement("a_avg", thisGame.emotiv.a_avg),
                new XElement("a_min", thisGame.emotiv.a_min),
                    new XElement("a_max", thisGame.emotiv.a_max),
            new XElement("d_avg", thisGame.emotiv.d_avg),
                new XElement("d_min", thisGame.emotiv.d_min),
                    new XElement("d_max", thisGame.emotiv.d_max),
                    new XElement("game_start", thisGame.game_start),
                                         new XElement("game_end", thisGame.game_end),
                       new XElement("game_play_duration", thisGame.game_play_duration)));
            doc.Save("games.xml");
            set_textblock_game_data(thisGame.size, thisGame.number_dots, thisGame.user_game_score_euc, thisGame.user_game_score_man, thisGame.user_game_score_euc_combo, thisGame.user_game_score_man_combo, thisGame.show_button_duration);

        }
        private void click_game_event(object sender, RoutedEventArgs e)
        {
            number_dots_clicked += 1;
            set_textblock_game_data(thisGame.size, number_dots_clicked, thisGame.user_game_score_euc, thisGame.user_game_score_man, thisGame.user_game_score_euc_combo, thisGame.user_game_score_man_combo, thisGame.show_button_duration);
            if (number_dots_clicked < thisGame.number_dots)
            {
                custom_button new_button = sender as custom_button;
                button_array[new_button.x, new_button.y].Template = Control_Template.Template;
                button_array[new_button.x, new_button.y].IsEnabled = false;
                cooridinate new_coord = new cooridinate();
                new_coord.x = new_button.x;
                new_coord.y = new_button.y;
                selections.Add(new_coord);
                Console.WriteLine("Click: " + number_dots_clicked + " of " + thisGame.number_dots);
            }
            else
            {
                custom_button new_button = sender as custom_button;
                button_array[new_button.x, new_button.y].Template = Control_Template.Template;
                cooridinate new_coord = new cooridinate();
                new_coord.x = new_button.x;
                new_coord.y = new_button.y;
                selections.Add(new_coord);

                List<cooridinate> answers2 = new List<cooridinate>(answers);
                List<cooridinate> answers3 = new List<cooridinate>(answers);
                List<cooridinate> answers4 = new List<cooridinate>(answers);
                List<cooridinate> selections2 = new List<cooridinate>(selections);
                List<cooridinate> selections3 = new List<cooridinate>(selections);
                List<cooridinate> selections4 = new List<cooridinate>(selections);

                thisGame.user_game_score_man = rowbasedMinManhattanDistance(answers2, selections2);
                thisGame.user_game_score_euc = rowbasedMinEuclideanDistance(answers, selections);

                thisGame.user_game_score_man_combo = combinationMinManhattanDistance(answers3, selections3);
                thisGame.user_game_score_euc_combo = combinationMinEuclideanDistance(answers4, selections4);


                thisGame.game_end = DateTime.Now;
                thisGame.game_play_duration = thisGame.game_start - thisGame.game_end;

                button_next_game.Visibility = Visibility.Visible;  // games over go to the next game
                number_dots_clicked = 0;

                foreach (Button b in button_array)
                {
                    b.IsEnabled = false;
                }

                set_game_data();
            }
        }
        private void click_next_game_event(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Go to the next game");
            thisGame.emotiv.reading = true;
            clear_buttons(button_array);

            run_game();
        }
        private void set_playing_grid_properties(int size, custom_button[,] buttonArray)
        {
            //       Console.WriteLine(button_array.ToString() + "Setting buttonArray with size: " + size);
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
                    buttonArray[i, j].Visibility = Visibility.Visible;
                    buttonArray[i, j].Style = plain_button.Style;
                    buttonArray[i, j].Template = plain_button.Template;

                    buttonArray[i, j].IsEnabled = false;

                    grid_button.Children.Add(buttonArray[i, j]); // add button
                    Grid.SetRow(buttonArray[i, j], buttonArray[i, j].x);
                    Grid.SetColumn(buttonArray[i, j], buttonArray[i, j].y);
                }
            }
        }
        public async void clear_random_pattern(List<cooridinate> coords, custom_button[,] buttonArray, int show_button_duration)
        {
            Console.WriteLine("clearing random pattern");
            await Task.Delay(show_button_duration);
            foreach (cooridinate coord in coords)
            {
                buttonArray[coord.x, coord.y].Template = plain_button.Template;
            }
            foreach (Button b in button_array)
            {
                b.IsEnabled = true;
            }
        }
        public void clear_buttons(custom_button[,] buttonArray)
        {
            //         Console.WriteLine("clearing buttons");
            foreach (custom_button button in buttonArray)
            {
                grid_button.Children.Remove(button);
            }
            for (int i = 0; i < grid_button.RowDefinitions.Count; i++)
            {
                //Console.WriteLine("removing def");
                grid_button.RowDefinitions.Remove(grid_button.RowDefinitions[i]);
                grid_button.ColumnDefinitions.Remove(grid_button.ColumnDefinitions[i]);
            }
            //           Console.WriteLine("Col and Row: " + grid_button.ColumnDefinitions.Count + " " + grid_button.RowDefinitions.Count);
        }
        private custom_button[,] get_button_array(int size)
        {
            //builds the complete button grid, but hides each button
            //Console.WriteLine("Starting set button grid");
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
                    button1.x = i;
                    button1.y = j;
                    button1.Visibility = Visibility.Hidden;
                    buttonArray[i, j] = button1;
                }
            }
            return buttonArray;
        }
        private List<cooridinate> get_random_coordinate_array(int size, int number_dots)
        {
            List<cooridinate> unique = new List<cooridinate>();
            bool unique_flag = true;
            while (unique.Count < number_dots)
            {
                cooridinate coord = new cooridinate();
                coord.x = (int)num.Next(0, size);
                coord.y = (int)num.Next(0, size);

                foreach (cooridinate test_coord in unique)
                {
                    if ((test_coord.x != coord.x ^ test_coord.y != coord.y) || (test_coord.x != coord.x && test_coord.y != coord.y)) // XOR and AND
                    {
                        unique_flag = true;
                    }
                    else
                    {
                        unique_flag = false;
                        break;
                    }
                }
                if (unique_flag == true)
                {
                    Console.WriteLine("Qualifying Coord: " + coord.x + " " + coord.y);
                    unique_flag = false;
                    unique.Add(coord);
                }
            }
            return unique;
        }
        public void set_random_pattern(List<cooridinate> coords, string color, custom_button[,] buttonArray)
        {
            //Console.WriteLine("set_random_pattern");
            foreach (cooridinate coord in coords)
            {
                buttonArray[coord.x, coord.y].Template = Control_Template.Template; ;
                buttonArray[coord.x, coord.y].Visibility = Visibility.Visible;
            }
        }
        public void set_mainwindow(MainWindow mw)
        {
            thisMainWindow = mw;
        }
        public void set_survey(survey survey)
        {
            thisSurvey = survey;

        }


        // new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below// new scoring code below


        // new scoring code below


        public float combinationMinEuclideanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            float[] pairings = createEuclideanMatrix(answers, selections);

            int fact = factorial(answers.Count);
            float[] distances = new float[fact]; // list to store distance combinations
            for (int i = 0; i < distances.Length; i++)
                distances[i] = -1;

            int[] taboo = new int[answers.Count]; // array to store temporarily disallowed indices
            for (int i = 0; i < taboo.Length; i++)
                taboo[i] = -1;

            int index = 0;
            createCombos(ref distances, pairings, 0, taboo, answers.Count, 0, ref index);

            float minDistance = Single.MaxValue;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < minDistance)
                {
                    minDistance = distances[i];
                }
            }

            return minDistance;

        }

        public int combinationMinManhattanDistance(List<cooridinate> answers, List<cooridinate> selections)
        {
            int[] pairings = createManhattanMatrix(answers, selections);

            int fact = factorial(answers.Count);
            int[] distances = new int[fact]; // list to store distance combinations
            for (int i = 0; i < distances.Length; i++)
                distances[i] = -1;

            int[] taboo = new int[answers.Count]; // array to store temporarily disallowed indices
            for (int i = 0; i < taboo.Length; i++)
                taboo[i] = -1;

            int index = 0;
            createCombos(ref distances, pairings, 0, taboo, answers.Count, 0, ref index);

            float maxFloat = Single.MaxValue;
            int minDistance = (int)maxFloat - 1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < minDistance)
                {
                    minDistance = distances[i];
                }
            }

            return minDistance;

        }
        public int factorial(int value)
        {
            int fact = 1;
            for (int i = value; i > 0; i--)
                fact *= i;
            return fact;
        }

        public float[] createEuclideanMatrix(List<cooridinate> answers, List<cooridinate> selections)
        {
            // create a list to hold the distances between all possible answer/selection pairs
            float[] pairings = new float[answers.Count * selections.Count];
            for (int i = 0; i < answers.Count; i++)
            {
                for (int j = 0; j < selections.Count; j++)
                {
                    // answer/selection pair (e.g. a1s1, ..., a1sn)
                    float dist = computeEuclideanDistance(answers[i], selections[j]);
                    pairings[i * selections.Count + j] = dist;
                }
            }

            // this is a matrix containing distances between answers and selections
            // has the form (a1s1, a1s2, ..., a1sn, ..., ans1, ans2, ..., ansn)
            return pairings;
        }

        public int[] createManhattanMatrix(List<cooridinate> answers, List<cooridinate> selections)
        {
            // create a list to hold the distances between all possible answer/selection pairs
            int[] matrix = new int[answers.Count * selections.Count];
            for (int i = 0; i < answers.Count; i++)
            {
                for (int j = 0; j < selections.Count; j++)
                {
                    // answer/selection pair (e.g. a1s1, ..., a1sn)
                    int dist = computeManhattanDistance(answers[i], selections[j]);
                    matrix[i * selections.Count + j] = dist;
                }
            }

            // this is a matrix containing distances between answers and selections
            // has the form (a1s1, a1s2, ..., a1sn, ..., ans1, ans2, ..., ansn)
            return matrix;
        }
        public void createCombos(ref float[] distances, float[] pairings, float temp, int[] taboo,
                                         int numAnswers, int distancesAdded, ref int distancesIndex)
        {
            for (int i = numAnswers * distancesAdded; i < numAnswers * (distancesAdded + 1); i++)
            {
                if (distancesAdded == numAnswers)
                {
                    // add the total distance to the distances array
                    distances[distancesIndex] = temp;
                    distancesIndex++;
                    break;
                }
                else
                {
                    bool isTaboo = false;
                    for (int t = 0; t < taboo.Length; t++)
                    {
                        // same column check, same row check
                        if (taboo[t] != -1 &&
                            (i % numAnswers == taboo[t] % numAnswers ||
                            i / numAnswers == taboo[t] / numAnswers))
                        {
                            isTaboo = true; // found a value in the same row or same column
                        }
                    }

                    if (!isTaboo)
                    {
                        // increment
                        temp += pairings[i];
                        taboo[distancesAdded] = i;
                        distancesAdded++;
                        // recurse
                        createCombos(ref distances, pairings, temp, taboo,
                                     numAnswers, distancesAdded, ref distancesIndex);
                        // decrement
                        temp -= pairings[i];
                        taboo[distancesAdded - 1] = -1;
                        distancesAdded--;
                    }
                }
            }
        }


        public void createCombos(ref int[] distances, int[] pairings, int temp, int[] taboo,
                                 int numAnswers, int distancesAdded, ref int distancesIndex)
        {
            for (int i = numAnswers * distancesAdded; i < numAnswers * (distancesAdded + 1); i++)
            {
                if (distancesAdded == numAnswers)
                {
                    // add the total distance to the distances array
                    distances[distancesIndex] = temp;
                    distancesIndex++;
                    break;
                }
                else
                {
                    bool isTaboo = false;
                    for (int t = 0; t < taboo.Length; t++)
                    {
                        // same column check, same row check
                        if (taboo[t] != -1 &&
                            (i % numAnswers == taboo[t] % numAnswers ||
                            i / numAnswers == taboo[t] / numAnswers))
                        {
                            isTaboo = true; // found a value in the same row or same column
                        }
                    }
                    if (!isTaboo)
                    {
                        // increment
                        temp += pairings[i];
                        taboo[distancesAdded] = i;
                        distancesAdded++;
                        // recurse
                        createCombos(ref distances, pairings, temp, taboo,
                                     numAnswers, distancesAdded, ref distancesIndex);
                        // decrement
                        temp -= pairings[i];
                        taboo[distancesAdded - 1] = -1;
                        distancesAdded--;
                    }
                }
            }
        }







    }


}
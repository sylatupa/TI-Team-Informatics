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
using main; //TI main functions



namespace Working_Memory_Battery_and_Sensor_Input
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
        /// This calls main
        /// performs interaction with the gui
        /// all major operation of the gui are written in the gui_and_visualization_class
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();
            Main main = new Main();
            main.main();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService n = NavigationService.GetNavigationService();
            //this.NavigationService.Navigate(new Uri("SelectionPage.xaml", UriKind.Relative));
            //n.Navigate(new Uri("Introduction.xaml", UriKind.Relative));

            // this.Frame.Navigate(typeof(Introduction));
        }
        string current_player1 = "", current_player2 = "";
        int p1 = 0, p2 = 0;

        private System.Windows.Controls.Button[] _buttonArray;
        Button hold_button;
        public void Form1()
        {
            //   InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _buttonArray = new Button[4] { button1, button2, button3, button4 };
            condition.Content = "Player-1 Place the Point";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Background == Brushes.LightGreen)
            {
                move_button(condition.Content.ToString().Split(new char[] { ' ' })[0].ToString(), hold_button, button1);
            }
            else
            {
                Place_Point(button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Background == Brushes.LightGreen)
            {
                move_button(condition.Content.ToString().Split(new char[] { ' ' })[0].ToString(), hold_button, button2);
            }
            else
            {
                Place_Point(button2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Background == Brushes.LightGreen)
            {
                move_button(condition.Content.ToString().Split(new char[] { ' ' })[0].ToString(), hold_button, button3);
            }
            else
            {
                Place_Point(button3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Background == Brushes.LightGreen)
            {
                move_button(condition.Content.ToString().Split(new char[] { ' ' })[0].ToString(), hold_button, button4);
            }
            else
            {
                Place_Point(button4);
            }
        }

        public class TicTacToeUtils
        {
            // Winners contains all the array locations of
            // the winning combination -- if they are all 
            // either X or O (and not blank)
            static private int[,] Winners = new int[,]
				   {
						{0,1,2},
						{3,4,5},
						{6,7,8},
						{0,3,6},
						{1,4,7},
						{2,5,8},
						{0,4,8},
						{2,4,6}
				   };

            //--------------------------------------------------------------
            // CheckAndProcessWinner determines if either X or O has won.
            // Once a winner has been determined, play stops.
            //--------------------------------------------------------------
            static public bool CheckAndProcessWinner(Button[] myControls)
            {
                bool gameOver = false;
                for (int i = 0; i < 8; i++)
                {
                    int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];		// get the indices
                    // of the winners

                    Button b1 = myControls[a], b2 = myControls[b], b3 = myControls[c];// just to make the 
                    // the code readable

                    if (b1.Content.ToString() == "" || b2.Content.ToString() == "" || b3.Content.ToString() == "")	// any of the squares blank
                        continue;											// try another -- no need to go further

                    if (b1.Content.ToString() == b2.Content.ToString() && b2.Content.ToString() == b3.Content.ToString())			// are they the same?
                    {
                        /*// if so, they WIN!
                        b1.Background = b2.Background = b3.Background = Color.LightCoral;
                        b1.FontStyle = b2.FontStyle = b3.FontStyle = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        gameOver = true;
                        break;  // don't bother to continue
                         */
                    }
                }
                return gameOver;

            }
        }

        void Place_Point(Button button)
        {
            try
            {
                if (condition.Content.ToString().Split(new char[] { ' ' })[0].ToString() == "Player-1")
                {
                    if (current_player1 == "")
                    {
                        if ((p1 < 3) && (button.Content.ToString() == ""))
                        {
                            button.Content = "0";
                            button.Foreground = Brushes.Blue;
                            record_condition("Player-1", button.Name, "Placed at ");
                            if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                            {
                                condition.Content = "Player 1 Won The Match";
                                MessageBox.Show("Game Over.. Player 1 won The Match");
                                disable();
                                
                            }
                            p1++;
                            if (p1 <= 3)
                            {
                                conditions("0");
                            }
                            else
                            {
                                moves("0");
                            }
                        }
                        else
                        {
                            check_back_color_button();
                            possi_moves(Convert.ToInt32(button.Name.Substring(6)), "0", button);

                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (current_player2 == "")
                    {
                        if ((p2 < 3) && (button.Content.ToString() == ""))
                        {
                            button.Content = "X";
                            button.Foreground = Brushes.Red;
                            record_condition("Player-2", button.Name, "Place at ");
                            if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                            {
                                condition.Content= "Player 2 Won The Match";
                                MessageBox.Show("Game Over.. Player 2 won The Match");
                                disable();
                            }
                            p2++;
                            if (p2 <= 2)
                            {
                                conditions("X");
                            }
                            else
                            {
                                moves("X");

                            }
                        }
                        else
                        {
                            check_back_color_button();
                            possi_moves(Convert.ToInt32(button.Name.Substring(6)), "X", button);

                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        void disable()
        {
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    //_buttonArray[i].Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }

        }

        void conditions(string value)
        {
            try
            {
                if (value == "0")
                {
                    condition.Content = "Player-2 Place the Point";
                }
                else
                {
                    condition.Content = "Player-1 Place the Point";
                }
            }
            catch (Exception ex)
            {
            }
        }

        void moves(string value)
        {
            try
            {
                if (value == "0")
                {
                    condition.Content = "Player-2 Move the Point";
                }
                else
                {
                    condition.Content = "Player-1 Move the Point";
                }
            }
            catch (Exception ex)
            {
            }
        }

        void record_condition(string player, string position, string condition)
        {
            if (player == "Player-1")
            {
                //                listBox1.Items.Add(condition.ToString()+position.ToString().Substring(6));
            }
            else
            {
                //              listBox2.Items.Add(condition.ToString()+position.ToString().Substring(6));
            }
        }

        void possi_moves(int button_no, string player, Button butt)
        {
            int[] a = new int[] { 1, 3 };
            int[] b = new int[] { 0, 2, 4 };
            int[] c = new int[] { 1, 5 };
            int[] d = new int[] { 0, 4, 6 };
            int[] e = new int[] { 1, 3, 5, 7 };
            int[] f = new int[] { 2, 4, 8 };
            int[] g = new int[] { 3, 7 };
            int[] h = new int[] { 4, 6, 8 };
            int[] i = new int[] { 5, 7 };
            hold_button = butt;
            if ((button_no == 1) && (butt.Content.ToString() == player.ToString().Trim()))
            {
                for (int j = 0; j <= a.Count(); j++)
                {
                    if (_buttonArray[a[j]].Content.ToString() == "")
                    {
                        _buttonArray[a[j]].Background = Brushes.LightGreen;
                    }
                }
            }
            if ((button_no == 2) && (butt.Content.ToString() == player.ToString().Trim()))
            {
                for (int j = 0; j <= b.Count(); j++)
                {
                    if (_buttonArray[b[j]].Content.ToString() == "")
                    {
                        _buttonArray[b[j]].Background = Brushes.LightGreen;
                    }
                }
            }
            if ((button_no == 3) && (butt.Content.ToString() == player.ToString().Trim()))
            {
                for (int j = 0; j <= c.Count(); j++)
                {
                    if (_buttonArray[c[j]].Content.ToString() == "")
                    {
                        _buttonArray[c[j]].Background = Brushes.LightGreen;
                    }
                }
            }
            if ((button_no == 4) && (butt.Content.ToString() == player.ToString().Trim()))
            {
                for (int j = 0; j <= d.Count(); j++)
                {
                    if (_buttonArray[d[j]].Content.ToString() == "")
                    {
                        _buttonArray[d[j]].Background = Brushes.LightGreen;
                    }
                }
            }
        }

        void check_back_color_button()
        {
            for (int i = 0; i < 9; i++)
            {
                if (_buttonArray[i].Background == Brushes.LightGreen)
                {
                    _buttonArray[i].Background = Brushes.LightGray;
                }

            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTicTacToe();
        }

        void move_button(string player, Button hold_button, Button move_button)
        {
            try
            {
                if (player == "Player-1")
                {
                    if (hold_button.Content.ToString() == "0")
                    {
                        move_button.Content = hold_button.Content.ToString();
                        hold_button.Content = "";
                        move_button.Background = Brushes.Blue;
                        record_condition("Player-1", move_button.Name, "Move to ");
                        check_back_color_button();
                        moves("0");
                        if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                        {
                            condition.Content = "Player 1 Won The Match";
                            MessageBox.Show("Game Over.. Player 1 won The Match");
                            disable();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Move..");
                    }
                }
                else
                {
                    if (hold_button.Content.ToString() == "X")
                    {
                        move_button.Content = hold_button.Content.ToString();
                        hold_button.Content = "";
                        move_button.Background = Brushes.Red;
                        record_condition("Player-2", move_button.Name, "Move to ");
                        check_back_color_button();
                        moves("X");
                        if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                        {
                            condition.Content = "Player 2 Won The Match";
                            MessageBox.Show("Game Over.. Player 2 won The Match");
                            disable();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Move..");
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        #region New Game
        private void InitTicTacToe()
        {
            for (int i = 0; i < 9; i++)
            {
                _buttonArray[i].Content = "";
                _buttonArray[i].Background = Brushes.LightGray;
                
            }
          //  listBox1.Items.Clear();
          //  listBox2.Items.Clear();
            condition.Content = "";
            p1 = 0; p2 = 0;
            current_player1 = "";
            current_player2 = "";
            condition.Content = "Player-1 Place the Point";
            for (int i = 0; i < 9; i++)
            {
               // _buttonArray[i].Enabled = true;
            }
        }
    }
}
        #endregion
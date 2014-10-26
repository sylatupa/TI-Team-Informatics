using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toi
{
    public partial class Form1 : Form
    {
        string current_player1 = "", current_player2 = "";
        int p1 = 0, p2 = 0;
        private System.Windows.Forms.Button[] _buttonArray;
        Button hold_button;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _buttonArray = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            condition.Text = "Player-1 Place the Point";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button1);
            }
            else
            {
                Place_Point(button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button2);
            }
            else
            {
                Place_Point(button2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button3);
            }
            else
            {
                Place_Point(button3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button4);
            }
            else
            {
                Place_Point(button4);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button5);
            }
            else
            {
                Place_Point(button5);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button6);
            }
            else
            {
                Place_Point(button6);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button7);
            }
            else
            {
                Place_Point(button7);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button8);
            }
            else
            {
                Place_Point(button8);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.LightGreen)
            {
                move_button(condition.Text.Split(new char[] { ' ' })[0].ToString(), hold_button, button9);
            }
            else
            {
                Place_Point(button9);
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

                    if (b1.Text == "" || b2.Text == "" || b3.Text == "")	// any of the squares blank
                        continue;											// try another -- no need to go further

                    if (b1.Text == b2.Text && b2.Text == b3.Text)			// are they the same?
                    {														// if so, they WIN!
                        b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                        b1.Font = b2.Font = b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        gameOver = true;
                        break;  // don't bother to continue
                    }
                }
                return gameOver;
                
            }
        }

        void Place_Point(Button button)
        {
            try
            {
                if (condition.Text.Split(new char[] { ' ' })[0].ToString() == "Player-1")
                {
                    if (current_player1 == "")
                    {
                        if ((p1 < 3) && (button.Text == ""))
                        {
                            button.Text = "0";
                            button.ForeColor = Color.Blue;
                            record_condition("Player-1", button.Name, "Placed at ");
                            if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                            {
                                condition.Text = "Player 1 Won The Match";
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
                        if ((p2 < 3) && (button.Text == ""))
                        {
                            button.Text = "X";
                            button.ForeColor = Color.Red;
                            record_condition("Player-2", button.Name, "Place at ");
                            if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                            {
                                condition.Text = "Player 2 Won The Match";
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
                    _buttonArray[i].Enabled = false;
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
                    condition.Text = "Player-2 Place the Point";
                }
                else
                {
                    condition.Text = "Player-1 Place the Point";
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
                    condition.Text = "Player-2 Move the Point";
                }
                else
                {
                    condition.Text = "Player-1 Move the Point";
                }
            }
            catch (Exception ex)
            {
            }
        }

        void record_condition(string player,string position,string condition)
        {
            if (player == "Player-1")
            {
                listBox1.Items.Add(condition.ToString()+position.ToString().Substring(6));
            }
            else
            {
                listBox2.Items.Add(condition.ToString()+position.ToString().Substring(6));
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
            if ((button_no == 1) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= a.Count(); j++)
                {
                    if (_buttonArray[a[j]].Text == "")
                    {
                        _buttonArray[a[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 2) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= b.Count(); j++)
                {
                    if (_buttonArray[b[j]].Text == "")
                    {
                        _buttonArray[b[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 3) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= c.Count(); j++)
                {
                    if (_buttonArray[c[j]].Text == "")
                    {
                        _buttonArray[c[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 4) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= d.Count(); j++)
                {
                    if (_buttonArray[d[j]].Text == "")
                    {
                        _buttonArray[d[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 5) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= e.Count(); j++)
                {
                    if (_buttonArray[e[j]].Text == "")
                    {
                        _buttonArray[e[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 6) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= f.Count(); j++)
                {
                    if (_buttonArray[f[j]].Text == "")
                    {
                        _buttonArray[f[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 7) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= g.Count(); j++)
                {
                    if (_buttonArray[g[j]].Text == "")
                    {
                        _buttonArray[g[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 8) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= h.Count(); j++)
                {
                    if (_buttonArray[h[j]].Text == "")
                    {
                        _buttonArray[h[j]].BackColor = Color.LightGreen;
                    }
                }
            }
            if ((button_no == 9) && (butt.Text == player.ToString().Trim()))
            {
                for (int j = 0; j <= i.Count(); j++)
                {
                    if (_buttonArray[i[j]].Text == "")
                    {
                        _buttonArray[i[j]].BackColor = Color.LightGreen;
                    }
                }
            }
        }

        void check_back_color_button()
        {
            for (int i = 0; i < 9; i++)
            {
                if (_buttonArray[i].BackColor == Color.LightGreen)
                {
                    _buttonArray[i].BackColor = Color.LightGray;
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                    if (hold_button.Text == "0")
                    {
                        move_button.Text = hold_button.Text;
                        hold_button.Text = "";
                        move_button.ForeColor = Color.Blue;
                        record_condition("Player-1", move_button.Name, "Move to ");
                        check_back_color_button();
                        moves("0");
                        if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                        {
                            condition.Text = "Player 1 Won The Match";
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
                    if (hold_button.Text == "X")
                    {
                        move_button.Text = hold_button.Text;
                        hold_button.Text = "";
                        move_button.ForeColor = Color.Red;
                        record_condition("Player-2", move_button.Name, "Move to ");
                        check_back_color_button();
                        moves("X");
                        if (TicTacToeUtils.CheckAndProcessWinner(_buttonArray))
                        {
                            condition.Text = "Player 2 Won The Match";
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
                _buttonArray[i].Text = "";
                _buttonArray[i].BackColor = Color.LightGray;
                
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            condition.Text = "";
            p1 = 0; p2 = 0;
            current_player1 = "";
            current_player2 = "";
            condition.Text = "Player-1 Place the Point";
            for (int i = 0; i < 9; i++)
            {
                _buttonArray[i].Enabled = true;
            }
        }
        #endregion
    }
}

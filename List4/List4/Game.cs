using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List4
{

    public partial class Game : Form
    {
        private Label[,] labels = new Label[3,3];
        private bool mainMenuButton = false;
        public enum Players
        {
            X = 0, O
        }

        public static Players? playerTurn;

        public Game()
        {
            InitializeComponent();

            //init event handlers
            label1.Click += new System.EventHandler(HandlePlayerTurn); labels[0, 0] = label1;
            label2.Click += new System.EventHandler(HandlePlayerTurn); labels[0, 1] = label2;
            label3.Click += new System.EventHandler(HandlePlayerTurn); labels[0, 2] = label3;
            label4.Click += new System.EventHandler(HandlePlayerTurn); labels[1, 0] = label4;
            label5.Click += new System.EventHandler(HandlePlayerTurn); labels[1, 1] = label5;
            label6.Click += new System.EventHandler(HandlePlayerTurn); labels[1, 2] = label6;
            label7.Click += new System.EventHandler(HandlePlayerTurn); labels[2, 0] = label7;
            label8.Click += new System.EventHandler(HandlePlayerTurn); labels[2, 1] = label8;
            label9.Click += new System.EventHandler(HandlePlayerTurn); labels[2, 2] = label9;

            //selecting random initial turn of the players
            Random rnd = new Random();
            if (rnd.Next(0, 1) == 0) playerTurn = Players.X;
            else playerTurn = Players.O;

            playerTurnLabel.Text += (playerTurn == Players.X ? " X" : " O");
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!mainMenuButton)
            Application.Exit();
        }

        private int Minimax(Label[,] board, int depth, bool isMaximizing)
        {
            if (CheckTheWinner()=='O')
                return 10 - depth;
            if (CheckTheWinner()=='X')
                return depth - 10;
            if (CheckTheWinner()=='-')
                return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j].Text == "")
                        {
                            board[i, j].Text = "O";
                            int score = Minimax(board, depth + 1, false);
                            board[i, j].Text = "";
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i,j].Text == "")
                        {
                            board[i, j].Text = "X";
                            int score = Minimax(board, depth + 1, true);
                            board[i, j].Text = "";
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }

                return bestScore;
            }
        }

        private char CheckTheWinner()
        {
            char temp = 'i';
            //int counter = 1;

            //checking the rows
            for(int i = 0;i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (labels[i, j].Text==""){ temp = 'i'; break; }
                    else if (temp == 'i') temp = labels[i, j].Text[0];
                    else if (temp != labels[i, j].Text[0]) { temp = 'i'; break; }
                }
                if (temp != 'i') break;
            }

            //checking the columns
            for(int i = 0;i<3;i++)
            {
                for(int j = 0;j<3;j++)
                {
                    if (labels[j,i].Text==""){ temp = 'i'; break; }
                    else if (temp == 'i') temp = labels[j, i].Text[0];
                    else if (temp != labels[j, i].Text[0]) { temp = 'i'; break; }
                }
                if (temp != 'i') break;
            }

            //checking crosses
            for (int i = 0; i < 3; i++)
            {
                if (labels[i, i].Text == "") { temp = 'i'; break; }
                else if (temp == 'i') temp = labels[i, i].Text[0];
                else if (temp != labels[i, i].Text[0]) { temp = 'i'; break; }
            }
            if (temp == 'i')
            {
                for (int i = 0; i < 3; i++)
                {
                    if (labels[i, 2 - i].Text == "") { temp = 'i'; break; }
                    else if (temp == 'i') temp = labels[i, 2 - i].Text[0];
                    else if (temp != labels[i, 2 - i].Text[0]) { temp = 'i'; break; }
                }
            }

            //checking if it's even
            bool even = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j=0; j < 3; j++)
                {
                    if (labels[i, j].Text == "") { even = false; break; }
                    else if (labels[i, j].Text != "" && i == 2 && j == 2) 
                    {
                        return '-';
                    }
                }
                if (!even) break;
            }

            return temp;
        }

        private void HandlePlayerTurn(object sender, EventArgs e)
        {
            Label crn = (Label)sender;
            switch (playerTurn)
            {
                case Players.X: crn.Text = "X"; crn.Enabled = false; playerTurn = Players.O; playerTurnLabel.Text = "Player Turn: O"; break;
                case Players.O: crn.Text = "O"; crn.Enabled = false; playerTurn = Players.X; playerTurnLabel.Text = "Player Turn: X"; break;
            }
            switch(CheckTheWinner())
            {
                case 'X':SetTheWinner('X');break;
                case 'O':SetTheWinner('O');break;
                case '-':SetTheWinner('-');break;
            }
        }

        void SetTheWinner(char winner)
        {
            foreach(var label in labels)
            {
                label.Enabled = false;
            }
            switch(winner)
            {
                case 'X': playerTurnLabel.ForeColor = Color.Green;
                playerTurnLabel.Text = "The Winner is X";break;
                case 'O':playerTurnLabel.ForeColor = Color.Green;
                playerTurnLabel.Text = "The Winner is O";break;
                case '-':playerTurnLabel.ForeColor = Color.Red;
                playerTurnLabel.Text = "Draw";break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenuButton = true;
            Close();
            TicTacToeForm.mainMenuForm.Visible = true;
        }
    }
}

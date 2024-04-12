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
        private Label[] labels = new Label[9];
        private bool mainMenuButton = false;
        public enum Players
        {
            X = 0, Y
        }

        public static Players? playerTurn;

        public Game()
        {
            InitializeComponent();
            label1.Click += new System.EventHandler(HandlePlayerTurn); labels[0] = label1;
            label2.Click += new System.EventHandler(HandlePlayerTurn); labels[1] = label2;
            label3.Click += new System.EventHandler(HandlePlayerTurn); labels[2] = label3;
            label4.Click += new System.EventHandler(HandlePlayerTurn); labels[3] = label4;
            label5.Click += new System.EventHandler(HandlePlayerTurn); labels[4] = label5;
            label6.Click += new System.EventHandler(HandlePlayerTurn); labels[5] = label6;
            label7.Click += new System.EventHandler(HandlePlayerTurn); labels[6] = label7;
            label8.Click += new System.EventHandler(HandlePlayerTurn); labels[7] = label8;
            label9.Click += new System.EventHandler(HandlePlayerTurn); labels[8] = label9;

            //selecting random initial turn of the players
            Random rnd = new Random();
            if (rnd.Next(0, 1) == 0) playerTurn = Players.X;
            else playerTurn = Players.Y;

            playerTurnLabel.Text += (playerTurn == Players.X ? " X" : " O");
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!mainMenuButton)
            Application.Exit();
        }

        private char CheckTheWinner()
        {
            char temp = 'i';
            int counter = 1;

            

            //checking the rows
            for (int i = 0; i < labels.Length; i++)
            {
                if (counter % 3 != 0)
                {
                    if (labels[i].Text == "") { temp = 'i'; i += 2 - (i % 3); counter = 1; continue; }
                    else if (temp == 'i') { temp = labels[i].Text[0]; continue; }
                    else if (temp != labels[i].Text[0]) { temp = 'i'; i += 2 - (i % 3); counter = 1; continue; }
                    counter++;
                }
                else if (temp != 'i') return temp;
            }

            //checking the columns
            for (int i = 0; i < labels.Length;)
            {
                if (counter % 3 != 0)
                {
                    if (labels[i].Text == "")
                    {
                        temp = 'i';
                        if (i == 2 || i == 5 | i == 8) break;
                        i = 1 + (i % 3);
                        counter = 1;
                        continue;
                    }
                    else if (temp == 'i') { temp = labels[i].Text[0]; i += 3; continue; }
                    else if (temp != labels[i].Text[0]) { temp = 'i'; if (i == 2 || i == 5 | i == 8) break; i = 1 + (i % 3); counter = 1; continue; }
                    counter++; 
                    if (counter % 3 == 0) return temp;
                    i += 3;
                }
            }

            bool reverse = false;
            //checking crosses
            for (int i = 0; i < labels.Length;)
            {
                if (labels[i].Text == "")
                {
                    temp = 'i';
                    if (i == 6||i==4||i==2) break;
                    i = 6; reverse = true; continue;
                }
                else if (temp == 'i') { temp = labels[i].Text[0]; }
                else if (temp != labels[i].Text[0]) {  temp = 'i';if (i == 6||i==4||i==2) break; i = 6;reverse = true; continue; }
                if (!reverse) i += 4;
                else { if (i == 2) break; i -= 2; }
            }


            for (int i = 0; i < labels.Length && temp == 'i'; i++)
            {
                if (labels[i].Text == "") break;
                else if (labels[i].Text != "" && i == 8)
                {
                    return '-';
                }
            }

            return temp;
        }

        private void HandlePlayerTurn(object sender, EventArgs e)
        {
            Label crn = (Label)sender;
            switch (playerTurn)
            {
                case Players.X: crn.Text = "X"; crn.Enabled = false; playerTurn = Players.Y; playerTurnLabel.Text = "Player Turn: O"; break;
                case Players.Y: crn.Text = "O"; crn.Enabled = false; playerTurn = Players.X; playerTurnLabel.Text = "Player Turn: X"; break;
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
                case 'Y':playerTurnLabel.ForeColor = Color.Green;
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

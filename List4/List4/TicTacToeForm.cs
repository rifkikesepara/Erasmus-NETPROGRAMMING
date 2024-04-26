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
    public partial class TicTacToeForm : Form
    {
        public static Form mainMenuForm;
        public enum GameState
        {
            TwoPlayer=0,Computer
        }

        public static GameState? gameState;
        public TicTacToeForm()
        {
            InitializeComponent();
            mainMenuForm = this;
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            Visible=false;
            gameState= GameState.TwoPlayer;
            Game gameForm = new Game();
            gameForm.Show();
        }

        private void aiButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            gameState = GameState.Computer;
            Game gameForm = new Game();
            gameForm.Show();
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {

        }
    }
}

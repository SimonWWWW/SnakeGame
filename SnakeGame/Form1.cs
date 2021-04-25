using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>(); //creating an list array for the snake
        private Circle food = new Circle(); //creating a single Circle class called food
        public Form1()
        {
            InitializeComponent();
            new Settings(); //linking the Settings CLass to this Form
            gameTimer.Interval = 1000 / Settings.Speed; // changing the game time to settings speed
            gameTimer.Tick += updateScreen; //linking a updateScreen function to the timer
            gameTimer.Start(); //starting the timer
            startGame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

        }

        private void keyisup(object sender, KeyEventArgs e)
        {

        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {

        }
        private void updateScreen(object sender, EventArgs e)
        {
            //timers update screen function
            if(Settings.GameOver == true)
            {
                //if the tame over is true and players presses enter we run the start game function
                if (Input.KeyPress(Keys.Enter))
                {
                    startGame();
                }
            }
            else
            {
                //if the game is not over then the following commands will be executed
                //below the actions will probe the keys being pressed by the player
                //and move the accoridingly
                if(Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                movePlayer(); //run move player function
            }
            pbCanvas.Invalidate(); //refresh the picture box and update graphics on it
        }
        private void startGame()
        {

        }
        private void movePlayer()
        {

        }
        private void generateFood()
        {

        }
        private void eat()
        {

        }
        private void die()
        {

        }
    }
}

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
            for (int i = Snake.Count -1; i>= 0; i--)
            {
                if(i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }
                    int maxXpos = pbCanvas.Size.Width / Settings.Width;
                    int maxYpos = pbCanvas.Size.Height / Settings.Height;
                    if (
                        Snake[i].X < 0 || Snake[i].Y < 0 || 
                        Snake[i].X > maxXpos || Snake[i].Y > maxXpos)
                    {
                        //end the game is snake either reaches edge of the canvas
                        die();
                    }
                    //detect collision with the body
                    for(int j = 1; j < Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            die();
                        }
                    }
                    //detect collision between snake head and food
                    if(Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        eat(); // run eat function
                    }
                }
                else
                {
                    //if there are no collisions then we continue moving the snake 
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
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

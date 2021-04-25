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
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true); //key down trigger the change state from the Input class
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false); //key up trigger the change state from the Input class
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            //this is where we will see the snake and its parts moving
            Graphics canvas = e.Graphics;//create a new graphics class called canvas
            if(Settings.GameOver == false)
            {
                //if the game is not over then we do the following
                Brush snakeColour; // create a new brush called snake colour
                //run a loop to check the snake parts
                for(int i = 0; i < Snake.Count; i++)
                {
                    if(i == 0)
                    {
                        //colour the head of the snake = black
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        //the colour of the rest body = green
                        snakeColour = Brushes.Green;
                    }
                    //draw snake body and head
                    canvas.FillEllipse(snakeColour, new Rectangle(Snake[i].X * Settings.Width,
                        Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
                    //draw food
                    canvas.FillEllipse(Brushes.Red, new Rectangle(food.X * Settings.Width,
                        food.Y * Settings.Height, Settings.Width, Settings.Height));
                    }
                }
            else
            {
                // this part will run when the game is over
                //it will show the game over text and make the label 3 visible on the screen
                string gameOver = "Game Over\n" + "Final Score is " + Settings.Score + "\n Press enter to Restart";
                label3.Text = gameOver;
                label3.Visible = true;
            }
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
            //start game function
            label3.Visible = false;// label 3 invisible
            new Settings(); //new instance of settings
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };// new head for the snake
            Snake.Add(head); // add the head to snake array

            label2.Text = Settings.Score.ToString(); // show the score to the label 2

            generateFood();// run the generate food function
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
            int maxXpos = pbCanvas.Size.Width / Settings.Width;
            // create a maximum X posistion int with half the size of the play area
            int maxYpos = pbCanvas.Size.Height / Settings.Height;
            // create a maximum Y posistion int with half the size of the play area
            Random rnd = new Random(); // new random class
            food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) }; //food with random positions
        }
        private void eat()
        {
            //add a part to body
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);//add the part to the snakes array
            Settings.Score += Settings.Points;//increase the score for the game
            label2.Text = Settings.Score.ToString();//show the score on the label 2
            generateFood();
        }
        private void die()
        {
            //change the game over Boolean to true
            Settings.GameOver = true;
        }
    }
}

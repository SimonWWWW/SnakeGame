﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
        public enum Directions
        {
            //enum class for classify directions
            Left,
            Right,
            Up,
            Down
        };
        class Settings
        {
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Speed { get; set; }
            public static int Score { get; set; }
            public static int Points { get; set; }
            public static bool GameOver { get; set; }
            public static Directions direction { get; set; } //direction as the class
            public Settings()
            {
                //default settings
                Width = 16;
                Height = 16;
                Speed = 20;
                Score = 0;
                Points = 100;
                GameOver = false;
                direction = Directions.Down;
            }
        }
    }

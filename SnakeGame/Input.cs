using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace SnakeGame
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable(); 
        //instance of Hashtable class used to optimize the keys inserted in it
        public static bool KeyPress(Keys key)
        {
            //this function will return a key back to the class
            if (keyTable[key] == null)
            {
                // if the hashtable is empty we return false
                return false;
            }
            // if the hashtable is not empty we return true
            return (bool)keyTable[key];
        }
        public static void changeState(Keys key, bool state)
        {
            //this function will change state of the keys and the player with it
            //this function has two arguments Key and state
            keyTable[key] = state;
        }
    }
}

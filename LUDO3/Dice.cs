using System;
using System.Collections.Generic;
using System.Text;

namespace Ludogame
{
    class Dice
    {
        public Random dice;
        public Dice() {
            //Laver random
            dice = new Random();
        }
        //Laver terning funktionen der retunere et kast imellem 1 og 7
        public int kast()
        {
            return dice.Next(1, 7);
        }
    }
}

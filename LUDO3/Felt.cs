using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Ludogame
{
    class Felt
    {
        //Opretter int x og y som skal bruges til kordinator
        private int x;
        private int y;

        //Opretter en metode der fortæller er at den x, y er lige med x, y
        public Felt(int x, int y)
        {
            this.x = x;
            this.y = y;
        } 
    }
}

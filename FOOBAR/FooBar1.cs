// Foobar called by main program'

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar1
{
    class FooBar
    {
        public int x;
        public string a = "foo";
        public string b = "Bar";
        List<object> mixedList = new List<object>();

        public FooBar(int x)
        {


            this.x = x;
            for (int i = 1; i < 16; i++)
            {

                if (i % 3 == 0)
                {
                    Console.Write(a + " ,");
                }
                else if (i % 5 == 0)
                {
                    Console.Write(b + " ,");
                }
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write(a + b);
                }
                else
                {
                    Console.Write(i + " ,");
                }
            }
        }
    }
}
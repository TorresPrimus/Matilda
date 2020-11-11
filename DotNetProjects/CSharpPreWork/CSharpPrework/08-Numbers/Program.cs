using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal Bill = 54.23;
            decimal Tip = 12;

            decimal Percentage = Tip / Bill;

            Console.WriteLine(Percentage);
            Console.WriteLine(Math.Round(Percentage, 2));
            Console.ReadLine();
        }
    }
}

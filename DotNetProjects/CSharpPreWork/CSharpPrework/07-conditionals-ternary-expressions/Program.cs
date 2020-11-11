using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_conditionals_ternary_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 10;

            //If Else Statement
            if (number == 7)
                Console.WriteLine("The number is 7.");
            else
                Console.WriteLine("The number is not 7.");

            //Ternary Expression:
            //1        //2    //3           //4    //5
            string response = ((number == 7) ? "The number is 7." : "The number is not 7."); // Parentheses are not necessary. Used for clarity.
            Console.WriteLine(response);
        }
    }
}

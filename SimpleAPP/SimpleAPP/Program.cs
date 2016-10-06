using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates the sum of two numbers");
            Console.WriteLine("Enter the first number");
            string input1 = Console.ReadLine();
            int  a = int.Parse(input1);

            Console.WriteLine("Enter the Second number");
            string input2 = Console.ReadLine();
            int b = int.Parse(input2);

            int c = b + a;
            
            Console.WriteLine("this is the sum of {0}  and {1}  is {2}", a, b, c);
            Console.ReadLine();
        }
    }
}

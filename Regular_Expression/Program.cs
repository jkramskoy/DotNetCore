using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Regular_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("The default regular expression checks for at least one digit.");
            while (true)
            {
                string inputExpression = string.Empty;  //Enter a regular expression
                string defaultExp = "^[a-z]+$";        //use the default
                WriteLine();
                Write("Enter a regular expression (or press ENTER to use the default) : ");

                //if user put ENTER so will use default expression, else will enter regular expression
                if (Console.ReadKey().Key == ConsoleKey.Enter)   
                {
                    inputExpression = defaultExp;
                    WriteLine();
                }
                else
                {
                    inputExpression = ReadLine();
                }

                Write("Enter some input: ");
                string input = ReadLine();

                //Matche regular expression with input
                WriteLine($"{input} matches {inputExpression} ? {Regex.Match(input, inputExpression).Success}");


                Write("Press ESC to end or any key to try again.");
                WriteLine();

                //Press escape to end a programm
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;

            }
        }
    }
}

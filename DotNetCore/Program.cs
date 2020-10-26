using System;
using System.Text;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace DotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
        
//remove not from the sentence.
        string input = @"I do not like them
In a house.
I do not like them
With a mouse.
I do not like them
Here or there.
I do not like them
Anywhere.
I do not like green eggs and ham.
I do not like them, Sam - I - am.";

        //Console.WriteLine(input);

        StringBuilder sb = new StringBuilder(input);

        sb.Replace("not", string.Empty);
sb.Replace(" ", " ");

Console.WriteLine(sb.ToString());
        }
    }
}



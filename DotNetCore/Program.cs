using System;
using MySql.Data.MySqlClient;

namespace DotNetCore
{
    class Program
    {
        static void Main(string[] args) {
        }
        
             private int _id;
             private string _name;

        public Program(string name)
        {
            _name = name;
        }

              public string Name { get => _name; set => _name = value; }
              public int Id { get => _id; set => _id = value; }
    }
}



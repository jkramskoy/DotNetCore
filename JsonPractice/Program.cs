using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonPractice
{
    class Item   //object Item
    {
        public string id { set; get; }
        public string label { set; get; }
    }

    class Menu  //object Menu
    {
        public string header { set; get; }
        public List<Item> items { set; get; }
    }

    class Top  //object not anditifaid, we will call it Top
    {
        public Menu menu { set; get; }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //JSON file 
            try
            {
                //create file
                string path = "menu.json";
                var jsonFile = File.ReadAllText(path);

                Console.Write(jsonFile);
                var resolt = JsonSerializer.Deserialize<Top>(jsonFile); // convert from JSON formate to Object


                Console.WriteLine(resolt.menu.header);

                //go throught list of items
                foreach (var i in resolt.menu.items)
                {
                    if (i != null)
                    {
                        Console.Write("\t id = " + i.id);

                        if (i.label != null)
                            Console.Write("; lable = " + i.label);

                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine("\t null");

                }
              

                // XML file

                XDocument xmlDoc = new XDocument(
                new XElement("menu",
                          new XElement("header", "Abode " + resolt.menu.header),
                          resolt.menu.items
                           .Select(i => i != null ?
                             new XElement("item",
                               new XAttribute("action", i.id),
                               new XAttribute("id", i.id),
                                 i.label != null ?
                                   i.label : i.id

                       ) : new XElement("separator")
                     )
                 )
               );
                xmlDoc.Save("Menu_new.xml");

                Console.Write("File was saved");

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}


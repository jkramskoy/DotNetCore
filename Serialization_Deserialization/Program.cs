using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization_Deserialization
{
    [Serializable()]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public class Shape
    {
        public string Color { set; get; }
        public virtual double Area { get; }

    }

    [Serializable()]
    public class Circle: Shape
    {
        public double Radius { set; get; }
        public override double Area => Math.PI * Math.Pow(Radius, 2);
    }

    [Serializable()]
    public class Rectangle: Shape
    {
        public double Height { set; get; }
        public double Width { set; get; }
        public override double Area => Height * Width;
    }


    class Program
    {
        static void Main(string[] args)
        {
            //create list of Shapes 
            var listOfShapes = new List<Shape>
            {
                new Circle {Color = "Red", Radius = 2.5},
                new Rectangle {Color = "Blue", Height = 20, Width = 10},
                new Circle { Color = "Green", Radius = 8 },
                new Circle {Color = "Purple", Radius = 12.3},
                new Rectangle {Color = "Blue", Height = 45, Width = 18},

            };

            foreach (var form in listOfShapes)
            {
                Console.WriteLine($"{form.GetType().Name} is {form.Color} and has anarea of { form.Area}");
                
            }
            Console.WriteLine("=================================");

            // use serialization to save it to the filesystem using XML
            var xs = new XmlSerializer(typeof(List<Shape>));
            string pathXML = "Shapes.xml";

            using (FileStream fs = File.Create(pathXML))
            {
                xs.Serialize(fs, listOfShapes);
            }

            // then deserializes it back

            using (StringReader sr = new StringReader(File.ReadAllText(pathXML)))
            {
                var resolt = (List<Shape>)xs.Deserialize(sr);
                
                foreach (var form in resolt)
                {
                    
                    Console.WriteLine($"{form.GetType().Name} is {form.Color} and has anarea of { form.Area}");
                }

            }
        }
    }
}

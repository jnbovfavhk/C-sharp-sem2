using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Example
    {
        public static void Main1()
        {
            List<Figure1> figures = new List<Figure1>
        {
            new Circle1 { Name = "Circle1", Radius = 5, Area = Math.PI * 5 * 5 },
            new Square1 { Name = "Square1", SideLength = 4, Area = 4 * 4 }
        };

            Serializer.Serialize1(figures);

            List<Figure1> list = Serializer.Deserialize1();

            foreach (Figure1 f1 in list)
            {
                Console.WriteLine(f1);
            }
        }
    }
}

public class Figure1
{
    public string Name { get; set; }
    public double Area { get; set; }
}

public class Circle1 : Figure1
{
    public double Radius { get; set; }
}

public class Square1 : Figure1
{
    public double SideLength { get; set; }
}

public static class Serializer
{
    public static void Serialize1(List<Figure1> figures)
    {
        string jsonString = JsonSerializer.Serialize(figures);

        using (StreamWriter f = new StreamWriter("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
        {
            f.Write(jsonString);
        }
        Console.WriteLine("Данные записаны");
    }


    public static List<Figure1> Deserialize1()
    {
        string jsonString;

        using (StreamReader reader = new StreamReader("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
        {
            jsonString = reader.ReadToEnd();
        }

        List<Figure1> figures = JsonSerializer.Deserialize<List<Figure1>>(jsonString);
        return figures;
    }
}
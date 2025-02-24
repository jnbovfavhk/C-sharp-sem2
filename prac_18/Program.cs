
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Задание 1\r\n1. Создать абстрактный класс Figure с методами вычисления площади и периметра, " +
                "а также\r\nметодом, выводящим информацию о фигуре на экран.\r\n2. Создать производные классы: Rectangle (прямоугольник), " +
                "Circle (круг), Triangle\r\n(треугольник) со своими методами вычисления площади и периметра.\r\n3. " +
                "Создать массив n фигур и вывести полную информацию о фигурах на экран.");

            List<Figure> figures = Deserialize();

            
            figures.Add(new Circle(10, 0, 1));
            figures.Add(new Rectangle(-2, -4, 5, 2));
            figures.Add(new Triangle());
            figures.Add(new Triangle(0, 0, 0, 2, 2, 0));

            
            Print(figures);
            Console.ReadLine();
            Console.WriteLine(figures);

            Serialize(figures);

            Console.ReadLine();

            List<Figure> figures2 = Deserialize();
            figures2.Add(new Rectangle(4, 6, 5, 2));
            Print(figures2);
        }

        public static void Serialize(List<Figure> figures)
        {
            String jsonString = JsonSerializer.Serialize(figures);
            

            using (StreamWriter f = new StreamWriter("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
               
                f.Write(jsonString);
            }
            Console.WriteLine("Данные записаны");
        }

        public static List<Figure> Deserialize()
        {
            List<Figure> figures = new List<Figure>();

            // Если файла нет, создать
            if (!File.Exists("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
                using (StreamWriter f = new StreamWriter("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
                {

                }
            }

            // считать и десериализовать
            using (StreamReader f = new StreamReader("C:\\Users\\ilyab\\source\\repos\\ConsoleApp1\\prac_18\\data.json"))
            {
                String data = f.ReadToEnd();
                if (data.Length > 0)
                {
                    try
                    {
                        figures = JsonSerializer.Deserialize<List<Figure>>(data);
                        Console.WriteLine("Данные взяты из файла data.json");

                        
                    }
                    catch (NotSupportedException ex)
                    {

                    }
                }
            }
            return figures;
        }

        public static void Print(List<Figure> figures)
        {
            foreach (Figure f in figures)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine("Периметр - " + f.Perimeter());
                Console.WriteLine("Площадь - " + f.Area());

            }
        }
    }
}
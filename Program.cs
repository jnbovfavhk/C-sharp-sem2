using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            List<Figure> figures = new List<Figure>();

            figures.Add(new Circle(10, 0, 1));
            figures.Add(new Rectangle(-2, -4, 5, 2));
            figures.Add(new Triangle());
            figures.Add(new Triangle(0, 0, 0, 2, 2, 0));

            foreach (Figure f in figures)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine("Периметр - " + f.Perimeter());
                Console.WriteLine("Площадь - " + f.Area());

            }
        }
    }
}
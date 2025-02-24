using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class PointFigure : Figure
    {
        public override double Area()
        {
            return 0;
        }

        public override double Perimeter()
        {
            return 0;
        }

        

        public PointFigure()
        {
            this.x = 0;
            this.y = 0;

        }

        public PointFigure(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public PointFigure(PointFigure point)
        {
            this.x = point.GetX();
            this.y = point.GetY();
        }

        // расстояние до центра фигуры
        public double distanceTo(Figure figure)
        {
            return Math.Sqrt(Math.Pow(x - figure.GetX(), 2) + Math.Pow(y - figure.GetY(), 2));
        }
    }
}

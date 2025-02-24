using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class Figure
    {
        // Координаты середины фигуры
        protected double x;

        protected double y;
        


        public virtual double Area()
        {
            return 0;
        }
        public virtual double Perimeter()
        {
            return 0;
        }

        public override string ToString()
        {
            return this.GetType().ToString() + "(" + x + ", " + y + ")";
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            if (this.ToString().Equals(obj.ToString()))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Area(), Perimeter(), x, y);
        }

        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
       
    }

}

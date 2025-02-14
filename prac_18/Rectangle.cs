using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Rectangle : PointFigure
    {
        private PointFigure pointLeftUp;
        private PointFigure pointRightUp;
        private PointFigure pointLeftDown;
        private PointFigure pointRightDown;
        public override double Area()
        {
            return pointLeftUp.distanceTo(pointLeftDown) * pointRightUp.distanceTo(pointLeftUp);
        }

        public override double Perimeter()
        {
            return pointLeftUp.distanceTo(pointLeftDown) * 2 + pointRightUp.distanceTo(pointLeftUp) * 2;
        }

        public Rectangle()
        {
            pointLeftUp = new PointFigure(-10, 10);
            pointLeftDown = new PointFigure(-10, -10);
            pointRightDown = new PointFigure(10, -10);
            pointRightUp = new PointFigure(10, 10);
        }

        public Rectangle(double x, double y, double height, double width)
        {
            this.x = x;
            this.y = y;
            this.pointLeftDown = new PointFigure(x - width / 2, y - height / 2);
            this.pointLeftUp = new PointFigure(x - width / 2, y + height / 2);
            this.pointRightDown = new PointFigure(x + width / 2, y - height / 2);
            this.pointRightUp = new PointFigure(x + width / 2, y + height / 2);

        }

        public Rectangle(Rectangle rect)
        {
            this.pointLeftDown = rect.pointLeftDown;
            this.pointLeftUp = rect.pointLeftUp;
            this.pointRightDown = rect.pointRightDown;
            this.pointRightUp = rect.pointRightUp;
        }

    }
}

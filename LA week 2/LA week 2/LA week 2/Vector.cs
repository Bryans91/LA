using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_2
{
    //opgave 1 b
    class Vector
    {
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double x { get; set; }
        public double y { get; set; }


        public void printVector()
        {
            Console.WriteLine("(" + x + " )");
            Console.WriteLine("(" + y + " )");
        }

        //convert to matrix
        public Matrix toMatrix()
        {
            Matrix m = new Matrix(1, 2);
            m.setValue(0,0, this.x);
            m.setValue(0,1, this.y);

            return m;
        }
    }
}

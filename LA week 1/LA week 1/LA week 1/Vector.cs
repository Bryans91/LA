using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_1
{
    class Vector
    {
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double x { get; set; }
        public double y { get; set; }


        public void printVector(){
            Console.WriteLine("(" + x + " )");
            Console.WriteLine("(" + y + " )");
        }
    }
}

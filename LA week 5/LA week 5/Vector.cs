using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_5
{
    class Vector
    {
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }



        public void printVector(){
            Console.WriteLine("(" + x + " )");
            Console.WriteLine("(" + y + " )");
            Console.WriteLine("(" + z + " )");
        }
    }
}

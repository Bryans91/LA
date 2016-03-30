using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Vector in1 = new Vector(1,2,3);
            Vector in2 = new Vector(5,4,3);

            Console.WriteLine("Inproduct = " + inproduct(in1, in2));
            Console.WriteLine("Uitproduct:");
            uitproduct(in1, in2).printVector();


            Console.ReadKey();

        }

        //Opdracht 1a
        static double inproduct(Vector a, Vector b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        //opdract 1b
        static Vector uitproduct(Vector a, Vector b)
        {
            double tempx = (a.y * b.z) - (b.y * a.z);
            double tempy = (b.x * a.z) - (a.x * b.z);
            double tempz = (a.x * b.y) - (b.x * a.y);

            return new Vector(tempx, tempy, tempz);
        }

    }
}

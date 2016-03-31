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

            Vector in1 = new Vector(6,6,0);
            Vector in2 = new Vector(1,1,0);

            Console.WriteLine("Inproduct = " + inproduct(in1, in2));
            
            
            
            Console.WriteLine("Uitproduct:");
            uitproduct(in1, in2).printVector();
            opdracht3a(0, -0, -3, 12x);

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


        //opdracht 3a
        static void opdracht3a(double p,double q,double r, double s){

            Vector steun = new Vector(0,0,0);
            Vector a = new Vector(0, 0, 0);
            Vector b = new Vector(0, 0, 0);

            if (p != 0)
            {
                steun = new Vector(s / p, 0, 0);
                a = new Vector(-q, p, 0);
                b = new Vector(-r, 0, p);
            }
            else if (p == 0 && q != 0)
            {
                steun = new Vector(0, s/q, 0);
                a = new Vector(q, 0, 0);
                b = new Vector(0, -r ,q);
            }
            else if (p == 0 && q == 0 && r != 0)
            {
                steun = new Vector(0, 0, s/r);
                a = new Vector(1, 0, 0);
                b = new Vector(0, 1, 0);
            }
            
            Console.WriteLine("("+steun.x+")    ("+a.x+")    ("+b.x+")");
            Console.WriteLine("(" + steun.y + ") + a(" + a.y + ") + u(" + b.y + ")");
            Console.WriteLine("(" + steun.z + ")    (" + a.z + ")    (" + b.z + ")");
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(37, 41);
            Vector b = new Vector(73, 14);

         //   Console.WriteLine(from1To2(a, b));
         //   Console.WriteLine("From 1 to 3");
           //   from1To3(a, b);


          //  from2To1(-0.5, 0);
          //  from2To3(-0,5, 0);


            //result of 1 to 3
            Vector aa = new Vector(12, 0);
            Vector bb = new Vector(-3, 0);


            Console.WriteLine("From 3 to 1");
            from3To1(aa, bb);
            Console.WriteLine(from3To2(aa, bb));
           


      


            Console.ReadKey();
        }


        //Representaties:
        //1. Lijn tussen de volgende punten (1,3) (3,7)
        //2. y = 1+2x 
        //3. (x) = (1) + Alpha(1)
        //   (y)   (3)        (2)

        //Opgave 2a
        public static string from1To2(Vector va,Vector vb){
            double a, b;

            if (vb.x - va.x != 0)
            {
                b = (vb.y-va.y) / (vb.x - va.x);
                a = va.y - (va.x * b);
                return "y =" + a + " + " + b + "x"; 
            }
            else
            {
                return "Conversie niet mogelijk";
            }
        }

        //controleren op juistheid
        public static void from2To1(double a, double b)
        {
            Vector va = new Vector(0, a);
            Vector vb = new Vector(1, a + b);

            Console.WriteLine("(" + va.x + ") (" + vb.x + ")");
            Console.WriteLine("(" + va.y + ") (" + vb.y + ")"); 

        }

        //controleren op juistheid
        public static void from1To3(Vector va, Vector vb)
        {
            Console.WriteLine("(x) = ("+va.x+") + Lambda("+(vb.x - va.x)+")");
            Console.WriteLine("(y) = ("+va.y+") +       ("+(vb.y - va.y)+")");
        }

        public static void from3To1(Vector va,Vector vb)
        {
            Vector p = new Vector(va.x, va.y);
            Vector q = new Vector(va.x + vb.x, va.y + vb.y);
            Console.WriteLine("P:");
            p.printVector();
            Console.WriteLine("Q:");

            q.printVector();
        }


        public static void from2To3(double a, double b)
        {
            Console.WriteLine("(x) = (" + 0 + ") + Lambda(" + 1 + ")");
            Console.WriteLine("(y) = (" + a + ") +       (" + b + ")");
        }

        public static string from3To2(Vector va, Vector vb)
        {
            double a, b;
            if (vb.x != 0)
            {
                b = vb.y / vb.x;
                a = va.y - (b * va.x);

               return "y = " + a + " + " + b + "x";
            }
            else
            {
                return ("Conversie niet mogelijk");
            }
        }


    }
}

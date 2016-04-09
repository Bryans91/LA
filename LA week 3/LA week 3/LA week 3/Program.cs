using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 3, 2);
            matrix1.setValue(0, 0, 0, 1);
            matrix1.setValue(1, 0, 0, 2);
            matrix1.setValue(2, 0, 0, 3);
            matrix1.setValue(0, 1, 0, 4);
            matrix1.setValue(1, 1, 0, 5);
            matrix1.setValue(2, 1, 0, 6);
            matrix1.setValue(0, 2, 0, 7);
            matrix1.setValue(1, 2, 0, 8);
            matrix1.setValue(2, 2, 0, 9);
 
            matrix1.setValue(0, 0, 1, 9);
            matrix1.setValue(1, 0, 1, 8);
            matrix1.setValue(2, 0, 1, 7);
            matrix1.setValue(0, 1, 1, 6);
            matrix1.setValue(1, 1, 1, 5);
            matrix1.setValue(2, 1, 1, 4);
            matrix1.setValue(0, 2, 1, 3);
            matrix1.setValue(1, 2, 1, 2);
            matrix1.setValue(2, 2, 1, 1);


            Console.WriteLine("3d matrix print test");
            matrix1.print();

            Console.WriteLine("Scale matrix test");
            scale(6.2, 3.8, 1.3).print();

            Console.WriteLine("Translate matrix test");
            translate(12, 23, -8).print();

            Console.ReadKey();
        }


        public static Matrix scale(double x,double y,double z){

            Matrix result = new Matrix(3, 3, 1);
            result.setValue(0, 0, 0, x);
            result.setValue(1, 0, 0, 0);
            result.setValue(2, 0, 0, 0);
            result.setValue(0, 1, 0, 0);
            result.setValue(1, 1, 0, y);
            result.setValue(2, 1, 0, 0);
            result.setValue(0, 2, 0, 0);
            result.setValue(1, 2, 0, 0);
            result.setValue(2, 2, 0, z);

            return result;
        }

        public static Matrix translate(double x, double y, double z){
            Matrix result = new Matrix(4, 4, 1);
            result.setValue(0, 0, 0, 1);
            result.setValue(1, 0, 0, 0);
            result.setValue(2, 0, 0, 0);
            result.setValue(3, 0, 0, x);

            result.setValue(0, 1, 0, 0);
            result.setValue(1, 1, 0, 1);
            result.setValue(2, 1, 0, 0);
            result.setValue(3, 1, 0, y);

            result.setValue(0, 2, 0, 0);
            result.setValue(1, 2, 0, 0);
            result.setValue(2, 2, 0, 1);
            result.setValue(3, 2, 0, z);

            result.setValue(0, 3, 0, 0);
            result.setValue(1, 3, 0, 0);
            result.setValue(2, 3, 0, 0);
            result.setValue(3, 3, 0, 1);


            return result;
        }



    }
}

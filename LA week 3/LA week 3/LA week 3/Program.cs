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


            Console.ReadKey();
        }
    }
}

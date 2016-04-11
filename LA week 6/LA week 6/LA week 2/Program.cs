using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //GUESS
            Matrix matrix1 = new Matrix(4, 4);
            matrix1.setValue(0, 0, 1);
            matrix1.setValue(1, 0, 4);
            matrix1.setValue(2, 0, 2);
            matrix1.setValue(3, 0, 3);
            matrix1.setValue(0, 1, 2);
            matrix1.setValue(1, 1, 3);
            matrix1.setValue(2, 1, 4);
            matrix1.setValue(3, 1, 1);
            matrix1.setValue(0, 2, 3);
            matrix1.setValue(1, 2, 2);
            matrix1.setValue(2, 2, 1);
            matrix1.setValue(3, 2, 4);
            matrix1.setValue(0, 3, 4);
            matrix1.setValue(1, 3, 1);
            matrix1.setValue(2, 3, 3);
            matrix1.setValue(3, 3, 2);

            Console.WriteLine("Matrix:");
            matrix1.print();
            Console.WriteLine();

            Console.WriteLine("Identity Matrix:");
            bool inversePossible = false;
            Matrix reverse = matrix1.inverseMatrix(out inversePossible);
            if (inversePossible == true)
            {
                //reverse.print();
            }
            Console.ReadKey();
        }

    }
}

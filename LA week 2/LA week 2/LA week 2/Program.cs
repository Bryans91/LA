using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COS & SIN DEGREES");

            Console.WriteLine("COS 30*:" + Math.Cos(30 * (Math.PI / 180.0)));
            Console.WriteLine("Sin 30*:" + Math.Sin(30 * (Math.PI / 180.0)));




            Console.WriteLine("OPDRACHT 1c");
            //matrix 1 test
            Matrix matrix1 = new Matrix(3, 3);
            matrix1.setValue(0, 0, 1);
            matrix1.setValue(1, 0, 2);
            matrix1.setValue(2, 0, 3);
            matrix1.setValue(0, 1, 4);
            matrix1.setValue(1, 1, 5);
            matrix1.setValue(2, 1, 6);
            matrix1.setValue(0, 2, 7);
            matrix1.setValue(1, 2, 8);
            matrix1.setValue(2, 2, 9);

            Matrix matrix2 = new Matrix(2, 3);
            matrix2.setValue(0, 0, 0);
            matrix2.setValue(1, 0, 1);
            matrix2.setValue(0, 1, 0);
            matrix2.setValue(1, 1, 1);
            matrix2.setValue(0, 2, 1);
            matrix2.setValue(1, 2, 0);
            Console.WriteLine("MATRIX 1 Test");
         //   multiplyMatrices(matrix1, matrix2);


            //matrix 2 test
            matrix1 = new Matrix(3, 3);
            matrix1.setValue(0, 0, 5);
            matrix1.setValue(1, 0, 0);
            matrix1.setValue(2, 0, 4);
            matrix1.setValue(0, 1, 0);
            matrix1.setValue(1, 1, 1);
            matrix1.setValue(2, 1, 1);
            matrix1.setValue(0, 2, 2);
            matrix1.setValue(1, 2, 3);
            matrix1.setValue(2, 2, 0);

            matrix2 = new Matrix(1, 2);
            matrix2.setValue(0, 0, 6);
            matrix2.setValue(0, 1, 5);
          
            //Throws error (sizes do not match)
            //multiplyMatrices(matrix1, matrix2);

            //matrix 3 test
            matrix1 = new Matrix(3, 3);
            matrix1.setValue(0, 0, 1);
            matrix1.setValue(1, 0, 0);
            matrix1.setValue(2, 0, 1);
            matrix1.setValue(0, 1, 0);
            matrix1.setValue(1, 1, 1);
            matrix1.setValue(2, 1, 1);
            matrix1.setValue(0, 2, 0);
            matrix1.setValue(1, 2, 0);
            matrix1.setValue(2, 2, 2);

            matrix2 = new Matrix(1, 3);
            matrix2.setValue(0, 0, 17);
            matrix2.setValue(0, 1, 19);
            matrix2.setValue(0, 2, 23);
            Console.WriteLine("MATRIX 3 TEST");
           // multiplyMatrices(matrix1, matrix2);


            //matrix 4 test
            matrix1 = new Matrix(2, 3);
            matrix1.setValue(0, 0, 3);
            matrix1.setValue(1, 0, 1);
     
            matrix1.setValue(0, 1, 2);
            matrix1.setValue(1, 1, 2);

            matrix1.setValue(0, 2, 1);
            matrix1.setValue(1, 2, 3);
       

            matrix2 = new Matrix(1, 3);
            matrix2.setValue(0, 0, 0);
            matrix2.setValue(0, 1, 3.1415);
            matrix2.setValue(0, 2, 2.7986);
            Console.WriteLine("MATRIX 4 TEST");
            //Throws error, sizes dont match
            //multiplyMatrices(matrix1, matrix2);


            //Transleertest
            Console.WriteLine("TRANSLEER TEST");
            matrix1 = new Matrix(1, 3);
            matrix1.setValue(0, 0, 3);
            matrix1.setValue(0, 1, 4);
            matrix1.setValue(0, 2, 1);
            multiplyMatrices(translate(12, 23), matrix1);

            Console.WriteLine("ROTATE TEST");
            rotate(30, 0, 12).print();


            Console.WriteLine("SCALE TEST");
            scale(300).print();

            Console.ReadKey();
        }


        //opgave 1 a
        public static Matrix multiplyMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.getxSize() == matrix2.getySize())
            {
                Matrix result = new Matrix(matrix2.getxSize(), matrix1.getySize());
                for (int x = 0; x < result.getxSize(); x++)
                {
                    for (int y = 0; y < result.getySize(); y++)
                    {
                        double endValue = 0;
                        //calculate endValue
                        int index = 0;
                        while (index < matrix1.getxSize() && index < matrix2.getySize())
                        {
                            endValue += matrix1.getValue(index, y) * matrix2.getValue(x, index);
                            index++;
                        }

                        result.setValue(x, y, endValue);
                    }
                }
                result.print();
                return result;

            }
            else
            {
                throw new Exception("Error multiplying matrices");
            }
        }

        //Translatie
        public static Matrix translate(double x, double y)
        {
            //translatie matrix
            Matrix t = new Matrix(3, 3);
            t.setValue(0, 0, 1);
            t.setValue(1, 0, 0);
            t.setValue(2, 0, x);
            t.setValue(0, 1, 0);
            t.setValue(1, 1, 1);
            t.setValue(2, 1, y);
            t.setValue(0, 2, 0);
            t.setValue(1, 2, 0);
            t.setValue(2, 2, 1);

            return t;
        }


        //ROTATIE
      
        public static Matrix rotate(double alpha, double x, double y)
        {
            Matrix rotation = new Matrix(3, 3);
            rotation.setValue(0, 0, Math.Cos(alpha * (Math.PI / 180.0)));
            rotation.setValue(1, 0, -Math.Sin(alpha * (Math.PI / 180.0)));
            rotation.setValue(2, 0, 0);
            rotation.setValue(0, 1, Math.Sin(alpha * (Math.PI / 180.0)));
            rotation.setValue(1, 1, Math.Cos(alpha * (Math.PI / 180.0)));
            rotation.setValue(2, 1, 0);
            rotation.setValue(0, 2, 0);
            rotation.setValue(1, 2, 0);
            rotation.setValue(2, 2, 1);

            Matrix point = new Matrix(1, 2);
            point.setValue(0, 0, x);
            point.setValue(0, 1, y);


            Matrix result = new Matrix(1, 3);
            result.setValue(0, 0, rotation.getValue(0, 0) * point.getValue(0, 0) - rotation.getValue(1, 0) * point.getValue(0, 1) + rotation.getValue(2,0));
            result.setValue(0, 1, rotation.getValue(0, 1) * point.getValue(0, 0) + rotation.getValue(1, 1) * point.getValue(0, 1) + rotation.getValue(2, 1));
            result.setValue(0, 2, rotation.getValue(0, 2) * point.getValue(0, 0) + rotation.getValue(1, 2) * point.getValue(0, 1) + +rotation.getValue(2, 2));
            return result;

        }


        public static Matrix scale(double velocity)
        {
            Matrix result = new Matrix(2, 2);

            double x = 1 - velocity / 600;
            double y = 1 + velocity / 300;

            try
            {
                result.setValue(0, 0, x);
                result.setValue(1, 0, 0);
                result.setValue(0, 1, 0);
                result.setValue(1, 1, y);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            return result;
        }





    }
}

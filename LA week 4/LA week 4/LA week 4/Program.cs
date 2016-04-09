using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //radius to degrees = degrees * (Math.PI / 180.0)
            Console.WriteLine("Testmatrix:");
            Matrix point = new Matrix(1, 3);
            point.setValue(0, 0, 1);
            point.setValue(0, 1, 4);
            point.setValue(0, 2, 0);


        }




          public Matrix RotatieOverX(double alpha)
        {
            alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(3, 3);

            //toprow
            rotatie.setValue(0, 0, 1);
            rotatie.setValue(1, 0, 0);
            rotatie.setValue(2, 0, 0);
            //midrow
            rotatie.setValue(0, 1, 0);
            rotatie.setValue(1, 1, Math.Cos(alpha));
            rotatie.setValue(2, 1, -Math.Sin(alpha));
            //bottomrow
            rotatie.setValue(0, 2, 0);
            rotatie.setValue(1, 2, Math.Sin(alpha));
            rotatie.setValue(2, 2, Math.Cos(alpha));

            return rotatie;
        }

        public Matrix RotatieOverY(double alpha)
        {
            alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(3, 3);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, 0);
            rotatie.setValue(2, 0, Math.Sin(alpha));
            //midrow
            rotatie.setValue(0, 1, 0);
            rotatie.setValue(1, 1, 1);
            rotatie.setValue(2, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, -Math.Sin(alpha));
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, Math.Cos(alpha));

            return rotatie;
        }

        public Matrix RotatieOverZ(double alpha)
        {
            alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(3, 3);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, Math.Sin(alpha));
            rotatie.setValue(2, 0, 0);
            //midrow
            rotatie.setValue(0, 1, Math.Sin(alpha));
            rotatie.setValue(1, 1, Math.Cos(alpha));
            rotatie.setValue(2, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, 0);
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, 1);

            return rotatie;
        }



        public static Matrix multiplyMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.xSize == matrix2.ySize)
            {
                Matrix result = new Matrix(matrix2.xSize, matrix1.ySize);
                for (int x = 0; x < result.xSize; x++)
                {
                    for (int y = 0; y < result.ySize; y++)
                    {
                        double endValue = 0;
                        //calculate endValue
                        int index = 0;
                        while (index < matrix1.xSize && index < matrix2.ySize)
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

        public static Matrix scale(double x, double y, double z)
        {

            Matrix result = new Matrix(4, 4);
            result.setValue(0, 0, x);
            result.setValue(1, 0, 0);
            result.setValue(2, 0, 0);
            result.setValue(3, 0, 0);
            result.setValue(0, 1, 0);
            result.setValue(1, 1, y);
            result.setValue(2, 1, 0);
            result.setValue(3, 1, 0);
            result.setValue(0, 2, 0);
            result.setValue(1, 2, 0);
            result.setValue(2, 2, z);
            result.setValue(3, 2, 0);
            result.setValue(0, 3, 0);
            result.setValue(1, 3, 0);
            result.setValue(2, 3, 0);
            result.setValue(3, 3, 1);

            return result;
        }

        public static Matrix translate(double x, double y, double z)
        {
            Matrix result = new Matrix(4, 4);
            result.setValue(0, 0, 1);
            result.setValue(1, 0, 0);
            result.setValue(2, 0, 0);
            result.setValue(3, 0, x);

            result.setValue(0, 1, 0);
            result.setValue(1, 1, 1);
            result.setValue(2, 1, 0);
            result.setValue(3, 1, y);

            result.setValue(0, 2, 0);
            result.setValue(1, 2, 0);
            result.setValue(2, 2, 1);
            result.setValue(3, 2, z);

            result.setValue(0, 3, 0);
            result.setValue(1, 3, 0);
            result.setValue(2, 3, 0);
            result.setValue(3, 3, 1);


            return result;
        }


    }
}

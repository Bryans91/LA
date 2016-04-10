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
            //1
            //radius to degrees = degrees * (Math.PI / 180.0)
            Console.WriteLine("ROTATIE:");
            Matrix rotatie = Rotatie(30, 3, 2, 4);

            Console.WriteLine("Translatie + rotatie + translatie:");
            Matrix translatieRotatie = Rotatie(30, 3, 2, 4, 6, 1, 4);
            translatieRotatie.print();


            //2a
            Console.WriteLine("Test rotatie over X / Y of Z");
            Matrix point = new Matrix(1, 4);
            point.setValue(0, 0, 1);
            point.setValue(0, 1, 2);
            point.setValue(0, 2, 3);
            point.setValue(0,3,1);

            testRotatieX(30, point);
            testRotatieY(30, point);
            testRotatieZ(30, point);


            //2b

            //2c




            Console.ReadKey();
        }

        //2a
        public static void testRotatieX(double alpha,Matrix point){

            Matrix newPoint = RotatieOverX(alpha * (Math.PI / 180.0));
            newPoint = multiplyMatrices(newPoint, point);

            double pointSq = Math.Sqrt((point.getValue(0, 1) * point.getValue(0, 1)) + (point.getValue(0, 2) * point.getValue(0, 2)) + (point.getValue(0, 3) * point.getValue(0, 3)));
            double newPointSq = Math.Sqrt((newPoint.getValue(0, 1) * newPoint.getValue(0, 1)) + (newPoint.getValue(0, 2) * newPoint.getValue(0, 2)) + (newPoint.getValue(0, 3) * newPoint.getValue(0, 3)));
     
            if (point.getValue(0, 0) != newPoint.getValue(0, 0))
            {
                Console.WriteLine("value of x has changed");
            }
            else if (pointSq != newPointSq)
            {
                Console.WriteLine("Size mismatch: Point:" + pointSq + " newPoint:" + newPointSq);
            }

            Console.WriteLine("Test X succesvol");
        }

        public static void testRotatieY(double alpha, Matrix point)
        {

            Matrix newPoint = RotatieOverY(alpha * (Math.PI / 180.0));
            newPoint = multiplyMatrices(newPoint, point);

            double pointSq = Math.Sqrt((point.getValue(0, 1) * point.getValue(0, 1)) + (point.getValue(0, 2) * point.getValue(0, 2)) + (point.getValue(0, 3) * point.getValue(0, 3)));
            double newPointSq = Math.Sqrt((newPoint.getValue(0, 1) * newPoint.getValue(0, 1)) + (newPoint.getValue(0, 2) * newPoint.getValue(0, 2)) + (newPoint.getValue(0, 3) * newPoint.getValue(0, 3)));

            if (point.getValue(0, 1) != newPoint.getValue(0,1))
            {
                Console.WriteLine("value of y has changed");
            }
            else if (pointSq != newPointSq)
            {
                Console.WriteLine("Size mismatch: Point:" + pointSq + " newPoint:" + newPointSq);
            }

            Console.WriteLine("Test Y succesvol");
        }

        public static void testRotatieZ(double alpha, Matrix point)
        {

            Matrix newPoint = RotatieOverZ(alpha * (Math.PI / 180.0));
            newPoint = multiplyMatrices(newPoint, point);

            double pointSq = Math.Sqrt((point.getValue(0, 1) * point.getValue(0, 1)) + (point.getValue(0, 2) * point.getValue(0, 2)) + (point.getValue(0, 3) * point.getValue(0, 3)));
            double newPointSq = Math.Sqrt((newPoint.getValue(0, 1) * newPoint.getValue(0, 1)) + (newPoint.getValue(0, 2) * newPoint.getValue(0, 2)) + (newPoint.getValue(0, 3) * newPoint.getValue(0, 3)));

            if (point.getValue(0, 2) != newPoint.getValue(0, 2))
            {
                Console.WriteLine("value of z has changed");
            }
            else if (pointSq != newPointSq)
            {
                Console.WriteLine("Size mismatch: Point:" + pointSq + " newPoint:" + newPointSq);
            }

            Console.WriteLine("Test Z succesvol");
        }

        public static Matrix Rotatie(double alpha, double x, double y, double z)
        {
            Matrix point = new Matrix(1, 4);
            point.setValue(0, 0, x);
            point.setValue(0, 1, y);
            point.setValue(0, 2, z);
            point.setValue(0,3,1);

            //Stap 1
            alpha = alpha * (Math.PI / 180.0);
            double t1 = Math.Atan2(z, x);
            double t2 = Math.Atan2(y, Math.Sqrt(x * x + z * z));
            

            //A''''' = Rotatie-Y(t1) * Rotatie-Z(t2) * RotatieX(Alpha) * RotatieZ *RotatieY
            //stap 2
            //rotate x door t2 op de z as
            Matrix temp = multiplyMatrices(RotatieOverY2(t1), RotatieOverZ2(t2));
            //stap 3
            //Rotate over de x met Alpha
            temp = multiplyMatrices(temp, RotatieOverX(alpha));
            //stap 4 rotate over de z as met -T2
            temp = multiplyMatrices(temp, RotatieOverZ2(t2));
            //stap 5 roteer over de y as met -T1
            temp = multiplyMatrices(temp, RotatieOverY2(t1));
            Console.WriteLine("Berekening Matricen:");
            temp.print();

            Console.WriteLine("Antwoord Berekening * point");
            temp = multiplyMatrices(temp, point);
            temp.print();


            return temp;
        }

        //Rotatie over punt Mx My Mz
        public static Matrix Rotatie(double alpha, double x, double y, double z, double Mx, double My, double Mz)
        {

            Matrix point = new Matrix(1, 4);
            point.setValue(0, 0, x);
            point.setValue(0, 1, y);
            point.setValue(0, 2, z);
            point.setValue(0, 3, 1);

            //Stap 1
            alpha = alpha * (Math.PI / 180.0);
            double t1 = Math.Atan2(z, x);
            double t2 = Math.Atan2(y, Math.Sqrt(x * x + z * z));

            //A''''' = Rotatie-Y(t1) * Rotatie-Z(t2) * RotatieX(Alpha) * RotatieZ *RotatieY
            //stap 2
            //rotate x door t2 op de z as
            Matrix temp = multiplyMatrices(RotatieOverY2(t1), RotatieOverZ2(t2));
            //stap 3
            //Rotate over de x met Alpha
            temp = multiplyMatrices(temp, RotatieOverX(alpha));
            //stap 4 rotate over de z as met -T2
            temp = multiplyMatrices(temp, RotatieOverZ2(t2));
            //stap 5 roteer over de y as met -T1
            temp = multiplyMatrices(temp, RotatieOverY2(t1));

            Matrix tempTr = multiplyMatrices(translate(Mx, My, Mz), temp);
            tempTr = multiplyMatrices(tempTr, translate(-Mx, -My, -Mz));
            tempTr = multiplyMatrices(tempTr, point);

            return tempTr;
        }



          public static Matrix RotatieOverX(double alpha)
        {
            //alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(4, 4);

            //toprow
            rotatie.setValue(0, 0, 1);
            rotatie.setValue(1, 0, 0);
            rotatie.setValue(2, 0, 0);
            rotatie.setValue(3, 0, 0);
            //midrow
            rotatie.setValue(0, 1, 0);
            rotatie.setValue(1, 1, Math.Cos(alpha));
            rotatie.setValue(2, 1, -Math.Sin(alpha));
            rotatie.setValue(3, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, 0);
            rotatie.setValue(1, 2, Math.Sin(alpha));
            rotatie.setValue(2, 2, Math.Cos(alpha));
            rotatie.setValue(3, 2, 0);

            rotatie.setValue(0, 3, 0);
            rotatie.setValue(1, 3, 0);
            rotatie.setValue(2, 3, 0);
            rotatie.setValue(3, 3, 1);


            return rotatie;
        }

        public static Matrix RotatieOverY(double alpha)
        {
          //  alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(4, 4);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, 0);
            rotatie.setValue(2, 0, -Math.Sin(alpha));
            rotatie.setValue(3, 0, 0);
            //midrow
            rotatie.setValue(0, 1, 0);
            rotatie.setValue(1, 1, 1);
            rotatie.setValue(2, 1, 0);
            rotatie.setValue(3, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, Math.Sin(alpha));
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, Math.Cos(alpha));
            rotatie.setValue(3, 2, 0);

            rotatie.setValue(0, 3, 0);
            rotatie.setValue(1, 3, 0);
            rotatie.setValue(2, 3, 0);
            rotatie.setValue(3, 3, 1);


            return rotatie;
        }



        public static Matrix RotatieOverZ(double alpha)
        {
         //   alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(4, 4);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, -Math.Sin(alpha));
            rotatie.setValue(2, 0, 0);
            rotatie.setValue(3, 0, 0);
            //midrow
            rotatie.setValue(0, 1, Math.Sin(alpha));
            rotatie.setValue(1, 1, Math.Cos(alpha));
            rotatie.setValue(2, 1, 0);
            rotatie.setValue(3, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, 0);
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, 1);
            rotatie.setValue(3, 2, 0);

            rotatie.setValue(0, 3, 0);
            rotatie.setValue(1, 3, 0);
            rotatie.setValue(2, 3, 0);
            rotatie.setValue(3, 3, 1);


            return rotatie;
        }

        public static Matrix RotatieOverY2(double alpha)
        {
            //  alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(4, 4);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, 0);
            rotatie.setValue(2, 0, Math.Sin(alpha));
            rotatie.setValue(3, 0, 0);
            //midrow
            rotatie.setValue(0, 1, 0);
            rotatie.setValue(1, 1, 1);
            rotatie.setValue(2, 1, 0);
            rotatie.setValue(3, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, -Math.Sin(alpha));
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, Math.Cos(alpha));
            rotatie.setValue(3, 2, 0);

            rotatie.setValue(0, 3, 0);
            rotatie.setValue(1, 3, 0);
            rotatie.setValue(2, 3, 0);
            rotatie.setValue(3, 3, 1);


            return rotatie;
        }
        public static Matrix RotatieOverZ2(double alpha)
        {
            //   alpha = alpha * (Math.PI / 180.0);
            Matrix rotatie = new Matrix(4, 4);

            //toprow
            rotatie.setValue(0, 0, Math.Cos(alpha));
            rotatie.setValue(1, 0, Math.Sin(alpha));
            rotatie.setValue(2, 0, 0);
            rotatie.setValue(3, 0, 0);
            //midrow
            rotatie.setValue(0, 1, -Math.Sin(alpha));
            rotatie.setValue(1, 1, Math.Cos(alpha));
            rotatie.setValue(2, 1, 0);
            rotatie.setValue(3, 1, 0);
            //bottomrow
            rotatie.setValue(0, 2, 0);
            rotatie.setValue(1, 2, 0);
            rotatie.setValue(2, 2, 1);
            rotatie.setValue(3, 2, 0);

            rotatie.setValue(0, 3, 0);
            rotatie.setValue(1, 3, 0);
            rotatie.setValue(2, 3, 0);
            rotatie.setValue(3, 3, 1);
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
                //result.print();
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

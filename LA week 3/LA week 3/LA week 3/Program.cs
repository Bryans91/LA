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
            Matrix matrix1 = new Matrix(4, 4);
            matrix1.setValue(0, 0, 1);
            matrix1.setValue(1, 0, 2);
            matrix1.setValue(2, 0, 3);
            matrix1.setValue(3, 0, 4);
            matrix1.setValue(0, 1, 4);
            matrix1.setValue(1, 1, 5);
            matrix1.setValue(2, 1, 6);
            matrix1.setValue(3, 1, 6);
            matrix1.setValue(0, 2, 0);
            matrix1.setValue(1, 2, 8);
            matrix1.setValue(2, 2, 9);
            matrix1.setValue(3, 2, 9);
            matrix1.setValue(0, 3, 1);
            matrix1.setValue(1, 3, 2);
            matrix1.setValue(2, 3, 3);
            matrix1.setValue(3, 3, 4);
           

            Console.WriteLine("3d matrix print test");
            matrix1.print();

            Console.WriteLine("Scale matrix test");
            Matrix sc = scale(6.2, 3.8, 1.3);
            sc.print();

            Console.WriteLine("Multiplied by scale");
            multiplyMatrices(sc, matrix1);

            Console.WriteLine("Test matrix");
            testScale( scale(6.2, 3.8, 1.3), matrix1);
           

            Console.WriteLine("Translate matrix test");
           // translate(12, 23, -8).print();

            Console.WriteLine("Translate test");
            testTranslate( matrix1, 0 , 23 , -8);

            Console.ReadKey();
        }


        //TODO 3d
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


        public static Matrix scale(double x,double y,double z){

            Matrix result = new Matrix(4, 4);
            result.setValue(0, 0,  x);
            result.setValue(1, 0,  0);
            result.setValue(2, 0,  0);
            result.setValue(3, 0, 0);
            result.setValue(0, 1,  0);
            result.setValue(1, 1,  y);
            result.setValue(2, 1,  0);
            result.setValue(3, 1, 0);
            result.setValue(0, 2,  0);
            result.setValue(1, 2,  0);
            result.setValue(2, 2,  z);
            result.setValue(3, 2, 0);
            result.setValue(0, 3, 0);
            result.setValue(1, 3, 0);
            result.setValue(2, 3, 0);
            result.setValue(3, 3, 1);

            return result;
        }

        public static Matrix translate(double x, double y, double z){
            Matrix result = new Matrix(4, 4);
            result.setValue(0, 0,  1);
            result.setValue(1, 0,  0);
            result.setValue(2, 0,  0);
            result.setValue(3, 0,  x);

            result.setValue(0, 1,  0);
            result.setValue(1, 1,  1);
            result.setValue(2, 1,  0);
            result.setValue(3, 1,  y);

            result.setValue(0, 2,  0);
            result.setValue(1, 2,  0);
            result.setValue(2, 2,  1);
            result.setValue(3, 2,  z);

            result.setValue(0, 3,  0);
            result.setValue(1, 3,  0);
            result.setValue(2, 3,  0);
            result.setValue(3, 3,  1);


            return result;
        }


        public static void testScale(Matrix scale, Matrix test){

            Matrix b = multiplyMatrices(scale, test);

            for (int y = 0; y < test.xSize; y++)
            {
                for (int x = 0; x < test.xSize; x++)
                {   //(TEST 1)
                    if (test.getValue(x, y) == 0 && b.getValue(x,y) != 0)
                    {
                        Console.Write(b.getValue(x, y));
                        throw new Exception("Value of scale is not 0");
                    } //(TEST 2)
                    else if(b.getValue(x,y) != 0 && scale.getValue(x,y) != 0)
                    {
                        if (b.getValue(x, y) != (scale.getValue(0, y) * test.getValue(x, 0)) + (scale.getValue(1, y) * test.getValue(x, 1)) + (scale.getValue(2, y) * test.getValue(x, 2)) + (scale.getValue(3, y) * test.getValue(x, 3)))
                        {
                            throw new Exception("Value of scale new does not match scale * old");
                        }
                    }
                }
              
            } // end 0 check

            Console.WriteLine("Matrix scale correctly applied");
        }

        public static void testTranslate(Matrix test, double tx , double ty, double tz)
        {
            Matrix trans = translate(tx,ty,tz);
            Console.WriteLine("Translate:");
            trans.print();

            Console.WriteLine("Result:");
            Matrix result = multiplyMatrices(trans, test);

            //check for 0 values (TEST 1)
            if (tx == 0 || ty == 0 || tz == 0)
            {
                int row = 0;
                if (ty == 0)
                {
                    row = 1;
                }
                else
                {
                    row = 3;
                }

                for (int x = 0; x < test.xSize; x++)
                {
                    if (result.getValue(x, row) != test.getValue(x, row))
                    {
                        throw new Exception("Translate = 0 but values do not match");
                    }
                }
            }

            Console.WriteLine("RESULT * TRANS:");
            //(TEST 2)
            Matrix transNegatief = multiplyMatrices(translate(tx * -1, ty * -1, tz * -1), result);

            for (int y = 0; y < test.xSize; y++)
            {
                for (int x = 0; x < test.xSize; x++)
                {   //(TEST 1)
                    if (transNegatief.getValue(x, y) != test.getValue(x, y))
                    {
                        throw new Exception("Translation back values do not match");
                    }
                }

            } // end 0 check


            Console.WriteLine("Translation checks out");
        }


    }
}

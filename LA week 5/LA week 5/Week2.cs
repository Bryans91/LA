using System;
using System.Collections.Generic;

namespace week2 {

    class Main {

        static void Main(string[] args)
        {

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
            matrix2.setValue(0, 0, 1);
            matrix2.setValue(1, 0, 1);
            matrix2.setValue(0, 1, 2);
            matrix2.setValue(1, 1, 2);
            matrix2.setValue(0, 2, 3);
            matrix2.setValue(1, 2, 3);

            matrix1.print();
            Console.WriteLine(" + ");
            matrix2.print();
            Console.WriteLine(" = ");
            multiplyMatrices(matrix1, matrix2);


            Matrix matrix3 = new Matrix(3, 3);
            matrix3.setValue(0, 0, 0);
            matrix3.setValue(1, 0, 0);
            matrix3.setValue(2, 0, 1);
            matrix3.setValue(0, 1, 1);
            matrix3.setValue(1, 1, 0);
            matrix3.setValue(2, 1, 0);
            matrix3.setValue(0, 2, 0);
            matrix3.setValue(1, 2, 1);
            matrix3.setValue(2, 2, 0);

            Matrix matrix4 = new Matrix(1, 3);
            matrix4.setValue(0, 0, 1.23);
            matrix4.setValue(0, 1, 2.84);
            matrix4.setValue(0, 2, 3.91);

            matrix3.print();
            Console.WriteLine(" + ");
            matrix4.print();
            Console.WriteLine(" = ");
            multiplyMatrices(matrix3, matrix4);

            //Opdracht 2e
            Matrix matrix9 = new Matrix(3, 3);
            matrix9.setValue(0, 0, 1);
            matrix9.setValue(1, 0, 0);
            matrix9.setValue(2, 0, 25);
            matrix9.setValue(0, 1, 0);
            matrix9.setValue(1, 1, 1);
            matrix9.setValue(2, 1, 50);
            matrix9.setValue(0, 2, 0);
            matrix9.setValue(1, 2, 0);
            matrix9.setValue(2, 2, 1);

            Matrix matrix10 = new Matrix(3, 3);
            matrix10.setValue(0, 0, 0.80);
            matrix10.setValue(1, 0, -0.60);
            matrix10.setValue(2, 0, 0);
            matrix10.setValue(0, 1, 0.60);
            matrix10.setValue(1, 1, 0.80);
            matrix10.setValue(2, 1, 0);
            matrix10.setValue(0, 2, 0);
            matrix10.setValue(1, 2, 0);
            matrix10.setValue(2, 2, 1);

            matrix9.print();
            Console.WriteLine(" + ");
            matrix10.print();
            Console.WriteLine(" = ");
            multiplyMatrices(matrix9, matrix10);



            scale(50.0).print();

        }



        public void multiplyMatrices(Matrix matrix1, Matrix matrix2)
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

            }
            else
            {
                throw new Exception("Error multiplying matrices");
            }
        }

        public Matrix scale(double velocity)
        {
            Matrix result = new Matrix(2, 2);

            double x = 1 + velocity / 200;
            double y = 1 - velocity / 400;

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
		


//matrix

namespace week2{

	class Matrix {
		private double[][] matrix;
		private int xSize;
		private int ySize;
		
		public Matrix(int xSize, int ySize){
			this.xSize = xSize;
			this.ySize = ySize;
			matrix = new double[xSize,ySize];
		}
		
		public void setValue(int x, int y, double value) {
			if(x < xSize && y < ySize){
				matrix[x][y] = value;
			} else {
				throw new Exception("Out of Range: x = "+ x + " y = "+ y);
			}
		}
		
		public double getValue(int x, int y) { 
			if(x < xSize && y < ySize){
				return matrix[x][y];
			} else {
				throw new Exception("Out of Range: x = "+ x + " y = "+ y);
			}
		}
		
		public void print(){
			for(int y = 0; y < getySize(); y++){
				for(int x = 0; x < getxSize(); x++){
					Console.WriteLine(matrix[x][y]+ " ");
				}
			}
		}

		public int getxSize() {
			return xSize;
		}

		public int getySize() {
			return ySize;
		}
	}
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_3
{
    class Matrix
    {
        private double[,] matrix;
        public int xSize { get; set; }
        public int ySize { get; set; }
  

        public Matrix(int xSize, int ySize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
        
            matrix = new double[xSize,ySize];
        }

        public void setValue(int x, int y, double value)
        {
            if (x < xSize && y < ySize)
            {
                this.matrix[x,y] = value;
            }
            else
            {
                throw new Exception("Out of Range: x = " + x + " y = " + y);
            }
        }

        public double getValue(int x, int y )
        {
            if (x < xSize && y < ySize )
            {
                return this.matrix[x,y];
            }
            else
            {
                throw new Exception("Out of Range: x = " + x + " y = " + y);
            }
        }


        public void print()
        {     
            for (int y = 0; y < this.ySize; y++)
            {
                Console.Write("(");
                for (int x = 0; x < this.xSize; x++)
                {
                    Console.Write(this.matrix[x,y]);
                    if (x + 1 != this.xSize)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine(")");
            }
        }

    }
}

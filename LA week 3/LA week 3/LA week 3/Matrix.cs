using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_3
{
    class Matrix
    {
        private double[,,] matrix;
        private int xSize { get; set; }
        private int ySize { get; set; }
        private int zSize { get; set; }

        public Matrix(int xSize, int ySize,int zSize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.zSize = zSize;
            matrix = new double[xSize,ySize,zSize];
        }

        public void setValue(int x, int y,int z, double value)
        {
            if (x < xSize && y < ySize)
            {
                this.matrix[x,y,z] = value;
            }
            else
            {
                throw new Exception("Out of Range: x = " + x + " y = " + y + " z = "  + z);
            }
        }

        public double getValue(int x, int y ,int z)
        {
            if (x < xSize && y < ySize && z < zSize)
            {
                return this.matrix[x,y,z];
            }
            else
            {
                throw new Exception("Out of Range: x = " + x + " y = " + y + " z = " + z);
            }
        }


        public void print()
        {
            for (int z = 0; z < this.zSize; z++)
            {
                Console.WriteLine("Z:" + z);
                for (int y = 0; y < this.xSize; y++)
                {
                    Console.Write("(");
                    for (int x = 0; x < this.xSize; x++)
                    {
                        Console.Write(this.matrix[x, y, z]);
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
}

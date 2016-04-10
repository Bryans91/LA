using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_week_6
{
    class Matrix
    {
        private double[,] matrix;
        public int xSize { get; set; }
        public int ySize { get; set; }

        Matrix identity;

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

        public double getValue(int x, int y)
        {
            if (x < this.xSize && y < this.ySize)
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
                        Console.Write(" , ");
                    }
                }
                Console.WriteLine(")");
            }
        }

        // Vanwege de signatuur van deze functie, in Matrix class gezet.
        public Matrix inverseMatrix(out bool inversePossible)
        {
            inversePossible = true;
            identity = identityMatrix();

            for (int rowNumber = 0; rowNumber < xSize; rowNumber++)
            {
                // Wissel rijen
                int highestRow = this.findHighest(rowNumber);
                Console.WriteLine();
                if (rowNumber != highestRow)
                {
                    Console.WriteLine("Wissel rij " + (rowNumber + 1) + " met " + (highestRow + 1));
                    swapRow(rowNumber, highestRow);
                    this.print();
                    identity.print();
                }
                else
                {
                    Console.WriteLine("Hoogste rij staat al op de juiste plek");
                }

                // Naar 1
                Console.WriteLine();
                Console.WriteLine("Zet value van " + (rowNumber + 1) + "," + (rowNumber + 1) + " naar 1");
                this.reduceToOne(rowNumber);
                this.print();
                identity.print();

                Console.WriteLine();
                Console.WriteLine("Andere rijen vegen");
                this.clearOthers(rowNumber);
                this.print();
                identity.print();
            }

            return identity; // Moet natuurlijk reverse zijn
        }

        // Check hoogste waarde kolom X van alle toegestane rijen
        private int findHighest(int x) {
            double highest = -100;
            int highestRow = -100;

            for (int i = x; i < ySize; i++)
            {
                if (this.getValue(x, i) > highest)
                {
                    highest = this.getValue(x, i);
                    highestRow = i;
                }
            }
            return highestRow;
        }

        // Wissel rijen
        private void swapRow(int a, int b)
        {
            double[] rowA = new double[4];
            double[] rowB = new double[4];
            double[] rowX = new double[4]; // Identity rijen
            double[] rowY = new double[4];
            for (int i = 0; i < xSize; i++)
            {
                rowA[i] = this.getValue(i, a);
                rowB[i] = this.getValue(i, b);
                rowX[i] = identity.getValue(i, a);
                rowY[i] = identity.getValue(i, b);
            }
            for (int i = 0; i < xSize; i++)
            {
                this.setValue(i, a, rowB[i]);
                this.setValue(i, b, rowA[i]);
                identity.setValue(i, a, rowY[i]);
                identity.setValue(i, b, rowX[i]);
            }

        }

        // Naar 1
        public void reduceToOne(int position)
        {
            double value = getValue(position, position);
            if (value > 0)
            {
                for (int i = 0; i < xSize; i++)
                {
                    this.setValue(i, position, getValue(i, position) / value);
                    identity.setValue(i, position, getValue(i, position) / value);
                }
            }
            else
            {
                for (int i = 0; i < xSize; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("This is my exit..");
                }
            }
        }

        // Anderen naar 0 zetten
        public void clearOthers(int position)
        {
            for (int i = 0; i < xSize; i++)
            {
                if (i != position)
                {
                    double value = this.getValue(position, i);
                    for (int x = position; x < xSize; x++) // position of 0?
                    {
                        this.setValue(x, i, this.getValue(x, i) - this.getValue(x, position) * value);
                        identity.setValue(x, i, identity.getValue(x, i) - identity.getValue(x, position) * value);
                    }
                }
            }
        }

        // Maak een identity Matrix
        public Matrix identityMatrix()
        {
            Matrix identity = null;
            if (xSize == ySize)
            {
                identity = new Matrix(xSize, ySize);
                for (int x = 0; x < xSize; x++)
                {
                    for (int y = 0; y < ySize; y++)
                    {
                        if (x == y)
                            identity.setValue(x, y, 1);
                        else
                            identity.setValue(x, y, 0);
                    }
                }
            }
            identity.print();
            return identity;
        }

    }
}

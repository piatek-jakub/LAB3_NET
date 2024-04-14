using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_LAB3
{
    internal class Problem
    {
        public List<Matrix> matrixList;
        int seed;
        int numberOfMatrices;

        public Problem(int seed)
        {
            matrixList = new List<Matrix>();
            numberOfMatrices = 2;
            this.seed = seed;
        }

        public void PrintMatrixList()
        {
            foreach (Matrix matrix in matrixList)
            {
                Console.WriteLine("height: " + matrix.height + " width: " + matrix.width);
                Console.WriteLine(matrix);
            }
        }
        public void RandomizeMatrix()
        {
            Random random = new Random(seed);
            int width = random.Next(490,510);
            int height = random.Next(490, 510);
            for(int i=0; i<numberOfMatrices; ++i)
            {
                Matrix matrix = new Matrix(height,width);
                matrixList.Add(matrix);
                height = width;
                width = random.Next(490, 510);
            }

            foreach (Matrix matrixObject in matrixList)
            {
                for (int i = 0; i < matrixObject.height; i++)
                {
                    for (int j = 0; j < matrixObject.width; j++)
                    {
                        matrixObject.matrixArray[i, j] = random.Next(1, 11);
                    }
                }
            }
        }
    }
}
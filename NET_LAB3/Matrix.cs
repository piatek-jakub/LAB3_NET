using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_LAB3
{
    internal class Matrix
    {
        public int[,] matrixArray;
        public int width { get; set; }
        public int height { get; set; }
        public Matrix()
        {
            this.width = 0;
            this.height = 0;
            matrixArray = new int[height, width];
        }
        public Matrix(int height, int width)
        {
            this.width = width;
            this.height = height;
            this.matrixArray = new int[height, width];
        }
        public void SetMatrix(int height, int width)
        {
            this.width = width;
            this.height = height;
            this.matrixArray = new int[height,width];
        }

        public override string ToString()
        {
            string matrixString = string.Empty;
            for(int i = 0; i < height;  i++)
            {
                for(int j = 0; j < width; j++)
                {
                    matrixString += matrixArray[i,j] + " ";
                }
                matrixString += Environment.NewLine;
            }
            return matrixString;
        }
    }
}

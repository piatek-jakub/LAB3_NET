using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET_LAB3
{
    internal class HighLevelThreading
    {
        public Problem problem;
        public int numberOfThreads;
        Matrix matrix;

        public HighLevelThreading(int numberOfThreads)
        {
            this.numberOfThreads = numberOfThreads;
            matrix = new Matrix();
        }

        public Matrix SolveProblem()
        {
            while (problem.matrixList.Count > 1)
            {
                CalculateMatrixSize();
                PrepareThreads();
                UpdateMatrixList();
                //Console.WriteLine(problem.matrixList[0]);
            }
            Matrix resultMatrix = problem.matrixList[0];
            return resultMatrix;
        }
        public void PrepareThreads()
        {
            Parallel.For(0, numberOfThreads, i =>
            {
                int threadID = i;
                SolveFields(threadID, matrix.width, matrix.height, numberOfThreads, matrix, problem.matrixList);
            });
        }

        public static void SolveFields(int threadID, int width, int height, int numberOfThreads, Matrix matrix, List<Matrix> matrixList)
        {
            int matrixSize = width * height;
            for (int i = threadID; i < matrixSize; i += numberOfThreads)
            {
                int sum = 0;
                for (int j = 0; j < matrixList[0].width; ++j)
                {
                    sum += matrixList[0].matrixArray[i / width, j] * matrixList[1].matrixArray[j, i % width];
                }
                matrix.matrixArray[i / width, i % width] = sum;
            }
        }
        public void CalculateMatrixSize()
        {
            Matrix firstMatrix = problem.matrixList[0];
            Matrix secondMatrix = problem.matrixList[1];
            if (firstMatrix.width != secondMatrix.height)
            {
                throw new ArgumentException("Cannot multiply matrices with given dimensions");
            }
            matrix = new Matrix();
            matrix.SetMatrix(firstMatrix.height, secondMatrix.width);
        }

        public void UpdateMatrixList()
        {
            problem.matrixList.RemoveRange(0, 2);
            problem.matrixList.Insert(0, matrix);
        }
        public void GenerateProblem()
        {
            Console.WriteLine("Enter seed: ");
            var answer = Console.ReadLine();
            if (!int.TryParse(answer, out var seed))
            {
                Console.WriteLine("Wrong seed!");
                return;
            }
            Console.WriteLine();
            problem = new Problem(seed);
            problem.RandomizeMatrix();
        }
    }
}

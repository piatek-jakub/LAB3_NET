using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_LAB3
{
    internal class LowLevelThreading
    {
        public Problem problem;
        public int numberOfThreads;
        Thread[] threads;
        Matrix matrix;
        public LowLevelThreading(int numberOfThreads)
        {
            this.numberOfThreads = numberOfThreads;
            this.threads = new Thread[numberOfThreads];
            matrix = new Matrix();
        }
        public void PrepareThreads()
        {
            for(int i=0; i<threads.Length; i++)
            {
                int threadID = i;
                threads[i] = new Thread(() =>
                {
                    SolveFields(threadID, matrix.width, matrix.height, numberOfThreads, matrix, problem.matrixList);
                });
            }
            foreach(Thread thread in threads)
            {
                thread.Start();
            }
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
        }
        public static void SolveFields(int threadID, int width, int height, int numberOfThreads, Matrix matrix, List<Matrix> matrixList)
        {
            //Console.WriteLine("Thread " + threadID + " here!");
            int matrixSize = width * height;
            for(int i = threadID; i < matrixSize; i+=numberOfThreads)
            {
                int sum = 0;
                for(int j = 0; j < matrixList[0].width; ++j)
                {
                    sum += matrixList[0].matrixArray[i / width, j] * matrixList[1].matrixArray[j, i % width];
                }
                matrix.matrixArray[i / width, i % width] = sum;
            }
            /*int remainder = matrixSize % numberOfThreads;
             *             int quotient = matrixSize / numberOfThreads;
            int startingPosition = quotient * threadID;
            int endingPosition = startingPosition + quotient;
            //Do quotients
            //Console.WriteLine("thread: " + threadID + " start: " + startingPosition + "end: " + endingPosition);
            for (int i = startingPosition; i < endingPosition; ++i)
            {
                //Console.Write("thread" + threadID + ": " + i/width + " " + i%width + "\n");
                int sum = 0;
                for(int j = 0; j < matrixList[0].width; j++)
                {
                    sum += matrixList[0].matrixArray[i / width, j] * matrixList[1].matrixArray[j, i % width];
                }
                matrix.matrixArray[i / width, i % width] = sum;
                //matrix.matrixArray[startingPosition/height,startingPosition%width]);
            }
            //Console.WriteLine("remainder: " + remainder);

            if(threadID < remainder)
            {
                int remainderPosition = quotient * numberOfThreads + threadID;
                int sum = 0;
                for (int i = 0; i < matrixList[0].width; i++)
                {
                    sum += matrixList[0].matrixArray[remainderPosition / width, i] * matrixList[1].matrixArray[i, remainderPosition % width];
                }
                matrix.matrixArray[remainderPosition / width, remainderPosition % width] = sum;
            }*/
        }
        public void CalculateMatrixSize()
        {
            Matrix firstMatrix = problem.matrixList[0];
            Matrix secondMatrix = problem.matrixList[1];
            if(firstMatrix.width != secondMatrix.height)
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
        public Matrix SolveProblem()
        {
            while(problem.matrixList.Count > 1)
            {
                CalculateMatrixSize();
                PrepareThreads();
                UpdateMatrixList();
                //Console.WriteLine(problem.matrixList[0]);
            }
            Matrix resultMatrix = problem.matrixList[0];
            return resultMatrix;
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

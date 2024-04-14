namespace NET_LAB3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfThreads = 16;
            LowLevelThreading lowLevelThreading = new LowLevelThreading(numberOfThreads);
            lowLevelThreading.GenerateProblem();
            //lowLevelThreading.problem.PrintMatrixList();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Matrix matrix = lowLevelThreading.SolveProblem();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Low level Time in ms:" + elapsedMs);
            HighLevelThreading highLevelThreading = new HighLevelThreading(numberOfThreads);
            highLevelThreading.GenerateProblem();
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            Matrix matrix2 = highLevelThreading.SolveProblem();
            watch.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            Console.WriteLine("High level Time in ms:" + elapsedMs2);
            //Console.WriteLine(matrix.ToString());
        }
    }
}

using System;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize variabes
            String logPath = "/Users/vedant/Projects/Assignment1/Assignment1/Logs/Log.txt";
            DateTime now = DateTime.Now;

            // start timer
            Stopwatch stopwatch = Stopwatch.StartNew();


            // walk through directories and parse files
            DirWalker dw = new DirWalker();
            dw.walk("/Users/vedant/Projects/Assignment1/Assignment1/Sample Data");

            // stop timer
            stopwatch.Stop();

            // log
            System.IO.File.AppendAllText(logPath, "\n\n" + now.ToString("s") + ": Total Number of Valid Rows: " + dw.validTotal);
            System.IO.File.AppendAllText(logPath, "\n" +  now.ToString("s") + ": Total Number of Skipped Rows: " + dw.invalidTotal);
            System.IO.File.AppendAllText(logPath, "\n" + now.ToString("s") + ": Execution Time (milliseconds): " + stopwatch.ElapsedMilliseconds.ToString());

            Console.WriteLine("\nTotal valid rows: " + dw.validTotal);
            Console.WriteLine("\nTotal invalid rows: " + dw.invalidTotal);
        }

    }
}

using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            String logPath = "/Users/vedant/Projects/Assignment1/Assignment1/Logs/Log.txt";
            DateTime now = DateTime.Now;

            DirWalker dw = new DirWalker();
            dw.walk("/Users/vedant/Projects/Assignment1/Assignment1/Sample Data");


            System.IO.File.AppendAllText(logPath, "\n\n" + now.ToString("s") + ": Total Number of Valid Rows: " + dw.validTotal);
            System.IO.File.AppendAllText(logPath, "\n" +  now.ToString("s") + ": Total Number of Skipped Rows: " + dw.invalidTotal);

            Console.WriteLine("\nTotal valid rows: " + dw.validTotal);
            Console.WriteLine("\nTotal invalid rows: " + dw.invalidTotal);
        }

    }
}

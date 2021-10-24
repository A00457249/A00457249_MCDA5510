using System;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] header = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "email Address", "Date" };
            String logPath = "/Users/vedant/Projects/Assignment1/Assignment1/Logs/Log.txt";
            String writeValid = "/Users/vedant/Projects/Assignment1/Assignment1/Output/validRows.csv";

            DateTime now = DateTime.Now;

            // start timer
            Stopwatch stopwatch = Stopwatch.StartNew();

            // open writer to write header
            FileWriter wc = new FileWriter();
            var writer = wc.OpenStream(writeValid);

            writer.WriteLine(String.Join(",", header));
            writer.Close();


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

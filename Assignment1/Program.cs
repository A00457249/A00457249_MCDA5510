using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVParser parser = new CSVParser();

            string readPath = "/Users/vedant/Projects/Assignment1/Assignment1/Sample Data/2019/1/1/CustomerData0.csv";
            string writeValid = "/Users/vedant/Projects/Assignment1/Assignment1/validRows.csv";
            string writeInvalid = "/Users/vedant/Projects/Assignment1/Assignment1/invalidRows.csv";

            (int validCount, int invalidCount) = parser.Parse(readPath, writeValid, writeInvalid);

            Console.WriteLine("Count of valid rows: " + validCount);
            Console.WriteLine("Count of invalid rows: " + invalidCount);
        }
    }
}

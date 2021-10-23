using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVParser parser = new CSVParser();
            (int validCount, int invalidCount) = parser.Parse("/Users/vedant/Projects/Assignment1/Assignment1/Sample Data/2019/1/1/CustomerData0.csv");

            Console.WriteLine(validCount);
            Console.WriteLine(invalidCount);
        }
    }
}

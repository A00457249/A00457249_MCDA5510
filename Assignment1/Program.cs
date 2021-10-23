using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirWalker dw = new DirWalker();
            dw.walk("/Users/vedant/Projects/Assignment1/Assignment1/Sample Data");
            Console.ReadKey();
        }
    }
}

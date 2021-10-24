using System;
using System.IO;

namespace Assignment1
{
    public class DirWalker
    {
        // initialize class variables
        public int validTotal = 0;
        public int invalidTotal = 0;

        public void walk(String path)
        {
            // initialize path strings
            String writeValid = "/Users/vedant/Projects/Assignment1/Assignment1/Output/validRows.csv";

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path, "*.csv");
            for (int i = 0; i < fileList.Length; i++)
            {
                // parse files
                CSVParser parser = new CSVParser();
                (int validCount, int invalidCount) = parser.Parse(fileList[i], writeValid);

                // add up counts across files
                validTotal += validCount;
                invalidTotal += invalidCount;
            }
        }

    }
}

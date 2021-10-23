using System;
using System.IO;

namespace Assignment1
{
    public class DirWalker
    {
        public int validTotal = 0;
        public int invalidTotal = 0;

        public void walk(String path)
        {

            String writeValid = "/Users/vedant/Projects/Assignment1/Assignment1/validRows.csv";
            String writeInvalid = "/Users/vedant/Projects/Assignment1/Assignment1/invalidRows.csv";

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

                CSVParser parser = new CSVParser();
                (int validCount, int invalidCount) = parser.Parse(fileList[i], writeValid, writeInvalid);

                validTotal += validCount;
                invalidTotal += invalidCount;
            }
        }

    }
}

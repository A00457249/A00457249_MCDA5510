using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace Assignment1
{
    public class CSVParser
    {

        // initialize class variables
        static String logPath = "/Users/vedant/Projects/Assignment1/Assignment1/Logs/Log.txt";
        static DateTime now = DateTime.Now;

        public Tuple<int, int> Parse(String readPath, String writeValid, String writeInvalid)
        {
            // initialize writer
            FileWriter wc = new FileWriter();
            var validRow = wc.OpenStream(writeValid);
            var invalidRow = wc.OpenStream(writeInvalid);

            // initialize vairables
            int validCount = 0;
            int invalidCount = 0;

            try
            {
                using (TextFieldParser parser = new TextFieldParser(readPath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // skip headers
                    parser.ReadLine();

                    int rowCount = 0;
                    while (!parser.EndOfData)
                    {
                        rowCount++;

                        // determine valid / invalid rows
                        bool isValidRow = false;

                        // process row
                        List<string> fields = new List<string>(parser.ReadFields());
                        for (int i = 0; i < fields.Count; i++)
                        {

                            // check for empty string
                            if (string.IsNullOrEmpty(fields[i]) | fields[3].Contains("/"))
                            {

                                // log if cell value is missing
                                System.IO.File.AppendAllText(logPath, now.ToString("s") + ": Skipped row at line " + rowCount + " of file: " + readPath + "\n");
                                isValidRow = true;
                                break;
                            }

                        }
                        if (isValidRow)
                        {
                            // increment if row is invalid
                            invalidCount++;
                            invalidRow.WriteLine(String.Join(",", fields));

                            continue;
                        }
                        else
                        {
                            // increment if row is valid
                            validCount++;

                            // add date
                            var splitPath = readPath.Split('/');
                            var strdate = splitPath.GetValue(7) + "/" + splitPath.GetValue(8) + "/" + splitPath.GetValue(9);
                            DateTime date = DateTime.Parse(strdate);

                            fields.Add(date.ToString("yyyy-MM-dd"));

                            validRow.WriteLine(String.Join(",", fields));
                        }
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

            // close the writer
            validRow.Close();
            invalidRow.Close();

            // return counts
            return Tuple.Create(validCount, invalidCount);
        }

    }
}

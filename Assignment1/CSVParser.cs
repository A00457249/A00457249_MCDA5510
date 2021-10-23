using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;



namespace Assignment1
{
    public class CSVParser
    {
        public Tuple<int, int> Parse(String readPath, String writeValid, String writeInvalid)
        {
            // initialize variables
            WriteCSV wc = new WriteCSV();
            var validRow = wc.OpenStream(writeValid);
            var invalidRow = wc.OpenStream(writeInvalid);

            int validCount = 0;
            int invalidCount = 0;

            try
            {
                using (TextFieldParser parser = new TextFieldParser(readPath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    bool firstLine = true;

                    while (!parser.EndOfData)
                    {
                        // determine valid / invalid rows
                        bool flag = false;

                        // process row
                        string[] fields = parser.ReadFields();

                        // skip headers after first iter
                        if (firstLine)
                        {
                            validRow.WriteLine(String.Join(",", fields));
                            invalidRow.WriteLine(String.Join(",", fields));

                            firstLine = false;
                            continue;
                        }

                        foreach (string field in fields)
                        {
                            // check for empty string
                            if (string.IsNullOrEmpty(field))
                            {
                                flag = true;
                                break;
                            }
                        
                        }
                        if (flag)
                        {
                            // Increment if row is invalid
                            invalidCount++;
                            invalidRow.WriteLine(String.Join(",", fields));

                            continue;
                        }
                        else
                        {
                            // increment if row is valid
                            validCount++;
                            validRow.WriteLine(String.Join(",", fields));
                        }
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

            validRow.Close();
            invalidRow.Close();


            return Tuple.Create(validCount, invalidCount);
        }

    }
}

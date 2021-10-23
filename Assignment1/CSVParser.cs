using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class CSVParser
    {
        public Tuple<int, int> Parse(String fileName)
        {
            // initialize count variables
            int validCount = 0;
            int invalidCount = 0;

            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        // determine valid / invalid rows
                        bool flag = false;

                        // process row
                        string[] fields = parser.ReadFields();
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
                            Console.WriteLine(String.Join(",", fields));
                            continue;
                        }
                        else
                        {
                            // increment if row is valid
                            validCount++;
                        }
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

            return Tuple.Create(validCount, invalidCount);
        }

    }
}

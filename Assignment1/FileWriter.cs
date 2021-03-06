using System;
using System.IO;


namespace Assignment1
{
    public class FileWriter
    {

        public StreamWriter OpenStream(string path)
        {

            // check if path is null
            if (path is null)
            {
                Console.WriteLine("You did not supply a file path.");
                return null;
            }

            try
            {
                FileStream fs = null;

                // create new file if path exists else open in append mode
                if (!File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.CreateNew);
                }
                else
                    fs = new FileStream(path, FileMode.Append);
                
                return new StreamWriter(fs);
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }

    }
}

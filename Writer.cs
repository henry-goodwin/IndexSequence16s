using System;
using System.IO;

namespace IndexSequence16s
{
    public class Writer
    {
        // Create new StreamWriter
        private StreamWriter writerFile;

        // Create string to store the file name
        private string fileName;

        // Initialise class with file name
        public Writer(string FileName)
        {
            fileName = FileName;
        }

        // Function that returns true if the file can be opended
        public bool OpenFile()
        {
            // Try open the writer file
            try
            {
                // Open the writer file
                writerFile = new StreamWriter(fileName);
                return true;

            }
            catch
            {
                // Print error if file could not be openeded
                Console.WriteLine("Could Not Find File.");
                return false;
            }
        }

        // Function to write string to writer file
        public void WriteFile(string output_string)
        {
            writerFile.WriteLine(output_string);
        }

        // Function to close the writer file
        public void CloseFile()
        {
            writerFile.Close();
        }
    }
}

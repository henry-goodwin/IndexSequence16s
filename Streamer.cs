using System;
using System.IO;

namespace IndexSequence16s
{
    public class Streamer
    {
        // Create new FileStream and StreamReader
        private FileStream fileStream;
        private StreamReader reader;

        // Private string to store the fileName
        private string fileName;

        // Initial Function to set the file name of Streamer
        public Streamer(string FileName)
        {
            fileName = FileName;
        }

        // Function that return true if the file could be opened
        public bool OpenStream()
        {
            // Try open the file Stream and reader
           try
            {
                // Try open file stream in open read mode
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                // Open reader in fileStream
                reader = new StreamReader(fileStream);
                return true;

            } catch
            {
                // If stream could not be opened print error
                Console.WriteLine("Could Not Find File.");
                return false;
            }
        }

        // Function to seek file stream to specific index
        public void Seek(int index)
        {
            // Seek file stream to index
            fileStream.Seek(index, SeekOrigin.Begin);
        }

        // Function to return file stream byte 
        public int ReadByte()
        {
            return fileStream.ReadByte();
        }

        // Function to return file stream offset
        public int GetOffset()
        {
            return (int)(fileStream.Position - 1);
        }

        // Function to close the file stream and reader file
        public void CloseFile()
        {
            reader.Close();
            fileStream.Close();
        }
    }
}

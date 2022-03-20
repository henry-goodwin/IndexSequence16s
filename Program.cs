using System;
using System.IO;

namespace IndexSequence16s
{
    class Program
    {
        static void Main(string[] args)
        {
            // If argument length is greater or equal to 2, Index the file
            if (args.Length >= 2)
            {
                // Create new Index refrence so that the file can be indexed
                Index index = new Index();
                // Run the index function with argument 0 and 1 - (fastaFile, indexFile)
                index.IndexFile(args[0], args[1]);

            } else {
                // If incorrect number of aguments where provided print an error
                Console.WriteLine("Incorrect number of arguments were provided");
            }
        }
    }
}

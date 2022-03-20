using System;
namespace IndexSequence16s
{
    public class Index
    {
        // 16S.fasta 16S.index - command to run
        // Function that indexes an input fasta file
        public void IndexFile(string fileName, string indexFileName)
        {
            // Create new streamer to run through the file
            Streamer fastaFileStream = new Streamer(fileName);

            // If the fasta file stream is opened
            if (fastaFileStream.OpenStream())
            {
                // Go to the beginning of the file
                fastaFileStream.Seek(0);

                // Create new Writer file for saving the result
                Writer resultsFile = new Writer(indexFileName);

                // If the results file stream is opened
                if (resultsFile.OpenFile())
                {
                    // Create new fasta byte refrence to store byte 
                    FastaByte fastaByte = new FastaByte();

                    // While the end of the fasta file stream byte has not been reached - (loop through each byte)
                    while (fastaByte.SetByte(fastaFileStream.ReadByte()))
                    {
                        // If the fasta byte is a new sequence ID
                        if (fastaByte.IsIDSequence())
                        {
                            // Get the sequence ID offset 
                            int offset = fastaFileStream.GetOffset();
                            // String to store the sequence ID
                            string sequence_id = "";

                            // Loop through the fasta file stream 11 times to retrive the full sequence name
                            for (int id_search = 0; id_search < 11; id_search++)
                            {
                                // If the end of file has not been reached read the byte
                                if (fastaByte.SetByte(fastaFileStream.ReadByte()))
                                {
                                    // Append the byte to the sequence array
                                    sequence_id += fastaByte.GetByte();
                                }
                            }

                            // Create string to store the full sequence ID and offest 
                            string index_string = sequence_id + " " + offset;

                            // Write the string to the results file
                            resultsFile.WriteFile(index_string);
                        }
                    }

                    // Close the results file
                    resultsFile.CloseFile();
                }

                // Close the fasta file stream
                fastaFileStream.CloseFile();
            }
        }   
    }
}

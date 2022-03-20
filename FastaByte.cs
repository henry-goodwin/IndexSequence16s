using System;
namespace IndexSequence16s
{
    // Fasta Byte Class is used to store and perform actions on the a fasta byte
    public class FastaByte
    {
        // Private int to store a byte
        private int fastaByte;

        // Function that returns true if the byte is not at the end of file
        public bool SetByte(int f_byte)
        {
            // If byte is valid set byte and return true
            if (f_byte != -1)
            {
                fastaByte = f_byte;
                return true;
            }

            // If byte is not valid and EOF has been reached return false
            return false;
        }

        // Function that returns true if the byte is the start of a new sequence ID
        public bool IsIDSequence()
        {
            return (fastaByte == '>');
        }

        // Function that returns the fasta byte as a charachter
        public char GetByte()
        {
            return (char)fastaByte;
        }
    }
}

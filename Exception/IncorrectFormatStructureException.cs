using System;

namespace ImageFormatConverter
{
    public class IncorrectFormatStructureException : Exception
    {
        public IncorrectFormatStructureException() : base("Incorrect image structure")
        {
            
        }
    }
}
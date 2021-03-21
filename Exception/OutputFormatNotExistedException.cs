using System;

namespace ImageFormatConverter
{
    public class OutputFormatNotExistedException : Exception
    {
        public OutputFormatNotExistedException(string name) : base(String.Format("Format {0} not implemented", name))
        {
            
        }
    }
}
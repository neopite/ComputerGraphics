using ImageConverter.ImageStructure;
using ImageFormatConverter;

namespace ImageConverter.Readers
{
    public class BmpReader : ImageReader
    {
        

        public BmpReader(string path) : base(path)
        {
        }

        public override Image ReadImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
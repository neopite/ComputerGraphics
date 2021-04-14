using ImageConverter.ImageStructure;
using ImageFormatConverter;
using Ninject;

namespace ImageConverter.Writers
{
    public abstract class IImageWriter
    {
        public string OutputPath { get; }

        [Inject]
        public IImageWriter(string outputPath)
        {
            OutputPath =  outputPath;
        }
        
        protected IImageWriter()
        {
        }

        public abstract void WriteImage(Image image);
    }
}
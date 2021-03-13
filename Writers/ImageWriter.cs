using System.IO;

namespace ImageFormatConverter.Writers
{
    public abstract class ImageWriter
    {
        public string OutputPath { get; }

        public ImageWriter(string outputPath)
        {
            OutputPath =  outputPath;
        }

        public abstract void WriteImage(Image image);
    }
}
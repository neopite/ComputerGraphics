using System;
using ImageConverter.Readers;
using ImageConverter.Writers;

namespace ImageConverter
{
    public class ImageConverter
    {
        private readonly ImageReader _imageReader;
        private readonly ImageWriter _imageWriter;

        public ImageConverter(string sourcePath , string convertTo,string outputPath)
        {
            _imageReader = ImageReaderFactory.GetInstance().GetImageReader(sourcePath);
            
            _imageWriter = ImageWriterFactory.GetInstance()
                    .GetImageWriter((ImageWriteFormat)Enum.Parse(typeof(ImageWriteFormat),convertTo,true),outputPath);
        }
        
        public void ConvertImage()
        {
            _imageWriter.WriteImage(_imageReader.ReadImage());
        }
    }
}
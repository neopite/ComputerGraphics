using System;

namespace ImageConverter.Writers
{
    public class ImageWriterFactory
    {
        private static ImageWriterFactory instance;

        private ImageWriterFactory()
        {
            
        }

        public static ImageWriterFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageWriterFactory();
            }
            return instance;
        }
        
        public ImageWriter GetImageWriter(ImageWriteFormat imageType,string outputPath)
        {
            switch (imageType)
            {
                case ImageWriteFormat.BMP : return new BmpWriter(outputPath);
                default: throw new Exception("Not such type");
            }
        }
    }
}
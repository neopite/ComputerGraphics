using System;

namespace ImageFormatConverter.Writers
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
        
        public ImageWriter GetImageWriter(ImageType imageType,string outputPath)
        {
            switch (imageType)
            {
                case ImageType.Bmp : return new BmpWriter(outputPath);
                default: throw new Exception("Not such type");
            }
        }
    }
}
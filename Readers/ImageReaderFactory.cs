using System;

namespace ImageFormatConverter
{
    public class ImageReaderFactory
    {
        private static ImageReaderFactory instance;

        private ImageReaderFactory()
        {
            
        }

        public static ImageReaderFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageReaderFactory();
            } 
            return instance;
        }
        
        public ImageReader GetImageReader(string sourcePath)
        {
            ImageType imageType = Util.ExtractImageTypeFromImageSignature(sourcePath);
            switch (imageType)
            {
                case ImageType.Bmp : return new BmpReader(sourcePath);
                case ImageType.Ppm : return new PpmReader(sourcePath);
                default: throw new Exception("Not such type");
            }
        }
    }
}
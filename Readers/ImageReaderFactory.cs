using System;

namespace ImageConverter.Readers
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
        
        public IImageReader GetImageReader(string sourcePath)
        {
            ImageType imageType = Util.ExtractImageTypeFromImageSignature(sourcePath);
            switch (imageType)
            {
                case ImageType.BMP : return new BmpReader(sourcePath);
                case ImageType.PPM : return new PpmReader(sourcePath);
                default: throw new Exception("Not such type");
            }
        }
    }
}
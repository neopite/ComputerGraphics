using System;

namespace ImageFormatConverter
{
    public class Util
    {
        public static ImageType ExtractImageTypeFromImageSignature(string imageSource)
        {
            string format = imageSource.Split('.')[1];
            return (ImageType)Enum.Parse(typeof(ImageType),format,true);
        }
    }
}
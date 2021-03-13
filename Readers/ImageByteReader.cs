namespace ImageFormatConverter
{
    public class ImageByteReader
    {
        public static byte[] GetImageByteArray(string path)
        {
           return System.IO.File.ReadAllBytes (path);
        }
    }
}
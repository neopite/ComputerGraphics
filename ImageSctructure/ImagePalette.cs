using System.Collections.Generic;

namespace ImageFormatConverter
{
    public class ImagePalette
    {
        public List<Pixel> ListOfPixels { get; set; }

        public ImagePalette()
        {
            ListOfPixels = new List<Pixel>();
        }
    }
}
using System.Collections.Generic;
using ImageFormatConverter;

namespace ImageConverter.ImageStructure
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
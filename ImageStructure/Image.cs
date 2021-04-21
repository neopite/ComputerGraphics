using ImageFormatConverter;

namespace ImageConverter.ImageStructure
{
    public class Image
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImagePalette ImagePalette { get; set; }

        public Image()
        {
            ImagePalette = new ImagePalette();
        }

        public Image(int width, int height, ImagePalette imagePalette)
        {
            Width = width;
            Height = height;
            ImagePalette = imagePalette;
        }

        public Image(int width, int height)
        {
            Width = width;
            Height = height;
            ImagePalette = new ImagePalette();
        }
    }
}
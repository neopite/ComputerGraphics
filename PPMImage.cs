namespace ImageFormatConverter
{
    public class PPMImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImagePalette ImagePalette { get; set; }

        public PPMImage()
        {
            ImagePalette = new ImagePalette();
        }

        public PPMImage(int width, int height)
        {
            Width = width;
            Height = height;
            ImagePalette = new ImagePalette();
        }
    }
}
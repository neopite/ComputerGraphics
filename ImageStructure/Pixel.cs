namespace ImageConverter.ImageStructure
{
    public class Pixel
    {
        public int X { get; }
        public int Y { get; }
        public Color Color { get; }
        
        public Pixel()
        {
        }

        public Pixel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
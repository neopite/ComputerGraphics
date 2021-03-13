using System.IO;

namespace ImageFormatConverter
{
    public class PPMReader : ImageReader
    {
        private string _path;
        public byte[] arr;

        public PPMReader(string path)
        {
            _path = path;
        }

        public void ReadImage()
        {
            Read();
        }

        public PPMImage Read()
        {
            var reader = new BinaryReader(new FileStream(_path, FileMode.Open));
            if (reader.ReadChar() != 'P' || reader.ReadChar() != '6')
                return null;
            reader.ReadChar();
            string width = ""; 
            string height = "";
            char currChar;
            while ((currChar = reader.ReadChar()) != ' ')
            {
                width += currChar;
            }
            while ((currChar = reader.ReadChar()) <= '9' && currChar >= '0' )
            {
                height += currChar;
            }
            reader.ReadChar();
            PPMImage bitmap = new PPMImage {Height = int.Parse(width), Width = int.Parse(height)};
            for (int x = 0; x < bitmap.Height; x++)
            {
                for (int y = 0; y < bitmap.Width; y++)
                {
                    bitmap.ImagePalette.ListOfPixels.Add(
                        new Pixel(x, y, new Color(reader.ReadByte(), reader.ReadByte(), reader.ReadByte())));
                }
            }
            return bitmap;
        }
    }
}
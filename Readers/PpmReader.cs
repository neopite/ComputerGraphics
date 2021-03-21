using System.IO;
using ImageConverter.ImageStructure;
using ImageFormatConverter;

namespace ImageConverter.Readers
{
    public class PpmReader : ImageReader
    {
        
        public PpmReader(string path) : base(path)
        {
        }
        public override Image ReadImage()
        {
            var reader = new BinaryReader(new FileStream(Path, FileMode.Open));
            if (reader.ReadChar() != 'P' || reader.ReadChar() != '6')
            {
                throw new IncorrectFormatStructureException();
            }
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
            string maxVal = "";
            while ((currChar = reader.ReadChar()) != '\n')
            {
                maxVal += currChar;
            }
            Image bitmap = new Image {Height = int.Parse(width), Width = int.Parse(height)};
            for (int x = bitmap.Height - 1; x >= 0; x--)
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
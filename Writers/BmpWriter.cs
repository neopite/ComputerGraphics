using System.IO;
using ImageConverter.ImageStructure;
using ImageConverter.Writers.FormatData;
using ImageFormatConverter;

namespace ImageConverter.Writers
{
    public class BmpWriter : ImageWriter
    {
        public BmpWriter(string outputPath) : base(outputPath)
        {
            
        }

        public override void WriteImage(Image image)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(OutputPath + ".bmp", FileMode.Create));
            BmpMetaData metaData = new BmpMetaData(image);

            writer.Write(BmpMetaData.bitmapSignatureBytes);
            writer.Write(metaData.sizeOfBitmapFile);
            writer.Write(BmpMetaData.reservedBytes);
            writer.Write(BmpMetaData.pixelDataOffset);

            writer.Write(BmpMetaData.sizeOfThisHeader);
            writer.Write(metaData.height);
            writer.Write(metaData.width);
            writer.Write(BmpMetaData.numberOfColorPlanes);
            writer.Write(BmpMetaData.colorDepth);
            writer.Write(BmpMetaData.compressionMethod);
            writer.Write(BmpMetaData.rawBitmapDataSize);
            writer.Write(BmpMetaData.horizontalResolution);
            writer.Write(BmpMetaData.verticalResolution);
            writer.Write(BmpMetaData.colorTableEntries);
            writer.Write(BmpMetaData.importantColors);

            for (int i = image.Height - 1; i >= 0; i--)
            {
                var rowOfPixels = image.ImagePalette.ListOfPixels.GetRange(i * image.Width, image.Width);
                foreach (var pixel in rowOfPixels)
                {
                    writer.Write(pixel.Color.B);
                    writer.Write(pixel.Color.G);
                    writer.Write(pixel.Color.R);
                }
            }
            writer.Write(new byte[]{0, 0});
            writer.Flush();
            writer.Close();
        }
    }
}
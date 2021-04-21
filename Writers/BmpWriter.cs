using System.IO;
using ImageConverter.ImageStructure;
using ImageConverter.Writers.FormatData;
using ImageFormatConverter;
using Ninject;

namespace ImageConverter.Writers
{
    public class BmpWriter : ImageWriter
    {
        [Inject]
        public BmpWriter()
        {
        }

        public override void WriteImage(Image image , string output)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(output + ".bmp", FileMode.Create));
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
                for (int itter = rowOfPixels.Count -1 ; itter >= 0 ; itter--)
                {
                    writer.Write(rowOfPixels[itter].Color.B);
                    writer.Write(rowOfPixels[itter].Color.G);
                    writer.Write(rowOfPixels[itter].Color.R);   
                }
            }
            writer.Write(new byte[]{0, 0});
            writer.Flush();
            writer.Close();
        }
    }
}
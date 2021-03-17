using System;
using System.IO;

namespace ImageFormatConverter.Writers
{
    public class BmpHeader
    {
        public char[] bitmapSignatureBytes;
        public int sizeOfBitmapFile;
        public int reservedBytes;
        public int pixelDataOffset;

        public BmpHeader(int SizeOfBitmapFileSize)
        {
            bitmapSignatureBytes = new []{'B', 'M'};
            sizeOfBitmapFile = 54 + SizeOfBitmapFileSize;
            reservedBytes = 0;
            pixelDataOffset = 14 + 40;
        }
    }

    public class BmpInfoHeader
    {
        public int sizeOfThisHeader;
        public int height; // in pixels
        public int width; // in pixels
        public ushort numberOfColorPlanes; // must be 1
        public ushort colorDepth;
        public int compressionMethod;
        public uint rawBitmapDataSize; // generally ignored
        public int horizontalResolution = 3780; // in pixel per meter
        public int verticalResolution = 3780; // in pixel per meter
        public uint colorTableEntries = 0;
        public uint importantColors = 0;

        public BmpInfoHeader(Image image)
        {
            sizeOfThisHeader = 40;
            height = image.Height;
            width = image.Width;
            numberOfColorPlanes = 1;
            colorDepth = 24;
            compressionMethod = 0;
            rawBitmapDataSize = 0;
            horizontalResolution = 3780;
            verticalResolution = 3780;
            colorTableEntries = 0;
            importantColors = 0;
        }
    }

    public class BmpWriter : ImageWriter
    {
        public BmpWriter(string outputPath) : base(outputPath)
        {
            
        }

        public override void WriteImage(Image image)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(OutputPath + "image_converted.bmp", FileMode.Create));
            BmpInfoHeader header2 = new BmpInfoHeader(image);
            BmpHeader header1 = new BmpHeader(image.Height * image.Width * header2.colorDepth);
            
            writer.Write(header1.bitmapSignatureBytes);
            writer.Write(header1.sizeOfBitmapFile);
            writer.Write(header1.reservedBytes);
            writer.Write(header1.pixelDataOffset);

            writer.Write(header2.sizeOfThisHeader);
            writer.Write(header2.height);
            writer.Write(header2.width);
            writer.Write(header2.numberOfColorPlanes);
            writer.Write(header2.colorDepth);
            writer.Write(header2.compressionMethod);
            writer.Write(header2.rawBitmapDataSize);
            writer.Write(header2.horizontalResolution);
            writer.Write(header2.verticalResolution);
            writer.Write(header2.colorTableEntries);
            writer.Write(header2.importantColors);

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
namespace ImageFormatConverter.FormatData
{
    public class BmpMetaData
    {
        public static readonly int sizeOfThisHeader = 40;
        
        public int height; // in pixels
        public int width; // in pixels
        
        public static readonly ushort numberOfColorPlanes = 1; // must be 1
        public static readonly ushort colorDepth = 24;
        public static readonly int compressionMethod = 0;
        public static readonly uint rawBitmapDataSize = 0; // generally ignored
        public static readonly int horizontalResolution = 3780; // in pixel per meter
        public static readonly int verticalResolution = 3780; // in pixel per meter
        public static readonly uint colorTableEntries = 0;
        public static readonly uint importantColors = 0;
        
        public static readonly char[] bitmapSignatureBytes = {'B', 'M'};
        public int sizeOfBitmapFile;
        public static readonly int reservedBytes = 0;
        public static readonly int pixelDataOffset = 54; //sum of 2 headers' sizes 
        
        public BmpMetaData(Image image)
        {
            height = image.Height;
            width = image.Width;
            int SizeOfBitmapFileSize = image.Height * image.Width * colorDepth;
            sizeOfBitmapFile = pixelDataOffset + SizeOfBitmapFileSize;
        }
        
    }
}
using System;
using System.IO;

namespace ImageFormatConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"/Images/";
            
            ImageConverter image = new ImageConverter(path+"mycow.ppm", "bmp",path);
            image.ConvertImage();
        }
    }
}
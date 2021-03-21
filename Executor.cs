using System;
using System.IO;
using System.Linq;

namespace ImageFormatConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            string source = args[0].Substring(9);
            string format = args[1].Substring(14);
            string output = args.Length > 3 ? args[2].Substring(9) : source.Split('.')[0];
            
            
            // string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"/Images/";
            //
            // ImageConverter image = new ImageConverter(path+source, format,path);
            
            ImageConverter image = new ImageConverter(source, format,output);
            image.ConvertImage();
        }
    }
}
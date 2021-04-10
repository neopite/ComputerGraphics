using System;
using System.Linq;
using ImageConverter.Writers;
using ImageFormatConverter;

namespace ImageConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
            /*Rendering.Rendering rendering = new Rendering.Rendering();
            new BmpWriter("D:\\Study\\CompGraphics\\ComputerGraphics\\Images").WriteImage(rendering.Render("D:\\Study\\CompGraphics\\ComputerGraphics\\Images\\cow.obj"));*/
            
            Console.WriteLine(args.Length);
            string source = args[0].Substring(9);
            string format = args[1].Substring(14);
            string output = args.Length > 2 ? args[2].Substring(9) : source.Split('.')[0];
            
            if (Enum.GetNames(typeof(ImageWriteFormat)).ToList().Contains(format.ToUpper()))
            {
                ImageConverter image = new ImageConverter(source, format, output);
                image.ConvertImage();
            }
            else throw new OutputFormatNotExistedException(format);
            
        }
    }
}
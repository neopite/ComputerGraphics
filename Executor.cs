using System;
using System.Linq;
using System.Reflection;
using ImageConverter.Readers;
using ImageConverter.Rendering;
using ImageConverter.Rendering.Renderer;
using ImageConverter.Writers;
using ImageFormatConverter;
using Ninject;

namespace ImageConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
            IKernel container = SetupContainer("D:\\Study\\CompAssignment\\ComputerGraphics\\Images","D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj");
            IRenderer rendering = new Rendering.DefaultRenderer();
            IImageWriter imageWriter = container.Get<IImageWriter>();
                imageWriter.WriteImage(rendering.RenderObj("D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj"));
            
            
                
            /*Console.WriteLine(args.Length);
            string source = args[0].Substring(9);
            string format = args[1].Substring(14);
            string output = args.Length > 2 ? args[2].Substring(9) : source.Split('.')[0];
            
            if (Enum.GetNames(typeof(ImageWriteFormat)).ToList().Contains(format.ToUpper()))
            {
                ImageConverter image = new ImageConverter(source, format, output);
                image.ConvertImage();
            }
            else throw new OutputFormatNotExistedException(format);*/
            
        }


        private static IKernel SetupContainer(string outputPath,string inputPath)
        {
            IKernel container = new StandardKernel();
            container.Bind<IImageWriter>().To<BmpWriter>()
                .WithConstructorArgument("outputPath", outputPath);
            container.Bind<IObjectParser>().To<Parser>();
            container.Bind<IRenderer>().To<DefaultRenderer>();
            return container;
        }
    }
}
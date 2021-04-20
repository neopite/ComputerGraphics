using System;
using System.Linq;
using System.Reflection;
using ImageConverter.Readers;
using ImageConverter.Rendering;
using ImageConverter.Rendering.Renderer;
using ImageConverter.Rendering.Renderer.Calculations;
using ImageConverter.Writers;
using ImageFormatConverter;
using Ninject;

namespace ImageConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
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
        
        /*private static IKernel SetupContainer(string outputPath,string inputPath)
        {
            IKernel container = new StandardKernel();
            container.Bind<IImageWriter>().To<BmpWriter>()
                .WithConstructorArgument("outputPath", outputPath);
            container.Bind<IObjectParser>().To<Parser>();
            container.Bind<IRenderer>().To<DefaultRenderer>();
            container.Bind<IRayIntersactionCalculation>().To<MollerTrumbore>();
            container.Bind<Vector3>().To<Vector3>().Named("CameraPos").WithConstructorArgument("x", 0.0)
                .WithConstructorArgument("y",0.0).WithConstructorArgument("z", 0.0);
            container.Bind<Vector3>().To<Vector3>().Named("CameraRot").WithConstructorArgument("x", 0.0)
                .WithConstructorArgument("y",0.0).WithConstructorArgument("z", 0.0);
            container.Bind<Vector3>().To<Vector3>().Named("CameraScale").WithConstructorArgument("x", 0.0)
                .WithConstructorArgument("y",0.0).WithConstructorArgument("z", 0.0);
            container.Bind<Transform>().To<Transform>().Named("CameraTransform")
                .WithConstructorArgument("position", container.Get<Vector3>("CameraPos"))
                .WithConstructorArgument("rotation", container.Get<Vector3>("CameraRot"))
                .WithConstructorArgument("scale", container.Get<Vector3>("CameraScale"));
            container.Bind<ICamera>().To<StaticCamera>().WithConstructorArgument("transform",container.Get<Transform>("CameraTransform"));
            
            return container;
        }*/
    }
}
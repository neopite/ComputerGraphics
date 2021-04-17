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
           // IKernel container = SetupContainer("D:\\Study\\CompAssignment\\ComputerGraphics\\Images","D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj");
            //IRenderer rendering = container.Get<IRenderer>();
            //IImageWriter imageWriter = container.Get<IImageWriter>();
            //    imageWriter.WriteImage(rendering.RenderObj("D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj"));
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
            container.Bind<ICamera>().To<StaticCamera>().WithConstructorArgument("Origin",container.Get<Vector3>("CameraPos"));
            
            return container;
        }*/
    }
}
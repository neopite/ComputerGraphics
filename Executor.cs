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
           ICamera camera = new StaticCamera(new Transform(new Vector3(0,0,0),Vector3.Zero,Vector3.One));
           IRayIntersactionCalculation rayIntersactionCalculation = new MollerTrumbore();
           IObjectParser objectParser = new Parser();
           IRenderer rendering = new DefaultRenderer(objectParser,rayIntersactionCalculation,camera);
           IImageWriter imageWriter = new BmpWriter();
                imageWriter.WriteImage(rendering.RenderObj("D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj"));
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
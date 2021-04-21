using System;
using System.Linq;
using System.Reflection;
using ImageConverter.Readers;
using ImageConverter.Rendering;
using ImageConverter.Rendering.Lights;
using ImageConverter.Rendering.Rays;
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
            string input = "D:\\Study\\CompAssignment\\ComputerGraphics\\Images\\cow.obj";
            string output = "D:\\Study\\CompAssignment\\ComputerGraphics\\Images";
            IKernel container = SetupContainer();
            IRenderer rendering = container.Get<IRenderer>();
            ImageWriter imageWriter = container.Get<ImageWriter>();
                imageWriter.WriteImage(rendering.RenderObj(input),output);

        }
        
        private static IKernel SetupContainer()
        {
            IKernel container = new StandardKernel();
            container.Bind<ImageWriter>().To<BmpWriter>();
            container.Bind<IObjectParser>().To<Parser>();
            container.Bind<ILight>().To<StaticLight>();
            container.Bind<IRayIntersactionCalculation>().To<MollerTrumbore>();
            container.Bind<ColorIntensativeCalculation>().To<ColorIntensativeCalculation>();
            container.Bind<Camera>().To<PerpectiveCamera>();
            container.Bind<IRenderer>().To<DefaultRenderer>();
            return container;
        }
    }
}
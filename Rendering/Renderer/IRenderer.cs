using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Renderer.Calculations;
using Ninject;

namespace ImageConverter.Rendering.Renderer
{
    public abstract  class IRenderer
    {
        private IObjectParser _objectParser;
        public IRayIntersactionCalculation RayIntersactionSolver { get; private set; }
        public ICamera Camera { get; private set; }


        [Inject]
        protected IRenderer(IObjectParser objectParser, IRayIntersactionCalculation rayIntersactionSolver , ICamera camera)
        {
            _objectParser = objectParser;
            RayIntersactionSolver = rayIntersactionSolver;
            Camera = camera;
        }
        
        public  abstract Image RenderObj(string inputPath);

        public List<Triangle> GetModel(string inputPath)
        {
            return  _objectParser.ParseObject(inputPath);
        }
        
        public List<Vector3> GetScreenPointsForRay(double screenSize , Image goalImage)
        {
            List<Vector3> listPointsForRay = new List<Vector3>();
            
            int imageHeight = goalImage.Height;
            int imageWidth = goalImage.Width;
            
            double pZ = -1; 
            
            for (int y = 0; y < imageHeight; y++)       
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    double pX = (2 * (x + 0.5) / imageWidth) - 1;
                    double pY = 1 - 2 * ((y + 0.5) / imageHeight);
                    Vector3 rayInWorldSpace = new Vector3(pX, pY, pZ);
                    listPointsForRay.Add(rayInWorldSpace);
                }
            }
            return listPointsForRay;
        }
    }
}
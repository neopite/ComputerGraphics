using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Calculation;
using ImageConverter.Rendering.Lights;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Renderer.Calculations;
using Ninject;

namespace ImageConverter.Rendering.Renderer
{
    public abstract  class IRenderer
    {
        private IObjectParser _objectParser;
        public IRayIntersactionCalculation RayIntersactionSolver { get; private set; }
        public ICamera Camera { get; private set; }
        public ColorIntensativeCalculation ColorIntensativeCalculation { get; private set; }


        [Inject]
        protected IRenderer(IObjectParser objectParser, IRayIntersactionCalculation rayIntersactionSolver , ICamera camera , ColorIntensativeCalculation calculation)
        {
            _objectParser = objectParser;
            RayIntersactionSolver = rayIntersactionSolver;
            Camera = camera;
            ColorIntensativeCalculation = calculation;
        }
        
        public  abstract Image RenderObj(string inputPath);

        public Mesh InitModel(string inputPath)
        {
            return  _objectParser.ParseObject(inputPath);
        }
        
        public List<Vector3> GetScreenPointsForRay(double screenSize , Image goalImage, ICamera camera, Vector3 screencenter)
        {
            List<Vector3> listPointsForRay = new List<Vector3>();
            
            int imageHeight = goalImage.Height;
            int imageWidth = goalImage.Width;

            Vector3 translation = screencenter - camera.Origin;
            Vector3 scale = new Vector3(1, 1, 1);
            Vector3 rotation = new Vector3(0, 0, 0);
            
            double pZ = -1; 
            
            for (int y = 0; y < imageHeight; y++)       
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    double pX = (2 * (x + 0.5) / imageWidth) - 1;
                    double pY = 1 - 2 * ((y + 0.5) / imageHeight);
                    Vector3 pointCoordinatesInPlainSpace = new Vector3(pX, pY, pZ);
                    listPointsForRay.Add(pointCoordinatesInPlainSpace);
                }
            }
            return listPointsForRay;
        }
    }
}
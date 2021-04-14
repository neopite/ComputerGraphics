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
        
        public List<Vector3> GetScreenPointsForRay(Vector3 screenCenter, double screenSize , Image goalImage)
        {
            List<Vector3> listPointsForRay = new List<Vector3>();
            
            int imageHeight = goalImage.Height;
            int imageWidth = goalImage.Width;

            double pixHeight = screenSize / imageHeight;
            double pixWidth = screenSize / imageWidth;


            double pZ = screenCenter.z; // const as for surface ( parallel oxy )
            
            for (int i = 0; i < imageHeight; i++)       
            {
                double pY = screenCenter.y - screenSize / 2 + pixHeight * (i + 0.5);
                for (int j = 0; j < imageWidth; j++)
                {
                    double pX = screenCenter.x - screenSize / 2 + pixWidth * (j + 0.5);         //pZ const ( takes from center coord)
                    Vector3 screenPointForRay = new Vector3(pX, pY, pZ);
                    listPointsForRay.Add(screenPointForRay);
                }
            }
            return listPointsForRay;
        }
        
    }
}
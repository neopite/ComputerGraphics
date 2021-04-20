using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Calculation;
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

        public Mesh InitModel(string inputPath)
        {
            return  _objectParser.ParseObject(inputPath);
        }
        
        public List<Vector3> GetScreenPointsForRay(double screenSize, Image goalImage, ICamera camera, Vector3 worldScreenCenter)
        {
            List<Vector3> listPointsForRay = new List<Vector3>();
            
            int imageHeight = goalImage.Height;
            int imageWidth = goalImage.Width;

            double pixHeight = screenSize / imageHeight;
            double pixWidth = screenSize / imageWidth;

            Vector3 plainScreenCenter = new Vector3(screenSize / 2, screenSize / 2, 0);
            

            Vector3 translation = worldScreenCenter;
            Vector3 scale = new Vector3(1, 1, 1);
            Vector3 rotation = new Vector3(270, 0, 0);

            var tranformationMatrix = Matrix4x4.GetTransformationMatrix(translation, rotation, scale);
            
            double pZ = 0;
            double pY;
            double pX;

            List<Vector3> temp = new List<Vector3>();

            for (int i = 0; i < imageHeight; i++)
            {
                pY = plainScreenCenter.y - screenSize / 2 + pixHeight * (i + 0.5);
                for (int j = 0; j < imageWidth; j++)
                {
                    pX = plainScreenCenter.x - screenSize / 2 + pixWidth * (j + 0.5);
                    
                    Vector3 pointCoordinatesInPlainSpace = new Vector3(pX, pY, pZ) - plainScreenCenter;
                    
                    temp.Add(pointCoordinatesInPlainSpace);

                    Vector3 pointCoordinatesInWorldSpace = Matrix4x4.TransformToWorldCoordinates(tranformationMatrix, pointCoordinatesInPlainSpace);
                    
                    
                    
                    listPointsForRay.Add(pointCoordinatesInWorldSpace);
                }
            }
            
            return listPointsForRay;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.ThreeD.Entities;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;
using ImageConverter.Rendering.Renderer;
using ImageConverter.Rendering.Renderer.Calculations;
using ObjLoader.Loader.Loaders;

namespace ImageConverter.Rendering
{
    public class DefaultRenderer : IRenderer
    {
        private static readonly Color _blackPixel = new Color(0, 0, 0);
        private static readonly Color _redPixel = new Color(255, 0, 0);
        private double _actualScreenSize; //Square screen

        public DefaultRenderer(IObjectParser objectParser, IRayIntersactionCalculation rayIntersactionSolver, ICamera camera) : base(objectParser, rayIntersactionSolver, camera)
        {
        }

        public override Image RenderObj(string inputPath)
        {
            #region CameraSettings
            Vector3 centerScreen = new Vector3(0,1,0);
            Vector3 camLookDirection = (centerScreen - Camera.Origin).Normalize();
            Image image = new Image(1000,1000);
            #endregion
            _actualScreenSize = MathCalculations.GetActualScreenSize((centerScreen - Camera.Origin).Length,90);

            Mesh objectMesh = new Mesh(GetModel(inputPath));
            GameObject gameObject = new GameObject();
            gameObject.MeshRenderer = objectMesh;
            List<Vector3> arrayOfPixelsCenters = GetScreenPointsForRay(_actualScreenSize,image, Camera, centerScreen);
            IRay[,] rays = GetRays(Camera,arrayOfPixelsCenters,image);
            image.ImagePalette = GetRayIntersactionWithModel(rays,objectMesh);
            return image;
        }
        
        private IRay[,] GetRays(ICamera camera , List<Vector3> listOfCentersOnScreen , Image image)
        {
            IRay[,] screenRays = new IRay[image.Width,image.Height];
            for (int i = 0; i < screenRays.GetLength(0); i++)
            {
                for (int j = 0; j < screenRays.GetLength(1); j++)
                {
                    screenRays[i, j] = new Ray(camera.Origin,
                        (listOfCentersOnScreen[(i * screenRays.GetLength(1)) + j] - camera.Origin));
                }
            }
            return screenRays;
        }

        private ImagePalette GetRayIntersactionWithModel(IRay[,] rays , Mesh objectMesh)
        {
            ImagePalette imagePalette = new ImagePalette();
            for (int i = rays.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = rays.GetLength(1) - 1; j >= 0 ; j--)
                {
                    bool isFilled = false;
                    foreach (Triangle tr in objectMesh.Faces)
                    {
                        isFilled = RayIntersactionSolver.RayIntersectsTriangle(rays[i, j],tr);
                        if(isFilled) break;
                    }
                    if (isFilled) imagePalette.ListOfPixels.Add(new Pixel(i, j, _redPixel));
                    else imagePalette.ListOfPixels.Add(new Pixel(i, j, _blackPixel));
                    isFilled = false;
                }
            }
            return imagePalette;
        }
    }
}

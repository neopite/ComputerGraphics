using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.ThreeD.Entities;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Lights;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;
using ImageConverter.Rendering.Renderer;
using ImageConverter.Rendering.Renderer.Calculations;
using ImageConverter.Rendering.Scene;
using ObjLoader.Loader.Loaders;

namespace ImageConverter.Rendering
{
    public class DefaultRenderer : IRenderer
    {
        private  double _actualScreenSize; //Square screen

        public DefaultRenderer(IObjectParser objectParser, IRayIntersactionCalculation rayIntersactionSolver, Camera camera, ColorIntensativeCalculation colorIntensativeCalculation) : base(objectParser, rayIntersactionSolver, camera, colorIntensativeCalculation)
        {
        }

        public override Image RenderObj(string inputPath)
        {
            _actualScreenSize = MathCalculations.GetActualScreenSize((camera.screenCenter - camera.transform.position).Length,90);
            Mesh objectMesh = InitModel(inputPath);
            List<Vector3> arrayOfPixelsCenters = camera.GetScreenPoints(_actualScreenSize);
            IRay[,] rays = GetRays(camera,arrayOfPixelsCenters);
            return new Image(camera.height,camera.width,GetRayIntersactionWithModel(rays, objectMesh));
        }
        
        private IRay[,] GetRays(Camera camera , List<Vector3> listOfCentersOnScreen)
        {
            IRay[,] screenRays = new IRay[camera.width , camera.height];
            for (int i = 0; i < screenRays.GetLength(0); i++)
            {
                for (int j = 0; j < screenRays.GetLength(1); j++)
                {
                    screenRays[i, j] = new Ray(camera.transform.position,
                        listOfCentersOnScreen[i * screenRays.GetLength(1) + j] - camera.transform.position);
                }
            }
            return screenRays;
        }

        private ImagePalette GetRayIntersactionWithModel(IRay[,] rays , Mesh objectMesh)
        {
            ImagePalette imagePalette = new ImagePalette();
            Tree tree = new Tree(objectMesh);
            for (int i = rays.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = rays.GetLength(1) - 1; j >= 0 ; j--)
                {
                    Color color = Color.Black;
                    Node node = tree.AppropriateBoxForRay(rays[i, j], tree.root);
                    if (node != null)
                    {
                         color = colorIntensativeCalculation.GetObjectColor(node, rays[i, j], rayIntersactionSolver);
                    }
                    imagePalette.ListOfPixels.Add(new Pixel(i, j, color));
                }
            }
            return imagePalette;
        }
    }
}

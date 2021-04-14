using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageConverter.ImageStructure;
using ObjLoader.Loader.Loaders;

namespace ImageConverter.Rendering
{
    public class Rendering
    {
        private static readonly Color _blackPixel = new Color(0, 0, 0);
        private static readonly Color _redPixel = new Color(255, 0, 0);
        private ICamera _camera;
        private double _actualScreenSize; //Square screen
        
        public Image Render(string inputPath)
        {
            #region CameraSettings
            Vector3 cameraPosition = new Vector3(0, 0, -2);
            Vector3 centerScreen = new Vector3(0, 0, -1);
            Vector3 camLookDirection = (centerScreen - cameraPosition).Normalize();
            _camera = new StaticCamera(cameraPosition,camLookDirection,90);
            #endregion
            _actualScreenSize = GetScreenSize((_camera.Origin - centerScreen).Length,_camera.Fov);

            List<Triangle> renderObject = GetModel(inputPath);
            Image image = new Image(1000,1000);
            List<Vector3> arrayOfPixelsCenters = GetScreenPointsForRay(centerScreen,_actualScreenSize,image);
            Vector3[,] rays = GetRays(_camera.Origin,arrayOfPixelsCenters,image);
            image.ImagePalette = GetRayIntersactionWithModel(rays,renderObject);
            return image;
        }
        
        //Assume that width == height
        private double GetScreenSize(double distanceFromCamToScreen , double fov)
        {
            double rad = DegreeToRad(fov);
            double size = 2 * distanceFromCamToScreen * Math.Tan(rad/2);
            return size;
        }

        private static double DegreeToRad(double degree)
        {
            return  degree / 180f * Math.PI;
        }
        
        private List<Vector3> GetScreenPointsForRay(Vector3 screenCenter, double screenSize , Image goalImage)
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

        private Vector3[,] GetRays(Vector3 originCamera , List<Vector3> listOfCentersOnScreen , Image image)
        {
            Vector3[,] screenRays = new Vector3[image.Width,image.Height];
            for (int i = 0; i < screenRays.GetLength(0); i++)
            {
                for (int j = 0; j < screenRays.GetLength(1); j++)
                {
                    screenRays[i, j] = (listOfCentersOnScreen[(i * screenRays.GetLength(1)) + j] - originCamera).Normalize();
                }
            }
            return screenRays;
        }

        private ImagePalette GetRayIntersactionWithModel(Vector3[,] rays , List<Triangle> renderObject)
        {
            ImagePalette imagePalette = new ImagePalette();
            for (int i = rays.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = rays.GetLength(1) - 1; j >= 0 ; j--)
                {
                    bool isFilled = false;
                    foreach (Triangle tr in renderObject)
                    {
                        isFilled = MollerTrumbore.RayIntersectsTriangle(_camera.Origin, rays[i, j], tr);
                        if(isFilled) break;
                    }
                    if (isFilled) imagePalette.ListOfPixels.Add(new Pixel(i, j, _redPixel));
                    else imagePalette.ListOfPixels.Add(new Pixel(i, j, _blackPixel));
                    isFilled = false;
                }
            }

            return imagePalette;
        }

        private List<Triangle> GetModel(string inputPath)
        {
            return  new Parser().ParseObject(inputPath);
        }
    }
}

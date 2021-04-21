using System.Collections.Generic;
using ImageConverter.Rendering.Calculation;

namespace ImageConverter.Rendering
{
    public class PerpectiveCamera : Camera 
    {
        public PerpectiveCamera(Transform transform, Vector3 screenCenter, int width, int height) : base(transform, screenCenter, width, height)
        {
        }

        public override List<Vector3> GetScreenPoints(double screenSize)
        {
            List<Vector3> listPointsForRay = new List<Vector3>();
            
            double pixHeight = screenSize / height;
            double pixWidth = screenSize / width;

            Vector3 plainScreenCenter = new Vector3(screenSize / 2, screenSize / 2, 0);
            
            var tranformationMatrix = Matrix4x4.GetTransformationMatrix(screenCenter, transform.rotation, transform.scale);
            
            double pY;
            double pX;
            
            for (int i = 0; i < height; i++)
            {
                pY = plainScreenCenter.y - screenSize / 2 + pixHeight * (i + 0.5);
                for (int j = 0; j < width; j++)
                {
                    pX = plainScreenCenter.x - screenSize / 2 + pixWidth * (j + 0.5);
                    Vector3 pointCoordinatesInWorldSpace = Matrix4x4.TransformToWorldCoordinates(tranformationMatrix, new Vector3(pX, pY, 0) - plainScreenCenter);
                    listPointsForRay.Add(pointCoordinatesInWorldSpace);
                }
            }
            return listPointsForRay;
        }
    }
}
using System;
using ImageConverter.Rendering.Lights;

namespace ImageConverter.Rendering.Rays
{
    public class ColorIntensativeCalculation
    {
        public ILight Light { get; private set; }

        public ColorIntensativeCalculation(ILight light)
        {
            Light = light;
        }

        public double FindColorIntensativeForTrinagle(Triangle triangle,Vector3 normal, Vector3 intersectionPoint)
        {
            Vector3 fromPointToLightOrigin = Light.Origin - intersectionPoint;
            Vector3 faceNormal = normal;
            
            double lightSourceDirectionLength = fromPointToLightOrigin.Length;
            double triangleNormalLength = faceNormal.Length;
            
            double cos = (fromPointToLightOrigin * faceNormal) / (lightSourceDirectionLength * triangleNormalLength);
            var globalLight = 0.1;
            return Math.Max(globalLight, cos);
        }
        
    }
}
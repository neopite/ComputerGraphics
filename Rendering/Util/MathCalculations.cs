using System;

namespace ImageConverter.Rendering
{
    public class MathCalculations
    {
        public static double DegreeToRad(double degree)
        {
            return  degree / 180f * Math.PI;
        }
        
        //Assume that screen is square 
        public static double GetActualScreenSize(double distanceFromCamToScreen , double fov)
        {
            double rad = MathCalculations.DegreeToRad(fov);
            double size = 2 * distanceFromCamToScreen * Math.Tan(rad/2);
            return size;
        }
    }
}
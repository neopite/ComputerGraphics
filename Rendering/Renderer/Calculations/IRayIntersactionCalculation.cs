using System;

namespace ImageConverter.Rendering.Renderer.Calculations
{
    public interface IRayIntersactionCalculation
    {
        public Boolean IsRayIntersectsTriangle(Vector3 rayOrigin, Vector3 rayVector, Triangle inTriangle);
    }
}
using System;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;

namespace ImageConverter.Rendering.Renderer.Calculations
{
    public interface IRayIntersactionCalculation
    {
        public  Boolean RayIntersectsTriangle(IRay ray, Triangle inTriangle);
    }
}
using System;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;

namespace ImageConverter.Rendering.Renderer.Calculations
{
    public interface IRayIntersactionCalculation
    {
        public  TriagleIntersectionModel RayIntersectsTriangle(IRay ray, Triangle inTriangle);
    }
}
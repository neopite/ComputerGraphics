using System;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;
using ImageConverter.Rendering.Renderer.Calculations;

namespace ImageConverter.Rendering
{
    public class MollerTrumbore : IRayIntersactionCalculation
    {
        private static readonly double EPSILON = 0.0000001;
        
        public Boolean RayIntersectsTriangle(IRay ray , Triangle inTriangle)
        {
            var vertex0 = inTriangle.a;
            var vertex1 = inTriangle.b;
            var vertex2 = inTriangle.c;
            var edge1 = vertex1 - vertex0;
            var edge2 = vertex2 - vertex0;
            var h = ray.Direction.CrossProduct(edge2);
            var a = edge1.DotProduct(h);
            if (a > -EPSILON && a < EPSILON)
            {
                return false;
            }
            var f = 1 / a;
            var s = ray.Origin - vertex0;
            var u = f * s.DotProduct(h);
            if (u < 0.0 || u > 1.0)
            {
                return false;
            }
            var q = s.CrossProduct(edge1);
            var v = f * ray.Direction.DotProduct(q);
            if (v < 0.0 || u + v > 1.0)
            {
                return false;
            }

            // At this stage we can compute t to find out where the intersection point is on the line.
            var t = f * edge2.DotProduct(q);
            return t > EPSILON;
        }
    }
}
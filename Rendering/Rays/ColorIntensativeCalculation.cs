using System;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Lights;
using ImageConverter.Rendering.Renderer.Calculations;

namespace ImageConverter.Rendering.Rays
{
    public class ColorIntensativeCalculation
    {
        public ILight Light { get; private set; }

        public ColorIntensativeCalculation(ILight light)
        {
            Light = light;
        }

        public Color GetObjectColor(Box box ,IRay ray ,IRayIntersactionCalculation rayIntersactionSolver)
        {
            for (int triangle = 0; triangle < box.triangles.Count; triangle++)
            {
                TriagleIntersectionModel intersection = rayIntersactionSolver.RayIntersectsTriangle(ray, box.triangles[triangle]);
                if (intersection != null)
                {
                    double intensative =
                        FindColorIntensativeForTrinagle(intersection.Triangle);
                    return Color.Red * intensative;
                }
            }
            return Color.Black;
        }

        private double FindColorIntensativeForTrinagle(Triangle triangle)
        {
            Vector3 triangleCenterPoint = GetSurfaceCenter(triangle);
            Vector3 lightDirection = Light.Origin - triangleCenterPoint;
            Vector3 faceNormal = GetSurfaceNormal(triangle);
            
            double lightSourceDirectionLength = lightDirection.Length;
            double triangleNormalLength = faceNormal.Length;

            Vector3 c = lightDirection - faceNormal;

            double cos =
                (lightSourceDirectionLength * lightSourceDirectionLength + triangleNormalLength * triangleNormalLength -
                 c.Length * c.Length) / (2 * lightSourceDirectionLength * triangleNormalLength);
            
            var globalLight = 0.05;
            return Math.Max(globalLight, Math.Abs(cos));
        }

        private static Vector3 GetSurfaceNormal(Triangle t)
        {
            double xNormal = (t.b.y - t.a.y) * (t.c.z - t.a.z) - (t.c.y - t.a.y) * (t.b.z - t.a.z);
            double yNormal = (t.b.z - t.a.z) * (t.c.x - t.a.x) - (t.b.x - t.a.x) * (t.c.z - t.a.z);
            double zNormal = (t.b.x - t.a.x) * (t.c.y - t.a.y) - (t.c.x - t.a.x) * (t.b.y - t.a.y);
            return new Vector3(xNormal, yNormal, zNormal);
        }

        private static Vector3 GetSurfaceCenter(Triangle tr)
        {
            return new Vector3((tr.a.x + tr.b.x + tr.c.x) / 3, (tr.a.y + tr.b.y + tr.c.y) / 3,
                (tr.a.z + tr.b.z + tr.c.z) / 3);
        }
    }
}
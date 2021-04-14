using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageConverter.Rendering
{
    public class Box
    {
        public double minX;
        public double maxX;
        public double minY;
        public double maxY;
        public double minZ;
        public double maxZ;

        public int size;
        public List<Triangle> triangles;
        public Box leftSubBox;
        public Box rightSubBox;
        
        public Box(List<Triangle> triangles)
        {
            this.triangles = triangles;
            
            minX = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.x, triangle.b.x), triangle.c.x)).Min();
            maxX = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.x, triangle.b.x), triangle.c.x)).Max();
            
            minY = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.y, triangle.b.y), triangle.c.y)).Min();
            maxY = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.y, triangle.b.y), triangle.c.y)).Max();
            
            minZ = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.z, triangle.b.z), triangle.c.z)).Min();
            maxZ = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.z, triangle.b.z), triangle.c.z)).Max();
        }

        public Box(double minX, double maxX, double minY, double maxY, double minZ, double maxZ)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.minZ = minZ;
            this.maxZ = maxZ;
        }

        public void DivideBox(string axis)
        {
            switch (axis)
            {
                case "x":
                    leftSubBox = new Box(minX, maxX / 2, minY, maxY, minZ, maxZ);
                    rightSubBox = new Box(maxX / 2, maxX, minY, maxY, minZ, maxZ);
                    break;
                case "y":
                    leftSubBox = new Box(minX, maxX, minY, maxY / 2, minZ, maxZ);
                    rightSubBox = new Box(minX, maxX, maxY / 2, maxY, minZ, maxZ);
                    break;
                case "z":
                    leftSubBox = new Box(minX, maxX, minY, maxY, minZ, maxZ / 2);
                    rightSubBox = new Box(maxX / 2, maxX, minY, maxY, maxZ / 2, maxZ);
                    break;
            }
        }
    }
    
}
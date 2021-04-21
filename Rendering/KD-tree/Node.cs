using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageConverter.Rendering
{
    public class Node
    {
        public BoundingBox boundingBox;
        public List<Triangle> triangles;
        public Node leftSubNode;
        public Node rightSubNode;
        
        public Node(List<Triangle> triangles)
        {
            this.triangles = triangles;
            boundingBox = new BoundingBox
            {
                minX = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.x, triangle.b.x), triangle.c.x)).Min(),
                maxX = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.x, triangle.b.x), triangle.c.x)).Max(),
                minY = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.y, triangle.b.y), triangle.c.y)).Min(),
                maxY = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.y, triangle.b.y), triangle.c.y)).Max(),
                minZ = triangles.Select(triangle => Math.Min(Math.Min(triangle.a.z, triangle.b.z), triangle.c.z)).Min(),
                maxZ = triangles.Select(triangle => Math.Max(Math.Max(triangle.a.z, triangle.b.z), triangle.c.z)).Max()
            };
            
        }

        public Node(List<Triangle> triangles, BoundingBox boundingBox)
        {
            this.boundingBox = new BoundingBox(boundingBox);
            
            var minX = boundingBox.minX;
            var maxX = boundingBox.maxX;
            var minY = boundingBox.minY;
            var maxY = boundingBox.maxY;
            var minZ = boundingBox.minZ;
            var maxZ = boundingBox.maxZ;

            this.triangles = triangles.FindAll(_ => (_.a.x >= minX && _.a.x <= maxX
                                                 && _.a.y >= minY && _.a.y <= maxY
                                                 && _.a.z >= minZ && _.a.z <= maxZ)
                || (_.b.x >= minX && _.b.x <= maxX
                                  && _.b.y >= minY && _.b.y <= maxY
                                  && _.b.z >= minZ && _.b.z <= maxZ)
                || (_.c.x >= minX && _.c.x <= maxX
                                  && _.c.y >= minY && _.c.y <= maxY 
                                  && _.c.z >= minZ && _.c.z <= maxZ))
                .ToList();
        }

        public void DivideBox(string axis)
        {
            double axisMin;
            double axisMax;
            double axisAvg;

            switch (axis)
            {
                case "x":
                    axisMin = boundingBox.minX;
                    axisMax = boundingBox.maxX;
                    axisAvg = (boundingBox.minX + boundingBox.maxX) / 2;
                    boundingBox.maxX = axisAvg;
                    leftSubNode = new Node(triangles, boundingBox);
                    boundingBox.maxX = axisMax;
                    boundingBox.minX = axisAvg;
                    rightSubNode = new Node(triangles, boundingBox);
                    boundingBox.minX = axisMin;
                    break;
                case "y":
                    axisMin = boundingBox.minY;
                    axisMax = boundingBox.maxY;
                    axisAvg = (boundingBox.minY + boundingBox.maxY) / 2;
                    boundingBox.maxY = axisAvg;
                    leftSubNode = new Node(triangles, boundingBox);
                    boundingBox.maxY = axisMax;
                    boundingBox.minY = axisAvg;
                    rightSubNode = new Node(triangles, boundingBox);
                    boundingBox.minY = axisMin;
                    break;
                case "z":
                    axisMin = boundingBox.minZ;
                    axisMax = boundingBox.maxZ;
                    axisAvg = (boundingBox.minZ + boundingBox.maxZ) / 2;
                    boundingBox.maxZ = axisAvg;
                    leftSubNode = new Node(triangles, boundingBox);
                    boundingBox.maxZ = axisMax;
                    boundingBox.minZ = axisAvg;
                    rightSubNode = new Node(triangles, boundingBox);
                    boundingBox.minZ = axisMin;
                    break;
            }
        }
    }
    
}
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

        public Box(List<Triangle> triangles, double minX, double maxX, double minY, double maxY, double minZ, double maxZ)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.minZ = minZ;
            this.maxZ = maxZ;

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
            double median;
            List<double> avgValuesArray;
            
            switch (axis)
            {
                case "x":
                    avgValuesArray = triangles.Select(triangle => (triangle.a.x + triangle.b.x + triangle.c.x) / 3).ToList();
                    avgValuesArray.Sort();
                    if (avgValuesArray.Count % 2 == 0)
                    {
                        median = (avgValuesArray[avgValuesArray.Count / 2 - 1] + avgValuesArray[avgValuesArray.Count / 2]) / 2;
                    }
                    else
                    {
                        median = avgValuesArray[(avgValuesArray.Count - 1) / 2];
                    }
                    leftSubBox = new Box(triangles, minX, median, minY, maxY, minZ, maxZ);
                    rightSubBox = new Box(triangles, median, maxX, minY, maxY, minZ, maxZ);
                    break;
                case "y":
                    avgValuesArray = triangles.Select(triangle => (triangle.a.y + triangle.b.y + triangle.c.y) / 3).ToList();
                    avgValuesArray.Sort();
                    if (avgValuesArray.Count % 2 == 0)
                    {
                        median = (avgValuesArray[avgValuesArray.Count / 2 - 1] + avgValuesArray[avgValuesArray.Count / 2]) / 2;
                    }
                    else
                    {
                        median = avgValuesArray[(avgValuesArray.Count - 1) / 2];
                    }
                    leftSubBox = new Box(triangles, minX, maxX, minY, median, minZ, maxZ);
                    rightSubBox = new Box(triangles, minX, maxX, median, maxY, minZ, maxZ);
                    break;
                case "z":
                    avgValuesArray = triangles.Select(triangle => (triangle.a.z + triangle.b.z + triangle.c.z) / 3).ToList();
                    avgValuesArray.Sort();
                    if (avgValuesArray.Count % 2 == 0)
                    {
                        median = (avgValuesArray[avgValuesArray.Count / 2 - 1] + avgValuesArray[avgValuesArray.Count / 2]) / 2;
                    }
                    else
                    {
                        median = avgValuesArray[(avgValuesArray.Count - 1) / 2];
                    }
                    leftSubBox = new Box(triangles, minX, maxX, minY, maxY, minZ, median);
                    rightSubBox = new Box(triangles, maxX / 2, maxX, minY, maxY, median, maxZ);
                    break;
            }
        }
    }
    
}
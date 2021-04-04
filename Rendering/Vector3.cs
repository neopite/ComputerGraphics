using System;

namespace ImageConverter.Rendering
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;
        
        public double Length => (double) Math.Sqrt(x * x + y * y + z * z);

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 Normalize()
        {
            var length = Length;
            return new Vector3(x/length, y/length, z/length);
        }
        
        
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
        }
    }
}
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
        public Vector3 CrossProduct(Vector3 edge2)
        {
            var u = this;
            var v = edge2;
            return new Vector3(
                u.y * v.z - u.z * v.y,
                u.z * v.x - u.x * v.z,
                u.x * v.y - u.y * v.x);
        }

        public double DotProduct(Vector3 other)
        {
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }
    }
}
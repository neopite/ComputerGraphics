using System;

namespace ImageConverter.Rendering
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        
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
        
        public static Vector3 operator *(Vector3 vector1 , double value) {
            return new Vector3(value * vector1.x , value * vector1.y , value * vector1.z);
        }
        
        public static double operator *(Vector3 vector1 , Vector3 value) {
            return value.x * vector1.x + value.y * vector1.y + value.z * vector1.z;
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
using System;

namespace ImageConverter.Rendering.Rays
{
    public class IRay
    {
        public Vector3 Origin { get; private set; }
        public Vector3 Direction { get; private set; }

        public IRay(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            if (direction.Length == 0)
            {
                throw new Exception("Ray magnitude == 0");
            }
            Direction = direction.Normalize();
        }
    }
}
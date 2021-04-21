using System.Collections.Generic;
using Ninject;

namespace ImageConverter.Rendering
{
    public abstract class Camera
    {
        public Transform transform;
        public readonly Vector3 screenCenter;
        public int width;
        public int height;

        protected Camera(Transform transform, Vector3 screenCenter, int width, int height)
        {
            this.transform = transform;
            this.screenCenter = screenCenter;
            this.width = width;
            this.height = height;
        }

        public abstract List<Vector3> GetScreenPoints(double actualScreenSize);


    }
}
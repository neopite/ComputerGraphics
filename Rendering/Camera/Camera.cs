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

        [Inject]
        protected Camera()
        {
            this.transform = new Transform(new Vector3(0, 1, 0), new Vector3(270, 180, 0), Vector3.One);
            this.screenCenter = new Vector3(0,0,0);
            this.width = 400;
            this.height = 400;
        }

        public abstract List<Vector3> GetScreenPoints(double actualScreenSize);


    }
}
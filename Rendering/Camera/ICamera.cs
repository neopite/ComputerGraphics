using Ninject;

namespace ImageConverter.Rendering
{
    public abstract class ICamera : GameObject
    {
        public Vector3 Origin { get;private set; }


        protected ICamera(Transform transform,Vector3 origin) : base(transform)
        {
            Origin = origin;
        }
    }
}
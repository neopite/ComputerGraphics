using Ninject;

namespace ImageConverter.Rendering
{
    public abstract class ICamera
    {
        public Vector3 Origin { get;private set; }
        
        [Inject]
        protected ICamera(Vector3 origin)
        {
            Origin = origin;
        }
    }
}
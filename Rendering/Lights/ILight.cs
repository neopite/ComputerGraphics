using Ninject;

namespace ImageConverter.Rendering.Lights
{
    public abstract class ILight
    {
        public Vector3 Origin { get; private set; }

        [Inject]
        public ILight()
        {
            Origin = new Vector3(0, 1, 0);
        }
    }
}
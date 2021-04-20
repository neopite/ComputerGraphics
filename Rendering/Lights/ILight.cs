namespace ImageConverter.Rendering.Lights
{
    public abstract class ILight
    {
        public Vector3 Origin { get; private set; }

        public ILight(Vector3 origin)
        {
            Origin = origin;
        }
    }
}
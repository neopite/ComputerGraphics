namespace ImageConverter.Rendering
{
    public abstract class ICamera
    {
        public Vector3 Origin { get;private set; }
        public Vector3 LookDirection { get;private set; }
        public double Fov { get;private set; }

        protected ICamera(Vector3 origin, Vector3 lookDirection, double fov)
        {
            Origin = origin;
            LookDirection = lookDirection;
            Fov = fov;
        }
    }
}
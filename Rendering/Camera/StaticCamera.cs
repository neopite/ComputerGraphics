namespace ImageConverter.Rendering
{
    public class StaticCamera : ICamera
    {
        public Vector3 Origin { get;private set; }
        public Vector3 LookDirection { get;private set; }
        public double Fov { get;private set; }

        public StaticCamera(Vector3 origin, Vector3 lookDirection, double fov) : base(origin, lookDirection, fov)
        {
        }
    }
}
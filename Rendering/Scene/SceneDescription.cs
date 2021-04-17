namespace ImageConverter.Rendering.Scene
{
    public abstract class SceneDescription
    {
        public static readonly int Height,Width = 1000;
        public static readonly Vector3 cameraPosition = new Vector3(0, 0, 0);
        public static readonly Vector3 screenDistance = new Vector3(0, 0, 1);
        public static readonly float cameraFov = 90;

        public static readonly GameObject GameObject =
            new GameObject(new Transform(new Vector3(0, 0, 5), Vector3.Zero, Vector3.One));
    }
}
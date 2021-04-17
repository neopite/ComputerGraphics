namespace ImageConverter.Rendering
{
    public class GameObject
    {
        public Transform Transform { get; set; }
        public Mesh MeshRenderer { get; set; }

        public GameObject(Transform transform)
        {
            Transform = transform;
        }
    }
}
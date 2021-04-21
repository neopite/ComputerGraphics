namespace ImageConverter.Rendering
{
    public class GameObject
    {
        public Transform transform;
        public Mesh meshRenderer;

        public GameObject(Transform transform)
        {
            this.transform = transform;
        }

        public GameObject()
        {
        }
    }
}
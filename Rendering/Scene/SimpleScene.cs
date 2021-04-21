namespace ImageConverter.Rendering.Scene
{
    public class SimpleScene : Scene
    {
        public override void AddGameObject(GameObject gameObject)
        {
            SceneGameObjects.Add(gameObject);
        }

        public SimpleScene(Camera mainCamera) : base(mainCamera)
        {
        }
    }
}
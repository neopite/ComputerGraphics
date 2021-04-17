using System.Collections.Generic;

namespace ImageConverter.Rendering.Scene
{
    public abstract class Scene
    {
        public List<GameObject> SceneGameObjects { get; set; } 
        public ICamera MainCamera { get; set; }
        public abstract void AddGameObject(GameObject gameObject);

        protected Scene(ICamera mainCamera)
        {
            MainCamera = mainCamera;
        }
    }
}
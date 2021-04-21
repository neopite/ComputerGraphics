using System.Collections.Generic;

namespace ImageConverter.Rendering.Scene
{
    public abstract class Scene
    {
        public List<GameObject> SceneGameObjects { get; set; } 
        public Camera MainCamera { get; set; }
        public abstract void AddGameObject(GameObject gameObject);

        protected Scene(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
    }
}
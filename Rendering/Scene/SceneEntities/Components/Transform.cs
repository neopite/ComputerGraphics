
using ImageConverter.Rendering.Calculation;

namespace ImageConverter.Rendering
{
    public class Transform
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public Transform parent;
        
        public Transform(Vector3 position,Vector3 rotation,Vector3 scale)
        {
            this.scale = scale;
            this.rotation = rotation;
            this.position = position;
        }
        
    }
}
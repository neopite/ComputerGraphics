
using ImageConverter.Rendering.Calculation;

namespace ImageConverter.Rendering
{
    public class Transform
    {
        public Vector3 Position { get; set; }    // Matrix4X4.applyTranslation(value);


        public Vector3 Rotation { get;set; }
        public Vector3 Scale { get; set; }
        public Transform Parent { get; set; }
        // public Matrix4x4 Matrix4X4 { get; set; }
        
        public Transform(Vector3 position,Vector3 rotation,Vector3 scale)
        {
            Scale = scale;
            Rotation = rotation;
            Position = position;
            // Matrix4X4 = new Matrix4x4();
            // Matrix4X4.generateTransformation(position,rotation,scale);
        }
        
    }
}
using System.Collections.Generic;

namespace ImageConverter.Rendering
{
    public class Mesh
    {
        public List<Vector3> Faces { get; private set; }

        public Mesh(List<Vector3> faces)
        {
            Faces = faces;
        }
    }
}
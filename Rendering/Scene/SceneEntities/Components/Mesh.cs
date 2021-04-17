using System.Collections.Generic;

namespace ImageConverter.Rendering
{
    public class Mesh
    {
        public List<Triangle> Faces { get; set; }

        public Mesh(List<Triangle> faces)
        {
            Faces = faces;
        }
    }
}
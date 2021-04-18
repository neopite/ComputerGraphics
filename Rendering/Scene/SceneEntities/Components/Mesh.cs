using System.Collections.Generic;

namespace ImageConverter.Rendering
{
    public class Mesh
    {
        public List<Triangle> Faces { get;private set; }
        public List<Vector3> Normals { get;private set; }

        public Mesh(List<Triangle> faces ,List<Vector3> normals)
        {
            Faces = faces;
            Normals = normals;
        }
    }
}
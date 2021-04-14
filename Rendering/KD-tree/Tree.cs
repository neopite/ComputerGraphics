using System.Collections.Generic;

namespace ImageConverter.Rendering
{
    public class Tree
    {
        public Box root;

        public Tree(List<Triangle> triangles)
        {
            root = new Box(triangles);
        }
    }
}
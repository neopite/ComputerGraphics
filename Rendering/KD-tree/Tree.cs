using System.Collections.Generic;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;

namespace ImageConverter.Rendering
{
    public class Tree
    {
        public Box root;
        public const int MaxDepth = 1;
        public static string[] axes = {"x", "y", "z"};
        public static int s = 0;

        public Tree(Mesh mesh)
        { 
            root = new Box(mesh.Faces);
            ConstructTree(root);
        }

        public void ConstructTree(Box root, int depth = 0)
        {
            Tree.s += root.triangles.Count;
            if (depth < MaxDepth)
            {
                root.DivideBox(axes[depth % 3]);
                ConstructTree(root.leftSubBox, depth + 1);
                ConstructTree(root.rightSubBox, depth + 1);
            }
            else
            {
                return;
            }
        }

        public Box AppropriateBoxForRay(IRay ray, Box root)
        {
            if (root.leftSubBox == null && root.rightSubBox == null)
            {
                return root;
            }
            else
            {
                if (RayBoxIntersection.RayIntersectsBox(ray, root))
                {
                    if (RayBoxIntersection.RayIntersectsBox(ray, root.leftSubBox))
                    {
                        return AppropriateBoxForRay(ray, root.leftSubBox);
                    }
                    if (RayBoxIntersection.RayIntersectsBox(ray, root.rightSubBox))
                    {
                        return AppropriateBoxForRay(ray, root.rightSubBox);
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
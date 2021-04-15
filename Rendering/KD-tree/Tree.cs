using System.Collections.Generic;

namespace ImageConverter.Rendering
{
    public class Tree
    {
        public Box root;
        public const int MaxTrianglesAmountInLeaf = 100;
        public static string[] axes = {"x", "y", "z"};
        public static int s = 0;

        public Tree(List<Triangle> triangles)
        { 
            root = new Box(triangles);
            ConstructTree(root);
        }

        public void ConstructTree(Box root, int depth = 0)
        {
            Tree.s += root.triangles.Count;
            if (root.triangles.Count > MaxTrianglesAmountInLeaf)
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

        public Box AppropriateBoxForRay(Vector3 ray, Box root)
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
                    else
                    {
                        return AppropriateBoxForRay(ray, root.rightSubBox);
                    }
                }
                else
                {
                    return null;
                }
            }
            
        }
    }
}
using System.Collections.Generic;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;

namespace ImageConverter.Rendering
{
    public class Tree
    {
        public Node root;
        public const int MaxDepth = 1;
        public static string[] axes = {"x", "y", "z"};
        public static int s = 0;

        public Tree(Mesh mesh)
        { 
            root = new Node(mesh.Faces);
            ConstructTree(root);
        }

        public void ConstructTree(Node root, int depth = 0)
        {
            if (depth < MaxDepth)
            {
                root.DivideBox(axes[depth % 3]);
                ConstructTree(root.leftSubNode, depth + 1);
                ConstructTree(root.rightSubNode, depth + 1);
            }
        }

        public Node AppropriateBoxForRay(IRay ray, Node root)
        {
            if (root.leftSubNode == null && root.rightSubNode == null)
            {
                return root;
            }
            else
            {
                if (RayBoxIntersection.RayIntersectsBox(ray, root))
                {
                    if (RayBoxIntersection.RayIntersectsBox(ray, root.leftSubNode))
                    {
                        return AppropriateBoxForRay(ray, root.leftSubNode);
                    }
                    if (RayBoxIntersection.RayIntersectsBox(ray, root.rightSubNode))
                    {
                        return AppropriateBoxForRay(ray, root.rightSubNode);
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
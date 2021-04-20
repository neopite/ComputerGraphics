using System;
using System.Numerics;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Rays.Implementation;

namespace ImageConverter.Rendering
{
    public class RayBoxIntersection
    {
        public static Boolean RayIntersectsBox(IRay ray, Box box)
        {
            double x = 1 / ray.Direction.x;
            double y = 1 / ray.Direction.y;
            double z = 1 / ray.Direction.z;
            
            Vector3 inv_dir = new Vector3(x, y, z);
            Vector3 ray_pos = ray.Origin;
            
            double lo = inv_dir.x * (box.minX - ray_pos.x);
            double hi = inv_dir.x * (box.maxX - ray_pos.x);

            double tmin = Math.Min(lo, hi);
            double tmax = Math.Max(lo, hi);
            
            double lo1 = inv_dir.y*(box.minY - ray_pos.y);

            double hi1 = inv_dir.y*(box.maxY - ray_pos.y);

            tmin  = Math.Max(tmin, Math.Min(lo1, hi1));
            tmax = Math.Min(tmax, Math.Max(lo1, hi1));
            
            double lo2 = inv_dir.z*(box.minZ - ray_pos.z);

            double hi2 = inv_dir.z*(box.maxZ - ray_pos.z);

            tmin  = Math.Max(tmin, Math.Min(lo2, hi2));

            tmax = Math.Min(tmax, Math.Max(lo2, hi2));
            
            return (tmin <= tmax) && (tmax > 0);
        }
    }
}
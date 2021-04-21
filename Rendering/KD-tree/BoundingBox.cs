namespace ImageConverter.Rendering
{
    public class BoundingBox
    {
        public double minX;
        public double maxX;
        public double minY;
        public double maxY;
        public double minZ;
        public double maxZ;

        public BoundingBox(BoundingBox other)
        {
            minX = other.minX;
            maxX = other.maxX;
            minY = other.minY;
            maxY = other.maxY;
            minZ = other.minZ;
            maxZ = other.maxZ;
        }
        
        public BoundingBox() {}
        
    }
}
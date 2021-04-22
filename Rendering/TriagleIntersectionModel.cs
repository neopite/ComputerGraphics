namespace ImageConverter.Rendering
{
    public class TriagleIntersectionModel
    {
        public Triangle Triangle { get; private set; }
        public Vector3 IntersactionPoint { get; private set; }
        public double Distance { get; private set; }

        public TriagleIntersectionModel(Triangle triangle, Vector3 intersactionPoint, double distance)
        {
            Triangle = triangle;
            IntersactionPoint = intersactionPoint;
            Distance = distance;
        }

        public TriagleIntersectionModel(double distance)
        {
            Distance = distance;
        }
    }
}
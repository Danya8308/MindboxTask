namespace MindboxTask.Shapes
{
    public sealed class Circle : Shape
    {
        public readonly double Radius;

        public Circle(double radius)
            : base(radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}

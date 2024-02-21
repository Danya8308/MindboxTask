using System.Collections.ObjectModel;

namespace MindboxTask.Shapes
{
    public abstract class Shape
    {
        public readonly ReadOnlyCollection<double> Lengths;

        protected Shape(params double[] lengths)
        {
            if (IsAvaliable(lengths) == false)
            {
                throw new ArgumentException($"Argument \"{nameof(lengths)}\" is not avaliable.");
            }

            Lengths = new ReadOnlyCollection<double>(lengths);
        }

        public static IEnumerable<double> GetAreas(params Shape[] shapes)
        {
            foreach (var shape in shapes)
            {
                yield return shape.GetArea();
            }
        }

        private bool IsAvaliable(double[] lengths)
        {
            foreach (var length in lengths)
            {
                if (length <= 0d)
                {
                    throw new ArgumentException($"Argument \"{nameof(length)}\" cannot be less than or equal to zero.");
                }
            }

            return CheckAvailable(lengths);
        }

        public abstract double GetArea();

        protected virtual bool CheckAvailable(double[] lengths) => true;
    }
}
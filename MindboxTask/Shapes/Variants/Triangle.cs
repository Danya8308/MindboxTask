namespace MindboxTask.Shapes
{
    public sealed class Triangle : Shape
    {
        public readonly double AB;
        public readonly double BC;
        public readonly double CA;

        public Triangle(double ab, double bc, double ca)
            : base(ab, bc, ca)
        {
            AB = ab;
            BC = bc;
            CA = ca;
        }

        protected override bool CheckAvailable(double[] lengths)
        {
            if (lengths.Length < 2)
            {
                throw new ArgumentException("The triangle must include three sides.");
            }

            for (int i = 0; i < lengths.Length; i++)
            {
                double checkLength = lengths[i];
                double sumOther = 0d;

                for (int j = 0; j < lengths.Length; j++)
                {
                    if (i != j)
                    {
                        sumOther += lengths[j];
                    }
                }

                if (checkLength >= sumOther)
                {
                    throw new ArgumentException("A triangle with such side lengths cannot exist.");
                }
            }

            return true;
        }

        public override double GetArea()
        {
            double p = Lengths.Sum() / 2d;
            double result = p;

            foreach (var side in Lengths)
            {
                result *= p - side;
            }

            return Math.Sqrt(result);
        }

        public bool IsRectangular()
        {
            if (IsCorrect() == true)
            {
                return false;
            }

            if (IsIsosceles() == true)
            {
                return false;
            }

            double hypotenuse = Lengths.Max();
            var cathets = Lengths.Where(x => x != hypotenuse);

            return cathets.Sum(x => Math.Pow(x, 2d)) == Math.Pow(hypotenuse, 2d);
        }

        public bool IsCorrect()
        {
            return Lengths.All(x => AB == x);
        }

        public bool IsIsosceles()
        {
            for (int i = 0; i < Lengths.Count; i++)
            {
                double checkLength = Lengths[i];

                for (int j = 0; j < Lengths.Count; j++)
                {
                    if (i != j && checkLength == Lengths[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

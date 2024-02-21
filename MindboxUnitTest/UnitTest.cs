using MindboxTask.Shapes;

namespace MindboxUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Rectangular()
        {
            var answerQuestionPairs = new Dictionary<bool, Triangle>()
            {
                [true] = new Triangle(4d, 3d, 5d),
                [false] = new Triangle(2d, 2d, 3d)
            };

            foreach (var pair in answerQuestionPairs)
            {
                bool correct = pair.Key;
                bool check = pair.Value.IsRectangular();

                Assert.AreEqual(correct, check);
            }
        }

        [TestMethod]
        public void CalculatingAreas()
        {
            var answerQuestionPairs = new Dictionary<double, Shape>()
            {
                [2.9047375096555625d] = new Triangle(2d, 3d, 4d),
                [1.984313483298443d] = new Triangle(2d, 2d, 3d),
                [12.566371d] = new Circle(2d),
                [50.265482d] = new Circle(4d),
            };

            foreach (var pair in answerQuestionPairs)
            {
                double correct = Round(pair.Key);
                double check = Round(pair.Value.GetArea());

                Assert.AreEqual(correct, check);
            }
        }

        public double Round(double value)
        {
            return Math.Round(value, 5);
        }
    }
}
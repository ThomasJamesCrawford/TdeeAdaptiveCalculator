using NUnit.Framework;
using TDEE;

namespace Tests
{
    public class WeekTests
    {
        Week w;

        [SetUp]
        public void Setup()
        {
            w = new Week(90);

            w.AddCal(4000);
            w.AddWeight(90.1);

            w.AddCal(4000);
            w.AddWeight(90.2);

            w.AddCal(4000);
            w.AddWeight(90.3);

            w.AddCal(4000);
            w.AddWeight(90.3);

            w.AddCal(4000);
            w.AddWeight(90.3);

            w.AddCal(4000);
            w.AddWeight(90.4);

            w.AddCal(4000);
            w.AddWeight(90.5);
        }

        [Test]
        public void AvgCalCorrect()
        {
            Assert.AreEqual(w.AvgCal(), 4000);
        }

        [Test]
        public void AvgWeightCorrect()
        {
            Assert.AreEqual(w.AvgWeight(), 90.3);
        }

        [Test]
        public void TDEECorrect()
        {
            Assert.AreEqual(w.Tdee, 3670);
        }
    }
}
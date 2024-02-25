using NUnit.Framework;
using Statistics; // Importera namespace för Statistics-klassen

namespace TestProject1
{
    public class Tests
    {
        private int[] testData;

        [SetUp]
        public void Setup()
        {
            // Exempeldata för testerna
            testData = new int[] { 1, 3, 5, 7, 9 };
        }

        [Test]
        public static void Maximum_ReturnsMaximumValue()
        {
            int expected = 9;

            int actual = Statistics.Statistics.Maximum();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void Minimum_ReturnsMinimumValue()
        {
            int expected = 1;

            int actual = Statistics.Statistics.Minimum();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void Mean_ReturnsMeanValue()
        {
            double expected = 5.0; // Förväntat medelvärde av testdatan

            double actual = Statistics.Statistics.Mean();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void Median_ReturnsMedianValue()
        {
            int[] testDataSorted = new int[] { 1, 3, 5, 7, 9 };
            double expected = 5; // Medianvärdet av testdatan

            double actual = Statistics.Statistics.Median();

            Assert.AreEqual(expected, actual);
        }
    }
}

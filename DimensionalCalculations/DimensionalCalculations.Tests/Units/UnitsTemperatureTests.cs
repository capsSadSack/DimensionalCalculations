using NUnit.Framework;

using DimensionalCalculations.Units.UnitsTemperature;

namespace DimensionalCalculations.Tests.Units
{
    internal class UnitsTemperatureTests
    {
        [TestCase(0, 273.15)]
        [TestCase(-273.15, 0)]
        public void Celsius_ToSI_CorrectValue(double celsiusValue, double expectedKelvinValue)
        {
            AbstractUnit celsius = new Celsius();
            double value_SI = celsius.ToSI(celsiusValue);

            Assert.AreEqual(expectedKelvinValue, value_SI, 1e-3);
        }

        [TestCase(100, 310.928)]
        [TestCase(32, 273.15)]
        [TestCase(0, 255.372)]
        public void Fahrenheit_ToSI_CorrectValue(double fahrenheitValue, double expectedKelvinValue)
        {
            AbstractUnit fahrenheit = new Fahrenheit();
            double value_SI = fahrenheit.ToSI(fahrenheitValue);

            Assert.AreEqual(expectedKelvinValue, value_SI, 1e-3);
        }
    }
}

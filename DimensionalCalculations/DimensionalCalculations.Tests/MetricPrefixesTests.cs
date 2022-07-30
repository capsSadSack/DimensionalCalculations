using NUnit.Framework;

using DimensionalCalculations.Units.MetricPrefixes;
using DimensionalCalculations.Units.UnitsLength;

namespace DimensionalCalculations.Tests
{
    internal class MetricPrefixesTests
    {
        #region Submultiple

        [Test]
        public void Deci_CorrectValue()
        {
            AbstractUnit dm = new Deci(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, dm);

            Assert.AreEqual(0.5, pq.Value, 1e-6);
        }

        [Test]
        public void Centi_CorrectValue()
        {
            AbstractUnit cm = new Centi(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, cm);

            Assert.AreEqual(5e-2, pq.Value, 1e-6);
        }

        [Test]
        public void Milli_CorrectValue()
        {
            AbstractUnit mm = new Milli(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, mm);

            Assert.AreEqual(5e-3, pq.Value, 1e-9);
        }

        [Test]
        public void Micro_CorrectValue()
        {
            AbstractUnit um = new Micro(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, um);

            Assert.AreEqual(5e-6, pq.Value, 1e-12);
        }

        [Test]
        public void Nano_CorrectValue()
        {
            AbstractUnit nm = new Nano(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, nm);

            Assert.AreEqual(5e-9, pq.Value, 1e-12);
        }

        [Test]
        public void Pico_CorrectValue()
        {
            AbstractUnit pm = new Pico(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, pm);

            Assert.AreEqual(5e-12, pq.Value, 1e-15);
        }

        [Test]
        public void Femto_CorrectValue()
        {
            AbstractUnit pm = new Femto(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, pm);

            Assert.AreEqual(5e-15, pq.Value, 1e-18);
        }

        [Test]
        public void Atto_CorrectValue()
        {
            AbstractUnit am = new Atto(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, am);

            Assert.AreEqual(5e-18, pq.Value, 1e-21);
        }

        [Test]
        public void Zepto_CorrectValue()
        {
            AbstractUnit zm = new Zepto(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, zm);

            Assert.AreEqual(5e-21, pq.Value, 1e-24);
        }

        [Test]
        public void Yocto_CorrectValue()
        {
            AbstractUnit ym = new Yocto(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, ym);

            Assert.AreEqual(5e-24, pq.Value, 1e-27);
        }

        #endregion

        #region Multiple

        [Test]
        public void Deca_CorrectValue()
        {
            AbstractUnit dam = new Deca(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, dam);

            Assert.AreEqual(5e1, pq.Value, 1e-3);
        }

        [Test]
        public void Hecto_CorrectValue()
        {
            AbstractUnit hm = new Hecto(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, hm);

            Assert.AreEqual(5e2, pq.Value, 1e-3);
        }

        [Test]
        public void Kilo_CorrectValue()
        {
            AbstractUnit km = new Kilo(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, km);

            Assert.AreEqual(5e3, pq.Value, 1e-3);
        }

        [Test]
        public void Mega_CorrectValue()
        {
            AbstractUnit Mm = new Mega(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Mm);

            Assert.AreEqual(5e6, pq.Value, 1e-3);
        }

        [Test]
        public void Giga_CorrectValue()
        {
            AbstractUnit Gm = new Giga(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Gm);

            Assert.AreEqual(5e9, pq.Value, 1e-3);
        }

        [Test]
        public void Tera_CorrectValue()
        {
            AbstractUnit Tm = new Tera(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Tm);

            Assert.AreEqual(5e12, pq.Value, 1e-3);
        }

        [Test]
        public void Peta_CorrectValue()
        {
            AbstractUnit Pm = new Peta(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Pm);

            Assert.AreEqual(5e15, pq.Value, 1);
        }

        [Test]
        public void Exa_CorrectValue()
        {
            AbstractUnit Em = new Exa(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Em);

            Assert.AreEqual(5e18, pq.Value, 1e3);
        }

        [Test]
        public void Zetta_CorrectValue()
        {
            AbstractUnit Zm = new Zetta(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Zm);

            Assert.AreEqual(5e21, pq.Value, 1e6);
        }

        [Test]
        public void Yotta_CorrectValue()
        {
            AbstractUnit Ym = new Yotta(new Meter());
            PhysicalQuantity pq = new PhysicalQuantity(5, Ym);

            Assert.AreEqual(5e24, pq.Value, 1e10);
        }

        #endregion
    }
}

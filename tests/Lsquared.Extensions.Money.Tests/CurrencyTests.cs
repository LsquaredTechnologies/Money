using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsquared.Extensions.Tests
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void Create_WithEuroIsoNumber()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency(978);

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void Create_WithEuroIsoCode()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency("EUR");

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void Create_WithEuroSymbol()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency("€");

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void Parse_EuroName_WithFrenchCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            var euro = Currency.Parse("EUR");

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void Parse_EuroSymbol_WithSpanishCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            var euro = Currency.Parse("€");

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void Parse_DollarSymbol_WithAmericanCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var dollar = Currency.Parse("$");

            Assert.AreEqual(Currency.USD, dollar);
        }

        [TestMethod]
        public void Parse_DollarSymbol_WithEnglishCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            var dollar = Currency.Parse("$");

            Assert.AreEqual(Currency.ARS, dollar); // ! \\ Currency is the first one found if no currency matches the current culture...
        }

        [TestMethod]
        public void Parse_SterlingPoundSymbol_WithEnglishCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            var pound = Currency.Parse("£");

            Assert.AreEqual(Currency.GBP, pound);
        }

        [TestMethod]
        public void ToString_WithEuroCurrency()
        {
            var euro = new Currency(978);

            Assert.AreEqual("Euro (978)", euro.ToString());
        }

        [TestMethod]
        public void ToString_WithNewTurkishLiraCurrency()
        {
            var lira = new Currency(949);

            Assert.AreEqual("Türk Lirası (949)", lira.ToString());
        }

        [TestMethod]
        public void FromCultureInfo_WithFrenchCulture()
        {
            var euro = Currency.FromCulture(new CultureInfo("fr-FR"));

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void FromCultureInfo_WithSpanishCulture()
        {
            var euro = Currency.FromCulture(new CultureInfo("es-ES"));

            Assert.AreEqual(Currency.EUR, euro);
        }

        [TestMethod]
        public void FromCultureInfo_WithEnglishCulture()
        {
            var pound = Currency.FromCulture(new CultureInfo("en-GB"));

            Assert.AreEqual(Currency.GBP, pound);
        }

        [TestMethod]
        public void FromCultureInfo_WithAmericanCulture()
        {
            var dollar = Currency.FromCulture(new CultureInfo("en-US"));

            Assert.AreEqual(Currency.USD, dollar);
        }

        [TestMethod]
        public void GetFormat_WithFrenchCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            var euro = Currency.EUR;
            var actual = 12.35.ToString("C", euro);

            Assert.AreEqual("12,35 €", actual);
        }

        [TestMethod]
        public void GetFormat_WithAmericanCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var dollar = Currency.FromCurrentCulture();
            var actual = 12.35.ToString("C", dollar);

            Assert.AreEqual("$12.35", actual);
        }
    }
}

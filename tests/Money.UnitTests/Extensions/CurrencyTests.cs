using System.Globalization;

#if !(NETSTANDARD1_6 && NETCOREAPP1_0)
using System.Threading;
#endif

using Xunit;

namespace Lsquared.Extensions
{
    public class CurrencyTests
    {
        [Fact]
        public void Create_WithEuroIsoNumber()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency(978);

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void Create_WithEuroIsoCode()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency("EUR");

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void Create_WithEuroSymbol()
        {
            // Don't need to set culture in current thread.

            var euro = new Currency("€");

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void Parse_EuroName_WithFrenchCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
#endif

            var euro = Currency.Parse("EUR");

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void Parse_EuroSymbol_WithSpanishCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
#endif

            var euro = Currency.Parse("€");

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void Parse_DollarSymbol_WithAmericanCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
#endif

            var dollar = Currency.Parse("$");

            Assert.Equal(Currency.USD, dollar);
        }

        [Fact]
        public void Parse_DollarSymbol_WithEnglishCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
#endif

            var dollar = Currency.Parse("$");

            Assert.Equal(Currency.ARS, dollar); // ! \\ Currency is the first one found if no currency matches the current culture...
        }

        [Fact]
        public void Parse_SterlingPoundSymbol_WithEnglishCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
#endif

            var pound = Currency.Parse("£");

            Assert.Equal(Currency.GBP, pound);
        }

        [Fact]
        public void ToString_WithEuroCurrency()
        {
            var euro = new Currency(978);

            Assert.Equal("Euro (978)", euro.ToString());
        }

        [Fact]
        public void ToString_WithNewTurkishLiraCurrency()
        {
            var lira = new Currency(949);

            Assert.Equal("Türk Lirası (949)", lira.ToString());
        }

        [Fact]
        public void FromCultureInfo_WithFrenchCulture()
        {
            var euro = Currency.FromCulture(new CultureInfo("fr-FR"));

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void FromCultureInfo_WithSpanishCulture()
        {
            var euro = Currency.FromCulture(new CultureInfo("es-ES"));

            Assert.Equal(Currency.EUR, euro);
        }

        [Fact]
        public void FromCultureInfo_WithEnglishCulture()
        {
            var pound = Currency.FromCulture(new CultureInfo("en-GB"));

            Assert.Equal(Currency.GBP, pound);
        }

        [Fact]
        public void FromCultureInfo_WithAmericanCulture()
        {
            var dollar = Currency.FromCulture(new CultureInfo("en-US"));

            Assert.Equal(Currency.USD, dollar);
        }

        [Fact]
        public void GetFormat_WithFrenchCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
#endif

            var euro = Currency.EUR;
            var actual = 12.35.ToString("C", euro);

            Assert.Equal("12,35 €", actual);
        }

        [Fact]
        public void GetFormat_WithAmericanCulture()
        {
#if NETSTANDARD1_6 || NETCOREAPP1_0
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
#else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
#endif

            var dollar = Currency.CurrentCurrency;
            var actual = 12.35.ToString("C", dollar);

            Assert.Equal("$12.35", actual);
        }
    }
}

using System;
using System.Globalization;

#if !(NETSTANDARD1_6 && NETCOREAPP1_0)
using System.Threading;
#endif

#if XUNIT
using Xunit;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;
#endif

namespace Lsquared.Extensions
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Create_WithEuroCurrency()
        {
            // Don't need to set culture in current thread.

            var value = new Money(12.35m, Currency.EUR);

            Assert.Equal(12.35m, value.Value);
        }

        [TestMethod]
        public void Add_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a + b;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 0;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 + a;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12;

            Assert.Equal(24.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12L;

            Assert.Equal(24.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12.35m;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);

            Assert.Throws<InvalidOperationException>(() => a + b);
        }

        [TestMethod]
        public void Subtract_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a - b;

            Assert.Equal(0, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 0;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 - a;

            Assert.Equal(-12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12;

            Assert.Equal(0.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12L;

            Assert.Equal(0.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12.35m;

            Assert.Equal(0, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);

            Assert.Throws<InvalidOperationException>(() => a - b);
        }

        [TestMethod]
        public void Multiply_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Multiply_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2L;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Multiply_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2m;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2L;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2m;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Parse_WithBadValue()
        {
            Assert.Throws<FormatException>(() => Money.Parse("ABC"));
        }

        [TestMethod]
        public void Parse_WithNull()
        {
            Assert.Throws<FormatException>(() => Money.Parse(null));
        }

        [TestMethod]
        public void Parse_WithEmptyString()
        {
            Assert.Throws<FormatException>(() => Money.Parse(string.Empty));
        }

        [TestMethod]
        public void Parse_WithBadValueAndCultureInfo()
        {
            Assert.Throws<FormatException>(() => Money.Parse("ABC", new CultureInfo("fr-FR")));
        }

        [TestMethod]
        public void Parse_WithEuroAndFrenchCulture()
        {
            var money = Money.Parse("3,23 €", new CultureInfo("fr-FR"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.EUR, money.Currency);
        }

        [TestMethod]
        public void Parse_WithPoundAndBritishCulture()
        {
            var money = Money.Parse("£3.23", new CultureInfo("en-GB"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.GBP, money.Currency);
        }

        [TestMethod]
        public void Parse_WithDollarAndAmericanCulture()
        {
            var money = Money.Parse("$3.23", new CultureInfo("en-US"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.USD, money.Currency);
        }

        [TestMethod]
        public void CompareTo_WithObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            Assert.Throws<NotSupportedException>(() => a.CompareTo(new object()));
        }

        [TestMethod]
        public void CompareTo_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a.CompareTo((object)b);

            Assert.Equal(0, actual);
        }

        [TestMethod]
        public void CompareTo_WithMoney()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);

            var actual = a.CompareTo(b);

            Assert.Equal(0, actual);
        }

        [TestMethod]
        public void CompareTo_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.USD);

            Assert.Throws<InvalidOperationException>(() => a.CompareTo(b));
        }

        [TestMethod]
        public void Equals_WithObject()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);
            var actual = money.Equals(new object());

            Assert.Equal(false, actual);
        }

        [TestMethod]
        public void Equals_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals((object)money2);

            Assert.Equal(true, actual);
        }

        [TestMethod]
        public void Equals_WithMoney()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals(money2);

            Assert.Equal(true, actual);
        }

        [TestMethod]
        public void Equals_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.USD);

            var actual = money1.Equals(money2);

            Assert.Equal(false, actual);
        }

        [TestMethod]
        public void ToString_WithFormat()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToString("C", Currency.EUR);

            Assert.Equal("12,35 €", actual);
        }

        [TestMethod]
        public void ToBoolean()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToBoolean(new CultureInfo("fr-FR")));
        }

        [TestMethod]
        public void ToByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToByte(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [TestMethod]
        public void ToChar()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToChar(new CultureInfo("fr-FR")));
        }

        [TestMethod]
        public void ToDateTime()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToDateTime(new CultureInfo("fr-FR")));
        }

        [TestMethod]
        public void ToDecimal()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDecimal(new CultureInfo("fr-FR"));

            Assert.Equal(12.35m, actual);
        }

        [TestMethod]
        public void ToDouble()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDouble(new CultureInfo("fr-FR"));

            Assert.Equal(12.35, actual);
        }

        [TestMethod]
        public void ToInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt16(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [TestMethod]
        public void ToInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt32(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [TestMethod]
        public void ToInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt64(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [TestMethod]
        public void ToSByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSByte(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [TestMethod]
        public void ToSingle()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSingle(new CultureInfo("fr-FR"));

            Assert.Equal(12.35f, actual);
        }

        [TestMethod]
        public void ToType()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToType(typeof(object), new CultureInfo("fr-FR")));
        }

        [TestMethod]
        public void ToUInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt16(new CultureInfo("fr-FR"));

            Assert.Equal(12U, actual);
        }

        [TestMethod]
        public void ToUInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt32(new CultureInfo("fr-FR"));

            Assert.Equal(12U, actual);
        }

        [TestMethod]
        public void ToUInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt64(new CultureInfo("fr-FR"));

            Assert.Equal(12UL, actual);
        }

        [TestMethod]
        public void GetTypeCode()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.GetTypeCode();

            Assert.Equal(TypeCode.Object, actual);
        }
    }
}

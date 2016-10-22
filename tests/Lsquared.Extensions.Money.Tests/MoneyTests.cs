using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsquared.Extensions.Tests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Create_WithEuroCurrency()
        {
            // Don't need to set culture in current thread.

            var value = new Money(12.35m, Currency.EUR);

            Assert.AreEqual(12.35m, value.Value);
        }

        [TestMethod]
        public void Add_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a + b;

            Assert.AreEqual(24.70m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 0;

            Assert.AreEqual(12.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 + a;

            Assert.AreEqual(12.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12;

            Assert.AreEqual(24.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12L;

            Assert.AreEqual(24.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Add_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12.35m;

            Assert.AreEqual(24.70m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);

            var actual = a + b;
        }

        [TestMethod]
        public void Subtract_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a - b;

            Assert.AreEqual(0, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 0;

            Assert.AreEqual(12.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 - a;

            Assert.AreEqual(-12.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12;

            Assert.AreEqual(0.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12L;

            Assert.AreEqual(0.35m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Subtract_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12.35m;

            Assert.AreEqual(0, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Subtract_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);
            var actual = a - b;
        }

        [TestMethod]
        public void Multiply_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2;

            Assert.AreEqual(24.70m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Multiply_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2L;

            Assert.AreEqual(24.70m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Multiply_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2m;

            Assert.AreEqual(24.70m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2;

            Assert.AreEqual(6.175m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2L;

            Assert.AreEqual(6.175m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        public void Divide_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2m;

            Assert.AreEqual(6.175m, actual.Value);
            Assert.AreEqual(Currency.EUR, actual.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_WithBadValue()
        {
            Money.Parse("ABC");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_WithNull()
        {
            Money.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_WithEmptyString()
        {
            Money.Parse(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_WithBadValueAndCultureInfo()
        {
            Money.Parse("ABC", new CultureInfo("fr-FR"));
        }

        [TestMethod]
        public void Parse_WithEuroAndFrenchCulture()
        {
            var money = Money.Parse("3,23 €", new CultureInfo("fr-FR"));

            Assert.AreEqual(3.23m, money.Value);
            Assert.AreEqual(Currency.EUR, money.Currency);
        }

        [TestMethod]
        public void Parse_WithPoundAndBritishCulture()
        {
            var money = Money.Parse("£3.23", new CultureInfo("en-GB"));

            Assert.AreEqual(3.23m, money.Value);
            Assert.AreEqual(Currency.GBP, money.Currency);
        }

        [TestMethod]
        public void Parse_WithDollarAndAmericanCulture()
        {
            var money = Money.Parse("$3.23", new CultureInfo("en-US"));

            Assert.AreEqual(3.23m, money.Value);
            Assert.AreEqual(Currency.USD, money.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void CompareTo_WithObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            a.CompareTo(new object());
        }

        [TestMethod]
        public void CompareTo_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);

            var actual = a.CompareTo((object)b);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void CompareTo_WithMoney()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);

            var actual = a.CompareTo(b);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CompareTo_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.USD);

            a.CompareTo(b);
        }

        [TestMethod]
        public void Equals_WithObject()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);
            var actual = money.Equals(new object());

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Equals_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals((object)money2);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Equals_WithMoney()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals(money2);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Equals_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.USD);

            var actual = money1.Equals(money2);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ToString_WithFormat()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToString("C", Currency.EUR);

            Assert.AreEqual("12,35 €", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToBoolean()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            money.ToBoolean(new CultureInfo("fr-FR"));
        }

        [TestMethod]
        public void ToByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToByte(new CultureInfo("fr-FR"));

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToChar()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            money.ToChar(new CultureInfo("fr-FR"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToDateTime()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            money.ToDateTime(new CultureInfo("fr-FR"));
        }

        [TestMethod]
        public void ToDecimal()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDecimal(new CultureInfo("fr-FR"));

            Assert.AreEqual(12.35m, actual);
        }

        [TestMethod]
        public void ToDouble()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDouble(new CultureInfo("fr-FR"));

            Assert.AreEqual(12.35, actual);
        }

        [TestMethod]
        public void ToInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt16(new CultureInfo("fr-FR"));

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void ToInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt32(new CultureInfo("fr-FR"));

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void ToInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt64(new CultureInfo("fr-FR"));

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void ToSByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSByte(new CultureInfo("fr-FR"));

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void ToSingle()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSingle(new CultureInfo("fr-FR"));

            Assert.AreEqual(12.35f, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToType()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            money.ToType(typeof(object), new CultureInfo("fr-FR"));
        }

        [TestMethod]
        public void ToUInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt16(new CultureInfo("fr-FR"));

            Assert.AreEqual(12U, actual);
        }

        [TestMethod]
        public void ToUInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt32(new CultureInfo("fr-FR"));

            Assert.AreEqual(12U, actual);
        }

        [TestMethod]
        public void ToUInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt64(new CultureInfo("fr-FR"));

            Assert.AreEqual(12UL, actual);
        }

        [TestMethod]
        public void GetTypeCode()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.GetTypeCode();

            Assert.AreEqual(TypeCode.Object, actual);
        }
    }
}

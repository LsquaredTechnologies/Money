using System;
using System.Globalization;

#if !(NETSTANDARD1_6 && NETCOREAPP1_0)
using System.Threading;
#endif

using Xunit;

namespace Lsquared.Extensions
{
    public class MoneyTests
    {
        [Fact]
        public void Create_WithEuroCurrency()
        {
            // Don't need to set culture in current thread.

            var value = new Money(12.35m, Currency.EUR);

            Assert.Equal(12.35m, value.Value);
        }

        [Fact]
        public void Add_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a + b;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 0;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 + a;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12;

            Assert.Equal(24.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12L;

            Assert.Equal(24.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a + 12.35m;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Add_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);

            Assert.Throws<InvalidOperationException>(() => a + b);
        }

        [Fact]
        public void Subtract_SameCurrency()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a - b;

            Assert.Equal(0, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_WithZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 0;

            Assert.Equal(12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_FromZero()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = 0 - a;

            Assert.Equal(-12.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12;

            Assert.Equal(0.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12L;

            Assert.Equal(0.35m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a - 12.35m;

            Assert.Equal(0, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Subtract_DifferenctCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.GBP);

            Assert.Throws<InvalidOperationException>(() => a - b);
        }

        [Fact]
        public void Multiply_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Multiply_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2L;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Multiply_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a * 2m;

            Assert.Equal(24.70m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Divide_WithInt32()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Divide_WithInt64()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2L;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Divide_WithDecimal()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var actual = a / 2m;

            Assert.Equal(6.175m, actual.Value);
            Assert.Equal(Currency.EUR, actual.Currency);
        }

        [Fact]
        public void Parse_WithBadValue()
        {
            Assert.Throws<FormatException>(() => Money.Parse("ABC"));
        }

        [Fact]
        public void Parse_WithNull()
        {
            Assert.Throws<FormatException>(() => Money.Parse(null));
        }

        [Fact]
        public void Parse_WithEmptyString()
        {
            Assert.Throws<FormatException>(() => Money.Parse(string.Empty));
        }

        [Fact]
        public void Parse_WithBadValueAndCultureInfo()
        {
            Assert.Throws<FormatException>(() => Money.Parse("ABC", new CultureInfo("fr-FR")));
        }

        [Fact]
        public void Parse_WithEuroAndFrenchCulture()
        {
            var money = Money.Parse("3,23 €", new CultureInfo("fr-FR"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.EUR, money.Currency);
        }

        [Fact]
        public void Parse_WithPoundAndBritishCulture()
        {
            var money = Money.Parse("£3.23", new CultureInfo("en-GB"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.GBP, money.Currency);
        }

        [Fact]
        public void Parse_WithDollarAndAmericanCulture()
        {
            var money = Money.Parse("$3.23", new CultureInfo("en-US"));

            Assert.Equal(3.23m, money.Value);
            Assert.Equal(Currency.USD, money.Currency);
        }

        [Fact]
        public void CompareTo_WithObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            Assert.Throws<NotSupportedException>(() => a.CompareTo(new object()));
        }

        [Fact]
        public void CompareTo_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);
            var actual = a.CompareTo((object)b);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void CompareTo_WithMoney()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.EUR);

            var actual = a.CompareTo(b);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void CompareTo_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var a = new Money(12.35m, Currency.EUR);
            var b = new Money(12.35m, Currency.USD);

            Assert.Throws<InvalidOperationException>(() => a.CompareTo(b));
        }

        [Fact]
        public void Equals_WithObject()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);
            var actual = money.Equals(new object());

            Assert.False(actual);
        }

        [Fact]
        public void Equals_WithMoneyAsObject()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals((object)money2);

            Assert.True(actual);
        }

        [Fact]
        public void Equals_WithMoney()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.EUR);

            var actual = money1.Equals(money2);

            Assert.True(actual);
        }

        [Fact]
        public void Equals_WithDifferentCurrencies()
        {
            // Don't need to set culture in current thread.

            var money1 = new Money(12.35m, Currency.EUR);
            var money2 = new Money(12.35m, Currency.USD);

            var actual = money1.Equals(money2);

            Assert.False(actual);
        }

        [Fact]
        public void ToString_WithFormat()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToString("C", Currency.EUR);

            Assert.Equal("12,35 €", actual);
        }

        [Fact]
        public void ToBoolean()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToBoolean(new CultureInfo("fr-FR")));
        }

        [Fact]
        public void ToByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToByte(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ToChar()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToChar(new CultureInfo("fr-FR")));
        }

        [Fact]
        public void ToDateTime()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToDateTime(new CultureInfo("fr-FR")));
        }

        [Fact]
        public void ToDecimal()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDecimal(new CultureInfo("fr-FR"));

            Assert.Equal(12.35m, actual);
        }

        [Fact]
        public void ToDouble()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToDouble(new CultureInfo("fr-FR"));

            Assert.Equal(12.35, actual);
        }

        [Fact]
        public void ToInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt16(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ToInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt32(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ToInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToInt64(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ToSByte()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSByte(new CultureInfo("fr-FR"));

            Assert.Equal(12, actual);
        }

        [Fact]
        public void ToSingle()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToSingle(new CultureInfo("fr-FR"));

            Assert.Equal(12.35f, actual);
        }

        [Fact]
        public void ToType()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            Assert.Throws<NotSupportedException>(() => money.ToType(typeof(object), new CultureInfo("fr-FR")));
        }

        [Fact]
        public void ToUInt16()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt16(new CultureInfo("fr-FR"));

            Assert.Equal(12U, actual);
        }

        [Fact]
        public void ToUInt32()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt32(new CultureInfo("fr-FR"));

            Assert.Equal(12U, actual);
        }

        [Fact]
        public void ToUInt64()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.ToUInt64(new CultureInfo("fr-FR"));

            Assert.Equal(12UL, actual);
        }

        [Fact]
        public void GetTypeCode()
        {
            // Don't need to set culture in current thread.

            var money = new Money(12.35m, Currency.EUR);

            var actual = money.GetTypeCode();

            Assert.Equal(TypeCode.Object, actual);
        }

        [Fact]
        public void Cast_FromInt32()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            Money money = 12;

            Assert.Equal(Currency.EUR, money.Currency);
            Assert.Equal(12m, money.Value);
        }

        [Fact]
        public void Cast_FromInt64()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            Money money = 12L;

            Assert.Equal(Currency.EUR, money.Currency);
            Assert.Equal(12m, money.Value);
        }

        [Fact]
        public void Cast_FromDecimal()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            Money money = 12.35m;

            Assert.Equal(Currency.EUR, money.Currency);
            Assert.Equal(12.35m, money.Value);
        }
    }
}

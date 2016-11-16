using System;
using System.Globalization;
using System.Text;

namespace Lsquared.Extensions
{
    /// <summary>
    /// Represents a money with the specific <see cref="Currency"/>.
    /// </summary>
    /// <seealso cref="IComparable{Money}" />
    /// <seealso cref="IComparable" />
    /// <seealso cref="IConvertible" />
    /// <seealso cref="IEquatable{Money}" />
    /// <seealso cref="IFormattable" />
    public partial struct Money
    {
        /// <summary>
        /// The zero value (regardless of <see cref="Currency"/>).
        /// </summary>
        public static readonly Money Zero = new Money(0, Currency.None);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value => _value;

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency Currency => _currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        public Money(int value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
#if CODE_ANALYSIS
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public Money(long value, Currency currency)
        {
            _value = Convert.ToDecimal(value);
            _currency = currency;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        public Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// An instance of <see cref="Money"/> representing the money for the specified value.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        public static Money Parse(string value)
        {
            Money money;
            if (TryParse(value, CultureInfo.CurrentCulture, out money))
                return money;

            throw new FormatException($"Cannot parse money: {value}");
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        /// An instance of <see cref="Money" /> representing the money for the specified value.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        public static Money Parse(string value, CultureInfo culture)
        {
            Money money;
            if (TryParse(value, culture, out money))
                return money;

            throw new FormatException($"Cannot parse money: {value}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="money">The money.</param>
        /// <returns>
        ///   <c>true</c> if the value can be parsed; otherwise, <c>false</c>.
        /// </returns>
#if CODE_ANALYSIS
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool TryParse(string value, out Money money)
        {
            return TryParse(value, CultureInfo.CurrentCulture, out money);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="money">The money.</param>
        /// <returns>
        ///   <c>true</c> if the value can be parsed; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParse(string value, CultureInfo culture, out Money money)
        {
            money = Zero;

            if (value == null || value.Length == 0)
                return false;

            decimal amount;
            if (!decimal.TryParse(value, NumberStyles.Currency, culture, out amount))
            {
                return false;
            }

            var b = new StringBuilder(value);
            b.Replace(amount.ToString(culture), string.Empty);
            int startIndex, index = 0;
            while (index < b.Length)
            {
                if (b[index] == ' ')
                {
                    startIndex = index;
                    while (b[index] == ' ')
                        ++index;
                    b.Remove(startIndex, index - startIndex);
                }
                ++index;
            }

            Currency currency;
            if (!Currency.TryParse(b.ToString(), culture, out currency))
                return false;

            money = new Money(amount, currency);

            return true;
        }
        
        #region Fields

        private readonly decimal _value;
        private readonly Currency _currency;

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Lsquared.Extensions
{
    /// <summary>
    /// Represents a currency.
    /// </summary>
    /// <remarks>
    /// Use the ISO-4217 to represent currencies.
    /// </remarks>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.IEquatable{Lsquared.Extensions.Currency}" />
    public partial struct Currency
    {
        /// <summary>
        /// Gets the currenct currency.
        /// </summary>
        /// <value>
        /// The currenct currency.
        /// </value>
#if CODE_ANALYSIS
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Currency CurrentCurrency
            => FromCulture(Thread.CurrentThread.CurrentCulture);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => FindEntry(_isoNumber).Name;

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol => FindEntry(_isoNumber).Symbol;

        /// <summary>
        /// Gets the iso number.
        /// </summary>
        /// <value>
        /// The iso number.
        /// </value>
        public int IsoNumber => _isoNumber;

        /// <summary>
        /// Gets the iso code.
        /// </summary>
        /// <value>
        /// The iso code.
        /// </value>
        public string IsoCode => FindEntry(_isoNumber).IsoCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> struct.
        /// </summary>
        /// <param name="isoNumber">The iso number.</param>
        public Currency(short isoNumber)
        {
            _isoNumber = isoNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> struct.
        /// </summary>
        /// <param name="isoCode">The iso code.</param>
        public Currency(string isoCode)
        {
            Currency currency;
            TryParse(isoCode, out currency);
            this = currency;
        }

        /// <summary>
        /// Get the defined currency from the specified culture.
        /// </summary>
        /// <param name="culture">The culture information.</param>
        /// <returns>
        /// An instance of <see cref="Currency"/> representing the specified culture currency.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Unknown culture: " + cultureInfo</exception>
        public static Currency FromCulture(CultureInfo culture)
        {
            short isoNumber;
            if (_nameToIsoNumber.TryGetValue(culture.Name, out isoNumber))
            {
                return new Currency(isoNumber);
            }

            throw new InvalidOperationException("Unknown culture: " + culture);
        }

        /// <summary>
        /// Parses the specified iso code or symbol.
        /// </summary>
        /// <param name="isoCodeOrSymbol">The ISO code or symbol.</param>
        /// <returns>
        /// An instance of <see cref="Currency"/> representing the currency for the specified ISO code or symbol.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        public static Currency Parse(string isoCodeOrSymbol)
        {
            Currency currency;
            if (TryParse(isoCodeOrSymbol, Thread.CurrentThread.CurrentCulture, out currency))
                return currency;

            throw new FormatException($"Cannot parse currency: {isoCodeOrSymbol}");
        }

        /// <summary>
        /// Parses the specified iso code or symbol.
        /// </summary>
        /// <param name="isoCodeOrSymbol">The ISO code or symbol.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        /// An instance of <see cref="Currency"/> representing the currency for the specified ISO code or symbol.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        public static Currency Parse(string isoCodeOrSymbol, CultureInfo culture)
        {
            Currency currency;
            if (TryParse(isoCodeOrSymbol, culture, out currency))
                return currency;

            throw new FormatException($"Cannot parse currency: {isoCodeOrSymbol}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isoCodeOrSymbol">The ISO code or symbol.</param>
        /// <param name="currency">The currency.</param>
        /// <returns>
        ///   <c>true</c> if the ISO code or symbol can be parsed; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParse(string isoCodeOrSymbol, out Currency currency)
        {
            return TryParse(isoCodeOrSymbol, Thread.CurrentThread.CurrentCulture, out currency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isoCodeOrSymbol">The ISO code or symbol.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="currency">The currency.</param>
        /// <returns>
        ///   <c>true</c> if the ISO code or symbol can be parsed; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParse(string isoCodeOrSymbol, CultureInfo culture, out Currency currency)
        {
            currency = None;

            short isoNumber;
            if (_isoCodeToIsoNumber.TryGetValue(isoCodeOrSymbol, out isoNumber))
            {
                currency = new Currency(isoNumber);
                return true;
            }

            List<short> isoNumbers;
            if (_symbolToIsoNumbers.TryGetValue(isoCodeOrSymbol, out isoNumbers)) // _symbolIndex
            {
                var cultureName = culture.Name;
                if (_nameToIsoNumber.TryGetValue(cultureName, out isoNumber) && // _lcidToIsoCodeLookup
                    !isoNumbers.Contains(isoNumber))
                {
                    isoNumber = isoNumbers[0];
                }

                currency = new Currency(isoNumber);
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public override string ToString()
            => $"{Name} ({_isoNumber})";

#if CODE_ANALYSIS
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        private static Entry FindEntry(short code)
        {
            Entry entry;
            if (_entries.TryGetValue(code, out entry))
            {
                return entry;
            }

            throw new InvalidOperationException($"Currency not found: {code}");
        }

        #region Fields

        private readonly short _isoNumber;

        #endregion
    }
}

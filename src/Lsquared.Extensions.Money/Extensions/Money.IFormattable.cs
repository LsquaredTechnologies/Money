using System;
using System.Globalization;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IFormattable interface.
    /// </content>
    partial struct Money : IFormattable
    {
        /// <inheritdoc />
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public override string ToString()
        {
            return ToString("C", (IFormatProvider)_currency ?? NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public string ToString(string format)
        {
            return ToString(format, (IFormatProvider)_currency ?? NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public string ToString(IFormatProvider provider)
        {
            return ToString("C", provider ?? _currency);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _value.ToString(format, formatProvider);
        }
    }
}

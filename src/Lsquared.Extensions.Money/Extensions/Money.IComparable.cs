using System;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IComparable interfaces.
    /// </content>
    partial struct Money : IComparable<Money>, IComparable
    {
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public int CompareTo(object obj)
        {
            if (obj is Money)
                return Compare(this, (Money)obj);

            throw new NotSupportedException($"Cannot compare Money with {obj.GetType()}");
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public int CompareTo(Money other)
        {
            return Compare(this, other);
        }

        /// <summary>
        /// Compares the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static int Compare(Money left, Money right)
        {
            if (left._currency != right._currency)
                throw DifferentCurrencies();

            return decimal.Compare(left._value, right._value);
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator >(Money left, Money right)
        {
            return Compare(left, right) > 0;
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator <(Money left, Money right)
        {
            return Compare(left, right) < 0;
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator >=(Money left, Money right)
        {
            return Compare(left, right) >= 0;
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator <=(Money left, Money right)
        {
            return Compare(left, right) <= 0;
        }
    }
}

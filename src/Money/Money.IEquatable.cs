using System;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IEquatable interface.
    /// </content>
    partial struct Money : IEquatable<Money>
    {
        /// <inheritdoc />
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public override int GetHashCode()
        {
            unchecked
            {
                return (397 * _value.GetHashCode()) ^ _currency.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
            => obj is Money && Equals(this, (Money)obj);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public bool Equals(Money other)
            => Equals(this, other);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// 
        /// </returns>
        public static bool Equals(Money left, Money right)
            => (left._currency == right._currency && left._value == right._value) || (left._value == 0 && right._value == 0);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator ==(Money left, Money right)
            => Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static bool operator !=(Money left, Money right)
            => Equals(left, right);
    }
}

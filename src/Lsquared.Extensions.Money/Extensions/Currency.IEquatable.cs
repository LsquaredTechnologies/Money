using System;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IEquatable interface.
    /// </content>
    partial struct Currency : IEquatable<Currency>
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override int GetHashCode()
            => 609502847 ^ _isoNumber;

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
            => obj is Currency && Equals(this, (Currency)obj);

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool Equals(Currency other)
            => Equals(this, other);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// 
        /// </returns>
        public static bool Equals(Currency left, Currency right)
            => left._isoNumber == right._isoNumber;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool operator ==(Currency left, Currency right)
            => Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static bool operator !=(Currency left, Currency right)
            => !Equals(left, right);
    }
}

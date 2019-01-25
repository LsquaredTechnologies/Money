using System;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IConvertible interface.
    /// </content>
#if PORTABLE
    partial struct Money
#else
    partial struct Money : IConvertible
#endif
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static implicit operator Money(int value)
        {
            return new Money(value, Currency.None);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static implicit operator Money(long value)
        {
            return new Money(value, Currency.None);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Decimal"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static explicit operator Money(decimal value)
        {
            return new Money(value, Currency.None);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Money"/> to <see cref="System.Decimal"/>.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static implicit operator decimal(Money money)
        {
            return money.Value;
        }
#if !PORTABLE
        /// <inheritdoc />
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
#endif

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider)
        {
            return _value;
        }

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value);
        }

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value);
        }

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_value);
        }

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_value);
        }

        /// <inheritdoc />
        [CLSCompliant(false)]
        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_value);
        }

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value);
        }

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        [CLSCompliant(false)]
        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value);
        }

        /// <inheritdoc />
        [CLSCompliant(false)]
        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value);
        }

        /// <inheritdoc />
        [CLSCompliant(false)]
        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value);
        }
    }
}

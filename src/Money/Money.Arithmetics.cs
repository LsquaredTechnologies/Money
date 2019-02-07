using System;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements arithmetic operators.
    /// </content>
    partial struct Money
    {
        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Money operator -(Money value)
        {
            return new Money(-value._value, value._currency);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator +(Money value)
        {
            return value;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator +(Money left, Money right)
        {
            return Add(left, right);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator +(Money left, int right)
        {
            return Add(left, right);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator +(Money left, long right)
        {
            return Add(left, right);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator +(Money left, decimal right)
        {
            return Add(left, right);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator -(Money left, Money right)
        {
            return Subtract(left, right);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator -(Money left, int right)
        {
            return Subtract(left, right);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator -(Money left, long right)
        {
            return Subtract(left, right);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator -(Money left, decimal right)
        {
            return Subtract(left, right);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator *(Money left, int right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator *(Money left, long right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator *(Money left, decimal right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator /(Money left, int right)
        {
            return Divide(left, right);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator /(Money left, long right)
        {
            return Divide(left, right);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public static Money operator /(Money left, decimal right)
        {
            return Divide(left, right);
        }

        /// <summary>
        /// Adds the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Add(Money left, Money right)
        {
            if (left._value == 0)
                return right;

            if (right._value == 0)
                return left;

            if (left._currency != right._currency)
                throw DifferentCurrencies();

            return new Money(left._value + right._value, left._currency);
        }

        /// <summary>
        /// Adds the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Add(Money left, int right)
        {
            if (left._value == 0)
                return new Money(right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value + right, left._currency);
        }

        /// <summary>
        /// Adds the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Add(Money left, long right)
        {
            if (left._value == 0)
                return new Money(right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value + right, left._currency);
        }

        /// <summary>
        /// Adds the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Add(Money left, decimal right)
        {
            if (left._value == 0)
                return new Money(right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value + right, left._currency);
        }

        /// <summary>
        /// Subtracts the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Subtract(Money left, Money right)
        {
            if (left._value == 0)
                return -right;

            if (right._value == 0)
                return left;

            if (left._currency != right._currency)
                throw DifferentCurrencies();

            return new Money(left._value - right._value, left._currency);
        }

        /// <summary>
        /// Subtracts the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Subtract(Money left, int right)
        {
            if (left._value == 0)
                return new Money(-right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value - right, left._currency);
        }

        /// <summary>
        /// Subtracts the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Subtract(Money left, long right)
        {
            if (left._value == 0)
                return new Money(-right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value - right, left._currency);
        }

        /// <summary>
        /// Subtracts the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Subtract(Money left, decimal right)
        {
            if (left._value == 0)
                return new Money(-right, left._currency);

            if (right == 0)
                return left;

            return new Money(left._value - right, left._currency);
        }

        /// <summary>
        /// Multiplies the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Multiply(Money left, int right)
        {
            if (left._value == 0)
                return new Money(0, left._currency);

            return new Money(left._value * right, left._currency);
        }

        /// <summary>
        /// Multiplies the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Multiply(Money left, long right)
        {
            if (left._value == 0)
                return new Money(0, left._currency);

            return new Money(left._value * right, left._currency);
        }

        /// <summary>
        /// Multiplies the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        public static Money Multiply(Money left, decimal right)
        {
            if (left._value == 0)
                return new Money(0, left._currency);

            return new Money(left._value * right, left._currency);
        }

        /// <summary>
        /// Divides the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="System.DivideByZeroException"></exception>
        public static Money Divide(Money left, int right)
        {
            if (left._value == 0)
                throw new DivideByZeroException();

            return new Money(left._value / right, left._currency);
        }

        /// <summary>
        /// Divides the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="System.DivideByZeroException"></exception>
        public static Money Divide(Money left, long right)
        {
            if (left._value == 0)
                throw new DivideByZeroException();

            return new Money(left._value / right, left._currency);
        }

        /// <summary>
        /// Divides the specified values.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="System.DivideByZeroException"></exception>
        public static Money Divide(Money left, decimal right)
        {
            if (left._value == 0)
                throw new DivideByZeroException();

            return new Money(left._value / right, left._currency);
        }

        private static InvalidOperationException DifferentCurrencies()
        {
            return new InvalidOperationException("Money values are in different currencies. Convert to the same currency before performing operations on the values.");
        }
    }
}

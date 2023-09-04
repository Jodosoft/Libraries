// Copyright (c) 2023 Joe Lawry-Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Defines a generalization for numeric value types.
    /// </summary>
    /// <typeparam name="TSelf">The type that implements <see cref="INumeric{TSelf}"/>.</typeparam>
    [SuppressMessage("csharpsquid", "S3444:Interfaces should not simply inherit from base interfaces with colliding members", Justification = "By design - IProvider instances are accessed via static classes")]
    public interface INumeric<TSelf> :
            IComparable,
            IComparable<TSelf>,
            IEquatable<TSelf>,
            IFormattable,
            IProvider<IBinaryIO<TSelf>>,
            IProvider<IConvert<TSelf>>,
            IProvider<IMath<TSelf>>,
            IProvider<INumericBitConverter<TSelf>>,
            IProvider<INumericRandom<TSelf>>,
            IProvider<INumericStatic<TSelf>>,
            IProvider<IVariantRandom<TSelf>>,
            ISerializable
        where TSelf : struct, INumeric<TSelf>
    {
        /// <summary>
        /// Determines whether the current value is greater than the specified value.
        /// </summary>
        /// <param name="value">The value to compare with the current value.</param>
        /// <returns><see langword="true"/> if the current value is greater than <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
        bool IsGreaterThan(TSelf value);

        /// <summary>
        /// Determines whether the current value is greater than or equal to the specified value.
        /// </summary>
        /// <param name="value">The value to compare with the current value.</param>
        /// <returns><see langword="true"/> if the current value is greater than or equal to <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
        bool IsGreaterThanOrEqualTo(TSelf value);

        /// <summary>
        /// Determines whether the current value is less than the specified value.
        /// </summary>
        /// <param name="value">The value to compare with the current value.</param>
        /// <returns><see langword="true"/> if the current value is less than <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
        bool IsLessThan(TSelf value);

        /// <summary>
        /// Determines whether the current value is less than or equal to the specified value.
        /// </summary>
        /// <param name="value">The value to compare with the current value.</param>
        /// <returns><see langword="true"/> if the current value is less than or equal to <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
        bool IsLessThanOrEqualTo(TSelf value);

        /// <summary>
        /// Computes the sum of the current value and the specified value.
        /// </summary>
        /// <param name="value">The value to add to the current value.</param>
        /// <returns>The sum of the current value and <paramref name="value"/>.</returns>
        TSelf Add(TSelf value);

        /// <summary>
        /// Produces a bitwise complement of the current value by reversing each bit.
        /// </summary>
        /// <returns>A bitwise complement of the current value.</returns>
        TSelf BitwiseComplement();

        /// <summary>
        /// Divides the current value by the specified value.
        /// </summary>
        /// <param name="value">The value as the divisor.</param>
        /// <returns>The result of dividing the current value by <paramref name="value"/>.</returns>
        TSelf Divide(TSelf value);

        /// <summary>
        /// <para>Shifts the current value left by the specified number of bits.</para>
        /// <para>Discards the high-order bits that are outside the range of the result type and sets the low-order empty bit positions to zero.</para>
        /// </summary>
        /// <param name="count">The number of bits.</param>
        /// <returns>The current value shifted to the left by the number of bits specified by <paramref name="count"/>.</returns>
        TSelf LeftShift(int count);

        /// <summary>
        /// Computes the bitwise logical AND of the current value and the specified value.
        /// </summary>
        /// <param name="value">The value with which to compute the logical bitwise AND.</param>
        /// <returns>The bitwise logical AND of the current value and <paramref name="value"/>.</returns>
        TSelf LogicalAnd(TSelf value);

        /// <summary>
        /// Computes the bitwise logical exclusive OR, also known as the bitwise logical XOR, of the current value and the specified value.
        /// </summary>
        /// <param name="value">The value with which to compute the logical exclusive OR.</param>
        /// <returns>The bitwise logical exclusive OR of the current value and <paramref name="value"/>.</returns>
        TSelf LogicalExclusiveOr(TSelf value);

        /// <summary>
        /// Computes the bitwise logical OR of the current value and the specified value.
        /// </summary>
        /// <param name="value">The value with which to compute the logical bitwise OR.</param>
        /// <returns>The bitwise logical OR of the current value and <paramref name="value"/>.</returns>
        TSelf LogicalOr(TSelf value);

        /// <summary>
        /// Computes the product of the current value and the specified value.
        /// </summary>
        /// <param name="value">The value to multiply with the current value.</param>
        /// <returns>The product of the current value and <paramref name="value"/>.</returns>
        TSelf Multiply(TSelf value);

        /// <summary>
        /// Computes the numeric negation of the current value.
        /// </summary>
        /// <returns>The numeric negation of the current value.</returns>
        TSelf Negative();

        /// <summary>
        /// Returns the current value.
        /// </summary>
        /// <returns>The current value.</returns>
        TSelf Positive();

        /// <summary>
        /// Computes the remainder after dividing the current value by the specified value.
        /// </summary>
        /// <param name="value">The value as the divisor.</param>
        /// <returns>The remainder after dividing the current value by <paramref name="value"/>.</returns>
        TSelf Remainder(TSelf value);

        /// <summary>
        /// <para>Shifts the current value right by the specified number of bits.</para>
        /// <para>Performs an signed (arithmetic) shift if <typeparamref name="TSelf"/> is signed; otherwise sets the high-order bits to zero. Discards the low-order bits.</para>
        /// </summary>
        /// <param name="count">The number of bits.</param>
        /// <returns>The current value shifted to the right by the number of bits specified by <paramref name="count"/>.</returns>
        TSelf RightShift(int count);

        /// <summary>
        /// Subtracts the specified value from the current value.
        /// </summary>
        /// <param name="value">The value to subtract from the current value.</param>
        /// <returns>The result of subtracting <paramref name="value"/> from the current value.</returns>
        TSelf Subtract(TSelf value);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/>.</returns>
        string ToString(string format);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="formatProvider"/>.</returns>
        string ToString(IFormatProvider formatProvider);

#if HAS_DEFAULT_INTERFACE_METHODS
        public static bool operator <(INumeric<TSelf> left, INumeric<TSelf> right) => left.IsLessThan((TSelf)right);
        public static bool operator <=(INumeric<TSelf> left, INumeric<TSelf> right) => left.IsLessThanOrEqualTo((TSelf)right);
        public static bool operator >(INumeric<TSelf> left, INumeric<TSelf> right) => left.IsGreaterThan((TSelf)right);
        public static bool operator >=(INumeric<TSelf> left, INumeric<TSelf> right) => left.IsGreaterThanOrEqualTo((TSelf)right);
        public static TSelf operator %(INumeric<TSelf> left, INumeric<TSelf> right) => left.Remainder((TSelf)right);
        public static TSelf operator &(INumeric<TSelf> left, INumeric<TSelf> right) => left.LogicalAnd((TSelf)right);
        public static TSelf operator -(INumeric<TSelf> left) => left.Negative();
        public static TSelf operator -(INumeric<TSelf> left, INumeric<TSelf> right) => left.Subtract((TSelf)right);
        public static TSelf operator *(INumeric<TSelf> left, INumeric<TSelf> right) => left.Multiply((TSelf)right);
        public static TSelf operator /(INumeric<TSelf> left, INumeric<TSelf> right) => left.Divide((TSelf)right);
        public static TSelf operator ^(INumeric<TSelf> left, INumeric<TSelf> right) => left.LogicalExclusiveOr((TSelf)right);
        public static TSelf operator |(INumeric<TSelf> left, INumeric<TSelf> right) => left.LogicalOr((TSelf)right);
        public static TSelf operator ~(INumeric<TSelf> left) => left.BitwiseComplement();
        public static TSelf operator +(INumeric<TSelf> left) => left.Positive();
        public static TSelf operator +(INumeric<TSelf> left, INumeric<TSelf> right) => left.Add((TSelf)right);
        public static TSelf operator <<(INumeric<TSelf> left, int right) => left.LeftShift(right);
        public static TSelf operator >>(INumeric<TSelf> left, int right) => left.RightShift(right);
#endif
    }
}

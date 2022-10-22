// Copyright (c) 2022 Joseph J. Short
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
using Jodo.Primitives;

namespace Jodo.Numerics
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
            IProvider<IBitBuffer<TSelf>>,
            IProvider<IConvert<TSelf>>,
            IProvider<IMath<TSelf>>,
            IProvider<INumericBitConverter<TSelf>>,
            IProvider<INumericRandom<TSelf>>,
            IProvider<INumericStatic<TSelf>>,
            IProvider<IVariantRandom<TSelf>>,
            ISerializable
        where TSelf : struct, INumeric<TSelf>
    {
        bool IsGreaterThan(TSelf value);
        bool IsGreaterThanOrEqualTo(TSelf value);
        bool IsLessThan(TSelf value);
        bool IsLessThanOrEqualTo(TSelf value);
        TSelf Add(TSelf value);
        TSelf BitwiseComplement();
        TSelf Divide(TSelf value);
        TSelf LeftShift(int count);
        TSelf LogicalAnd(TSelf value);
        TSelf LogicalExclusiveOr(TSelf value);
        TSelf LogicalOr(TSelf value);
        TSelf Multiply(TSelf value);
        TSelf Negative();
        TSelf Positive();
        TSelf Remainder(TSelf value);
        TSelf RightShift(int count);
        TSelf Subtract(TSelf value);

        string ToString(string format);
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

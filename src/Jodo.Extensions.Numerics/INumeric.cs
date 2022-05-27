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

using Jodo.Extensions.Primitives;
using System;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    public interface INumeric<N> :
            IBitConvertible<N>,
            IComparable,
            IComparable<N>,
            IConvertible<N>,
            IEquatable<N>,
            IFormattable,
            IRandomisable<N>,
            ISerializable,
            IStringParsable<N>
        where N : struct, INumeric<N>
    {
        IMath<N> Math { get; }
        ICast<N> Cast { get; }
        INumericFunctions<N> NumericFunctions { get; }

        public float ToSingle() => Convert<N>.ToSingle((N)this);
        public double ToDouble() => Convert<N>.ToDouble((N)this);

        bool IsGreaterThan(N value);
        bool IsGreaterThanOrEqualTo(N value);
        bool IsLessThan(N value);
        bool IsLessThanOrEqualTo(N value);
        N Add(N value);
        N BitwiseComplement();
        N Divide(N value);
        N LeftShift(int count);
        N LogicalAnd(N value);
        N LogicalExclusiveOr(N value);
        N LogicalOr(N value);
        N Multiply(N value);
        N Negative();
        N Positive();
        N Remainder(N value);
        N RightShift(int count);
        N Subtract(N value);

        string ToString(string format);
        string ToString(IFormatProvider formatProvider);

        public static bool operator <(INumeric<N> left, INumeric<N> right) => left.IsLessThan((N)right);
        public static bool operator <=(INumeric<N> left, INumeric<N> right) => left.IsLessThanOrEqualTo((N)right);
        public static bool operator >(INumeric<N> left, INumeric<N> right) => left.IsGreaterThan((N)right);
        public static bool operator >=(INumeric<N> left, INumeric<N> right) => left.IsGreaterThanOrEqualTo((N)right);
        public static N operator %(INumeric<N> left, INumeric<N> right) => left.Remainder((N)right);
        public static N operator &(INumeric<N> left, INumeric<N> right) => left.LogicalAnd((N)right);
        public static N operator -(INumeric<N> left) => left.Negative();
        public static N operator -(INumeric<N> left, INumeric<N> right) => left.Subtract((N)right);
        public static N operator *(INumeric<N> left, INumeric<N> right) => left.Multiply((N)right);
        public static N operator /(INumeric<N> left, INumeric<N> right) => left.Divide((N)right);
        public static N operator ^(INumeric<N> left, INumeric<N> right) => left.LogicalExclusiveOr((N)right);
        public static N operator |(INumeric<N> left, INumeric<N> right) => left.LogicalOr((N)right);
        public static N operator ~(INumeric<N> left) => left.BitwiseComplement();
        public static N operator +(INumeric<N> left) => left.Positive();
        public static N operator +(INumeric<N> left, INumeric<N> right) => left.Add((N)right);
        public static N operator <<(INumeric<N> left, int right) => left.LeftShift(right);
        public static N operator >>(INumeric<N> left, int right) => left.RightShift(right);

        public static bool operator <(INumeric<N> left, N right) => left.IsLessThan(right);
        public static bool operator <=(INumeric<N> left, N right) => left.IsLessThanOrEqualTo(right);
        public static bool operator >(INumeric<N> left, N right) => left.IsGreaterThan(right);
        public static bool operator >=(INumeric<N> left, N right) => left.IsGreaterThanOrEqualTo(right);
        public static N operator %(INumeric<N> left, N right) => left.Remainder(right);
        public static N operator -(INumeric<N> left, N right) => left.Subtract(right);
        public static N operator *(INumeric<N> left, N right) => left.Multiply(right);
        public static N operator /(INumeric<N> left, N right) => left.Divide(right);
        public static N operator +(INumeric<N> left, N right) => left.Add(right);
    }
}

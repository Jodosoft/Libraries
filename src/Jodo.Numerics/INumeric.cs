﻿// Copyright (c) 2022 Joseph J. Short
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
    /// <typeparam name="N">The type that implements INumeric&lt;N&gt;</typeparam>
    [SuppressMessage("csharpsquid", "S3444")] // by design
    [CLSCompliant(false)]
    public interface INumeric<N> :
            IComparable,
            IComparable<N>,
            IEquatable<N>,
            IFormattable,
            IProvider<IBitConverter<N>>,
            IProvider<ICast<N>>,
            IProvider<IConvert<N>>,
            IProvider<IMath<N>>,
            IProvider<INumericStatic<N>>,
            IProvider<IRandom<N>>,
            IProvider<IParser<N>>,
            ISerializable
        where N : struct, INumeric<N>
    {
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

        // todo:
        // N Half();
        // N Double();
        // N Squared();
        // N Cubed();

        string ToString(string format);
        string ToString(IFormatProvider formatProvider);

#if NETSTANDARD2_1
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
#endif
    }
}

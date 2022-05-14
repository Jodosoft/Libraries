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
    public interface INumeric<T> : IBitConvertible<T>, IConvertible<T>, IRandomisable<T>, IStringRepresentable<T>, IComparable<T>, IEquatable<T>, IComparable, ISerializable, IFormattable where T : struct, INumeric<T>
    {
        IMath<T> Math { get; }

        public static bool operator <(in INumeric<T> left, in INumeric<T> right) => Math<T>.IsLessThan((T)left, (T)right);
        public static bool operator <=(in INumeric<T> left, in INumeric<T> right) => Math<T>.IsLessThanOrEqualTo((T)left, (T)right);
        public static bool operator >(in INumeric<T> left, in INumeric<T> right) => Math<T>.IsGreaterThan((T)left, (T)right);
        public static bool operator >=(in INumeric<T> left, in INumeric<T> right) => Math<T>.IsGreaterThanOrEqualTo((T)left, (T)right);
        public static T operator %(in INumeric<T> left, in INumeric<T> right) => Math<T>.Remainder((T)left, (T)right);
        public static T operator -(in INumeric<T> left, in INumeric<T> right) => Math<T>.Subtract((T)left, (T)right);
        public static T operator *(in INumeric<T> left, in INumeric<T> right) => Math<T>.Multiply((T)left, (T)right);
        public static T operator /(in INumeric<T> left, in INumeric<T> right) => Math<T>.Divide((T)left, (T)right);
        public static T operator +(in INumeric<T> left, in INumeric<T> right) => Math<T>.Add((T)left, (T)right);
        public static T operator -(in INumeric<T> left) => Math<T>.Negative((T)left);
        public static T operator +(in INumeric<T> left) => Math<T>.Positive((T)left);

        public static bool operator <(in INumeric<T> left, in T right) => Math<T>.IsLessThan((T)left, right);
        public static bool operator <=(in INumeric<T> left, in T right) => Math<T>.IsLessThanOrEqualTo((T)left, right);
        public static bool operator >(in INumeric<T> left, in T right) => Math<T>.IsGreaterThan((T)left, right);
        public static bool operator >=(in INumeric<T> left, in T right) => Math<T>.IsGreaterThanOrEqualTo((T)left, right);
        public static T operator %(in INumeric<T> left, in T right) => Math<T>.Remainder((T)left, right);
        public static T operator -(in INumeric<T> left, in T right) => Math<T>.Subtract((T)left, right);
        public static T operator *(in INumeric<T> left, in T right) => Math<T>.Multiply((T)left, right);
        public static T operator /(in INumeric<T> left, in T right) => Math<T>.Divide((T)left, right);
        public static T operator +(in INumeric<T> left, in T right) => Math<T>.Add((T)left, right);

        public static bool operator <(INumeric<T> left, byte b) => left < Convert<T>.ToValue(b);
        public static bool operator <=(INumeric<T> left, byte b) => left <= Convert<T>.ToValue(b);
        public static bool operator >(INumeric<T> left, byte b) => left > Convert<T>.ToValue(b);
        public static bool operator >=(INumeric<T> left, byte b) => left >= Convert<T>.ToValue(b);
        public static T operator %(INumeric<T> left, byte b) => left % Convert<T>.ToValue(b);
        public static T operator -(INumeric<T> left, byte b) => left - Convert<T>.ToValue(b);
        public static T operator *(INumeric<T> left, byte b) => left * Convert<T>.ToValue(b);
        public static T operator /(INumeric<T> left, byte b) => left / Convert<T>.ToValue(b);
        public static T operator +(INumeric<T> left, byte b) => left + Convert<T>.ToValue(b);

        public static bool operator <(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) < left;
        public static bool operator <=(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) <= left;
        public static bool operator >(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) > left;
        public static bool operator >=(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) >= left;
        public static T operator %(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) % left;
        public static T operator -(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) - left;
        public static T operator *(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) * left;
        public static T operator /(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) / left;
        public static T operator +(in byte b, in INumeric<T> left) => Convert<T>.ToValue(b) + left;
    }
}

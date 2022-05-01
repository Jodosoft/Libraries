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

namespace Jodo.Extensions.CheckedNumerics
{
    public interface INumeric<T> : IStringFormatter<T>, IBitConverter<T>, IRandomGenerator<T>, IComparable<T>, IEquatable<T>, IComparable, ISerializable where T : struct, INumeric<T>
    {
        T Value { get; }

        T E { get; }
        T Epsilon { get; }
        T MaxValue { get; }
        T MinValue { get; }
        T MaxUnit { get; }
        T MinUnit { get; }
        T Zero { get; }
        T One { get; }
        T Pi { get; }
        bool IsSigned { get; }
        bool HasMantissa { get; }

        float Approximate(float offset);

        bool GreaterThan(T value2);
        bool GreaterThanOrEqualTo(T value2);
        bool LessThan(T value2);
        bool LessThanOrEqualTo(T value2);
        T Abs();
        T Acos();
        T Acosh();
        T Addition(T value2);
        T Asin();
        T Asinh();
        T Atan();
        T Atan2(T x);
        T Atanh();
        T Cbrt();
        T Ceiling();
        T Cos();
        T Cosh();
        T DegreesToRadians();
        T DegreesToTurns();
        T Divide(T value2);
        T Exp();
        T Floor();
        T Log();
        T Log(T newBase);
        T Log10();
        T Max(T y);
        T Min(T y);
        T Negative();
        T Multiply(T value2);
        T Positive();
        T Pow(T value2);
        T RadiansToDegrees();
        T RadiansToTurns();
        T Remainder(T value2);
        T Round();
        T Round(byte digits);
        T Round(byte digits, MidpointRounding mode);
        T Round(MidpointRounding mode);
        T Sin();
        T Sinh();
        T Sqrt();
        T Subtract(T value2);
        T Tan();
        T Tanh();
        T TurnsToDegrees();
        T TurnsToRadians();

        T Convert(byte value);

        public static bool operator <(INumeric<T> n, INumeric<T> t) => n.LessThan((T)t);
        public static bool operator <=(INumeric<T> n, INumeric<T> t) => n.LessThanOrEqualTo((T)t);
        public static bool operator >(INumeric<T> n, INumeric<T> t) => n.GreaterThan((T)t);
        public static bool operator >=(INumeric<T> n, INumeric<T> t) => n.GreaterThanOrEqualTo((T)t);
        public static T operator %(INumeric<T> n, INumeric<T> t) => n.Remainder((T)t);
        public static T operator -(INumeric<T> n, INumeric<T> t) => n.Subtract((T)t);
        public static T operator *(INumeric<T> n, INumeric<T> t) => n.Multiply((T)t);
        public static T operator /(INumeric<T> n, INumeric<T> t) => n.Divide((T)t);
        public static T operator +(INumeric<T> n, INumeric<T> t) => n.Addition((T)t);
        public static T operator -(INumeric<T> n) => n.Negative();
        public static T operator +(INumeric<T> n) => n.Positive();

        public static bool operator <(INumeric<T> n, T t) => n < (INumeric<T>)t;
        public static bool operator <=(INumeric<T> n, T t) => n <= (INumeric<T>)t;
        public static bool operator >(INumeric<T> n, T t) => n > (INumeric<T>)t;
        public static bool operator >=(INumeric<T> n, T t) => n >= (INumeric<T>)t;
        public static T operator %(INumeric<T> n, T t) => n % (INumeric<T>)t;
        public static T operator -(INumeric<T> n, T t) => n - (INumeric<T>)t;
        public static T operator *(INumeric<T> n, T t) => n * (INumeric<T>)t;
        public static T operator /(INumeric<T> n, T t) => n / (INumeric<T>)t;
        public static T operator +(INumeric<T> n, T t) => n + (INumeric<T>)t;

        public static bool operator <(INumeric<T> n, byte b) => n < Math<T>.Convert(b);
        public static bool operator <=(INumeric<T> n, byte b) => n <= Math<T>.Convert(b);
        public static bool operator >(INumeric<T> n, byte b) => n > Math<T>.Convert(b);
        public static bool operator >=(INumeric<T> n, byte b) => n >= Math<T>.Convert(b);
        public static T operator %(INumeric<T> n, byte b) => n % Math<T>.Convert(b);
        public static T operator -(INumeric<T> n, byte b) => n - Math<T>.Convert(b);
        public static T operator *(INumeric<T> n, byte b) => n * Math<T>.Convert(b);
        public static T operator /(INumeric<T> n, byte b) => n / Math<T>.Convert(b);
        public static T operator +(INumeric<T> n, byte b) => n + Math<T>.Convert(b);

        public static bool operator <(byte b, INumeric<T> n) => Math<T>.Convert(b) < n;
        public static bool operator <=(byte b, INumeric<T> n) => Math<T>.Convert(b) <= n;
        public static bool operator >(byte b, INumeric<T> n) => Math<T>.Convert(b) > n;
        public static bool operator >=(byte b, INumeric<T> n) => Math<T>.Convert(b) >= n;
        public static T operator %(byte b, INumeric<T> n) => Math<T>.Convert(b) % n;
        public static T operator -(byte b, INumeric<T> n) => Math<T>.Convert(b) - n;
        public static T operator *(byte b, INumeric<T> n) => Math<T>.Convert(b) * n;
        public static T operator /(byte b, INumeric<T> n) => Math<T>.Convert(b) / n;
        public static T operator +(byte b, INumeric<T> n) => Math<T>.Convert(b) + n;
    }
}

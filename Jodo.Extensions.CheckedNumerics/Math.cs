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
using System.Globalization;

namespace Jodo.Extensions.CheckedNumerics
{
    public static class Math<T> where T : struct, INumeric<T>
    {
        private static readonly T Default = default;

        public static readonly T E = Default.E;
        public static readonly T Epsilon = Default.Epsilon;
        public static readonly T MaxUnit = Default.MaxUnit;
        public static readonly T MaxValue = Default.MaxValue;
        public static readonly T MinUnit = Default.MinUnit;
        public static readonly T MinValue = Default.MinValue;
        public static readonly T One = Default.One;
        public static readonly T Pi = Default.Pi;
        public static readonly T Zero = default;

        public static T Convert(byte value) => Default.Convert(value);
        public static T Parse(string s) => Default.Parse(s);
        public static T Parse(string s, IFormatProvider provider) => Default.Parse(s, provider);
        public static T Parse(string s, NumberStyles style) => Default.Parse(s, style);
        public static T Parse(string s, NumberStyles style, IFormatProvider provider) => Default.Parse(s, style, provider);

        public static T Abs(T value) => value.Abs();
        public static T Acos(T value) => value.Acos();
        public static T Acosh(T value) => value.Acosh();
        public static T Asin(T value) => value.Asin();
        public static T Asinh(T value) => value.Asinh();
        public static T Atan(T value) => value.Atan();
        public static T Atan2(T x, T value) => x.Atan2(value);
        public static T Atan2(T x, byte value) => x.Atan2(Convert(value));
        public static T Atanh(T value) => value.Atanh();
        public static T Cbrt(T value) => value.Cbrt();
        public static T Ceiling(T value) => value.Ceiling();
        public static T Clamp(T value, T minInclusive, T maxInclusive) => Math<T>.Min(Math<T>.Max(value, minInclusive), maxInclusive);
        public static T Cos(T value) => value.Cos();
        public static T Cosh(T value) => value.Cosh();
        public static T DegreesToRadians(T value) => value.DegreesToRadians();
        public static T DegreesToTurns(T value) => value.DegreesToTurns();
        public static T Division(T value1, T value2) => value1.Divide(value2);
        public static T Division(T value1, byte value2) => value1.Divide(Convert(value2));
        public static T Exp(T value) => value.Exp();
        public static T Floor(T value) => value.Floor();
        public static T Log(T value) => value.Log();
        public static T Log(T value1, T value2) => value1.Log(value2);
        public static T Log(T value1, byte value2) => value1.Log(Convert(value2));
        public static T Log10(T value) => value.Log10();
        public static T Max(T value1, T value2) => value1 > value2 ? value1 : value2;
        public static T Max(T value1, byte value2) => value1 > Convert(value2) ? value1 : Convert(value2);
        public static T Min(T value1, T value2) => value1 < value2 ? value1 : value2;
        public static T Min(T value1, byte value2) => value1 < Convert(value2) ? value1 : Convert(value2);
        public static T Pow(T value1, byte value2) => value1.Pow(Convert(value2));
        public static T Pow(T value1, T value2) => value1.Pow(value2);
        public static T RadiansToDegrees(T value) => value.RadiansToDegrees();
        public static T RadiansToTurns(T value) => value.RadiansToTurns();
        public static T Round(T value, byte digits) => value.Round(digits);
        public static T Round(T value, byte digits, MidpointRounding mode) => value.Round(digits, mode);
        public static T Round(T value, MidpointRounding mode) => value.Round(mode);
        public static T Round(T value1) => value1.Round();
        public static T Sin(T value) => value.Sin();
        public static T Sinh(T value) => value.Sinh();
        public static T Sqrt(T value) => value.Sqrt();
        public static T Tan(T value) => value.Tan();
        public static T Tanh(T value) => value.Tanh();
        public static T TurnsToDegrees(T value) => value.TurnsToDegrees();
        public static T TurnsToRadians(T value) => value.TurnsToRadians();
    }
}

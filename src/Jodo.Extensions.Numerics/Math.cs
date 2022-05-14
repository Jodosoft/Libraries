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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Extensions.Numerics
{
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S2743")]
    public static class Math<T> where T : struct, INumeric<T>
    {
        private static readonly IMath<T> Instance = default(T).Math;

        public static T E => Instance.E;
        public static T PI => Instance.PI;
        public static T Epsilon => Instance.Epsilon;
        public static T MaxValue => Instance.MaxValue;
        public static T MinValue => Instance.MinValue;
        public static T MaxUnit => Instance.MaxUnit;
        public static T MinUnit => Instance.MinUnit;
        public static T Zero => Instance.Zero;
        public static T One => Instance.One;
        public static bool IsSigned => Instance.IsSigned;
        public static bool IsReal => Instance.IsReal;

        [DebuggerStepThrough]
        public static bool IsGreaterThan(T x, T y) => Instance.IsGreaterThan(x, y);

        [DebuggerStepThrough]
        public static bool IsGreaterThanOrEqualTo(T x, T y) => Instance.IsGreaterThanOrEqualTo(x, y);

        [DebuggerStepThrough]
        public static bool IsLessThan(T x, T y) => Instance.IsLessThan(x, y);

        [DebuggerStepThrough]
        public static bool IsLessThanOrEqualTo(T x, T y) => Instance.IsLessThanOrEqualTo(x, y);

        [DebuggerStepThrough]
        public static double ToDouble(T x) => Instance.ToDouble(x, 0);

        [DebuggerStepThrough]
        public static double ToDouble(T x, double offset) => Instance.ToDouble(x, offset);

        [DebuggerStepThrough]
        public static float ToSingle(T x, float offset) => Instance.ToSingle(x, offset);

        [DebuggerStepThrough]
        public static int Sign(T x) => Instance.Sign(x);

        [DebuggerStepThrough]
        public static T Abs(T x) => Instance.Abs(x);

        [DebuggerStepThrough]
        public static T Acos(T x) => Instance.Acos(x);

        [DebuggerStepThrough]
        public static T Acosh(T x) => Instance.Acosh(x);

        [DebuggerStepThrough]
        public static T Add(T x, T y) => Instance.Add(x, y);

        [DebuggerStepThrough]
        public static T Asin(T x) => Instance.Asin(x);

        [DebuggerStepThrough]
        public static T Asinh(T x) => Instance.Asinh(x);

        [DebuggerStepThrough]
        public static T Atan(T x) => Instance.Atan(x);

        [DebuggerStepThrough]
        public static T Atan2(T x, T y) => Instance.Atan2(x, y);

        [DebuggerStepThrough]
        public static T Atanh(T x) => Instance.Atanh(x);

        [DebuggerStepThrough]
        public static T Cbrt(T x) => Instance.Cbrt(x);

        [DebuggerStepThrough]
        public static T Ceiling(T x) => Instance.Ceiling(x);

        [DebuggerStepThrough]
        public static T Clamp(T x, T bound1, T bound2) => Instance.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        public static T Cos(T x) => Instance.Cos(x);

        [DebuggerStepThrough]
        public static T Cosh(T x) => Instance.Cosh(x);

        [DebuggerStepThrough]
        public static T DegreesToRadians(T x) => Instance.DegreesToRadians(x);

        [DebuggerStepThrough]
        public static T DegreesToTurns(T x) => Instance.DegreesToTurns(x);

        [DebuggerStepThrough]
        public static T Divide(T x, T y) => Instance.Divide(x, y);

        [DebuggerStepThrough]
        public static T Exp(T x) => Instance.Exp(x);

        [DebuggerStepThrough]
        public static T Floor(T x) => Instance.Floor(x);

        [DebuggerStepThrough]
        public static T IEEERemainder(T x, T y) => Instance.IEEERemainder(x, y);

        [DebuggerStepThrough]
        public static T Log(T x) => Instance.Log(x);

        [DebuggerStepThrough]
        public static T Log(T x, T y) => Instance.Log(x, y);

        [DebuggerStepThrough]
        public static T Log10(T x) => Instance.Log10(x);

        [DebuggerStepThrough]
        public static T Max(T x, T y) => Instance.Max(x, y);

        [DebuggerStepThrough]
        public static T Min(T x, T y) => Instance.Min(x, y);

        [DebuggerStepThrough]
        public static T Multiply(T x, T y) => Instance.Multiply(x, y);

        [DebuggerStepThrough]
        public static T Negative(T x) => Instance.Negative(x);

        [DebuggerStepThrough]
        public static T Positive(T x) => Instance.Positive(x);

        [DebuggerStepThrough]
        public static T Pow(T x, byte y) => Instance.Pow(x, y);

        [DebuggerStepThrough]
        public static T Pow(T x, T y) => Instance.Pow(x, y);

        [DebuggerStepThrough]
        public static T RadiansToDegrees(T x) => Instance.RadiansToDegrees(x);

        [DebuggerStepThrough]
        public static T RadiansToTurns(T x) => Instance.RadiansToTurns(x);

        [DebuggerStepThrough]
        public static T Remainder(T x, T y) => Instance.Remainder(x, y);

        [DebuggerStepThrough]
        public static T Round(T x) => Instance.Round(x);

        [DebuggerStepThrough]
        public static T Round(T x, int digits) => Instance.Round(x, digits);

        [DebuggerStepThrough]
        public static T Round(T x, int digits, MidpointRounding mode) => Instance.Round(x, digits, mode);

        [DebuggerStepThrough]
        public static T Round(T x, MidpointRounding mode) => Instance.Round(x, mode);

        [DebuggerStepThrough]
        public static T Sin(T x) => Instance.Sin(x);

        [DebuggerStepThrough]
        public static T Sinh(T x) => Instance.Sinh(x);

        [DebuggerStepThrough]
        public static T Sqrt(T x) => Instance.Sqrt(x);

        [DebuggerStepThrough]
        public static T Subtract(T x, T y) => Instance.Subtract(x, y);

        [DebuggerStepThrough]
        public static T Tan(T x) => Instance.Tan(x);

        [DebuggerStepThrough]
        public static T Tanh(T x) => Instance.Tanh(x);

        [DebuggerStepThrough]
        public static T Truncate(T x) => Instance.Truncate(x);

        [DebuggerStepThrough]
        public static T TurnsToDegrees(T x) => Instance.TurnsToDegrees(x);

        [DebuggerStepThrough]
        public static T TurnsToRadians(T x) => Instance.TurnsToRadians(x);
    }
}

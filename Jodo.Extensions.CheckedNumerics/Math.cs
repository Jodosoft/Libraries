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
using System.Runtime.CompilerServices;

namespace Jodo.Extensions.CheckedNumerics
{
    public static class Math<T> where T : struct, INumeric<T>
    {
        private static readonly IMath<T> Instance = default(T).Math;

        public static readonly T E = Instance.E;
        public static readonly T PI = Instance.PI;
        public static readonly T Epsilon = Instance.Epsilon;
        public static readonly T MaxValue = Instance.MaxValue;
        public static readonly T MinValue = Instance.MinValue;
        public static readonly T MaxUnit = Instance.MaxUnit;
        public static readonly T MinUnit = Instance.MinUnit;
        public static readonly T Zero = Instance.Zero;
        public static readonly T One = Instance.One;
        public static readonly bool IsSigned = Instance.IsSigned;
        public static readonly bool IsReal = Instance.IsReal;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsGreaterThan(in T x, in T y) => Instance.IsGreaterThan(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsGreaterThanOrEqualTo(in T x, in T y) => Instance.IsGreaterThanOrEqualTo(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsLessThan(in T x, in T y) => Instance.IsLessThan(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsLessThanOrEqualTo(in T x, in T y) => Instance.IsLessThanOrEqualTo(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double ToDouble(in T x, in double offset) => Instance.ToDouble(x, offset);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float ToSingle(in T x, in float offset) => Instance.ToSingle(x, offset);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Sign(in T x) => Instance.Sign(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Abs(in T x) => Instance.Abs(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Acos(in T x) => Instance.Acos(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Acosh(in T x) => Instance.Acosh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Add(in T x, in T y) => Instance.Add(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Asin(in T x) => Instance.Asin(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Asinh(in T x) => Instance.Asinh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Atan(in T x) => Instance.Atan(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Atan2(in T x, in T y) => Instance.Atan2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Atanh(in T x) => Instance.Atanh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Cbrt(in T x) => Instance.Cbrt(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Ceiling(in T x) => Instance.Ceiling(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Clamp(in T x, in T bound1, in T bound2) => Instance.Clamp(x, bound1, bound2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Convert(in byte value) => Instance.Convert(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Cos(in T x) => Instance.Cos(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Cosh(in T x) => Instance.Cosh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T DegreesToRadians(in T x) => Instance.DegreesToRadians(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T DegreesToTurns(in T x) => Instance.DegreesToTurns(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Divide(in T x, in T y) => Instance.Divide(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Exp(in T x) => Instance.Exp(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Floor(in T x) => Instance.Floor(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T IEEERemainder(in T x, in T y) => Instance.IEEERemainder(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Log(in T x) => Instance.Log(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Log(in T x, in T y) => Instance.Log(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Log10(in T x) => Instance.Log10(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Max(in T x, in T y) => Instance.Max(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Min(in T x, in T y) => Instance.Min(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Multiply(in T x, in T y) => Instance.Multiply(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Negative(in T x) => Instance.Negative(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Positive(in T x) => Instance.Positive(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Pow(in T x, in byte y) => Instance.Pow(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Pow(in T x, in T y) => Instance.Pow(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RadiansToDegrees(in T x) => Instance.RadiansToDegrees(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RadiansToTurns(in T x) => Instance.RadiansToTurns(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Remainder(in T x, in T y) => Instance.Remainder(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Round(in T x) => Instance.Round(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Round(in T x, in int digits) => Instance.Round(x, digits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Round(in T x, in int digits, in MidpointRounding mode) => Instance.Round(x, digits, mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Round(in T x, in MidpointRounding mode) => Instance.Round(x, mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Sin(in T x) => Instance.Sin(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Sinh(in T x) => Instance.Sinh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Sqrt(in T x) => Instance.Sqrt(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Subtract(in T x, in T y) => Instance.Subtract(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Tan(in T x) => Instance.Tan(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Tanh(in T x) => Instance.Tanh(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Truncate(in T x) => Instance.Truncate(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T TurnsToDegrees(in T x) => Instance.TurnsToDegrees(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T TurnsToRadians(in T x) => Instance.TurnsToRadians(x);
    }
}

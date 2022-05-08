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

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan(in T x, in T y) => Instance.IsGreaterThan(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEqualTo(in T x, in T y) => Instance.IsGreaterThanOrEqualTo(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan(in T x, in T y) => Instance.IsLessThan(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEqualTo(in T x, in T y) => Instance.IsLessThanOrEqualTo(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(in T x, in double offset) => Instance.ToDouble(x, offset);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle(in T x, in float offset) => Instance.ToSingle(x, offset);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(in T x) => Instance.Sign(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs(in T x) => Instance.Abs(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Acos(in T x) => Instance.Acos(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Acosh(in T x) => Instance.Acosh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add(in T x, in T y) => Instance.Add(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Asin(in T x) => Instance.Asin(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Asinh(in T x) => Instance.Asinh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atan(in T x) => Instance.Atan(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atan2(in T x, in T y) => Instance.Atan2(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atanh(in T x) => Instance.Atanh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cbrt(in T x) => Instance.Cbrt(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Ceiling(in T x) => Instance.Ceiling(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Clamp(in T x, in T bound1, in T bound2) => Instance.Clamp(x, bound1, bound2);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(in byte value) => Instance.Convert(value);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cos(in T x) => Instance.Cos(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cosh(in T x) => Instance.Cosh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DegreesToRadians(in T x) => Instance.DegreesToRadians(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DegreesToTurns(in T x) => Instance.DegreesToTurns(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Divide(in T x, in T y) => Instance.Divide(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp(in T x) => Instance.Exp(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Floor(in T x) => Instance.Floor(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IEEERemainder(in T x, in T y) => Instance.IEEERemainder(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log(in T x) => Instance.Log(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log(in T x, in T y) => Instance.Log(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log10(in T x) => Instance.Log10(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max(in T x, in T y) => Instance.Max(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min(in T x, in T y) => Instance.Min(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Multiply(in T x, in T y) => Instance.Multiply(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negative(in T x) => Instance.Negative(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Positive(in T x) => Instance.Positive(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Pow(in T x, in byte y) => Instance.Pow(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Pow(in T x, in T y) => Instance.Pow(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T RadiansToDegrees(in T x) => Instance.RadiansToDegrees(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T RadiansToTurns(in T x) => Instance.RadiansToTurns(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Remainder(in T x, in T y) => Instance.Remainder(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round(in T x) => Instance.Round(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round(in T x, in int digits) => Instance.Round(x, digits);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round(in T x, in int digits, in MidpointRounding mode) => Instance.Round(x, digits, mode);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round(in T x, in MidpointRounding mode) => Instance.Round(x, mode);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sin(in T x) => Instance.Sin(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sinh(in T x) => Instance.Sinh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sqrt(in T x) => Instance.Sqrt(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract(in T x, in T y) => Instance.Subtract(x, y);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Tan(in T x) => Instance.Tan(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Tanh(in T x) => Instance.Tanh(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Truncate(in T x) => Instance.Truncate(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T TurnsToDegrees(in T x) => Instance.TurnsToDegrees(x);

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T TurnsToRadians(in T x) => Instance.TurnsToRadians(x);
    }
}

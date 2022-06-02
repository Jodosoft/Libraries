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
using System.Diagnostics;

namespace Jodo.Extensions.Numerics
{
    public static class Math<T> where T : struct, IProvider<IMath<T>>
    {
        private static readonly IMath<T> Default = default(T).GetInstance();

        public static T E => Default.E;
        public static T PI => Default.PI;
        public static T Tau => Default.Tau;

        [DebuggerStepThrough]
        public static int Sign(T x) => Default.Sign(x);

        [DebuggerStepThrough]
        public static T Abs(T x) => Default.Abs(x);

        [DebuggerStepThrough]
        public static T Acos(T x) => Default.Acos(x);

        [DebuggerStepThrough]
        public static T Acosh(T x) => Default.Acosh(x);

        [DebuggerStepThrough]
        public static T Asin(T x) => Default.Asin(x);

        [DebuggerStepThrough]
        public static T Asinh(T x) => Default.Asinh(x);

        [DebuggerStepThrough]
        public static T Atan(T x) => Default.Atan(x);

        [DebuggerStepThrough]
        public static T Atan2(T x, T y) => Default.Atan2(x, y);

        [DebuggerStepThrough]
        public static T Atanh(T x) => Default.Atanh(x);

        [DebuggerStepThrough]
        public static T Cbrt(T x) => Default.Cbrt(x);

        [DebuggerStepThrough]
        public static T Ceiling(T x) => Default.Ceiling(x);

        [DebuggerStepThrough]
        public static T Clamp(T x, T bound1, T bound2) => Default.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        public static T Cos(T x) => Default.Cos(x);

        [DebuggerStepThrough]
        public static T Cosh(T x) => Default.Cosh(x);

        [DebuggerStepThrough]
        public static T DegreesToRadians(T x) => Default.DegreesToRadians(x);

        [DebuggerStepThrough]
        public static T Exp(T x) => Default.Exp(x);

        [DebuggerStepThrough]
        public static T Floor(T x) => Default.Floor(x);

        [DebuggerStepThrough]
        public static T IEEERemainder(T x, T y) => Default.IEEERemainder(x, y);

        [DebuggerStepThrough]
        public static T Log(T x) => Default.Log(x);

        [DebuggerStepThrough]
        public static T Log(T x, T y) => Default.Log(x, y);

        [DebuggerStepThrough]
        public static T Log10(T x) => Default.Log10(x);

        [DebuggerStepThrough]
        public static T Max(T x, T y) => Default.Max(x, y);

        [DebuggerStepThrough]
        public static T Min(T x, T y) => Default.Min(x, y);

        [DebuggerStepThrough]
        public static T Pow(T x, T y) => Default.Pow(x, y);

        [DebuggerStepThrough]
        public static T RadiansToDegrees(T x) => Default.RadiansToDegrees(x);

        [DebuggerStepThrough]
        public static T Round(T x) => Default.Round(x);

        [DebuggerStepThrough]
        public static T Round(T x, int digits) => Default.Round(x, digits);

        [DebuggerStepThrough]
        public static T Round(T x, int digits, MidpointRounding mode) => Default.Round(x, digits, mode);

        [DebuggerStepThrough]
        public static T Round(T x, MidpointRounding mode) => Default.Round(x, mode);

        [DebuggerStepThrough]
        public static T Sin(T x) => Default.Sin(x);

        [DebuggerStepThrough]
        public static T Sinh(T x) => Default.Sinh(x);

        [DebuggerStepThrough]
        public static T Sqrt(T x) => Default.Sqrt(x);

        [DebuggerStepThrough]
        public static T Tan(T x) => Default.Tan(x);

        [DebuggerStepThrough]
        public static T Tanh(T x) => Default.Tanh(x);

        [DebuggerStepThrough]
        public static T Truncate(T x) => Default.Truncate(x);
    }
}

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
    [SuppressMessage("csharpsquid", "S2743")]
    public static class Math<N> where N : struct, INumeric<N>
    {
        private static readonly IMath<N> Instance = default(N).Math;

        public static N E => Instance.E;
        public static N PI => Instance.PI;
        public static N Tau => Instance.Tau;

        [DebuggerStepThrough]
        public static int Sign(N x) => Instance.Sign(x);

        [DebuggerStepThrough]
        public static N Abs(N x) => Instance.Abs(x);

        [DebuggerStepThrough]
        public static N Acos(N x) => Instance.Acos(x);

        [DebuggerStepThrough]
        public static N Acosh(N x) => Instance.Acosh(x);

        [DebuggerStepThrough]
        public static N Asin(N x) => Instance.Asin(x);

        [DebuggerStepThrough]
        public static N Asinh(N x) => Instance.Asinh(x);

        [DebuggerStepThrough]
        public static N Atan(N x) => Instance.Atan(x);

        [DebuggerStepThrough]
        public static N Atan2(N x, N y) => Instance.Atan2(x, y);

        [DebuggerStepThrough]
        public static N Atanh(N x) => Instance.Atanh(x);

        [DebuggerStepThrough]
        public static N Cbrt(N x) => Instance.Cbrt(x);

        [DebuggerStepThrough]
        public static N Ceiling(N x) => Instance.Ceiling(x);

        [DebuggerStepThrough]
        public static N Clamp(N x, N bound1, N bound2) => Instance.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        public static N Cos(N x) => Instance.Cos(x);

        [DebuggerStepThrough]
        public static N Cosh(N x) => Instance.Cosh(x);

        [DebuggerStepThrough]
        public static N DegreesToRadians(N x) => Instance.DegreesToRadians(x);

        [DebuggerStepThrough]
        public static N Exp(N x) => Instance.Exp(x);

        [DebuggerStepThrough]
        public static N Floor(N x) => Instance.Floor(x);

        [DebuggerStepThrough]
        public static N IEEERemainder(N x, N y) => Instance.IEEERemainder(x, y);

        [DebuggerStepThrough]
        public static N Log(N x) => Instance.Log(x);

        [DebuggerStepThrough]
        public static N Log(N x, N y) => Instance.Log(x, y);

        [DebuggerStepThrough]
        public static N Log10(N x) => Instance.Log10(x);

        [DebuggerStepThrough]
        public static N Max(N x, N y) => Instance.Max(x, y);

        [DebuggerStepThrough]
        public static N Min(N x, N y) => Instance.Min(x, y);

        [DebuggerStepThrough]
        public static N Pow(N x, N y) => Instance.Pow(x, y);

        [DebuggerStepThrough]
        public static N RadiansToDegrees(N x) => Instance.RadiansToDegrees(x);

        [DebuggerStepThrough]
        public static N Round(N x) => Instance.Round(x);

        [DebuggerStepThrough]
        public static N Round(N x, int digits) => Instance.Round(x, digits);

        [DebuggerStepThrough]
        public static N Round(N x, int digits, MidpointRounding mode) => Instance.Round(x, digits, mode);

        [DebuggerStepThrough]
        public static N Round(N x, MidpointRounding mode) => Instance.Round(x, mode);

        [DebuggerStepThrough]
        public static N RoundToSignificance(N x, int significantDigits, MidpointRounding mode) => Instance.RoundToSignificance(x, significantDigits, mode);

        [DebuggerStepThrough]
        public static N Sin(N x) => Instance.Sin(x);

        [DebuggerStepThrough]
        public static N Sinh(N x) => Instance.Sinh(x);

        [DebuggerStepThrough]
        public static N Sqrt(N x) => Instance.Sqrt(x);

        [DebuggerStepThrough]
        public static N Tan(N x) => Instance.Tan(x);

        [DebuggerStepThrough]
        public static N Tanh(N x) => Instance.Tanh(x);

        [DebuggerStepThrough]
        public static N Truncate(N x) => Instance.Truncate(x);

        [DebuggerStepThrough]
        public static N TruncateToSignificance(N x, int significantDigits) => Instance.TruncateToSignificance(x, significantDigits);
    }
}

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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Extensions.Numerics
{
    [SuppressMessage("csharpsquid", "S2743")]
    public static class Numeric<N> where N : struct, INumeric<N>
    {
        private static readonly INumericFunctions<N> Instance = default(N).NumericFunctions;

        public static bool IsReal => Instance.IsReal;
        public static bool IsSigned => Instance.IsSigned;
        public static N Epsilon => Instance.Epsilon;
        public static N MaxUnit => Instance.MaxUnit;
        public static N MaxValue => Instance.MaxValue;
        public static N MinUnit => Instance.MinUnit;
        public static N MinValue => Instance.MinValue;
        public static N One => Instance.One;
        public static N Ten => Instance.Ten;
        public static N Two => Instance.Two;
        public static N Zero => Instance.Zero;

        [DebuggerStepThrough]
        public static bool IsFinite(N x) => Instance.IsFinite(x);

        [DebuggerStepThrough]
        public static bool IsInfinity(N x) => Instance.IsInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNaN(N x) => Instance.IsNaN(x);

        [DebuggerStepThrough]
        public static bool IsNegative(N x) => Instance.IsNegative(x);

        [DebuggerStepThrough]
        public static bool IsNegativeInfinity(N x) => Instance.IsNegativeInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNormal(N x) => Instance.IsNormal(x);

        [DebuggerStepThrough]
        public static bool IsPositiveInfinity(N x) => Instance.IsPositiveInfinity(x);

        [DebuggerStepThrough]
        public static bool IsSubnormal(N x) => Instance.IsSubnormal(x);
    }
}

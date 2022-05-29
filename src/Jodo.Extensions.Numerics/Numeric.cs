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
        private static readonly INumericFunctions<N> Default = default(N).NumericFunctions;

        public static bool HasFloatingPoint => Default.HasFloatingPoint;
        public static bool IsReal => Default.IsReal;
        public static bool IsSigned => Default.IsSigned;
        public static N Epsilon => Default.Epsilon;
        public static N MaxUnit => Default.MaxUnit;
        public static N MaxValue => Default.MaxValue;
        public static N MinUnit => Default.MinUnit;
        public static N MinValue => Default.MinValue;
        public static N One => Default.One;
        public static N Ten => Default.Ten;
        public static N Two => Default.Two;
        public static N Zero => Default.Zero;

        [DebuggerStepThrough]
        public static bool IsFinite(N x) => Default.IsFinite(x);

        [DebuggerStepThrough]
        public static bool IsInfinity(N x) => Default.IsInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNaN(N x) => Default.IsNaN(x);

        [DebuggerStepThrough]
        public static bool IsNegative(N x) => Default.IsNegative(x);

        [DebuggerStepThrough]
        public static bool IsNegativeInfinity(N x) => Default.IsNegativeInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNormal(N x) => Default.IsNormal(x);

        [DebuggerStepThrough]
        public static bool IsPositiveInfinity(N x) => Default.IsPositiveInfinity(x);

        [DebuggerStepThrough]
        public static bool IsSubnormal(N x) => Default.IsSubnormal(x);
    }
}

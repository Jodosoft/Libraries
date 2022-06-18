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
using Jodo.Primitives;

namespace Jodo.Numerics
{
    [SuppressMessage("csharpsquid", "S2743")]
    public static class Numeric<T> where T : struct, IProvider<INumericStatic<T>>
    {
        private static readonly INumericStatic<T> Default = default(T).GetInstance();

        public static bool HasFloatingPoint => Default.HasFloatingPoint;
        public static bool HasInfinity => Default.HasInfinity;
        public static bool HasNaN => Default.HasNaN;
        public static bool IsReal => Default.IsReal;
        public static bool IsSigned => Default.IsSigned;
        public static T Epsilon => Default.Epsilon;
        public static T MaxUnit => Default.MaxUnit;
        public static T MaxValue => Default.MaxValue;
        public static T MinUnit => Default.MinUnit;
        public static T MinValue => Default.MinValue;
        public static T One => Default.One;
        public static T Ten => Default.Ten;
        public static T Two => Default.Two;
        public static T Zero => Default.Zero;

        [DebuggerStepThrough]
        public static bool IsFinite(T x) => Default.IsFinite(x);

        [DebuggerStepThrough]
        public static bool IsInfinity(T x) => Default.IsInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNaN(T x) => Default.IsNaN(x);

        [DebuggerStepThrough]
        public static bool IsNegative(T x) => Default.IsNegative(x);

        [DebuggerStepThrough]
        public static bool IsNegativeInfinity(T x) => Default.IsNegativeInfinity(x);

        [DebuggerStepThrough]
        public static bool IsNormal(T x) => Default.IsNormal(x);

        [DebuggerStepThrough]
        public static bool IsPositiveInfinity(T x) => Default.IsPositiveInfinity(x);

        [DebuggerStepThrough]
        public static bool IsSubnormal(T x) => Default.IsSubnormal(x);
    }
}

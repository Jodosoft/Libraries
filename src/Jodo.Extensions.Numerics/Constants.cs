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

using System.Diagnostics.CodeAnalysis;

namespace Jodo.Extensions.Numerics
{
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S2743")]
    public static class Constants<N> where N : struct, INumeric<N>
    {
        private static readonly IConstants<N> Instance = default(N).Constants;

        public static bool IsReal => Instance.IsReal;
        public static bool IsSigned => Instance.IsSigned;
        public static N Epsilon => Instance.Epsilon;
        public static N MaxUnit => Instance.MaxUnit;
        public static N MaxValue => Instance.MaxValue;
        public static N MinUnit => Instance.MinUnit;
        public static N MinValue => Instance.MinValue;
        public static N One => Instance.One;
        public static N Zero => Instance.Zero;
    }
}

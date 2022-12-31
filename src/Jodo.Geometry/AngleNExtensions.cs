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

using Jodo.Numerics;

namespace Jodo.Geometry
{
    public static class AngleNExtensions
    {
        public static TNumeric GetRadians<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => AngleN.DegreesToRadians(angle.Degrees);

        public static TNumeric Cos<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Cos(angle.GetRadians());

        public static TNumeric Cosh<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Cosh(angle.GetRadians());

        public static TNumeric Sin<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Sin(angle.GetRadians());

        public static TNumeric Sinh<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Sinh(angle.GetRadians());

        public static TNumeric Tan<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Tan(angle.GetRadians());

        public static TNumeric Tanh<TNumeric>(this AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Tanh(angle.GetRadians());
    }
}

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
using Jodo.Numerics;

namespace Jodo.Geometry
{
    [CLSCompliant(false)]
    public static class TwoDimensionalExtensions
    {
        public static T Translate<T, N>(this T value, (N, N) delta)
                where T : struct, ITwoDimensional<T, N>
                where N : struct, INumeric<N>
            => value.Translate((Vector2<N>)delta);

        public static T Translate<T, N>(this T value, N deltaX, N deltaY)
                where T : struct, ITwoDimensional<T, N>
                where N : struct, INumeric<N>
            => value.Translate(new Vector2<N>(deltaX, deltaY));
    }
}

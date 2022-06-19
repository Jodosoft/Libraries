﻿// Copyright (c) 2022 Joseph J. Short
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
    public interface ITwoDimensional<T, N> where N : struct, INumeric<N>
    {
        AARectangle<N> GetBounds();
        bool Contains(T other);
        bool Contains(Vector2<N> point);
        bool IntersectsWith(T other);
        N GetArea();
        Vector2<N>[] GetVertices(int circumferenceDivisor);
        Vector2<N> GetCenter();
        T Translate(Vector2<N> delta);

        /*
         * Upcoming: 
         * 
         * T FlipHorizontally();
         * T FlipVertically();
         * T RotateLeft();
         * T RotateLeft(Vector2<N> pivot);
         * T RotateRight();
         * T RotateRight(Vector2<N> pivot);
         * T SnapToGrid(N gridDimensions);
         * T SnapToGrid(Vector2<N> gridDimensions);
         * T UnitTranslate(Vector2<N> delta);
         * T Grow(Vector2<N> scalar); //stretch, shrink, inflate
         * T Grow(N scalar); //stretch, shrink, inflate
        */
    }
}
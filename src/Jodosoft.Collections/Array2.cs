﻿// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Collections
{
    public static class Array2
    {
        public static Array2<T> Empty<T>() => Array2<T>.Empty;
    }

    public sealed class Array2<T> : IReadOnlyArray2<T>
    {
        public static readonly Array2<T> Empty = new Array2<T>(0, 0);

        private readonly T[] _array;

        public int Length => _array.Length;
        public int LengthX { get; }
        public int LengthY { get; }

        public T this[int x, int y]
        {
            get => _array[(y * LengthX) + x];
            set => _array[(y * LengthX) + x] = value;
        }

        public Array2(int lengthX, int lengthY)
        {
            _array = new T[lengthX * lengthY];
            LengthX = lengthX;
            LengthY = lengthY;
        }

#if HAS_SPANS
        public ReadOnlySpan<T> AsSpan() => _array.AsSpan();
        public ReadOnlyMemory<T> AsMemory() => _array.AsMemory();
#endif

        public T[] ToArray()
        {
            T[]? copy = new T[_array.Length];
            Array.Copy(_array, copy, _array.Length);
            return copy;
        }

        public override bool Equals(object? obj) => _array.Equals(obj);
        public override int GetHashCode() => _array.GetHashCode();
    }
}

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

using Jodo.Extensions.CheckedNumerics;

namespace System
{
    public static class RandomExtensions
    {
        public static T NextNumeric<T>(this Random random) where T : struct, INumeric<T>
            => default(T).GetNext(random, default(T).MinValue, default(T).MaxValue);

        public static T NextNumeric<T>(this Random random, T bound1, T bound2) where T : struct, INumeric<T>
            => default(T).GetNext(random, bound1, bound2);

        public static fix64 NextFix64(this Random random, fix64 minValue, fix64 maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            return fix64.FromInternalRepresentation(
                random.NextInt64(fix64.GetInternalRepresentation(minValue), fix64.GetInternalRepresentation(maxValue)));
        }

        public static fix64 NextFix64(this Random random)
            => fix64.FromBytes(random.NextBytes(64));

    }
}

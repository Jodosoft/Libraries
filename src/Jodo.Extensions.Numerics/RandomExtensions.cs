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

using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;

namespace System
{
    public static class RandomExtensions
    {
        public static N NextNumeric<N>(this Random random) where N : struct, INumeric<N>
            => default(N).Random.Next(random, Math<N>.MinValue, Math<N>.MaxValue);

        public static N NextNumeric<N>(this Random random, N bound1, N bound2) where N : struct, INumeric<N>
            => default(N).Random.Next(random, bound1, bound2);

        public static N NextNumeric<N>(this Random random, byte bound1, byte bound2) where N : struct, INumeric<N>
            => default(N).Random.Next(random, Convert<N>.ToValue(bound1), Convert<N>.ToValue(bound2));

        public static N NextNumeric<N>(this Random random, double bound1, double bound2) where N : struct, INumeric<N>
        {
            bound1 = Math.Clamp(bound1, Math<N>.MinValue.ToDouble(), Math<N>.MaxValue.ToDouble());
            bound2 = Math.Clamp(bound2, Math<N>.MinValue.ToDouble(), Math<N>.MaxValue.ToDouble());
            return random.NextNumeric(Convert<N>.ToValue(bound1), Convert<N>.ToValue(bound2));
        }
    }
}

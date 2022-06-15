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

using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using System.Diagnostics;

namespace System
{
    public static class RandomExtensions
    {
        [DebuggerStepThrough]
        public static N NextNumeric<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<N>>)default(N)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static N NextNumeric<N>(this Random random, N bound1, N bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<N>>)default(N)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Unit<N> NextUnit<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Unit<N>>>)default(Unit<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Unit<N> NextUnit<N>(this Random random, Unit<N> bound1, Unit<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Unit<N>>>)default(Unit<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Vector2<N> NextVector2<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Vector2<N>>>)default(Vector2<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Vector2<N> NextVector2<N>(this Random random, Vector2<N> bound1, Vector2<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Vector2<N>>>)default(Vector2<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Vector3<N> NextVector3<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Vector3<N>>>)default(Vector3<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Vector3<N> NextVector3<N>(this Random random, Vector3<N> bound1, Vector3<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Vector3<N>>>)default(Vector3<N>)).GetInstance().Next(random, bound1, bound2);
    }
}

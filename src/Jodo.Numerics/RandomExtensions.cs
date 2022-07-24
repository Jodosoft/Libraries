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
using System.Diagnostics;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class RandomExtensions
    {
        [DebuggerStepThrough]
        public static TNumeric NextNumeric<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<TNumeric>>)default(TNumeric)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static TNumeric NextNumeric<TNumeric>(this Random random, TNumeric bound1, TNumeric bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<TNumeric>>)default(TNumeric)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Unit<TNumeric> NextUnit<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Unit<TNumeric>>>)default(Unit<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Unit<TNumeric> NextUnit<TNumeric>(this Random random, Unit<TNumeric> bound1, Unit<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Unit<TNumeric>>>)default(Unit<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Vector2<TNumeric> NextVector2<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Vector2<TNumeric>>>)default(Vector2<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Vector2<TNumeric> NextVector2<TNumeric>(this Random random, Vector2<TNumeric> bound1, Vector2<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Vector2<TNumeric>>>)default(Vector2<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Vector3<TNumeric> NextVector3<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Vector3<TNumeric>>>)default(Vector3<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Vector3<TNumeric> NextVector3<TNumeric>(this Random random, Vector3<TNumeric> bound1, Vector3<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Vector3<TNumeric>>>)default(Vector3<TNumeric>)).GetInstance().Next(random, bound1, bound2);
    }
}

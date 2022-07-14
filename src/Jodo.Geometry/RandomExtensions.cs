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
using Jodo.Numerics;
using Jodo.Primitives;

namespace Jodo.Geometry
{
    public static class RandomExtensions
    {
        [DebuggerStepThrough]
        public static AARectangle<N> NextAARectangle<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<AARectangle<N>>>)default(AARectangle<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static AARectangle<N> NextAARectangle<N>(this Random random, AARectangle<N> bound1, AARectangle<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<AARectangle<N>>>)default(AARectangle<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Angle<N> NextAngle<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Angle<N>>>)default(Angle<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Angle<N> NextAngle<N>(this Random random, Angle<N> bound1, Angle<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Angle<N>>>)default(Angle<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Circle<N> NextCircle<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Circle<N>>>)default(Circle<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Circle<N> NextCircle<N>(this Random random, Circle<N> bound1, Circle<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Circle<N>>>)default(Circle<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Rectangle<N> NextRectangle<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Rectangle<N>>>)default(Rectangle<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Rectangle<N> NextRectangle<N>(this Random random, Rectangle<N> bound1, Rectangle<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Rectangle<N>>>)default(Rectangle<N>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Triangle<N> NextTriangle<N>(this Random random) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Triangle<N>>>)default(Triangle<N>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Triangle<N> NextTriangle<N>(this Random random, Triangle<N> bound1, Triangle<N> bound2) where N : struct, INumeric<N>
            => ((IProvider<IRandom<Triangle<N>>>)default(Triangle<N>)).GetInstance().Next(random, bound1, bound2);
    }
}

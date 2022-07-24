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
        public static AARectangle<TNumeric> NextAARectangle<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<AARectangle<TNumeric>>>)default(AARectangle<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static AARectangle<TNumeric> NextAARectangle<TNumeric>(this Random random, AARectangle<TNumeric> bound1, AARectangle<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<AARectangle<TNumeric>>>)default(AARectangle<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Angle<TNumeric> NextAngle<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Angle<TNumeric>>>)default(Angle<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Angle<TNumeric> NextAngle<TNumeric>(this Random random, Angle<TNumeric> bound1, Angle<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Angle<TNumeric>>>)default(Angle<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Circle<TNumeric> NextCircle<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Circle<TNumeric>>>)default(Circle<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Circle<TNumeric> NextCircle<TNumeric>(this Random random, Circle<TNumeric> bound1, Circle<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Circle<TNumeric>>>)default(Circle<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Rectangle<TNumeric> NextRectangle<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Rectangle<TNumeric>>>)default(Rectangle<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Rectangle<TNumeric> NextRectangle<TNumeric>(this Random random, Rectangle<TNumeric> bound1, Rectangle<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Rectangle<TNumeric>>>)default(Rectangle<TNumeric>)).GetInstance().Next(random, bound1, bound2);

        [DebuggerStepThrough]
        public static Triangle<TNumeric> NextTriangle<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Triangle<TNumeric>>>)default(Triangle<TNumeric>)).GetInstance().Next(random);

        [DebuggerStepThrough]
        public static Triangle<TNumeric> NextTriangle<TNumeric>(this Random random, Triangle<TNumeric> bound1, Triangle<TNumeric> bound2) where TNumeric : struct, INumeric<TNumeric>
            => ((IProvider<IRandom<Triangle<TNumeric>>>)default(Triangle<TNumeric>)).GetInstance().Next(random, bound1, bound2);
    }
}

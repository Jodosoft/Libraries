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

using Jodo.Extensions.CheckedGeometry;
using Jodo.Extensions.CheckedNumerics;

namespace System
{
    public static class RandomExtensions
    {

        public static T NextGeometric<T>(this Random random) where T : struct, IGeometric<T>
            => throw new NotImplementedException();

        public static Angle<T> NextAngle<T>(this Random random) where T : struct, INumeric<T>
            => Angle<T>.FromRadians(random.NextNumeric<T>());

        public static Unit<T> NextUnit<T>(this Random random) where T : struct, INumeric<T>
            => (Unit<T>)random.NextNumeric(Math<T>.MinUnit, Math<T>.MaxUnit);

        public static Circle<T> NextCircle<T>(this Random random) where T : struct, INumeric<T>
            => new Circle<T>(random.NextNumeric<T>(), random.NextNumeric<T>(), random.NextNumeric<T>());

        public static Vector2<T> NextVector2<T>(this Random random) where T : struct, INumeric<T>
            => new Vector2<T>(random.NextNumeric<T>(), random.NextNumeric<T>());

        public static Vector2<T> NextVector2<T>(this Random random, T minValue, T maxValue) where T : struct, INumeric<T>
            => new Vector2<T>(random.NextNumeric(minValue, maxValue), random.NextNumeric(minValue, maxValue));

        public static AARectangle<T> NextAARectangle<T>(this Random random) where T : struct, INumeric<T>
            => AARectangle<T>.FromCenter((random.NextNumeric<T>(), random.NextNumeric<T>()), (random.NextNumeric<T>(), random.NextNumeric<T>()));

        public static Rectangle<T> NextRectangle<T>(this Random random) where T : struct, INumeric<T>
            => new Rectangle<T>((random.NextNumeric<T>(), random.NextNumeric<T>()), (random.NextNumeric<T>(), random.NextNumeric<T>()), random.NextAngle<T>());
    }
}

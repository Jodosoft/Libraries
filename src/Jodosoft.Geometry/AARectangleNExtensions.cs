// Copyright (c) 2023 Joe Lawry-Short
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

using System.Runtime.CompilerServices;
using Jodosoft.Numerics;

namespace Jodosoft.Geometry
{
    public static class AARectangleNExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetBottom<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottom(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetLeft<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetRight<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetTop<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTop(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomCenter<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomLeft<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomRight<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetLeftCenter<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetLeftCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetRightCenter<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetRightCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopCenter<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopLeft<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopRight<TNumeric>(this AARectangleN<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Grow<TNumeric>(this AARectangleN<TNumeric> value, Vector2N<TNumeric> delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(value.Center, value.Dimensions + delta);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Grow<TNumeric>(this AARectangleN<TNumeric> value, TNumeric deltaX, TNumeric deltaY) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Grow(new Vector2N<TNumeric>(deltaX, deltaY));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Grow<TNumeric>(this AARectangleN<TNumeric> value, TNumeric delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Grow(new Vector2N<TNumeric>(delta, delta));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Shrink<TNumeric>(this AARectangleN<TNumeric> value, Vector2N<TNumeric> delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(value.Center, value.Dimensions - delta);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Shrink<TNumeric>(this AARectangleN<TNumeric> value, TNumeric deltaX, TNumeric deltaY) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Shrink(new Vector2N<TNumeric>(deltaX, deltaY));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Shrink<TNumeric>(this AARectangleN<TNumeric> value, TNumeric delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Shrink(new Vector2N<TNumeric>(delta, delta));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> Rotate<TNumeric>(this AARectangleN<TNumeric> value, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(value.Center, value.Dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> RotateAround<TNumeric>(this AARectangleN<TNumeric> value, Vector2N<TNumeric> pivot, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(value.Center.RotateAround(pivot, angle), value.Dimensions, angle);
        }
    }
}

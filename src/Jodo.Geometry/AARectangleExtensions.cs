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

using System.Runtime.CompilerServices;
using Jodo.Numerics;

namespace Jodo.Geometry
{
    public static class AARectangleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetBottom<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetBottom(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetLeft<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetRight<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric GetTop<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetTop(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomCenter<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetBottomCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomLeft<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetBottomLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomRight<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetBottomRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetLeftCenter<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetLeftCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetRightCenter<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetRightCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopCenter<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetTopCenter(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopLeft<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetTopLeft(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopRight<TNumeric>(this AARectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangle.GetTopRight(value.Center, value.Dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Grow<TNumeric>(this AARectangle<TNumeric> value, Vector2N<TNumeric> delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(value.Center, value.Dimensions + delta);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Grow<TNumeric>(this AARectangle<TNumeric> value, TNumeric deltaX, TNumeric deltaY) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Grow(new Vector2N<TNumeric>(deltaX, deltaY));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Grow<TNumeric>(this AARectangle<TNumeric> value, TNumeric delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Grow(new Vector2N<TNumeric>(delta, delta));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Shrink<TNumeric>(this AARectangle<TNumeric> value, Vector2N<TNumeric> delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(value.Center, value.Dimensions - delta);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Shrink<TNumeric>(this AARectangle<TNumeric> value, TNumeric deltaX, TNumeric deltaY) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Shrink(new Vector2N<TNumeric>(deltaX, deltaY));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Shrink<TNumeric>(this AARectangle<TNumeric> value, TNumeric delta) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Shrink(new Vector2N<TNumeric>(delta, delta));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle<TNumeric> Rotate<TNumeric>(this AARectangle<TNumeric> value, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Rectangle<TNumeric>(value.Center, value.Dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle<TNumeric> RotateAround<TNumeric>(this AARectangle<TNumeric> value, Vector2N<TNumeric> pivot, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Rectangle<TNumeric>(value.Center.RotateAround(pivot, angle), value.Dimensions, angle);
        }
    }
}

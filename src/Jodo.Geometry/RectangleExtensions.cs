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
    public static class RectangleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TNumeric GetLeftAxisAligned<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Center.X.Subtract(value.Width.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TNumeric GetRightAxisAligned<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.GetLeftAxisAligned().Add(value.Dimensions.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TNumeric GetBottomAxisAligned<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.Center.Y.Subtract(value.Height.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TNumeric GetTopAxisAligned<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value.GetBottomAxisAligned().Add(value.Dimensions.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomCenter<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.Center.X, value.GetBottomAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomLeft<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetLeftAxisAligned(), value.GetBottomAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetBottomRight<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetRightAxisAligned(), value.GetBottomAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetLeftCenter<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetLeftAxisAligned(), value.Center.Y)
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetRightCenter<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetRightAxisAligned(), value.Center.Y)
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopCenter<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.Center.X, value.GetTopAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopLeft<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetLeftAxisAligned(), value.GetTopAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> GetTopRight<TNumeric>(this Rectangle<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.GetRightAxisAligned(), value.GetTopAxisAligned())
                .RotateAround(value.Center, value.Angle);
        }
    }
}

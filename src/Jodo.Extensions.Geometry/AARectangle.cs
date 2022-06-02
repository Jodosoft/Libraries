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
using System;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct AARectangle<N> : IGeometric<AARectangle<N>> where N : struct, INumeric<N>
    {
        public readonly Vector2<N> Center;
        public readonly Vector2<N> Dimensions;

        public N Area => Math<N>.Abs(Dimensions.X * Dimensions.Y);
        public N Bottom => Center.Y - (Dimensions.Y / Primitives.Convert<N>.ToValue(2));
        public N Height => Dimensions.Y;
        public N Left => Center.X - (Dimensions.X / Primitives.Convert<N>.ToValue(2));
        public N Right => Center.X + (Dimensions.X / Primitives.Convert<N>.ToValue(2));
        public N Top => Center.Y + (Dimensions.Y / Primitives.Convert<N>.ToValue(2));
        public N Width => Dimensions.X;

        public Vector2<N> BottomCenter => GetBottomCenter(Center, Dimensions);
        public Vector2<N> BottomLeft => GetBottomLeft(Center, Dimensions);
        public Vector2<N> BottomRight => GetBottomRight(Center, Dimensions);
        public Vector2<N> LeftCenter => GetLeftCenter(Center, Dimensions);
        public Vector2<N> RightCenter => GetRightCenter(Center, Dimensions);
        public Vector2<N> TopCenter => GetTopCenter(Center, Dimensions);
        public Vector2<N> TopLeft => GetTopLeft(Center, Dimensions);
        public Vector2<N> TopRight => GetTopRight(Center, Dimensions);


        private AARectangle(Vector2<N> center, Vector2<N> dimensions)
        {
            Center = center;
            Dimensions = dimensions;
        }

        private AARectangle(N centerX, N centerY, N width, N height)
        {
            Center = new Vector2<N>(centerX, centerY);
            Dimensions = new Vector2<N>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(Dimensions), typeof(Vector2<N>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<N>));
        }

        public AARectangle<N> Grow(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions + delta);
        public AARectangle<N> Grow((N, N) delta) => Grow((Vector2<N>)delta);
        public AARectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public AARectangle<N> Shrink(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions - delta);
        public AARectangle<N> Shrink((N, N) delta) => Shrink((Vector2<N>)delta);
        public AARectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public AARectangle<N> Translate(Vector2<N> delta) => new AARectangle<N>(Center + delta, Dimensions);
        public AARectangle<N> Translate((N, N) delta) => Translate((Vector2<N>)delta);
        public AARectangle<N> Translate(N deltaX, N deltaY) => Translate(new Vector2<N>(deltaX, deltaY));

        public bool Contains(Vector2<N> delta) => delta.X >= Left && delta.X <= Right && delta.Y >= Bottom && delta.Y <= Top;
        public bool Contains((N, N) delta) => Contains((Vector2<N>)delta);
        public bool Contains(N deltaX, N deltaY) => Contains(new Vector2<N>(deltaX, deltaY));

        public bool Contains(AARectangle<N> other) => IntersectsWith(other); // jjs
        public bool IntersectsWith(AARectangle<N> other) => Left < other.Right && Right > other.Left && Bottom < other.Top && Top > other.Bottom;

        public AARectangle<N> Rotate90() => new AARectangle<N>(Center, (Dimensions.Y, Dimensions.X));
        public AARectangle<N> Rotate90(Vector2<N> pivot) => new AARectangle<N>(Center.RotateAround(pivot, Angle<N>.C90Degrees), (Dimensions.Y, Dimensions.X));

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(Center, Dimensions, angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Center.RotateAround(pivot, angle), Dimensions, angle);

        public (N, N, N, N) Convert() => this;
        public AARectangle<TOther> Convert<TOther>(Func<N, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<N> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<N> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Dimensions);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static AARectangle<N> FromCenter(Vector2<N> center, Vector2<N> dimensions) => new AARectangle<N>(center, dimensions);
        public static AARectangle<N> FromBottomLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromLeftCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromRightCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomLeft(bottomLeft, dimensions), dimensions);

        private static Vector2<N> GetBottomCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetBottomLeft(Vector2<N> center, Vector2<N> dimensions) => center - (dimensions / Numeric<N>.Two);
        private static Vector2<N> GetBottomRight(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y - (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetLeftCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y);
        private static Vector2<N> GetRightCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y);
        private static Vector2<N> GetTopCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetTopLeft(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetTopRight(Vector2<N> center, Vector2<N> dimensions) => center + (dimensions / Numeric<N>.Two);

        public static bool operator ==(AARectangle<N> left, AARectangle<N> right) => left.Equals(right);
        public static bool operator !=(AARectangle<N> left, AARectangle<N> right) => !(left == right);
        public static implicit operator AARectangle<N>((N, N, N, N) value) => new AARectangle<N>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (N, N, N, N)(AARectangle<N> value) => (value.Center.X, value.Center.Y, value.Dimensions.X, value.Dimensions.Y);
        public static implicit operator AARectangle<N>((Vector2<N>, Vector2<N>) value) => new AARectangle<N>(value.Item1, value.Item2);
        public static implicit operator (Vector2<N>, Vector2<N>)(AARectangle<N> value) => (value.Center, value.Dimensions);
    }
}

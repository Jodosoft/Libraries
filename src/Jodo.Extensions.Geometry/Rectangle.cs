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
using System.Linq;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Rectangle<N> : IGeometric<Rectangle<N>> where N : struct, INumeric<N>
    {
        public readonly Vector2<N> Center;
        public readonly Vector2<N> Dimensions;
        public readonly Angle<N> Angle;

        public Rectangle(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle)
        {
            Center = center;
            Dimensions = dimensions;
            Angle = angle;
        }

        public Rectangle(N centerX, N centerY, N width, N height, N degrees)
        {
            Center = new Vector2<N>(centerX, centerY);
            Dimensions = new Vector2<N>(width, height);
            Angle = Angle<N>.FromDegrees(degrees);
        }

        private Rectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(Dimensions), typeof(Vector2<N>)),
            (Angle<N>)info.GetValue(nameof(Angle), typeof(Angle<N>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<N>));
            info.AddValue(nameof(Angle), Angle, typeof(Angle<N>));
        }

        public bool Equals(Rectangle<N> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions) && Angle.Equals(other.Angle);
        public override bool Equals(object? obj) => obj is Rectangle<N> rectangle && Equals(rectangle);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions, Angle);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Dimensions, Angle);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public N Area => Math<N>.Abs(Width * Height);
        public N Height => Dimensions.Y;
        public N Width => Dimensions.X;

        public Vector2<N> BottomCenter => GetBottomCenter(Center, Dimensions, Angle);
        public Vector2<N> BottomLeft => GetBottomLeft(Center, Dimensions, Angle);
        public Vector2<N> BottomRight => GetBottomRight(Center, Dimensions, Angle);
        public Vector2<N> LeftCenter => GetLeftCenter(Center, Dimensions, Angle);
        public Vector2<N> RightCenter => GetRightCenter(Center, Dimensions, Angle);
        public Vector2<N> TopCenter => GetTopCenter(Center, Dimensions, Angle);
        public Vector2<N> TopLeft => GetTopLeft(Center, Dimensions, Angle);
        public Vector2<N> TopRight => GetTopRight(Center, Dimensions, Angle);

        IBitConverter<Rectangle<N>> IBitConvertible<Rectangle<N>>.BitConverter => throw new NotImplementedException();

        IRandom<Rectangle<N>> IRandomisable<Rectangle<N>>.Random => throw new NotImplementedException();

        IStringParser<Rectangle<N>> IStringParsable<Rectangle<N>>.StringParser => throw new NotImplementedException();

        public Rectangle<N> Grow((N, N) delta) => Grow((Vector2<N>)delta);
        public Rectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public Rectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Grow(Vector2<N> delta) => new Rectangle<N>(BottomLeft - delta, Dimensions + delta + delta, Angle);

        public Rectangle<N> Scale(N scale) => new Rectangle<N>(Center, Dimensions * scale, Angle);

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(BottomLeft, Dimensions, Angle + angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Center.RotateAround(pivot, angle), Dimensions, Angle + angle);
        public Rectangle<N> Shrink((N, N) delta) => Shrink((Vector2<N>)delta);
        public Rectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public Rectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Shrink(Vector2<N> delta) => new Rectangle<N>(BottomLeft, Dimensions - delta, Angle);
        public Rectangle<N> Translate((N, N) delta) => Translate((Vector2<N>)delta);
        public Rectangle<N> Translate(N deltaX, N deltaY) => Translate(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Translate(Vector2<N> delta) => new Rectangle<N>(BottomLeft + delta, Dimensions, Angle);
        public Rectangle<N> UnitTranslate((N, N) delta) => Translate((Vector2<N>)delta);
        public Rectangle<N> UnitTranslate(N deltaX, N deltaY) => Translate(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> UnitTranslate(Vector2<N> delta) => new Rectangle<N>(BottomLeft + (delta.X * Width, delta.Y * Height), Dimensions, Angle);

        public static Rectangle<N> FromCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(center, dimensions, angle);
        public static Rectangle<N> FromBottomLeft(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetTopRight(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromBottomCenter(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetTopCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromBottomRight(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetTopLeft(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromLeftCenter(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetRightCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromRightCenter(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetLeftCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromTopLeft(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetBottomRight(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromTopCenter(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetBottomCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<N> FromTopRight(Vector2<N> bottomLeft, Vector2<N> dimensions, Angle<N> angle) => new Rectangle<N>(GetBottomLeft(bottomLeft, dimensions, default), dimensions, angle);

        public AARectangle<N> GetBounds()
        {
            var xs = new[] { TopLeft.X, TopRight.X, BottomLeft.X, BottomRight.X };
            var ys = new[] { TopLeft.Y, TopRight.Y, BottomLeft.Y, BottomRight.Y };

            var minX = xs.Min();
            var maxX = xs.Max();
            var minY = ys.Min();
            var maxY = ys.Max();

            var dimensions = new Vector2<N>(maxX - minX, maxY - minY);
            return AARectangle<N>.FromBottomLeft((minX, minY), dimensions);
        }

        private static Vector2<N> GetBottomCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Math<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetBottomLeft(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => (center - (dimensions / Math<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetBottomRight(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X + (dimensions.X / Math<N>.Two), center.Y - (dimensions.Y / Math<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetLeftCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X - (dimensions.X / Math<N>.Two), center.Y).RotateAround(center, angle);
        private static Vector2<N> GetRightCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X + (dimensions.X / Math<N>.Two), center.Y).RotateAround(center, angle);
        private static Vector2<N> GetTopCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Math<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetTopLeft(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X - (dimensions.X / Math<N>.Two), center.Y + (dimensions.Y / Math<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetTopRight(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => (center + (dimensions / Math<N>.Two)).RotateAround(center, angle);

        public static bool operator ==(Rectangle<N> left, Rectangle<N> right) => left.Equals(right);
        public static bool operator !=(Rectangle<N> left, Rectangle<N> right) => !(left == right);
        public static implicit operator Rectangle<N>(AARectangle<N> value) => new Rectangle<N>(value.Center, value.Dimensions, Angle<N>.Zero);
    }
}

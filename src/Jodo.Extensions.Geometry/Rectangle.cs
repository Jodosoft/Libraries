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
    public readonly struct Rectangle<T> : IGeometric<Rectangle<T>> where T : struct, INumeric<T>
    {
        public readonly Vector2<T> Center;
        public readonly Vector2<T> Dimensions;
        public readonly Angle<T> Angle;

        public Rectangle(Vector2<T> center, Vector2<T> dimensions, Angle<T> angle)
        {
            Center = center;
            Dimensions = dimensions;
            Angle = angle;
        }

        public Rectangle(T centerX, T centerY, T width, T height, T degrees)
        {
            Center = new Vector2<T>(centerX, centerY);
            Dimensions = new Vector2<T>(width, height);
            Angle = Angle<T>.FromDegrees(degrees);
        }

        private Rectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<T>)info.GetValue(nameof(Center), typeof(Vector2<T>)),
            (Vector2<T>)info.GetValue(nameof(Dimensions), typeof(Vector2<T>)),
            (Angle<T>)info.GetValue(nameof(Angle), typeof(Angle<T>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<T>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<T>));
            info.AddValue(nameof(Angle), Angle, typeof(Angle<T>));
        }

        public bool Equals(Rectangle<T> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions) && Angle.Equals(other.Angle);
        public override bool Equals(object? obj) => obj is Rectangle<T> rectangle && Equals(rectangle);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions, Angle);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Dimensions, Angle);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public T Area => Math<T>.Abs(Width * Height);
        public T Height => Dimensions.Y;
        public T Width => Dimensions.X;

        public Vector2<T> BottomCenter => GetBottomCenter(Center, Dimensions, Angle);
        public Vector2<T> BottomLeft => GetBottomLeft(Center, Dimensions, Angle);
        public Vector2<T> BottomRight => GetBottomRight(Center, Dimensions, Angle);
        public Vector2<T> LeftCenter => GetLeftCenter(Center, Dimensions, Angle);
        public Vector2<T> RightCenter => GetRightCenter(Center, Dimensions, Angle);
        public Vector2<T> TopCenter => GetTopCenter(Center, Dimensions, Angle);
        public Vector2<T> TopLeft => GetTopLeft(Center, Dimensions, Angle);
        public Vector2<T> TopRight => GetTopRight(Center, Dimensions, Angle);

        IBitConverter<Rectangle<T>> IBitConvertible<Rectangle<T>>.BitConverter => throw new NotImplementedException();

        IRandom<Rectangle<T>> IRandomisable<Rectangle<T>>.Random => throw new NotImplementedException();

        IStringParser<Rectangle<T>> IStringRepresentable<Rectangle<T>>.StringParser => throw new NotImplementedException();

        public Rectangle<T> Grow((T, T) delta) => Grow((Vector2<T>)delta);
        public Rectangle<T> Grow(T delta) => Grow(new Vector2<T>(delta, delta));
        public Rectangle<T> Grow(T deltaX, T deltaY) => Grow(new Vector2<T>(deltaX, deltaY));
        public Rectangle<T> Grow(Vector2<T> delta) => new Rectangle<T>(BottomLeft - delta, Dimensions + delta + delta, Angle);

        public Rectangle<T> Scale(T scale) => new Rectangle<T>(Center, Dimensions * scale, Angle);

        public Rectangle<T> Rotate(in Angle<T> angle) => new Rectangle<T>(BottomLeft, Dimensions, Angle + angle);
        public Rectangle<T> RotateAround(in Vector2<T> pivot, in Angle<T> angle) => new Rectangle<T>(Center.RotateAround(pivot, angle), Dimensions, Angle + angle);
        public Rectangle<T> Shrink((T, T) delta) => Shrink((Vector2<T>)delta);
        public Rectangle<T> Shrink(T delta) => Shrink(new Vector2<T>(delta, delta));
        public Rectangle<T> Shrink(T deltaX, T deltaY) => Shrink(new Vector2<T>(deltaX, deltaY));
        public Rectangle<T> Shrink(Vector2<T> delta) => new Rectangle<T>(BottomLeft, Dimensions - delta, Angle);
        public Rectangle<T> Translate((T, T) delta) => Translate((Vector2<T>)delta);
        public Rectangle<T> Translate(T deltaX, T deltaY) => Translate(new Vector2<T>(deltaX, deltaY));
        public Rectangle<T> Translate(Vector2<T> delta) => new Rectangle<T>(BottomLeft + delta, Dimensions, Angle);
        public Rectangle<T> UnitTranslate((T, T) delta) => Translate((Vector2<T>)delta);
        public Rectangle<T> UnitTranslate(T deltaX, T deltaY) => Translate(new Vector2<T>(deltaX, deltaY));
        public Rectangle<T> UnitTranslate(Vector2<T> delta) => new Rectangle<T>(BottomLeft + (delta.X * Width, delta.Y * Height), Dimensions, Angle);

        public bool Contains(Vector2<T> delta) => throw new NotImplementedException();
        public bool Contains((T, T) delta) => throw new NotImplementedException();
        public bool Contains(T deltaX, T deltaY) => throw new NotImplementedException();
        public bool Contains(Rectangle<T> other) => throw new NotImplementedException();
        public bool IntersectsWith(Rectangle<T> other) => throw new NotImplementedException();

        public static Rectangle<T> FromCenter(Vector2<T> center, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(center, dimensions, angle);
        public static Rectangle<T> FromBottomLeft(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetTopRight(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromBottomCenter(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetTopCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromBottomRight(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetTopLeft(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromLeftCenter(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetRightCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromRightCenter(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetLeftCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromTopLeft(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetBottomRight(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromTopCenter(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetBottomCenter(bottomLeft, dimensions, default), dimensions, angle);
        public static Rectangle<T> FromTopRight(Vector2<T> bottomLeft, Vector2<T> dimensions, Angle<T> angle) => new Rectangle<T>(GetBottomLeft(bottomLeft, dimensions, default), dimensions, angle);

        public AARectangle<T> GetBounds()
        {
            var xs = new[] { TopLeft.X, TopRight.X, BottomLeft.X, BottomRight.X };
            var ys = new[] { TopLeft.Y, TopRight.Y, BottomLeft.Y, BottomRight.Y };

            var minX = xs.Min();
            var maxX = xs.Max();
            var minY = ys.Min();
            var maxY = ys.Max();

            var dimensions = new Vector2<T>(maxX - minX, maxY - minY);
            return AARectangle<T>.FromBottomLeft((minX, minY), dimensions);
        }

        private static Vector2<T> GetBottomCenter(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X, center.Y + (dimensions.Y / 2)).RotateAround(center, angle);
        private static Vector2<T> GetBottomLeft(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => (center - (dimensions / 2)).RotateAround(center, angle);
        private static Vector2<T> GetBottomRight(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X + (dimensions.X / 2), center.Y - (dimensions.Y / 2)).RotateAround(center, angle);
        private static Vector2<T> GetLeftCenter(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X - (dimensions.X / 2), center.Y).RotateAround(center, angle);
        private static Vector2<T> GetRightCenter(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X + (dimensions.X / 2), center.Y).RotateAround(center, angle);
        private static Vector2<T> GetTopCenter(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X, center.Y + (dimensions.Y / 2)).RotateAround(center, angle);
        private static Vector2<T> GetTopLeft(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => new Vector2<T>(center.X - (dimensions.X / 2), center.Y + (dimensions.Y / 2)).RotateAround(center, angle);
        private static Vector2<T> GetTopRight(in Vector2<T> center, in Vector2<T> dimensions, in Angle<T> angle) => (center + (dimensions / 2)).RotateAround(center, angle);

        public static bool operator ==(Rectangle<T> left, Rectangle<T> right) => left.Equals(right);
        public static bool operator !=(Rectangle<T> left, Rectangle<T> right) => !(left == right);
        public static implicit operator Rectangle<T>(AARectangle<T> value) => new Rectangle<T>(value.Center, value.Dimensions, Angle<T>.Zero);
    }
}

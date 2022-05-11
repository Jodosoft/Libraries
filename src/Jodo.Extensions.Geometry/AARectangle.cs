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
    public readonly struct AARectangle<T> : IGeometric<AARectangle<T>> where T : struct, INumeric<T>
    {
        public readonly Vector2<T> Center;
        public readonly Vector2<T> Dimensions;

        public T Area => Math<T>.Abs(Dimensions.X * Dimensions.Y);
        public T Bottom => Center.Y - (Dimensions.Y / 2);
        public T Height => Dimensions.Y;
        public T Left => Center.X - (Dimensions.X / 2);
        public T Right => Center.X + (Dimensions.X / 2);
        public T Top => Center.Y + (Dimensions.Y / 2);
        public T Width => Dimensions.X;

        public Vector2<T> BottomCenter => GetBottomCenter(Center, Dimensions);
        public Vector2<T> BottomLeft => GetBottomLeft(Center, Dimensions);
        public Vector2<T> BottomRight => GetBottomRight(Center, Dimensions);
        public Vector2<T> LeftCenter => GetLeftCenter(Center, Dimensions);
        public Vector2<T> RightCenter => GetRightCenter(Center, Dimensions);
        public Vector2<T> TopCenter => GetTopCenter(Center, Dimensions);
        public Vector2<T> TopLeft => GetTopLeft(Center, Dimensions);
        public Vector2<T> TopRight => GetTopRight(Center, Dimensions);

        IBitConverter<AARectangle<T>> IBitConvertible<AARectangle<T>>.BitConverter => throw new NotImplementedException();

        IRandom<AARectangle<T>> IRandomisable<AARectangle<T>>.Random => throw new NotImplementedException();

        IStringParser<AARectangle<T>> IStringRepresentable<AARectangle<T>>.StringParser => throw new NotImplementedException();

        private AARectangle(Vector2<T> center, Vector2<T> dimensions)
        {
            Center = center;
            Dimensions = dimensions;
        }

        private AARectangle(T centerX, T centerY, T width, T height)
        {
            Center = new Vector2<T>(centerX, centerY);
            Dimensions = new Vector2<T>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext _) : this(
            (Vector2<T>)info.GetValue(nameof(Center), typeof(Vector2<T>)),
            (Vector2<T>)info.GetValue(nameof(Dimensions), typeof(Vector2<T>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<T>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<T>));
        }

        public AARectangle<T> Grow(Vector2<T> delta) => new AARectangle<T>(Center, Dimensions + delta);
        public AARectangle<T> Grow((T, T) delta) => Grow((Vector2<T>)delta);
        public AARectangle<T> Grow(T deltaX, T deltaY) => Grow(new Vector2<T>(deltaX, deltaY));
        public AARectangle<T> Grow(T delta) => Grow(new Vector2<T>(delta, delta));
        public AARectangle<T> Shrink(Vector2<T> delta) => new AARectangle<T>(Center, Dimensions - delta);
        public AARectangle<T> Shrink((T, T) delta) => Shrink((Vector2<T>)delta);
        public AARectangle<T> Shrink(T deltaX, T deltaY) => Shrink(new Vector2<T>(deltaX, deltaY));
        public AARectangle<T> Shrink(T delta) => Shrink(new Vector2<T>(delta, delta));
        public AARectangle<T> Translate(Vector2<T> delta) => new AARectangle<T>(Center + delta, Dimensions);
        public AARectangle<T> Translate((T, T) delta) => Translate((Vector2<T>)delta);
        public AARectangle<T> Translate(T deltaX, T deltaY) => Translate(new Vector2<T>(deltaX, deltaY));

        public bool Contains(Vector2<T> delta) => delta.X >= Left && delta.X <= Right && delta.Y >= Bottom && delta.Y <= Top;
        public bool Contains((T, T) delta) => Contains((Vector2<T>)delta);
        public bool Contains(T deltaX, T deltaY) => Contains(new Vector2<T>(deltaX, deltaY));

        public bool Contains(AARectangle<T> other) => IntersectsWith(other); // jjs
        public bool IntersectsWith(AARectangle<T> other) => Left < other.Right && Right > other.Left && Bottom < other.Top && Top > other.Bottom;

        public AARectangle<T> Rotate90() => new AARectangle<T>(Center, (Dimensions.Y, Dimensions.X));
        public AARectangle<T> Rotate90(Vector2<T> pivot) => new AARectangle<T>(Center.RotateAround(pivot, Angle<T>.C90Degrees), (Dimensions.Y, Dimensions.X));

        public Rectangle<T> Rotate(in Angle<T> angle) => new Rectangle<T>(Center, Dimensions, angle);
        public Rectangle<T> RotateAround(in Vector2<T> pivot, in Angle<T> angle) => new Rectangle<T>(Center.RotateAround(pivot, angle), Dimensions, angle);

        public (T, T, T, T) Convert() => this;
        public AARectangle<TOther> Convert<TOther>(Func<T, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<T> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<T> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Dimensions);

        //    AARectangle<T> IBitConverter<AARectangle<T>>.Read(in IReadOnlyStream<byte> stream)
        //    {
        //        return new AARectangle<T>(
        //            stream.Read<Vector2<T>>(),
        //            stream.Read<Vector2<T>>());
        //    }
        //
        //    void IBitConverter<AARectangle<T>>.Write(in IWriteOnlyStream<byte> stream)
        //    {
        //        stream.Write(Center);
        //        stream.Write(Dimensions);
        //    }

        public static AARectangle<T> FromCenter(Vector2<T> center, Vector2<T> dimensions) => new AARectangle<T>(center, dimensions);
        public static AARectangle<T> FromBottomLeft(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetTopRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromBottomCenter(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromBottomRight(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromLeftCenter(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromRightCenter(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromTopLeft(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromTopCenter(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<T> FromTopRight(Vector2<T> bottomLeft, Vector2<T> dimensions) => new AARectangle<T>(GetBottomLeft(bottomLeft, dimensions), dimensions);

        private static Vector2<T> GetBottomCenter(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X, center.Y + (dimensions.Y / 2));
        private static Vector2<T> GetBottomLeft(in Vector2<T> center, in Vector2<T> dimensions) => center - (dimensions / 2);
        private static Vector2<T> GetBottomRight(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X + (dimensions.X / 2), center.Y - (dimensions.Y / 2));
        private static Vector2<T> GetLeftCenter(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X - (dimensions.X / 2), center.Y);
        private static Vector2<T> GetRightCenter(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X + (dimensions.X / 2), center.Y);
        private static Vector2<T> GetTopCenter(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X, center.Y + (dimensions.Y / 2));
        private static Vector2<T> GetTopLeft(in Vector2<T> center, in Vector2<T> dimensions) => new Vector2<T>(center.X - (dimensions.X / 2), center.Y + (dimensions.Y / 2));
        private static Vector2<T> GetTopRight(in Vector2<T> center, in Vector2<T> dimensions) => center + (dimensions / 2);

        //   AARectangle<T> IStringParser<AARectangle<T>>.Parse(in string s)
        //   {
        //       throw new NotImplementedException();
        //   }
        //
        //   AARectangle<T> IStringParser<AARectangle<T>>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider)
        //   {
        //       throw new NotImplementedException();
        //   }
        //
        //   AARectangle<T> IRandom<AARectangle<T>>.GetNext(Random random)
        //   {
        //       return new AARectangle<T>(
        //           random.NextGeometric<Vector2<T>>(),
        //           random.NextGeometric<Vector2<T>>());
        //   }
        //
        //   AARectangle<T> IRandom<AARectangle<T>>.GetNext(Random random, in AARectangle<T> bound1, in AARectangle<T> bound2)
        //   {
        //       throw new NotImplementedException();
        //   }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AARectangle<T> left, AARectangle<T> right) => left.Equals(right);
        public static bool operator !=(AARectangle<T> left, AARectangle<T> right) => !(left == right);
        public static implicit operator AARectangle<T>(in (T, T, T, T) value) => new AARectangle<T>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (T, T, T, T)(in AARectangle<T> value) => (value.Center.X, value.Center.Y, value.Dimensions.X, value.Dimensions.Y);
        public static implicit operator AARectangle<T>(in (Vector2<T>, Vector2<T>) value) => new AARectangle<T>(value.Item1, value.Item2);
        public static implicit operator (Vector2<T>, Vector2<T>)(in AARectangle<T> value) => (value.Center, value.Dimensions);
    }
}

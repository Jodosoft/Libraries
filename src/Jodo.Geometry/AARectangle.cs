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
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [CLSCompliant(false)]
    public readonly struct AARectangle<N> :
            IEquatable<AARectangle<N>>,
            IFormattable,
            IProvider<IBitConverter<AARectangle<N>>>,
            IProvider<IRandom<AARectangle<N>>>,
            IProvider<IParser<AARectangle<N>>>,
            ITwoDimensional<AARectangle<N>, N>,
            IRotatable<Rectangle<N>, Angle<N>, Vector2<N>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private const string Symbol = "□";

        public readonly Vector2<N> Center;
        public readonly Vector2<N> Dimensions;

        public N Bottom => Center.Y.Subtract(Dimensions.Y.Divide(Cast<N>.ToNumeric(2)));
        public N Height => Dimensions.Y;
        public N Left => Center.X.Subtract(Dimensions.X.Divide(Cast<N>.ToNumeric(2)));
        public N Right => Center.X.Add(Dimensions.X.Divide(Cast<N>.ToNumeric(2)));
        public N Top => Center.Y.Add(Dimensions.Y.Divide(Cast<N>.ToNumeric(2)));
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

        public N GetArea() => Math<N>.Abs(Dimensions.X.Multiply(Dimensions.Y));
        public Vector2<N>[] GetVertices() => new[] { BottomLeft, BottomRight, TopRight, TopLeft };

        public AARectangle<N> Grow(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions + delta);
        public AARectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public AARectangle<N> Shrink(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions - delta);
        public AARectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public AARectangle<N> Translate(Vector2<N> delta) => new AARectangle<N>(Center + delta, Dimensions);

        public bool Contains(Vector2<N> point) =>
            point.X.IsGreaterThanOrEqualTo(Left) &&
            point.X.IsLessThanOrEqualTo(Right) &&
            point.Y.IsGreaterThanOrEqualTo(Bottom) &&
            point.Y.IsLessThanOrEqualTo(Top);

        public bool Contains(AARectangle<N> other) =>
            Left.IsLessThanOrEqualTo(other.Left) &&
            Right.IsGreaterThanOrEqualTo(other.Right) &&
            Bottom.IsLessThanOrEqualTo(other.Bottom) &&
            Top.IsGreaterThanOrEqualTo(other.Top);

        public bool IntersectsWith(AARectangle<N> other) =>
            Left.IsLessThan(other.Right) &&
            Right.IsGreaterThan(other.Left) &&
            Bottom.IsLessThan(other.Top) &&
            Top.IsGreaterThan(other.Bottom);

        public AARectangle<N> RotateRight() => new AARectangle<N>(Center, new Vector2<N>(Dimensions.Y, Dimensions.X));

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(Center, Dimensions, angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Center.RotateAround(pivot, angle), Dimensions, angle);

        public AARectangle<TOther> Convert<TOther>(Func<N, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<N> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<N> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions);
        public override string ToString() => $"{Symbol}({Center}, {Dimensions})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({Center.ToString(format, formatProvider)}, {Dimensions.ToString(format, formatProvider)})";

        public static bool TryParse(string value, out AARectangle<N> result)
            => Try.Run(() => Parse(value), out result);

        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out AARectangle<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static AARectangle<N> Parse(string value)
        {
            string[] parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new AARectangle<N>(
                    Vector2<N>.Parse(parts[0]),
                    Vector2<N>.Parse(parts[1]));
            if (parts.Length == 4)
                return new AARectangle<N>(
                    Parser<N>.Parse(parts[0]),
                    Parser<N>.Parse(parts[1]),
                    Parser<N>.Parse(parts[2]),
                    Parser<N>.Parse(parts[2]));
            else throw new FormatException();
        }

        public static AARectangle<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            string[] parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new AARectangle<N>(
                    Vector2<N>.Parse(parts[0], style, provider),
                    Vector2<N>.Parse(parts[1], style, provider));
            if (parts.Length == 4)
                return new AARectangle<N>(
                    Parser<N>.Parse(parts[0], style, provider),
                    Parser<N>.Parse(parts[1], style, provider),
                    Parser<N>.Parse(parts[2], style, provider),
                    Parser<N>.Parse(parts[2], style, provider));
            else throw new FormatException();
        }

        public static AARectangle<N> FromCenter(Vector2<N> center, Vector2<N> dimensions) => new AARectangle<N>(center, dimensions);
        public static AARectangle<N> FromBottomLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromLeftCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromRightCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomLeft(bottomLeft, dimensions), dimensions);

        public static AARectangle<N> Between(Vector2<N> point1, Vector2<N> point2)
        {
            N xMin = Math<N>.Min(point1.X, point2.X);
            N xMax = Math<N>.Max(point1.X, point2.X);
            N yMin = Math<N>.Min(point1.Y, point2.Y);
            N yMax = Math<N>.Max(point1.Y, point2.Y);
            N width = xMax.Subtract(xMin);
            N height = yMax.Subtract(yMin);
            N centerX = xMin.Add(width.Divide(Numeric<N>.Two));
            N centerY = yMin.Add(height.Divide(Numeric<N>.Two));
            return new AARectangle<N>(centerX, centerY, width, height);
        }

        private static Vector2<N> GetBottomCenter(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X, center.Y.Add(dimensions.Y.Divide(Numeric<N>.Two)));

        private static Vector2<N> GetBottomLeft(Vector2<N> center, Vector2<N> dimensions)
            => center - (dimensions / Numeric<N>.Two);

        private static Vector2<N> GetBottomRight(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X.Add(dimensions.X.Divide(Numeric<N>.Two)), center.Y.Subtract(dimensions.Y.Divide(Numeric<N>.Two)));

        private static Vector2<N> GetLeftCenter(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X.Subtract(dimensions.X.Divide(Numeric<N>.Two)), center.Y);

        private static Vector2<N> GetRightCenter(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X.Add(dimensions.X.Divide(Numeric<N>.Two)), center.Y);

        private static Vector2<N> GetTopCenter(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X, center.Y.Add(dimensions.Y.Divide(Numeric<N>.Two)));

        private static Vector2<N> GetTopLeft(Vector2<N> center, Vector2<N> dimensions)
            => new Vector2<N>(center.X.Subtract(dimensions.X.Divide(Numeric<N>.Two)), center.Y.Add(dimensions.Y.Divide(Numeric<N>.Two)));

        private static Vector2<N> GetTopRight(Vector2<N> center, Vector2<N> dimensions)
            => center + (dimensions / Numeric<N>.Two);

        public static bool operator ==(AARectangle<N> left, AARectangle<N> right) => left.Equals(right);
        public static bool operator !=(AARectangle<N> left, AARectangle<N> right) => !(left == right);

#if NETSTANDARD2_0_OR_GREATER
        public static implicit operator AARectangle<N>((Vector2<N>, Vector2<N>) value) => new AARectangle<N>(value.Item1, value.Item2);
        public static implicit operator (Vector2<N>, Vector2<N>)(AARectangle<N> value) => (value.Center, value.Dimensions);
        public static implicit operator AARectangle<N>((N, N, N, N) value) => new AARectangle<N>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (N, N, N, N)(AARectangle<N> value) => (value.Center.X, value.Center.Y, value.Dimensions.X, value.Dimensions.Y);
#endif

        Vector2<N> ITwoDimensional<AARectangle<N>, N>.GetCenter() => Center;
        AARectangle<N> ITwoDimensional<AARectangle<N>, N>.GetBounds() => this;
        Vector2<N>[] ITwoDimensional<AARectangle<N>, N>.GetVertices(int circumferenceDivisor) => GetVertices();

        IBitConverter<AARectangle<N>> IProvider<IBitConverter<AARectangle<N>>>.GetInstance() => Utilities.Instance;
        IRandom<AARectangle<N>> IProvider<IRandom<AARectangle<N>>>.GetInstance() => Utilities.Instance;
        IParser<AARectangle<N>> IProvider<IParser<AARectangle<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<AARectangle<N>>,
           IRandom<AARectangle<N>>,
           IParser<AARectangle<N>>
        {
            public static readonly Utilities Instance = new Utilities();

            AARectangle<N> IRandom<AARectangle<N>>.Next(Random random)
            {
                do
                {
                    try
                    {
                        return checked(AARectangle<N>.Between(
                            random.NextVector2<N>(),
                            random.NextVector2<N>()));
                    }
                    catch (OverflowException)
                    {
                        // Try again
                    }
                } while (true);
            }

            AARectangle<N> IRandom<AARectangle<N>>.Next(Random random, AARectangle<N> bound1, AARectangle<N> bound2)
            {
                N xMin = Math<N>.Min(bound1.BottomLeft.X, bound2.BottomLeft.X);
                N xMax = Math<N>.Max(bound1.TopRight.X, bound2.TopRight.X);
                N yMin = Math<N>.Min(bound1.BottomLeft.Y, bound2.BottomLeft.Y);
                N yMax = Math<N>.Max(bound1.TopRight.Y, bound2.TopRight.Y);
                Vector2<N> point1 = new Vector2<N>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));
                Vector2<N> point2 = new Vector2<N>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));
                return AARectangle<N>.Between(point1, point2);
            }

            AARectangle<N> IParser<AARectangle<N>>.Parse(string s) => Parse(s);

            AARectangle<N> IParser<AARectangle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            AARectangle<N> IBitConverter<AARectangle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                return new AARectangle<N>(
                    BitConverter<Vector2<N>>.Read(stream),
                    BitConverter<Vector2<N>>.Read(stream));
            }

            void IBitConverter<AARectangle<N>>.Write(AARectangle<N> value, IWriteOnlyStream<byte> stream)
            {
                BitConverter<Vector2<N>>.Write(stream, value.Center);
                BitConverter<Vector2<N>>.Write(stream, value.Dimensions);
            }
        }
    }
}

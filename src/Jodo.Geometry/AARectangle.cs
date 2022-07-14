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

        public readonly Vector2<N> Origin;
        public readonly Vector2<N> Dimensions;
        public N Height => Dimensions.Y;
        public N Width => Dimensions.X;

        public N GetBottom() => Origin.Y;
        public N GetLeft() => Origin.X;
        public N GetRight() => Origin.X.Add(Dimensions.X);
        public N GetTop() => Origin.Y.Add(Dimensions.Y);
        public Vector2<N> GetCenter() => GetCenter(Origin, Dimensions);
        public Vector2<N> GetBottomCenter() => GetBottomCenter(Origin, Dimensions);
        public Vector2<N> GetBottomLeft() => Origin;
        public Vector2<N> GetBottomRight() => GetBottomRight(Origin, Dimensions);
        public Vector2<N> GetLeftCenter() => GetLeftCenter(Origin, Dimensions);
        public Vector2<N> GetRightCenter() => GetRightCenter(Origin, Dimensions);
        public Vector2<N> GetTopCenter() => GetTopCenter(Origin, Dimensions);
        public Vector2<N> GetTopLeft() => GetTopLeft(Origin, Dimensions);
        public Vector2<N> GetTopRight() => GetTopRight(Origin, Dimensions);

        public AARectangle(Vector2<N> origin, Vector2<N> dimensions)
        {
            Origin = origin;
            Dimensions = dimensions;
        }

        public AARectangle(N originX, N originY, N width, N height)
        {
            Origin = new Vector2<N>(originX, originY);
            Dimensions = new Vector2<N>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(Origin), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(Dimensions), typeof(Vector2<N>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Origin), Origin, typeof(Vector2<N>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<N>));
        }

        public N GetArea() => MathN.Abs(Dimensions.X.Multiply(Dimensions.Y));
        public Vector2<N>[] GetVertices() => new[] { GetBottomLeft(), GetBottomRight(), GetTopRight(), GetTopLeft() };

        public AARectangle<N> Grow(Vector2<N> delta) => new AARectangle<N>(Origin, Dimensions + delta);
        public AARectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public AARectangle<N> Shrink(Vector2<N> delta) => new AARectangle<N>(Origin, Dimensions - delta);
        public AARectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public AARectangle<N> Translate(Vector2<N> delta) => new AARectangle<N>(Origin + delta, Dimensions);

        public bool Contains(Vector2<N> point) =>
            point.X.IsGreaterThanOrEqualTo(GetLeft()) &&
            point.X.IsLessThanOrEqualTo(GetRight()) &&
            point.Y.IsGreaterThanOrEqualTo(GetBottom()) &&
            point.Y.IsLessThanOrEqualTo(GetTop());

        public bool Contains(AARectangle<N> other) =>
            GetLeft().IsLessThanOrEqualTo(other.GetLeft()) &&
            GetRight().IsGreaterThanOrEqualTo(other.GetRight()) &&
            GetBottom().IsLessThanOrEqualTo(other.GetBottom()) &&
            GetTop().IsGreaterThanOrEqualTo(other.GetTop());

        public bool IntersectsWith(AARectangle<N> other) =>
            GetLeft().IsLessThan(other.GetRight()) &&
            GetRight().IsGreaterThan(other.GetLeft()) &&
            GetBottom().IsLessThan(other.GetTop()) &&
            GetTop().IsGreaterThan(other.GetBottom());

        public AARectangle<N> RotateRight() => new AARectangle<N>(Origin, new Vector2<N>(Dimensions.Y, Dimensions.X));

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(Origin, Dimensions, angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Origin.RotateAround(pivot, angle), Dimensions, angle);

        public AARectangle<TOther> Convert<TOther>(Func<N, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Origin.X), convert(Origin.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<N> other) => Origin.Equals(other.Origin) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<N> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Origin, Dimensions);
        public override string ToString() => $"{Symbol}({Origin}, {Dimensions})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({Origin.ToString(format, formatProvider)}, {Dimensions.ToString(format, formatProvider)})";

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
        public static AARectangle<N> FromBottomLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(bottomLeft, dimensions);
        public static AARectangle<N> FromBottomCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromLeftCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromRightCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(bottomLeft, dimensions);

        public static AARectangle<N> Between(Vector2<N> point1, Vector2<N> point2)
        {
            return new AARectangle<N>(point1, point2 - point1);
        }

        private static Vector2<N> GetCenter(Vector2<N> origin, Vector2<N> dimensions)
            => origin + dimensions.Half();

        private static Vector2<N> GetBottomCenter(Vector2<N> origin, Vector2<N> dimensions)
            => new Vector2<N>(origin.X.Add(dimensions.X.Half()), origin.Y);

        private static Vector2<N> GetBottomRight(Vector2<N> origin, Vector2<N> dimensions)
            => new Vector2<N>(origin.X.Add(dimensions.X), origin.Y);

        private static Vector2<N> GetLeftCenter(Vector2<N> origin, Vector2<N> dimensions)
            => new Vector2<N>(origin.X, origin.Y.Add(dimensions.Y.Half()));

        private static Vector2<N> GetRightCenter(Vector2<N> origin, Vector2<N> dimensions)
             => new Vector2<N>(origin.X.Add(dimensions.X), origin.Y.Add(dimensions.Y.Half()));

        private static Vector2<N> GetTopCenter(Vector2<N> origin, Vector2<N> dimensions)
             => new Vector2<N>(origin.X.Add(dimensions.X.Half()), origin.Y.Add(dimensions.Y));

        private static Vector2<N> GetTopLeft(Vector2<N> origin, Vector2<N> dimensions)
             => new Vector2<N>(origin.X, origin.Y.Add(dimensions.Y));

        private static Vector2<N> GetTopRight(Vector2<N> origin, Vector2<N> dimensions)
             => origin + dimensions;

        public static bool operator ==(AARectangle<N> left, AARectangle<N> right) => left.Equals(right);
        public static bool operator !=(AARectangle<N> left, AARectangle<N> right) => !(left == right);

#if NETSTANDARD2_0_OR_GREATER
        public static implicit operator AARectangle<N>((Vector2<N>, Vector2<N>) value) => new AARectangle<N>(value.Item1, value.Item2);
        public static implicit operator (Vector2<N>, Vector2<N>)(AARectangle<N> value) => (value.Origin, value.Dimensions);
        public static implicit operator AARectangle<N>((N, N, N, N) value) => new AARectangle<N>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (N, N, N, N)(AARectangle<N> value) => (value.Origin.X, value.Origin.Y, value.Dimensions.X, value.Dimensions.Y);
#endif

        Vector2<N> ITwoDimensional<AARectangle<N>, N>.GetCenter() => GetCenter();
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
                N xMin = MathN.Min(bound1.GetBottomLeft().X, bound2.GetBottomLeft().X);
                N xMax = MathN.Max(bound1.GetTopRight().X, bound2.GetTopRight().X);
                N yMin = MathN.Min(bound1.GetBottomLeft().Y, bound2.GetBottomLeft().Y);
                N yMax = MathN.Max(bound1.GetTopRight().Y, bound2.GetTopRight().Y);
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
                BitConverter<Vector2<N>>.Write(stream, value.Origin);
                BitConverter<Vector2<N>>.Write(stream, value.Dimensions);
            }
        }
    }
}

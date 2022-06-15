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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Rectangle<N> :
            IEquatable<Rectangle<N>>,
            IFormattable,
            IProvider<IBitConverter<Rectangle<N>>>,
            IProvider<IRandom<Rectangle<N>>>,
            IProvider<IStringParser<Rectangle<N>>>,
            ITwoDimensional<Rectangle<N>, N>,
            IRotatable<Rectangle<N>, Angle<N>, Vector2<N>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private const string Symbol = "□";

        public readonly Vector2<N> Center;
        public readonly Vector2<N> Dimensions;
        public readonly Angle<N> Angle;

        public N Height => Dimensions.Y;
        public N Width => Dimensions.X;

        public Vector2<N> GetBottomCenter() => GetBottomCenter(Center, Dimensions, Angle);
        public Vector2<N> GetBottomLeft() => GetBottomLeft(Center, Dimensions, Angle);
        public Vector2<N> GetBottomRight() => GetBottomRight(Center, Dimensions, Angle);
        public Vector2<N> GetLeftCenter() => GetLeftCenter(Center, Dimensions, Angle);
        public Vector2<N> GetRightCenter() => GetRightCenter(Center, Dimensions, Angle);
        public Vector2<N> GetTopCenter() => GetTopCenter(Center, Dimensions, Angle);
        public Vector2<N> GetTopLeft() => GetTopLeft(Center, Dimensions, Angle);
        public Vector2<N> GetTopRight() => GetTopRight(Center, Dimensions, Angle);

        public Rectangle(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle)
        {
            Center = center;
            Dimensions = dimensions;
            Angle = angle;
        }

        private Rectangle(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>));
            Dimensions = (Vector2<N>)info.GetValue(nameof(Dimensions), typeof(Vector2<N>));
            Angle = (Angle<N>)info.GetValue(nameof(Angle), typeof(Angle<N>));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<N>));
            info.AddValue(nameof(Angle), Angle, typeof(Angle<N>));
        }

        public bool Contains(Rectangle<N> other)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2<N> point)
        {
            throw new NotImplementedException();
        }

        public bool IntersectsWith(Rectangle<N> other)
        {
            throw new NotImplementedException();
        }

        public N GetArea() => Math<N>.Abs(Width * Height);

        public ReadOnlySpan<Vector2<N>> GetVertices()
        {
            return new[]
            {
                GetBottomLeft(),
                GetBottomRight(),
                GetTopRight(),
                GetTopLeft()
            };
        }

        public Rectangle<N> Grow((N, N) delta) => Grow((Vector2<N>)delta);
        public Rectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public Rectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Grow(Vector2<N> delta) => new Rectangle<N>(GetBottomLeft() - delta, Dimensions + delta + delta, Angle);

        public Rectangle<N> Scale(N scale) => new Rectangle<N>(Center, Dimensions * scale, Angle);

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(GetBottomLeft(), Dimensions, Angle + angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Center.RotateAround(pivot, angle), Dimensions, Angle + angle);
        public Rectangle<N> Shrink((N, N) delta) => Shrink((Vector2<N>)delta);
        public Rectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public Rectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Shrink(Vector2<N> delta) => new Rectangle<N>(GetBottomLeft(), Dimensions - delta, Angle);
        public Rectangle<N> Translate((N, N) delta) => Translate((Vector2<N>)delta);
        public Rectangle<N> Translate(N deltaX, N deltaY) => Translate(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> Translate(Vector2<N> delta) => new Rectangle<N>(GetBottomLeft() + delta, Dimensions, Angle);
        public Rectangle<N> UnitTranslate((N, N) delta) => Translate((Vector2<N>)delta);
        public Rectangle<N> UnitTranslate(N deltaX, N deltaY) => Translate(new Vector2<N>(deltaX, deltaY));
        public Rectangle<N> UnitTranslate(Vector2<N> delta) => new Rectangle<N>(GetBottomLeft() + (delta.X * Width, delta.Y * Height), Dimensions, Angle);

        public bool Equals(Rectangle<N> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions) && Angle.Equals(other.Angle);
        public override bool Equals(object? obj) => obj is Rectangle<N> rectangle && Equals(rectangle);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions, Angle);
        public override string ToString() => $"{Symbol}({Center}, {Dimensions}, {Angle})";
        public string ToString(string? format, IFormatProvider? formatProvider)
            => $"{Symbol}({Center.ToString(format, formatProvider)}, {Dimensions.ToString(format, formatProvider)}, {Angle.ToString(format, formatProvider)})";

        public static bool TryParse(string value, out Rectangle<N> result)
            => Try.Run(() => Parse(value), out result);

        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out Rectangle<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static Rectangle<N> Parse(string value)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 3)
                return new Rectangle<N>(
                    Vector2<N>.Parse(parts[0]),
                    Vector2<N>.Parse(parts[1]),
                    Angle<N>.Parse(parts[2]));
            else throw new FormatException();
        }

        public static Rectangle<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 3)
                return new Rectangle<N>(
                    Vector2<N>.Parse(parts[0], style, provider),
                    Vector2<N>.Parse(parts[1], style, provider),
                    Angle<N>.Parse(parts[1], style, provider));
            else throw new FormatException();
        }

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
            var xs = new[] { GetTopLeft().X, GetTopRight().X, GetBottomLeft().X, GetBottomRight().X };
            var ys = new[] { GetTopLeft().Y, GetTopRight().Y, GetBottomLeft().Y, GetBottomRight().Y };

            var minX = xs.Min();
            var maxX = xs.Max();
            var minY = ys.Min();
            var maxY = ys.Max();

            var dimensions = new Vector2<N>(maxX - minX, maxY - minY);
            return AARectangle<N>.FromBottomLeft((minX, minY), dimensions);
        }

        private static Vector2<N> GetBottomCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetBottomLeft(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => (center - (dimensions / Numeric<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetBottomRight(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y - (dimensions.Y / Numeric<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetLeftCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y).RotateAround(center, angle);
        private static Vector2<N> GetRightCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y).RotateAround(center, angle);
        private static Vector2<N> GetTopCenter(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetTopLeft(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y + (dimensions.Y / Numeric<N>.Two)).RotateAround(center, angle);
        private static Vector2<N> GetTopRight(Vector2<N> center, Vector2<N> dimensions, Angle<N> angle) => (center + (dimensions / Numeric<N>.Two)).RotateAround(center, angle);

        public static bool operator ==(Rectangle<N> left, Rectangle<N> right) => left.Equals(right);
        public static bool operator !=(Rectangle<N> left, Rectangle<N> right) => !(left == right);
        public static implicit operator Rectangle<N>(AARectangle<N> value) => new Rectangle<N>(value.Center, value.Dimensions, Angle<N>.Zero);

        ReadOnlySpan<Vector2<N>> ITwoDimensional<Rectangle<N>, N>.GetVertices(int circumferenceDivisor) => GetVertices();
        Vector2<N> ITwoDimensional<Rectangle<N>, N>.GetCenter() => Center;

        IBitConverter<Rectangle<N>> IProvider<IBitConverter<Rectangle<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Rectangle<N>> IProvider<IRandom<Rectangle<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<Rectangle<N>> IProvider<IStringParser<Rectangle<N>>>.GetInstance() => Utilities.Instance;


        private sealed class Utilities :
           IBitConverter<Rectangle<N>>,
           IRandom<Rectangle<N>>,
           IStringParser<Rectangle<N>>
        {
            public readonly static Utilities Instance = new Utilities();

            Rectangle<N> IRandom<Rectangle<N>>.Next(Random random)
            {
                do
                {
                    try
                    {
                        checked
                        {
                            var result = AARectangle<N>.Between(
                                random.NextVector2<N>(),
                                random.NextVector2<N>()).Rotate(random.NextAngle<N>());
                            if (result.GetBounds() != default)
                            {
                                return result;
                            }
                        }
                    }
                    catch (OverflowException) { }
                } while (true);
            }

            Rectangle<N> IRandom<Rectangle<N>>.Next(Random random, Rectangle<N> bound1, Rectangle<N> bound2)
            {
                var bound1Bounds = bound1.GetBounds();
                var bound2Bounds = bound2.GetBounds();
                var xMin = Math<N>.Min(bound1Bounds.BottomLeft.X, bound2Bounds.BottomLeft.X);
                var xMax = Math<N>.Max(bound1Bounds.TopRight.X, bound2Bounds.TopRight.X);
                var yMin = Math<N>.Min(bound1Bounds.BottomLeft.Y, bound2Bounds.BottomLeft.Y);
                var yMax = Math<N>.Max(bound1Bounds.TopRight.Y, bound2Bounds.TopRight.Y);

                var center = new Vector2<N>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));

                var xMaxRadius = Math<N>.Min(xMax - center.X, center.X - xMin);
                var yMaxRadius = Math<N>.Min(yMax - center.Y, center.Y - yMin);

                var angle = random.NextAngle<N>();
                var dimensions = new Vector2<N>(xMaxRadius * Numeric<N>.Two, yMaxRadius * Numeric<N>.Two);

                return new Rectangle<N>(center, dimensions, angle);
            }

            Rectangle<N> IStringParser<Rectangle<N>>.Parse(string s)
                => Parse(s);

            Rectangle<N> IStringParser<Rectangle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
                => Parse(s, style, provider);

            Rectangle<N> IBitConverter<Rectangle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                return new Rectangle<N>(
                    BitConverter<Vector2<N>>.Read(stream),
                    BitConverter<Vector2<N>>.Read(stream),
                    BitConverter<Angle<N>>.Read(stream));
            }

            void IBitConverter<Rectangle<N>>.Write(Rectangle<N> value, IWriteOnlyStream<byte> stream)
            {
                BitConverter<Vector2<N>>.Write(stream, value.Center);
                BitConverter<Vector2<N>>.Write(stream, value.Dimensions);
                BitConverter<Angle<N>>.Write(stream, value.Angle);
            }
        }
    }
}

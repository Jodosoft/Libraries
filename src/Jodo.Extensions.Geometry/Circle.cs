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
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Circle<N> :
            IEquatable<Circle<N>>,
            IFormattable,
            IProvider<IBitConverter<Circle<N>>>,
            IProvider<IRandom<Circle<N>>>,
            IProvider<IStringParser<Circle<N>>>,
            ITwoDimensional<Circle<N>, N>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private const string Symbol = "○";

        public readonly Vector2<N> Center;
        public readonly N Radius;

        public N GetDiameter() => Numeric<N>.Two * Radius;
        public N GetCircumeference() => Numeric<N>.Two * Math<N>.PI * Radius;


        public Circle(Vector2<N> center, N radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(N centerX, N centerY, N radius)
        {
            Center = new Vector2<N>(centerX, centerY);
            Radius = radius;
        }

        private Circle(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>));
            Radius = (N)info.GetValue(nameof(Radius), typeof(N));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Radius), Radius, typeof(N));
        }

        public ReadOnlySpan<Vector2<N>> GetVertices(int circumferenceDivisor)
        {
            var centerX = Convert<N>.ToDouble(Center.X);
            var centerY = Convert<N>.ToDouble(Center.Y);
            var radius = Convert<N>.ToDouble(Radius);

            var results = new Vector2<N>[circumferenceDivisor + 1];
            results[0] = Center;
            for (int i = 0; i < circumferenceDivisor; i++)
            {
                var degrees = i * 360 / (double)circumferenceDivisor;

                var radians = degrees * NumericUtilities.RadiansPerDegree;

                results[i + 1] = new Vector2<N>(
                    Convert<N>.ToNumeric(centerX + radius * Math.Cos(radians)),
                    Convert<N>.ToNumeric(centerY + radius * Math.Sin(radians)));
            }
            return results;
        }

        public N GetArea() => Math<N>.PI * Math<N>.Pow(Radius, Numeric<N>.Two);
        public bool Contains(Circle<N> other) => Radius >= other.Radius && Center.DistanceFrom(other.Center) <= Radius - other.Radius;
        public bool Contains(Vector2<N> point) => point.DistanceFrom(Center) < Radius;
        public Circle<N> Translate(Vector2<N> delta) => new Circle<N>(Center.Translate(delta), Radius);
        public Circle<N> Translate(N deltaX, N deltaY) => new Circle<N>(Center.Translate((deltaX, deltaY)), Radius);
        public AARectangle<N> GetBounds() => AARectangle<N>.FromCenter(Center, (GetDiameter(), GetDiameter()));
        public bool IntersectsWith(Circle<N> other) => Center.DistanceFrom(other.Center) < Radius + other.Radius;

        public bool Equals(Circle<N> other) => Center.Equals(other.Center) && Radius.Equals(other.Radius);
        public override bool Equals(object? obj) => obj is Circle<N> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => $"{Symbol}({Center}, r{GetDiameter()})";
        public string ToString(string format, IFormatProvider formatProvider) => $"{Symbol}({Center.ToString(format, formatProvider)}, r{GetDiameter().ToString(format, formatProvider)})";


        public static bool TryParse(string value, out Circle<N> result)
            => Try.Run(() => Parse(value), out result);

        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out Circle<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static Circle<N> Parse(string value)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new Circle<N>(
                    Vector2<N>.Parse(parts[0]),
                    StringParser<N>.Parse(parts[1].StartsWith("r") ? parts[1][1..] : parts[1]));
            else throw new FormatException();
        }

        public static Circle<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new Circle<N>(
                    Vector2<N>.Parse(parts[0], style, provider),
                    StringParser<N>.Parse(parts[1].StartsWith("r") ? parts[1][1..] : parts[1], style, provider));
            else throw new FormatException();
        }

        public static bool operator ==(Circle<N> left, Circle<N> right) => left.Equals(right);
        public static bool operator !=(Circle<N> left, Circle<N> right) => !(left == right);

        Vector2<N> ITwoDimensional<Circle<N>, N>.GetCenter() => Center;
        IBitConverter<Circle<N>> IProvider<IBitConverter<Circle<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Circle<N>> IProvider<IRandom<Circle<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<Circle<N>> IProvider<IStringParser<Circle<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<Circle<N>>,
           IRandom<Circle<N>>,
           IStringParser<Circle<N>>
        {
            public readonly static Utilities Instance = new Utilities();

            Circle<N> IRandom<Circle<N>>.Next(Random random)
            {
                do
                {
                    var result = new Circle<N>(random.NextVector2<N>(), random.NextNumeric<N>());
                    try
                    {
                        if (checked(result.GetBounds() != default))
                        {
                            return result;
                        }
                    }
                    catch (OverflowException) { }
                } while (true);
            }

            Circle<N> IRandom<Circle<N>>.Next(Random random, Circle<N> bound1, Circle<N> bound2)
            {
                var xMin = Math<N>.Min(bound1.Center.X - bound1.Radius, bound2.Center.X - bound2.Radius);
                var xMax = Math<N>.Max(bound1.Center.X + bound1.Radius, bound2.Center.X + bound2.Radius);
                var yMin = Math<N>.Min(bound1.Center.Y - bound1.Radius, bound2.Center.Y - bound2.Radius);
                var yMax = Math<N>.Max(bound1.Center.Y + bound1.Radius, bound2.Center.Y + bound2.Radius);

                var center = new Vector2<N>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));

                var xMaxRadius = Math<N>.Min(xMax - center.X, center.X - xMin);
                var yMaxRadius = Math<N>.Min(yMax - center.Y, center.Y - yMin);
                var radius = random.NextNumeric(Numeric<N>.Zero, Math<N>.Min(xMaxRadius, yMaxRadius));

                return new Circle<N>(center, radius);
            }

            Circle<N> IStringParser<Circle<N>>.Parse(string s) => Parse(s);

            Circle<N> IStringParser<Circle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            Circle<N> IBitConverter<Circle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                return new Circle<N>(BitConverter<Vector2<N>>.Read(stream), BitConverter<N>.Read(stream));
            }

            void IBitConverter<Circle<N>>.Write(Circle<N> value, IWriteOnlyStream<byte> stream)
            {
                BitConverter<Vector2<N>>.Write(stream, value.Center);
                BitConverter<N>.Write(stream, value.Radius);
            }
        }
    }
}

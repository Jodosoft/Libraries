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
    public readonly struct Circle<TNumeric> :
            IEquatable<Circle<TNumeric>>,
            IFormattable,
            IProvider<IBitConverter<Circle<TNumeric>>>,
            IProvider<IRandom<Circle<TNumeric>>>,
            IProvider<IStringParser<Circle<TNumeric>>>,
            ITwoDimensional<Circle<TNumeric>, TNumeric>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        private const string Symbol = "○";

        public readonly Vector2<TNumeric> Center;
        public readonly TNumeric Radius;

        public TNumeric GetDiameter() => Numeric.Two<TNumeric>().Multiply(Radius);
        public TNumeric GetCircumeference() => Numeric.Two<TNumeric>().Multiply(MathN.PI<TNumeric>()).Multiply(Radius);

        public Circle(Vector2<TNumeric> center, TNumeric radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(TNumeric centerX, TNumeric centerY, TNumeric radius)
        {
            Center = new Vector2<TNumeric>(centerX, centerY);
            Radius = radius;
        }

        private Circle(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2<TNumeric>)info.GetValue(nameof(Center), typeof(Vector2<TNumeric>));
            Radius = (TNumeric)info.GetValue(nameof(Radius), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<TNumeric>));
            info.AddValue(nameof(Radius), Radius, typeof(TNumeric));
        }

        public Vector2<TNumeric>[] GetVertices(int circumferenceDivisor)
        {
            double centerX = ConvertN.ToDouble(Center.X);
            double centerY = ConvertN.ToDouble(Center.Y);
            double radius = ConvertN.ToDouble(Radius);

            Vector2<TNumeric>[]? results = new Vector2<TNumeric>[circumferenceDivisor + 1];
            results[0] = Center;
            for (int i = 0; i < circumferenceDivisor; i++)
            {
                double degrees = i * 360d / circumferenceDivisor;

                double radians = degrees * NumericUtilities.RadiansPerDegree;

                results[i + 1] = new Vector2<TNumeric>(
                    ConvertN.ToNumeric<TNumeric>(centerX + (radius * Math.Cos(radians))),
                    ConvertN.ToNumeric<TNumeric>(centerY + (radius * Math.Sin(radians))));
            }
            return results;
        }

        public TNumeric GetArea() => MathN.PI<TNumeric>().Multiply(MathN.Pow(Radius, Numeric.Two<TNumeric>()));
        public bool Contains(Circle<TNumeric> other) => Radius.IsGreaterThanOrEqualTo(other.Radius) && Center.DistanceFrom(other.Center).IsLessThanOrEqualTo(Radius.Subtract(other.Radius));
        public bool Contains(Vector2<TNumeric> point) => point.DistanceFrom(Center).IsLessThan(Radius);
        public Circle<TNumeric> Translate(Vector2<TNumeric> delta) => new Circle<TNumeric>(Center.Translate(delta), Radius);
        public Circle<TNumeric> Translate(TNumeric deltaX, TNumeric deltaY) => new Circle<TNumeric>(Center.Translate(new Vector2<TNumeric>(deltaX, deltaY)), Radius);
        public AARectangle<TNumeric> GetBounds() => AARectangle.FromCenter(Center, new Vector2<TNumeric>(GetDiameter(), GetDiameter()));
        public bool IntersectsWith(Circle<TNumeric> other) => Center.DistanceFrom(other.Center).IsLessThan(Radius.Add(other.Radius));

        public bool Equals(Circle<TNumeric> other) => Center.Equals(other.Center) && Radius.Equals(other.Radius);
        public override bool Equals(object? obj) => obj is Circle<TNumeric> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => $"{Symbol}({Center}, r{GetDiameter()})";
        public string ToString(string format, IFormatProvider formatProvider) => $"{Symbol}({Center.ToString(format, formatProvider)}, r{GetDiameter().ToString(format, formatProvider)})";

        public static bool operator ==(Circle<TNumeric> left, Circle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Circle<TNumeric> left, Circle<TNumeric> right) => !(left == right);

        Vector2<TNumeric> ITwoDimensional<Circle<TNumeric>, TNumeric>.GetCenter() => Center;
        IBitConverter<Circle<TNumeric>> IProvider<IBitConverter<Circle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IRandom<Circle<TNumeric>> IProvider<IRandom<Circle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IStringParser<Circle<TNumeric>> IProvider<IStringParser<Circle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<Circle<TNumeric>>,
           IRandom<Circle<TNumeric>>,
           IStringParser<Circle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Circle<TNumeric> IRandom<Circle<TNumeric>>.Next(Random random)
            {
                do
                {
                    Circle<TNumeric> result = new Circle<TNumeric>(random.NextVector2<TNumeric>(), random.NextNumeric<TNumeric>());
                    try
                    {
                        if (checked(result.GetBounds() != default))
                        {
                            return result;
                        }
                    }
                    catch (OverflowException)
                    {
                        // Try again
                    }
                } while (true);
            }

            Circle<TNumeric> IRandom<Circle<TNumeric>>.Next(Random random, Circle<TNumeric> bound1, Circle<TNumeric> bound2)
            {
                TNumeric xMin = MathN.Min(bound1.Center.X.Subtract(bound1.Radius), bound2.Center.X.Subtract(bound2.Radius));
                TNumeric xMax = MathN.Max(bound1.Center.X.Add(bound1.Radius), bound2.Center.X.Add(bound2.Radius));
                TNumeric yMin = MathN.Min(bound1.Center.Y.Subtract(bound1.Radius), bound2.Center.Y.Subtract(bound2.Radius));
                TNumeric yMax = MathN.Max(bound1.Center.Y.Add(bound1.Radius), bound2.Center.Y.Add(bound2.Radius));

                Vector2<TNumeric> center = new Vector2<TNumeric>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));

                TNumeric xMaxRadius = MathN.Min(xMax.Subtract(center.X), center.X.Subtract(xMin));
                TNumeric yMaxRadius = MathN.Min(yMax.Subtract(center.Y), center.Y.Subtract(yMin));
                TNumeric radius = random.NextNumeric(Numeric.Zero<TNumeric>(), MathN.Min(xMaxRadius, yMaxRadius));

                return new Circle<TNumeric>(center, radius);
            }

            Circle<TNumeric> IStringParser<Circle<TNumeric>>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
            {
                string[] parts = StringUtilities.ParseVectorParts(s.Replace(Symbol, string.Empty));
                if (parts.Length == 2)
                    return new Circle<TNumeric>(
                        StringParser.Parse<Vector2<TNumeric>>(parts[0], style, provider),
                        StringParser.Parse<TNumeric>(parts[1].StartsWith("r", StringComparison.InvariantCultureIgnoreCase) ? parts[1].Substring(1) : parts[1], style, provider));
                else throw new FormatException();
            }

            Circle<TNumeric> IBitConverter<Circle<TNumeric>>.Read(IReader<byte> stream)
            {
                return new Circle<TNumeric>(BitConvert.Read<Vector2<TNumeric>>(stream), BitConvert.Read<TNumeric>(stream));
            }

            void IBitConverter<Circle<TNumeric>>.Write(Circle<TNumeric> value, IWriter<byte> stream)
            {
                BitConvert.Write(stream, value.Center);
                BitConvert.Write(stream, value.Radius);
            }
        }
    }
}

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
            IProvider<IVariantRandom<Circle<TNumeric>>>,
            ISerializable,
            ITwoDimensional<Circle<TNumeric>, TNumeric>
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly TNumeric Radius;

        public TNumeric GetDiameter() => Numeric.Two<TNumeric>().Multiply(Radius);
        public TNumeric GetCircumeference() => Numeric.Two<TNumeric>().Multiply(MathN.PI<TNumeric>()).Multiply(Radius);

        public Circle(Vector2N<TNumeric> center, TNumeric radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(TNumeric centerX, TNumeric centerY, TNumeric radius)
        {
            Center = new Vector2N<TNumeric>(centerX, centerY);
            Radius = radius;
        }

        private Circle(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2N<TNumeric>)info.GetValue(nameof(Center), typeof(Vector2N<TNumeric>));
            Radius = (TNumeric)info.GetValue(nameof(Radius), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Radius), Radius, typeof(TNumeric));
        }

        public Vector2N<TNumeric>[] GetVertices(int circumferenceDivisor)
        {
            double centerX = ConvertN.ToDouble(Center.X);
            double centerY = ConvertN.ToDouble(Center.Y);
            double radius = ConvertN.ToDouble(Radius);

            Vector2N<TNumeric>[]? results = new Vector2N<TNumeric>[circumferenceDivisor + 1];
            results[0] = Center;
            for (int i = 0; i < circumferenceDivisor; i++)
            {
                double degrees = i * 360d / circumferenceDivisor;

                double radians = degrees * BitOperations.RadiansPerDegree;

                results[i + 1] = new Vector2N<TNumeric>(
                    ConvertN.ToNumeric<TNumeric>(centerX + (radius * Math.Cos(radians))),
                    ConvertN.ToNumeric<TNumeric>(centerY + (radius * Math.Sin(radians))));
            }
            return results;
        }

        public TNumeric GetArea() => MathN.PI<TNumeric>().Multiply(MathN.Pow(Radius, Numeric.Two<TNumeric>()));
        public bool Contains(Circle<TNumeric> other) => Radius.IsGreaterThanOrEqualTo(other.Radius) && Center.DistanceFrom(other.Center).IsLessThanOrEqualTo(Radius.Subtract(other.Radius));
        public bool Contains(Vector2N<TNumeric> point) => point.DistanceFrom(Center).IsLessThan(Radius);
        public Circle<TNumeric> Translate(Vector2N<TNumeric> delta) => new Circle<TNumeric>(Center.Translate(delta), Radius);
        public Circle<TNumeric> Translate(TNumeric deltaX, TNumeric deltaY) => new Circle<TNumeric>(Center.Translate(new Vector2N<TNumeric>(deltaX, deltaY)), Radius);
        public AARectangle<TNumeric> GetBounds() => AARectangle.FromCenter(Center, new Vector2N<TNumeric>(GetDiameter(), GetDiameter()));
        public bool IntersectsWith(Circle<TNumeric> other) => Center.DistanceFrom(other.Center).IsLessThan(Radius.Add(other.Radius));

        public bool Equals(Circle<TNumeric> other) => Center.Equals(other.Center) && Radius.Equals(other.Radius);
        public override bool Equals(object? obj) => obj is Circle<TNumeric> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => $"<X:{Center.X}, Y:{Center.Y}, R:{Radius}>";
        public string ToString(string format, IFormatProvider formatProvider) => $"<X:{Center.X.ToString(format, formatProvider)}, Y:{Center.Y.ToString(format, formatProvider)}, R:{Radius.ToString(format, formatProvider)}>";

        public static bool operator ==(Circle<TNumeric> left, Circle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Circle<TNumeric> left, Circle<TNumeric> right) => !(left == right);

        Vector2N<TNumeric> ITwoDimensional<Circle<TNumeric>, TNumeric>.GetCenter() => Center;

        IVariantRandom<Circle<TNumeric>> IProvider<IVariantRandom<Circle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IVariantRandom<Circle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Circle<TNumeric> IVariantRandom<Circle<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Circle<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(scenarios),
                    random.NextVariant<TNumeric>(scenarios));
            }
        }
    }

    public static class Circle
    {
        public static Circle<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 3)
                return new Circle<TNumeric>(
                    Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[2].Replace("R:", string.Empty).Trim(), style, provider));
            else throw new FormatException();
        }
    }
}

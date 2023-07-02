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
using System.IO;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct CircleN<TNumeric> :
            IEquatable<CircleN<TNumeric>>,
            IFormattable,
            IProvider<IBinaryIO<CircleN<TNumeric>>>,
            IProvider<IVariantRandom<CircleN<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly TNumeric Radius;

        public TNumeric GetDiameter() => Radius.Double();
        public TNumeric GetCircumeference() => MathN.PI<TNumeric>().Double().Multiply(Radius);

        public CircleN(Vector2N<TNumeric> center, TNumeric radius)
        {
            Center = center;
            Radius = radius;
        }

        public CircleN(TNumeric centerX, TNumeric centerY, TNumeric radius)
        {
            Center = new Vector2N<TNumeric>(centerX, centerY);
            Radius = radius;
        }

        private CircleN(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2N<TNumeric>)info.GetValue(nameof(Center), typeof(Vector2N<TNumeric>));
            Radius = (TNumeric)info.GetValue(nameof(Radius), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Radius), Radius, typeof(TNumeric));
        }

        public TNumeric GetArea() => MathN.PI<TNumeric>().Multiply(Radius).Multiply(Radius);
        public bool Contains(CircleN<TNumeric> other) => Radius.IsGreaterThanOrEqualTo(other.Radius) && Center.DistanceFrom(other.Center).IsLessThanOrEqualTo(Radius.Subtract(other.Radius));
        public bool Contains(Vector2N<TNumeric> point) => point.DistanceFrom(Center).IsLessThan(Radius);
        public CircleN<TNumeric> Translate(Vector2N<TNumeric> delta) => new CircleN<TNumeric>(Center.Translate(delta), Radius);
        public CircleN<TNumeric> Translate(TNumeric deltaX, TNumeric deltaY) => new CircleN<TNumeric>(Center.Translate(new Vector2N<TNumeric>(deltaX, deltaY)), Radius);
        public AARectangleN<TNumeric> GetBounds() => AARectangleN.FromCenter(Center, new Vector2N<TNumeric>(GetDiameter(), GetDiameter()));
        public bool IntersectsWith(CircleN<TNumeric> other) => Center.DistanceFrom(other.Center).IsLessThan(Radius.Add(other.Radius));

        public bool Equals(CircleN<TNumeric> other) => Center.Equals(other.Center) && Radius.Equals(other.Radius);
        public override bool Equals(object? obj) => obj is CircleN<TNumeric> circle && Equals(circle);
        public override int GetHashCode() => HashCodeShim.Combine(Center, Radius);
        public override string ToString() => $"<X:{Center.X}, Y:{Center.Y}, R:{Radius}>";
        public string ToString(string format, IFormatProvider formatProvider) => $"<X:{Center.X.ToString(format, formatProvider)}, Y:{Center.Y.ToString(format, formatProvider)}, R:{Radius.ToString(format, formatProvider)}>";

        public static bool operator ==(CircleN<TNumeric> left, CircleN<TNumeric> right) => left.Equals(right);
        public static bool operator !=(CircleN<TNumeric> left, CircleN<TNumeric> right) => !(left == right);

        IBinaryIO<CircleN<TNumeric>> IProvider<IBinaryIO<CircleN<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<CircleN<TNumeric>> IProvider<IVariantRandom<CircleN<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBinaryIO<CircleN<TNumeric>>,
           IVariantRandom<CircleN<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<CircleN<TNumeric>>.Write(BinaryWriter writer, CircleN<TNumeric> value)
            {
                writer.Write(value.Center);
                writer.Write(value.Radius);
            }

            CircleN<TNumeric> IBinaryIO<CircleN<TNumeric>>.Read(BinaryReader reader)
            {
                return new CircleN<TNumeric>(
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<TNumeric>());
            }

            CircleN<TNumeric> IVariantRandom<CircleN<TNumeric>>.Generate(Random random, Variants variants)
            {
                return new CircleN<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(variants),
                    random.NextVariant<TNumeric>(variants));
            }
        }
    }

    public static class CircleN
    {
        public static CircleN<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 3)
                return new CircleN<TNumeric>(
                    Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[2].Replace("R:", string.Empty).Trim(), style, provider));
            else throw new FormatException();
        }
    }
}

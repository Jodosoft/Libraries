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

        public bool Contains(Circle<N> other)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2<N> point) => point.DistanceFrom(Center) < Radius;

        public N GetArea() => Math<N>.PI * Math<N>.Pow(Radius, Numeric<N>.Two);

        public ReadOnlySpan<Vector2<N>> GetVertices(int pointsPerRadian)
        {
            throw new NotImplementedException();
        }

        public Circle<N> Translate(Vector2<N> delta) => new Circle<N>(Center.Translate(delta), Radius);
        public Circle<N> Translate(N deltaX, N deltaY) => new Circle<N>(Center.Translate((deltaX, deltaY)), Radius);
        public AARectangle<N> GetBounds() => AARectangle<N>.FromCenter(Center, (GetDiameter(), GetDiameter()));
        public bool IntersectsWith(Circle<N> other) => Center.DistanceFrom(other.Center) < Radius + other.Radius;

        public bool Equals(Circle<N> other) => Center.Equals(other.Center) && Radius.Equals(other.Radius);
        public override bool Equals(object? obj) => obj is Circle<N> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => $"{Symbol}({Center}, r{GetDiameter()})";
        public string ToString(string format, IFormatProvider formatProvider) => $"{Symbol}({Center.ToString(format, formatProvider)}, r{GetDiameter().ToString(format, formatProvider)})";


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
                throw new NotImplementedException();
            }

            Circle<N> IRandom<Circle<N>>.Next(Random random, Circle<N> bound1, Circle<N> bound2)
            {
                throw new NotImplementedException();
            }

            Circle<N> IStringParser<Circle<N>>.Parse(string s)
            {
                throw new NotImplementedException();
            }

            Circle<N> IStringParser<Circle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
            {
                throw new NotImplementedException();
            }

            Circle<N> IBitConverter<Circle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }

            void IBitConverter<Circle<N>>.Write(Circle<N> value, IWriteOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}

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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Circle<N> : IGeometric<Circle<N>> where N : struct, INumeric<N>
    {
        public readonly Vector2<N> Center;
        public readonly N Radius;

        public N Diameter => Numeric<N>.Two * Radius;
        public N Area => Math<N>.PI * Math<N>.Pow(Radius, Numeric<N>.Two);
        public N Circumeference => Numeric<N>.Two * Math<N>.PI * Radius;


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

#pragma warning disable CS8605 // Unboxing a possibly null value.
        private Circle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>)),
            (N)info.GetValue(nameof(Radius), typeof(N)))
        { }
#pragma warning restore CS8605 // Unboxing a possibly null value.

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Radius), Radius, typeof(N));
        }

        public Circle<N> Translate(Vector2<N> delta) => new Circle<N>(Center.Translate(delta), Radius);
        public Circle<N> Translate(N deltaX, N deltaY) => new Circle<N>(Center.Translate((deltaX, deltaY)), Radius);
        public AARectangle<N> GetBounds() => AARectangle<N>.FromCenter(Center, (Diameter, Diameter));
        public bool IntersectsWith(Circle<N> other) => Center.DistanceFrom(other.Center) < Radius + other.Radius;


        public bool Equals(Circle<N> other) => Center.Equals(other.Center) && EqualityComparer<N>.Default.Equals(Radius, other.Radius);
        public override bool Equals(object? obj) => obj is Circle<N> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Radius);
        public string ToString(string? format, IFormatProvider? formatProvider) => throw new NotImplementedException();

        public static bool operator ==(Circle<N> left, Circle<N> right) => left.Equals(right);
        public static bool operator !=(Circle<N> left, Circle<N> right) => !(left == right);
    }
}

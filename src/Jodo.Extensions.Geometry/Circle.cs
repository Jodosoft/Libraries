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
    public readonly struct Circle<T> : IGeometric<Circle<T>> where T : struct, INumeric<T>
    {
        public readonly Vector2<T> Center;
        public readonly T Radius;

        public T Diameter => 2 * Radius;
        public T Area => Math<T>.PI * Math<T>.Pow(Radius, 2);
        public T Circumeference => 2 * Math<T>.PI * Radius;

        IBitConverter<Circle<T>> IBitConvertible<Circle<T>>.BitConverter => throw new NotImplementedException();

        IRandom<Circle<T>> IRandomisable<Circle<T>>.Random => throw new NotImplementedException();

        IStringParser<Circle<T>> IStringRepresentable<Circle<T>>.StringParser => throw new NotImplementedException();

        public Circle(Vector2<T> center, T radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(T centerX, T centerY, T radius)
        {
            Center = new Vector2<T>(centerX, centerY);
            Radius = radius;
        }

        private Circle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<T>)info.GetValue(nameof(Center), typeof(Vector2<T>)),
            (T)info.GetValue(nameof(Radius), typeof(T)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<T>));
            info.AddValue(nameof(Radius), Radius, typeof(T));
        }

        public Circle<T> Translate(Vector2<T> delta) => new Circle<T>(Center.Translate(delta), Radius);
        public Circle<T> Translate(T deltaX, T deltaY) => new Circle<T>(Center.Translate(deltaX, deltaY), Radius);
        public AARectangle<T> GetBounds() => AARectangle<T>.FromCenter(Center, (Diameter, Diameter));
        public bool IntersectsWith(Circle<T> other) => Center.DistanceFrom(other.Center) < Radius + other.Radius;


        public bool Equals(Circle<T> other) => Center.Equals(other.Center) && EqualityComparer<T>.Default.Equals(Radius, other.Radius);
        public override bool Equals(object? obj) => obj is Circle<T> circle && Equals(circle);
        public override int GetHashCode() => HashCode.Combine(Center, Radius);
        public override string ToString() => StringRepresentation.Combine(GetType(), Center, Radius);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static bool operator ==(Circle<T> left, Circle<T> right) => left.Equals(right);
        public static bool operator !=(Circle<T> left, Circle<T> right) => !(left == right);
    }
}

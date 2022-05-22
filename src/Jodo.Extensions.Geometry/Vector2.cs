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
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Vector2<N> : IGeometric<Vector2<N>> where N : struct, INumeric<N>
    {
        public readonly N X;
        public readonly N Y;

        public N Length => Math<N>.Sqrt((X * X) + (Y * Y));

        IBitConverter<Vector2<N>> IBitConvertible<Vector2<N>>.BitConverter => throw new NotImplementedException();

        IRandom<Vector2<N>> IRandomisable<Vector2<N>>.Random => throw new NotImplementedException();

        IStringParser<Vector2<N>> IStringParsable<Vector2<N>>.StringParser => throw new NotImplementedException();

        public Vector2(byte x, N y) : this(Convert<N>.ToNumeric(x), y) { }
        public Vector2(N x, byte y) : this(x, Convert<N>.ToNumeric(y)) { }
        public Vector2(byte x, byte y) : this(Convert<N>.ToNumeric(x), Convert<N>.ToNumeric(y)) { }

        public Vector2(N x, N y)
        {
            X = x;
            Y = y;
        }

        private Vector2(SerializationInfo info, StreamingContext context) : this(
            (N)info.GetValue(nameof(X), typeof(N)),
            (N)info.GetValue(nameof(Y), typeof(N)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(N));
            info.AddValue(nameof(Y), Y, typeof(N));
        }

        public Vector2<N> RotateAround(Vector2<N> pivot, Angle<N> angle)
        {
            var newAngle = -angle;
            var difference = this - pivot;
            return pivot + new Vector2<N>(
                (difference.X * newAngle.Cosine) - (difference.Y * newAngle.Sine),
                (difference.X * newAngle.Sine) + (difference.Y * newAngle.Cosine));
        }

        public N DistanceFrom(Vector2<N> point) => Math<N>.Sqrt(Math<N>.Pow(X - point.X, Math<N>.Two) + Math<N>.Pow(Y - point.Y, Math<N>.Two));
        public N DistanceFrom((N X, N Y) point) => DistanceFrom((Vector2<N>)point);
        public N DistanceFrom(N x, N y) => DistanceFrom((x, y));
        public Vector2<N> Translate((N X, N Y) delta) => new Vector2<N>(X + delta.X, Y + delta.Y);
        public Vector2<N> Translate(N x, N y) => Translate((x, y));

        public bool Equals(Vector2<N> other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object? obj) => obj is Vector2<N> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => StringRepresentation.Combine(GetType(), X, Y);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static bool TryParse(string value, out Vector2<N> result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static Vector2<N> Parse(string value)
        {
            value = value.Replace(StringRepresentation.Combine(typeof(Vector2<N>)), string.Empty);
            var args = value.Replace("(", string.Empty).Replace(")", string.Empty).Split(",");
            if (args.Length != 2) throw new FormatException(""); // jjs
            return new Vector2<N>(StringParser<N>.Parse(args[0].Trim()), StringParser<N>.Parse(args[1].Trim()));
        }


        public static Vector2<N> operator -(Vector2<N> value) => new Vector2<N>(-value.X, -value.Y);
        public static Vector2<N> operator -(Vector2<N> value1, Vector2<N> value2) => new Vector2<N>(value1.X - value2.X, value1.Y - value2.Y);
        public static Vector2<N> operator *(Vector2<N> value, N scalar) => new Vector2<N>(value.X * scalar, value.Y * scalar);
        public static Vector2<N> operator *(N scalar, Vector2<N> value) => value * scalar;
        public static Vector2<N> operator /(Vector2<N> value, N scalar) => new Vector2<N>(value.X / scalar, value.Y / scalar);
        public static Vector2<N> operator +(Vector2<N> value) => value;
        public static Vector2<N> operator +(Vector2<N> value1, Vector2<N> value2) => new Vector2<N>(value1.X + value2.X, value1.Y + value2.Y);
        public static implicit operator Vector2<N>((N, N) value) => new Vector2<N>(value.Item1, value.Item2);
        public static implicit operator (N, N)(Vector2<N> value) => (value.X, value.Y);
        public static implicit operator Vector2<N>(Tuple<N, N> value) => new Vector2<N>(value.Item1, value.Item2);
        public static implicit operator Tuple<N, N>(Vector2<N> value) => new Tuple<N, N>(value.X, value.Y);
        public static bool operator ==(Vector2<N> left, Vector2<N> right) => left.Equals(right);
        public static bool operator !=(Vector2<N> left, Vector2<N> right) => !(left == right);
    }
}

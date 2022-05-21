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
    public readonly struct Vector2<T> : IGeometric<Vector2<T>> where T : struct, INumeric<T>
    {
        public readonly T X;
        public readonly T Y;

        public T Length => Math<T>.Sqrt((X * X) + (Y * Y));

        IBitConverter<Vector2<T>> IBitConvertible<Vector2<T>>.BitConverter => throw new NotImplementedException();

        IRandom<Vector2<T>> IRandomisable<Vector2<T>>.Random => throw new NotImplementedException();

        IStringParser<Vector2<T>> IStringParsable<Vector2<T>>.StringParser => throw new NotImplementedException();

        public Vector2(byte x, T y) : this(Convert<T>.ToValue(x), y) { }
        public Vector2(T x, byte y) : this(x, Convert<T>.ToValue(y)) { }
        public Vector2(byte x, byte y) : this(Convert<T>.ToValue(x), Convert<T>.ToValue(y)) { }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        private Vector2(SerializationInfo info, StreamingContext context) : this(
            (T)info.GetValue(nameof(X), typeof(T)),
            (T)info.GetValue(nameof(Y), typeof(T)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(T));
            info.AddValue(nameof(Y), Y, typeof(T));
        }

        public Vector2<T> RotateAround(Vector2<T> pivot, Angle<T> angle)
        {
            var newAngle = -angle;
            var difference = this - pivot;
            return pivot + new Vector2<T>(
                (difference.X * newAngle.Cosine) - (difference.Y * newAngle.Sine),
                (difference.X * newAngle.Sine) + (difference.Y * newAngle.Cosine));
        }

        public T DistanceFrom(Vector2<T> point) => Math<T>.Sqrt(Math<T>.Pow(X - point.X, 2) + Math<T>.Pow(Y - point.Y, 2));
        public T DistanceFrom((T X, T Y) point) => DistanceFrom((Vector2<T>)point);
        public T DistanceFrom(T x, T y) => DistanceFrom((x, y));
        public Vector2<T> Translate((T X, T Y) delta) => new Vector2<T>(X + delta.X, Y + delta.Y);
        public Vector2<T> Translate(T x, T y) => Translate((x, y));

        public bool Equals(Vector2<T> other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object? obj) => obj is Vector2<T> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => StringRepresentation.Combine(GetType(), X, Y);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static bool TryParse(string value, out Vector2<T> result)
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

        public static Vector2<T> Parse(string value)
        {
            value = value.Replace(StringRepresentation.Combine(typeof(Vector2<T>)), string.Empty);
            var args = value.Replace("(", string.Empty).Replace(")", string.Empty).Split(",");
            if (args.Length != 2) throw new FormatException(""); // jjs
            return new Vector2<T>(StringParser<T>.Parse(args[0].Trim()), StringParser<T>.Parse(args[1].Trim()));
        }


        public static Vector2<T> operator -(Vector2<T> value) => new Vector2<T>(-value.X, -value.Y);
        public static Vector2<T> operator -(Vector2<T> value1, Vector2<T> value2) => new Vector2<T>(value1.X - value2.X, value1.Y - value2.Y);
        public static Vector2<T> operator *(Vector2<T> value, T scalar) => new Vector2<T>(value.X * scalar, value.Y * scalar);
        public static Vector2<T> operator *(T scalar, Vector2<T> value) => value * scalar;
        public static Vector2<T> operator /(Vector2<T> value, T scalar) => new Vector2<T>(value.X / scalar, value.Y / scalar);
        public static Vector2<T> operator +(Vector2<T> value) => value;
        public static Vector2<T> operator +(Vector2<T> value1, Vector2<T> value2) => new Vector2<T>(value1.X + value2.X, value1.Y + value2.Y);
        public static implicit operator Vector2<T>((T, T) value) => new Vector2<T>(value.Item1, value.Item2);
        public static implicit operator (T, T)(Vector2<T> value) => (value.X, value.Y);
        public static implicit operator Vector2<T>(Tuple<T, T> value) => new Vector2<T>(value.Item1, value.Item2);
        public static implicit operator Tuple<T, T>(Vector2<T> value) => new Tuple<T, T>(value.X, value.Y);
        public static bool operator ==(Vector2<T> left, Vector2<T> right) => left.Equals(right);
        public static bool operator !=(Vector2<T> left, Vector2<T> right) => !(left == right);
    }
}

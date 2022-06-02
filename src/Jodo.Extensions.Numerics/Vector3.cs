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

using Jodo.Extensions.Primitives;
using System;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    public readonly struct Vector3<N> : ISerializable where N : struct, INumeric<N>
    {
        public readonly N X;
        public readonly N Y;
        public readonly N Z;

        public N Length => Math<N>.Sqrt((X * X) + (Y * Y) + (Z * Z));



        public Vector3(N x, N y, N z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private Vector3(SerializationInfo info, StreamingContext context) : this(
            (N)info.GetValue(nameof(X), typeof(N)),
            (N)info.GetValue(nameof(Y), typeof(N)),
            (N)info.GetValue(nameof(Z), typeof(N)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(N));
            info.AddValue(nameof(Y), Y, typeof(N));
            info.AddValue(nameof(Z), Z, typeof(N));
        }

        public bool Equals(Vector3<N> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public override bool Equals(object? obj) => obj is Vector3<N> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        public override string ToString() => StringRepresentation.Combine(GetType(), X, Y, Z);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static bool TryParse(string value, out Vector3<N> result)
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

        public static Vector3<N> Parse(string value)
        {
            value = value.Replace(StringRepresentation.Combine(typeof(Vector3<N>)), string.Empty);
            var args = value.Replace("(", string.Empty).Replace(")", string.Empty).Split(",");
            if (args.Length != 3) throw new FormatException();
            return new Vector3<N>(
                StringParser<N>.Parse(args[0].Trim()),
                StringParser<N>.Parse(args[1].Trim()),
                StringParser<N>.Parse(args[2].Trim()));
        }

        public static Vector3<N> operator -(Vector3<N> value) => new Vector3<N>(-value.X, -value.Y, -value.Z);
        public static Vector3<N> operator -(Vector3<N> value1, Vector3<N> value2) => new Vector3<N>(value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z);
        public static Vector3<N> operator *(Vector3<N> value, N scalar) => new Vector3<N>(value.X * scalar, value.Y * scalar, value.Z * scalar);
        public static Vector3<N> operator *(N scalar, Vector3<N> value) => value * scalar;
        public static Vector3<N> operator /(Vector3<N> value, N scalar) => new Vector3<N>(value.X / scalar, value.Y / scalar, value.Z / scalar);
        public static Vector3<N> operator +(Vector3<N> value) => value;
        public static Vector3<N> operator +(Vector3<N> value1, Vector3<N> value2) => new Vector3<N>(value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z);
        public static implicit operator Vector3<N>((N, N, N) value) => new Vector3<N>(value.Item1, value.Item2, value.Item3);
        public static implicit operator (N, N, N)(Vector3<N> value) => (value.X, value.Y, value.Z);
        public static implicit operator Vector3<N>(Tuple<N, N, N> value) => new Vector3<N>(value.Item1, value.Item2, value.Item3);
        public static implicit operator Tuple<N, N, N>(Vector3<N> value) => new Tuple<N, N, N>(value.X, value.Y, value.Z);
        public static bool operator ==(Vector3<N> left, Vector3<N> right) => left.Equals(right);
        public static bool operator !=(Vector3<N> left, Vector3<N> right) => !(left == right);
    }
}

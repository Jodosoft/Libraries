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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Vector3<N> :
            IEquatable<Vector3<N>>,
            IFormattable,
            IProvider<IBitConverter<Vector3<N>>>,
            IProvider<IRandom<Vector3<N>>>,
            IProvider<IStringParser<Vector3<N>>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        public readonly N X;
        public readonly N Y;
        public readonly N Z;

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
        public override string ToString() => $"({X}, {Y}, {Z})";
        public string ToString(string format, IFormatProvider provider)
            => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)})";


        public static bool TryParse(string value, out Vector3<N> result) => Try.Run(() => Parse(value), out result);

        public static Vector3<N> Parse(string value)
        {
            var (x, y, z) = ParseParts(ref value);
            return new Vector3<N>(
                StringParser<N>.Parse(x),
                StringParser<N>.Parse(y),
                StringParser<N>.Parse(z));
        }

        public static Vector3<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            var (x, y, z) = ParseParts(ref value);
            return new Vector3<N>(
                StringParser<N>.Parse(x, style, provider),
                StringParser<N>.Parse(y, style, provider),
                StringParser<N>.Parse(z, style, provider));
        }

        private static (string X, string Y, string Z) ParseParts(ref string value)
        {
            value = value.Replace(StringRepresentation.Combine(typeof(Vector2<N>)), string.Empty);
            var parts = value.Replace("(", string.Empty).Replace(")", string.Empty).Split(",");
            if (parts.Length != 3) throw new FormatException();
            return (parts[0], parts[1], parts[2]);
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

        IBitConverter<Vector3<N>> IProvider<IBitConverter<Vector3<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Vector3<N>> IProvider<IRandom<Vector3<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<Vector3<N>> IProvider<IStringParser<Vector3<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<Vector3<N>>,
           IRandom<Vector3<N>>,
           IStringParser<Vector3<N>>
        {
            public readonly static Utilities Instance = new Utilities();

            Vector3<N> IRandom<Vector3<N>>.Next(Random random)
            {
                return new Vector3<N>(
                    random.NextNumeric<N>(),
                    random.NextNumeric<N>(),
                    random.NextNumeric<N>());
            }

            Vector3<N> IRandom<Vector3<N>>.Next(Random random, Vector3<N> bound1, Vector3<N> bound2)
            {
                return new Vector3<N>(
                    random.NextNumeric(bound1.X, bound2.X),
                    random.NextNumeric(bound1.Y, bound2.Y),
                    random.NextNumeric(bound1.Z, bound2.Z));
            }

            Vector3<N> IStringParser<Vector3<N>>.Parse(string s)
            {
                return Parse(s);
            }

            Vector3<N> IStringParser<Vector3<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
            {
                return Parse(s, style, provider);
            }

            Vector3<N> IBitConverter<Vector3<N>>.Read(IReadOnlyStream<byte> stream)
            {
                return new Vector3<N>(
                    BitConverter<N>.Read(stream),
                    BitConverter<N>.Read(stream),
                    BitConverter<N>.Read(stream));
            }

            void IBitConverter<Vector3<N>>.Write(Vector3<N> value, IWriteOnlyStream<byte> stream)
            {
                BitConverter<N>.Write(stream, value.X);
                BitConverter<N>.Write(stream, value.Y);
                BitConverter<N>.Write(stream, value.Z);
            }
        }
    }
}

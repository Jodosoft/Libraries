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
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Primitives.Compatibility;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [CLSCompliant(false)]
    public readonly struct Vector2<N> :
            IEquatable<Vector2<N>>,
            IFormattable,
            IProvider<IBitConverter<Vector2<N>>>,
            IProvider<IRandom<Vector2<N>>>,
            IProvider<IStringParser<Vector2<N>>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private const string Symbol = "→";

        public static readonly Vector2<N> Zero = default;

        public readonly N X;
        public readonly N Y;

        public Vector2(N x, N y)
        {
            X = x;
            Y = y;
        }

        private Vector2(SerializationInfo info, StreamingContext context)
        {
            X = (N)info.GetValue(nameof(X), typeof(N));
            Y = (N)info.GetValue(nameof(Y), typeof(N));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(N));
            info.AddValue(nameof(Y), Y, typeof(N));
        }

        public Vector2<NResult> Convert<NResult>(Func<N, NResult> convert) where NResult : struct, INumeric<NResult> => new Vector2<NResult>(convert(X), convert(Y));

        public bool Equals(Vector2<N> other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object? obj) => obj is Vector2<N> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => $"{Symbol}({X}, {Y})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)})";

        public static bool TryParse(string value, out Vector2<N> result) => Try.Run(() => Parse(value), out result);
        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out Vector2<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static Vector2<N> Parse(string value)
        {
            string[] parts = StringUtilities.ParseVectorParts(value.Trim().Replace(Symbol, string.Empty));
            if (parts.Length != 2) throw new FormatException();
            return new Vector2<N>(
                StringParser<N>.Parse(parts[0]),
                StringParser<N>.Parse(parts[1]));
        }

        public static Vector2<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            string[] parts = StringUtilities.ParseVectorParts(value.Trim().Replace(Symbol, string.Empty));
            if (parts.Length != 2) throw new FormatException();
            return new Vector2<N>(
                StringParser<N>.Parse(parts[0], style, provider),
                StringParser<N>.Parse(parts[1], style, provider));
        }

        public static Vector2<N> operator -(Vector2<N> value) => new Vector2<N>(value.X.Negative(), value.Y.Negative());
        public static Vector2<N> operator -(Vector2<N> value1, Vector2<N> value2) => new Vector2<N>(value1.X.Subtract(value2.X), value1.Y.Subtract(value2.Y));
        public static Vector2<N> operator *(Vector2<N> value, N scalar) => new Vector2<N>(value.X.Multiply(scalar), value.Y.Multiply(scalar));
        public static Vector2<N> operator *(N scalar, Vector2<N> value) => value * scalar;
        public static Vector2<N> operator /(Vector2<N> value, N scalar) => new Vector2<N>(value.X.Divide(scalar), value.Y.Divide(scalar));
        public static Vector2<N> operator +(Vector2<N> value) => value;
        public static Vector2<N> operator +(Vector2<N> value1, Vector2<N> value2) => new Vector2<N>(value1.X.Add(value2.X), value1.Y.Add(value2.Y));
        public static implicit operator Vector2<N>((N, N) value) => new Vector2<N>(value.Item1, value.Item2);
        public static implicit operator (N, N)(Vector2<N> value) => (value.X, value.Y);
        public static implicit operator Vector2<N>(Tuple<N, N> value) => new Vector2<N>(value.Item1, value.Item2);
        public static implicit operator Tuple<N, N>(Vector2<N> value) => new Tuple<N, N>(value.X, value.Y);
        public static bool operator ==(Vector2<N> left, Vector2<N> right) => left.Equals(right);
        public static bool operator !=(Vector2<N> left, Vector2<N> right) => !(left == right);

        IBitConverter<Vector2<N>> IProvider<IBitConverter<Vector2<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Vector2<N>> IProvider<IRandom<Vector2<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<Vector2<N>> IProvider<IStringParser<Vector2<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<Vector2<N>>,
           IRandom<Vector2<N>>,
           IStringParser<Vector2<N>>
        {
            public static readonly Utilities Instance = new Utilities();

            Vector2<N> IRandom<Vector2<N>>.Next(Random random)
            {
                return new Vector2<N>(random.NextNumeric<N>(), random.NextNumeric<N>());
            }

            Vector2<N> IRandom<Vector2<N>>.Next(Random random, Vector2<N> bound1, Vector2<N> bound2)
            {
                return new Vector2<N>(random.NextNumeric(bound1.X, bound2.X), random.NextNumeric(bound1.Y, bound2.Y));
            }

            Vector2<N> IStringParser<Vector2<N>>.Parse(string s)
            {
                return Parse(s);
            }

            Vector2<N> IStringParser<Vector2<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
            {
                return Parse(s, style, provider);
            }

            Vector2<N> IBitConverter<Vector2<N>>.Read(IReadOnlyStream<byte> stream)
            {
                return new Vector2<N>(BitConverter<N>.Read(stream), BitConverter<N>.Read(stream));
            }

            void IBitConverter<Vector2<N>>.Write(Vector2<N> value, IWriteOnlyStream<byte> stream)
            {
                BitConverter<N>.Write(stream, value.X);
                BitConverter<N>.Write(stream, value.Y);
            }
        }
    }
}

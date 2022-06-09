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
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Triangle<N> :
            IEquatable<Triangle<N>>,
            IFormattable,
            IProvider<IBitConverter<Triangle<N>>>,
            IProvider<IRandom<Triangle<N>>>,
            IProvider<IStringParser<Triangle<N>>>,
            ITwoDimensional<Triangle<N>, N>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private static readonly string Symbol = "△";

        public readonly Vector2<N> A;
        public readonly Vector2<N> B;
        public readonly Vector2<N> C;

        public Triangle(Vector2<N> a, Vector2<N> b, Vector2<N> c)
        {
            A = a;
            B = b;
            C = c;
        }

        private Triangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(A), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(B), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(C), typeof(Vector2<N>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(A), A, typeof(Vector2<N>));
            info.AddValue(nameof(B), B, typeof(Vector2<N>));
            info.AddValue(nameof(C), C, typeof(Vector2<N>));
        }

        public AARectangle<N> GetBounds()
        {
            throw new NotImplementedException();
        }

        public N GetArea()
        {
            throw new NotImplementedException();
        }

        public ReadOnlySpan<Vector2<N>> GetVertices()
        {
            throw new NotImplementedException();
        }

        public Vector2<N> GetCenter()
        {
            throw new NotImplementedException();
        }

        public Triangle<N> Translate(Vector2<N> delta) => new Triangle<N>(A + delta, B + delta, C + delta);

        public bool Contains(Vector2<N> point) => throw new NotImplementedException();
        public bool Contains((N, N) point) => Contains((Vector2<N>)point);
        public bool Contains(N pointX, N pointY) => Contains(new Vector2<N>(pointX, pointY));

        public bool Contains(Triangle<N> other) => throw new NotImplementedException();
        public bool IntersectsWith(Triangle<N> other) => throw new NotImplementedException();

        public Triangle<N> Rotate90() => throw new NotImplementedException();
        public Rectangle<N> Rotate(Angle<N> angle) => throw new NotImplementedException();
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => throw new NotImplementedException();

        public Triangle<NResult> Convert<NResult>(Func<N, NResult> converter) where NResult : struct, INumeric<NResult>
            => new Triangle<NResult>(A.Convert(converter), B.Convert(converter), C.Convert(converter));
        public bool Equals(Triangle<N> other) => A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C);
        public override bool Equals(object? obj) => obj is Triangle<N> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(A, B, C);
        public override string ToString() => $"{Symbol}({A}, {B}, {C})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({A}, {B}, {C})";

        public static bool TryParse(string value, out Vector3<N> result)
            => Try.Run(() => Parse(value), out result);

        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out Vector3<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static Vector3<N> Parse(string value)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length != 3) throw new FormatException();
            return new Vector3<N>(
                StringParser<N>.Parse(parts[0]),
                StringParser<N>.Parse(parts[1]),
                StringParser<N>.Parse(parts[2]));
        }

        public static Vector3<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length != 3) throw new FormatException();
            return new Vector3<N>(
                StringParser<N>.Parse(parts[0], style, provider),
                StringParser<N>.Parse(parts[1], style, provider),
                StringParser<N>.Parse(parts[2], style, provider));
        }

        public static bool operator ==(Triangle<N> left, Triangle<N> right) => left.Equals(right);
        public static bool operator !=(Triangle<N> left, Triangle<N> right) => !(left == right);
        public static implicit operator Triangle<N>((Vector2<N>, Vector2<N>, Vector2<N>) value) => new Triangle<N>(value.Item1, value.Item2, value.Item3);
        public static implicit operator (Vector2<N>, Vector2<N>, Vector2<N>)(Triangle<N> value) => (value.A, value.B, value.C);

        ReadOnlySpan<Vector2<N>> ITwoDimensional<Triangle<N>, N>.GetVertices(int pointsPerRadian) => GetVertices();
        IBitConverter<Triangle<N>> IProvider<IBitConverter<Triangle<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Triangle<N>> IProvider<IRandom<Triangle<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<Triangle<N>> IProvider<IStringParser<Triangle<N>>>.GetInstance() => Utilities.Instance;


        private sealed class Utilities :
           IBitConverter<Triangle<N>>,
           IRandom<Triangle<N>>,
           IStringParser<Triangle<N>>
        {
            public readonly static Utilities Instance = new Utilities();

            Triangle<N> IRandom<Triangle<N>>.Next(Random random)
            {
                throw new NotImplementedException();
            }

            Triangle<N> IRandom<Triangle<N>>.Next(Random random, Triangle<N> bound1, Triangle<N> bound2)
            {
                throw new NotImplementedException();
            }

            Triangle<N> IStringParser<Triangle<N>>.Parse(string s)
            {
                throw new NotImplementedException();
            }

            Triangle<N> IStringParser<Triangle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
            {
                throw new NotImplementedException();
            }

            Triangle<N> IBitConverter<Triangle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }

            void IBitConverter<Triangle<N>>.Write(Triangle<N> value, IWriteOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}

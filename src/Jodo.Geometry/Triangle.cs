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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    public static class Triangle
    {
        public static Triangle<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Triangle<TNumeric> :
            IEquatable<Triangle<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Triangle<TNumeric>>>,
                        IProvider<IVariantRandom<Triangle<TNumeric>>>,
            ITwoDimensional<Triangle<TNumeric>, TNumeric>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        private const string Symbol = "△";

        public readonly Vector2N<TNumeric> A;
        public readonly Vector2N<TNumeric> B;
        public readonly Vector2N<TNumeric> C;

        public Triangle(Vector2N<TNumeric> a, Vector2N<TNumeric> b, Vector2N<TNumeric> c)
        {
            A = a;
            B = b;
            C = c;
        }

        private Triangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2N<TNumeric>)info.GetValue(nameof(A), typeof(Vector2N<TNumeric>)),
            (Vector2N<TNumeric>)info.GetValue(nameof(B), typeof(Vector2N<TNumeric>)),
            (Vector2N<TNumeric>)info.GetValue(nameof(C), typeof(Vector2N<TNumeric>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(A), A, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(B), B, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(C), C, typeof(Vector2N<TNumeric>));
        }

        public AARectangle<TNumeric> GetBounds()
        {
            throw new NotImplementedException();
        }

        public TNumeric GetArea()
        {
            throw new NotImplementedException();
        }

        public Vector2N<TNumeric>[] GetVertices()
        {
            throw new NotImplementedException();
        }

        public Vector2N<TNumeric> GetCenter()
        {
            throw new NotImplementedException();
        }

        public Triangle<TNumeric> Translate(Vector2N<TNumeric> delta) => new Triangle<TNumeric>(A + delta, B + delta, C + delta);

        public bool Contains(Vector2N<TNumeric> point) => throw new NotImplementedException();
        public bool Contains(TNumeric pointX, TNumeric pointY) => Contains(new Vector2N<TNumeric>(pointX, pointY));

        public bool Contains(Triangle<TNumeric> other) => throw new NotImplementedException();
        public bool IntersectsWith(Triangle<TNumeric> other) => throw new NotImplementedException();

        public Triangle<TNumeric> Rotate90() => throw new NotImplementedException();
        public Rectangle<TNumeric> Rotate(Angle<TNumeric> angle) => throw new NotImplementedException();
        public Rectangle<TNumeric> RotateAround(Vector2N<TNumeric> pivot, Angle<TNumeric> angle) => throw new NotImplementedException();

        public Triangle<TResult> Convert<TResult>(Func<TNumeric, TResult> converter) where TResult : struct, INumeric<TResult>
            => new Triangle<TResult>(A.Convert(converter), B.Convert(converter), C.Convert(converter));
        public bool Equals(Triangle<TNumeric> other) => A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C);
        public override bool Equals(object? obj) => obj is Triangle<TNumeric> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(A, B, C);
        public override string ToString() => $"{Symbol}({A}, {B}, {C})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({A}, {B}, {C})";

        public static bool operator ==(Triangle<TNumeric> left, Triangle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Triangle<TNumeric> left, Triangle<TNumeric> right) => !(left == right);

#if HAS_VALUE_TUPLES
        public static implicit operator Triangle<TNumeric>((Vector2N<TNumeric>, Vector2N<TNumeric>, Vector2N<TNumeric>) value) => new Triangle<TNumeric>(value.Item1, value.Item2, value.Item3);
        public static implicit operator (Vector2N<TNumeric>, Vector2N<TNumeric>, Vector2N<TNumeric>)(Triangle<TNumeric> value) => (value.A, value.B, value.C);
#endif

        Vector2N<TNumeric>[] ITwoDimensional<Triangle<TNumeric>, TNumeric>.GetVertices(int circumferenceDivisor) => GetVertices();
        IBitConvert<Triangle<TNumeric>> IProvider<IBitConvert<Triangle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Triangle<TNumeric>> IProvider<IVariantRandom<Triangle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConvert<Triangle<TNumeric>>,
           IVariantRandom<Triangle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Triangle<TNumeric> IVariantRandom<Triangle<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Triangle<TNumeric>(
                   random.NextVariant<Vector2N<TNumeric>>(scenarios),
                   random.NextVariant<Vector2N<TNumeric>>(scenarios),
                   random.NextVariant<Vector2N<TNumeric>>(scenarios));
            }

            Triangle<TNumeric> IBitConvert<Triangle<TNumeric>>.Read(IReader<byte> stream)
            {
                throw new NotImplementedException();
            }

            void IBitConvert<Triangle<TNumeric>>.Write(Triangle<TNumeric> value, IWriter<byte> stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}

// Copyright (c) 2023 Joe Lawry-Short
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
using System.IO;
using System.Runtime.Serialization;
using Jodosoft.Numerics;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct TriangleN<TNumeric> :
            IEquatable<TriangleN<TNumeric>>,
            IFormattable,
            IProvider<IBinaryIO<TriangleN<TNumeric>>>,
            IProvider<IVariantRandom<TriangleN<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> A;
        public readonly Vector2N<TNumeric> B;
        public readonly Vector2N<TNumeric> C;

        public TriangleN(Vector2N<TNumeric> a, Vector2N<TNumeric> b, Vector2N<TNumeric> c)
        {
            A = a;
            B = b;
            C = c;
        }

        private TriangleN(SerializationInfo info, StreamingContext context) : this(
            (Vector2N<TNumeric>)(info.GetValue(nameof(A), typeof(Vector2N<TNumeric>)) ?? throw new InvalidOperationException()),
            (Vector2N<TNumeric>)(info.GetValue(nameof(B), typeof(Vector2N<TNumeric>)) ?? throw new InvalidOperationException()),
            (Vector2N<TNumeric>)(info.GetValue(nameof(C), typeof(Vector2N<TNumeric>)) ?? throw new InvalidOperationException()))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(A), A, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(B), B, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(C), C, typeof(Vector2N<TNumeric>));
        }

        public AARectangleN<TNumeric> GetBounds()
        {
            throw new NotImplementedException();
        }

        public TNumeric GetArea()
        {
            throw new NotImplementedException();
        }

        public Vector2N<TNumeric> GetCenter()
        {
            throw new NotImplementedException();
        }

        public TriangleN<TNumeric> Translate(Vector2N<TNumeric> delta) => new TriangleN<TNumeric>(A + delta, B + delta, C + delta);

        public TriangleN<TResult> Convert<TResult>(Func<TNumeric, TResult> converter) where TResult : struct, INumeric<TResult>
            => new TriangleN<TResult>(A.Convert(converter), B.Convert(converter), C.Convert(converter));
        public bool Equals(TriangleN<TNumeric> other) => A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C);
        public override bool Equals(object? obj) => obj is TriangleN<TNumeric> fix && Equals(fix);
        public override int GetHashCode() => HashCodeShim.Combine(A, B, C);
        public override string ToString() => $"({A}, {B}, {C})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"({A}, {B}, {C})";

        public static bool operator ==(TriangleN<TNumeric> left, TriangleN<TNumeric> right) => left.Equals(right);
        public static bool operator !=(TriangleN<TNumeric> left, TriangleN<TNumeric> right) => !(left == right);

        IBinaryIO<TriangleN<TNumeric>> IProvider<IBinaryIO<TriangleN<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<TriangleN<TNumeric>> IProvider<IVariantRandom<TriangleN<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBinaryIO<TriangleN<TNumeric>>,
           IVariantRandom<TriangleN<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<TriangleN<TNumeric>>.Write(BinaryWriter writer, TriangleN<TNumeric> value)
            {
                writer.Write(value.A);
                writer.Write(value.B);
                writer.Write(value.C);
            }

            TriangleN<TNumeric> IBinaryIO<TriangleN<TNumeric>>.Read(BinaryReader reader)
            {
                return new TriangleN<TNumeric>(
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<Vector2N<TNumeric>>());
            }

            TriangleN<TNumeric> IVariantRandom<TriangleN<TNumeric>>.Generate(Random random, Variants variants)
            {
                return new TriangleN<TNumeric>(
                   random.NextVariant<Vector2N<TNumeric>>(variants),
                   random.NextVariant<Vector2N<TNumeric>>(variants),
                   random.NextVariant<Vector2N<TNumeric>>(variants));
            }
        }
    }

    public static class TriangleN
    {
        public static TriangleN<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            throw new NotImplementedException();
        }
    }
}

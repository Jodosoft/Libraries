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
using Jodo.Primitives;

namespace Jodo.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [CLSCompliant(false)]
    public readonly struct Unit<N> :
            IComparable,
            IComparable<Unit<N>>,
            IEquatable<Unit<N>>,
            IFormattable,
            IProvider<IBitConverter<Unit<N>>>,
            IProvider<IRandom<Unit<N>>>,
            IProvider<IParser<Unit<N>>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        public static readonly Unit<N> Zero = new Unit<N>(Numeric<N>.Zero);
        public static readonly Unit<N> MaxValue = new Unit<N>(Numeric<N>.MaxUnit);
        public static readonly Unit<N> MinValue = new Unit<N>(Numeric<N>.MinUnit);

        public readonly N Value { get; }

        private Unit(N value)
        {
            Value = Math<N>.Clamp(value, Numeric<N>.MinUnit, Numeric<N>.MaxUnit);
        }

        private Unit(SerializationInfo info, StreamingContext context)
        {
            Value = Math<N>.Clamp((N)info.GetValue(nameof(Value), typeof(N) ?? throw new InvalidOperationException()), Numeric<N>.MinUnit, Numeric<N>.MaxUnit);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Value), Value, typeof(N));

        public int CompareTo(object? obj) => obj is Unit<N> other ? CompareTo(other) : 1;
        public int CompareTo(Unit<N> other) => Value.CompareTo(other.Value);
        public bool Equals(Unit<N> other) => Value.Equals(other.Value);
        public override bool Equals(object? obj) => obj is Unit<N> unit && Equals(unit);
        public override int GetHashCode() => Value.GetHashCode();
        public override string? ToString() => Value.ToString();
        public string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);

        public static Unit<N> Clamp(N value) => new Unit<N>(value);

        public static implicit operator N(Unit<N> unit) => unit.Value;
        public static explicit operator Unit<N>(N value) => new Unit<N>(value);

        public static bool operator !=(Unit<N> left, Unit<N> right) => !left.Equals(right);
        public static bool operator <(Unit<N> left, Unit<N> right) => left.Value.IsLessThan(right.Value);
        public static bool operator <=(Unit<N> left, Unit<N> right) => left.Value.IsLessThan(right.Value);
        public static bool operator ==(Unit<N> left, Unit<N> right) => left.Equals(right);
        public static bool operator >(Unit<N> left, Unit<N> right) => left.Value.IsGreaterThan(right.Value);
        public static bool operator >=(Unit<N> left, Unit<N> right) => left.Value.IsGreaterThanOrEqualTo(right.Value);
        public static N operator %(Unit<N> left, Unit<N> right) => left.Value.Remainder(right.Value);
        public static N operator -(Unit<N> left, Unit<N> right) => left.Value.Subtract(right.Value);
        public static N operator -(Unit<N> value) => value.Value.Negative();
        public static N operator *(Unit<N> left, Unit<N> right) => left.Value.Multiply(right.Value);
        public static N operator /(Unit<N> left, Unit<N> right) => left.Value.Divide(right.Value);
        public static N operator +(Unit<N> left, Unit<N> right) => left.Value.Add(right.Value);
        public static N operator +(Unit<N> value) => value.Value;

        public static bool operator !=(Unit<N> left, N right) => !left.Value.Equals(right);
        public static bool operator <(Unit<N> left, N right) => left.Value.IsLessThan(right);
        public static bool operator <=(Unit<N> left, N right) => left.Value.IsLessThanOrEqualTo(right);
        public static bool operator ==(Unit<N> left, N right) => left.Value.Equals(right);
        public static bool operator >(Unit<N> left, N right) => left.Value.IsGreaterThan(right);
        public static bool operator >=(Unit<N> left, N right) => left.Value.IsGreaterThanOrEqualTo(right);
        public static N operator %(Unit<N> left, N right) => left.Value.Remainder(right);
        public static N operator -(Unit<N> left, N right) => left.Value.Subtract(right);
        public static N operator *(Unit<N> left, N right) => left.Value.Multiply(right);
        public static N operator /(Unit<N> left, N right) => left.Value.Divide(right);
        public static N operator +(Unit<N> left, N right) => left.Value.Add(right);

        public static bool operator !=(N left, Unit<N> right) => !left.Equals(right.Value);
        public static bool operator <(N left, Unit<N> right) => left.IsLessThan(right.Value);
        public static bool operator <=(N left, Unit<N> right) => left.IsLessThanOrEqualTo(right.Value);
        public static bool operator ==(N left, Unit<N> right) => left.Equals(right.Value);
        public static bool operator >(N left, Unit<N> right) => left.IsGreaterThan(right.Value);
        public static bool operator >=(N left, Unit<N> right) => left.IsGreaterThanOrEqualTo(right.Value);
        public static N operator %(N left, Unit<N> right) => left.Remainder(right.Value);
        public static N operator -(N left, Unit<N> right) => left.Subtract(right.Value);
        public static N operator *(N left, Unit<N> right) => left.Multiply(right.Value);
        public static N operator /(N left, Unit<N> right) => left.Divide(right.Value);
        public static N operator +(N left, Unit<N> right) => left.Add(right.Value);

        IBitConverter<Unit<N>> IProvider<IBitConverter<Unit<N>>>.GetInstance() => Utilities.Instance;
        IRandom<Unit<N>> IProvider<IRandom<Unit<N>>>.GetInstance() => Utilities.Instance;
        IParser<Unit<N>> IProvider<IParser<Unit<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<Unit<N>>,
            IRandom<Unit<N>>,
            IParser<Unit<N>>
        {
            public static readonly Utilities Instance = new Utilities();

            Unit<N> IRandom<Unit<N>>.Next(Random random) => new Unit<N>(random.NextNumeric(Numeric<N>.MinUnit, Numeric<N>.MaxUnit));
            Unit<N> IRandom<Unit<N>>.Next(Random random, Unit<N> bound1, Unit<N> bound2) => new Unit<N>(random.NextNumeric(bound1.Value, bound2.Value));

            Unit<N> IParser<Unit<N>>.Parse(string s) => new Unit<N>(Parser<N>.Parse(s));
            Unit<N> IParser<Unit<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider) => new Unit<N>(Parser<N>.Parse(s, style, provider));

            Unit<N> IBitConverter<Unit<N>>.Read(IReadOnlyStream<byte> stream) => new Unit<N>(BitConverter<N>.Read(stream));
            void IBitConverter<Unit<N>>.Write(Unit<N> value, IWriteOnlyStream<byte> stream) => BitConverter<N>.Write(stream, value.Value);
        }
    }
}

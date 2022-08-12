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
    public static class Unit
    {

        public static Unit<TNumeric> Zero<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new Unit<TNumeric>(Numeric.Zero<TNumeric>());

        public static Unit<TNumeric> MaxValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new Unit<TNumeric>(Numeric.MaxUnit<TNumeric>());

        public static Unit<TNumeric> MinValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new Unit<TNumeric>(Numeric.MinUnit<TNumeric>());
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Unit<TNumeric> :
            IComparable,
            IComparable<Unit<TNumeric>>,
            IEquatable<Unit<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Unit<TNumeric>>>,
            IProvider<IRandom<Unit<TNumeric>>>,
            IProvider<IStringConvert<Unit<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {

        public readonly TNumeric Value { get; }

        public Unit(TNumeric value)
        {
            Value = MathN.Clamp(value, Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>());
        }

        private Unit(SerializationInfo info, StreamingContext context)
        {
            Value = MathN.Clamp((TNumeric)info.GetValue(nameof(Value), typeof(TNumeric) ?? throw new InvalidOperationException()), Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>());
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Value), Value, typeof(TNumeric));

        public int CompareTo(object? obj) => obj is Unit<TNumeric> other ? CompareTo(other) : 1;
        public int CompareTo(Unit<TNumeric> other) => Value.CompareTo(other.Value);
        public bool Equals(Unit<TNumeric> other) => Value.Equals(other.Value);
        public override bool Equals(object? obj) => obj is Unit<TNumeric> unit && Equals(unit);
        public override int GetHashCode() => Value.GetHashCode();
        public override string? ToString() => Value.ToString();
        public string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);

        public static implicit operator TNumeric(Unit<TNumeric> unit) => unit.Value;
        public static explicit operator Unit<TNumeric>(TNumeric value) => new Unit<TNumeric>(value);

        public static bool operator !=(Unit<TNumeric> left, Unit<TNumeric> right) => !left.Equals(right);
        public static bool operator <(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.IsLessThan(right.Value);
        public static bool operator <=(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.IsLessThanOrEqualTo(right.Value);
        public static bool operator ==(Unit<TNumeric> left, Unit<TNumeric> right) => left.Equals(right);
        public static bool operator >(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.IsGreaterThan(right.Value);
        public static bool operator >=(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.IsGreaterThanOrEqualTo(right.Value);
        public static TNumeric operator %(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.Remainder(right.Value);
        public static TNumeric operator -(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.Subtract(right.Value);
        public static TNumeric operator -(Unit<TNumeric> value) => value.Value.Negative();
        public static TNumeric operator *(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.Multiply(right.Value);
        public static TNumeric operator /(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.Divide(right.Value);
        public static TNumeric operator +(Unit<TNumeric> left, Unit<TNumeric> right) => left.Value.Add(right.Value);
        public static TNumeric operator +(Unit<TNumeric> value) => value.Value;

        public static bool operator !=(Unit<TNumeric> left, TNumeric right) => !left.Value.Equals(right);
        public static bool operator <(Unit<TNumeric> left, TNumeric right) => left.Value.IsLessThan(right);
        public static bool operator <=(Unit<TNumeric> left, TNumeric right) => left.Value.IsLessThanOrEqualTo(right);
        public static bool operator ==(Unit<TNumeric> left, TNumeric right) => left.Value.Equals(right);
        public static bool operator >(Unit<TNumeric> left, TNumeric right) => left.Value.IsGreaterThan(right);
        public static bool operator >=(Unit<TNumeric> left, TNumeric right) => left.Value.IsGreaterThanOrEqualTo(right);
        public static TNumeric operator %(Unit<TNumeric> left, TNumeric right) => left.Value.Remainder(right);
        public static TNumeric operator -(Unit<TNumeric> left, TNumeric right) => left.Value.Subtract(right);
        public static TNumeric operator *(Unit<TNumeric> left, TNumeric right) => left.Value.Multiply(right);
        public static TNumeric operator /(Unit<TNumeric> left, TNumeric right) => left.Value.Divide(right);
        public static TNumeric operator +(Unit<TNumeric> left, TNumeric right) => left.Value.Add(right);

        public static bool operator !=(TNumeric left, Unit<TNumeric> right) => !left.Equals(right.Value);
        public static bool operator <(TNumeric left, Unit<TNumeric> right) => left.IsLessThan(right.Value);
        public static bool operator <=(TNumeric left, Unit<TNumeric> right) => left.IsLessThanOrEqualTo(right.Value);
        public static bool operator ==(TNumeric left, Unit<TNumeric> right) => left.Equals(right.Value);
        public static bool operator >(TNumeric left, Unit<TNumeric> right) => left.IsGreaterThan(right.Value);
        public static bool operator >=(TNumeric left, Unit<TNumeric> right) => left.IsGreaterThanOrEqualTo(right.Value);
        public static TNumeric operator %(TNumeric left, Unit<TNumeric> right) => left.Remainder(right.Value);
        public static TNumeric operator -(TNumeric left, Unit<TNumeric> right) => left.Subtract(right.Value);
        public static TNumeric operator *(TNumeric left, Unit<TNumeric> right) => left.Multiply(right.Value);
        public static TNumeric operator /(TNumeric left, Unit<TNumeric> right) => left.Divide(right.Value);
        public static TNumeric operator +(TNumeric left, Unit<TNumeric> right) => left.Add(right.Value);

        IBitConvert<Unit<TNumeric>> IProvider<IBitConvert<Unit<TNumeric>>>.GetInstance() => Utilities.Instance;
        IRandom<Unit<TNumeric>> IProvider<IRandom<Unit<TNumeric>>>.GetInstance() => Utilities.Instance;
        IStringConvert<Unit<TNumeric>> IProvider<IStringConvert<Unit<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<Unit<TNumeric>>,
            IRandom<Unit<TNumeric>>,
            IStringConvert<Unit<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Unit<TNumeric> IRandom<Unit<TNumeric>>.Next(Random random) => new Unit<TNumeric>(random.NextNumeric(Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>()));
            Unit<TNumeric> IRandom<Unit<TNumeric>>.Next(Random random, Unit<TNumeric> bound1, Unit<TNumeric> bound2) => new Unit<TNumeric>(random.NextNumeric(bound1.Value, bound2.Value));

            Unit<TNumeric> IStringConvert<Unit<TNumeric>>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => new Unit<TNumeric>(StringConvert.Parse<TNumeric>(s, style, provider));

            Unit<TNumeric> IBitConvert<Unit<TNumeric>>.Read(IReader<byte> stream) => new Unit<TNumeric>(BitConvert.Read<TNumeric>(stream));
            void IBitConvert<Unit<TNumeric>>.Write(Unit<TNumeric> value, IWriter<byte> stream) => BitConvert.Write(stream, value.Value);
        }
    }
}

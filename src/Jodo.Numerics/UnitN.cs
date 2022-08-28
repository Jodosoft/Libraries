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
    public readonly struct UnitN<TNumeric> :
            IComparable,
            IComparable<UnitN<TNumeric>>,
            IEquatable<UnitN<TNumeric>>,
            IFormattable,
            IProvider<INumericBitConverter<UnitN<TNumeric>>>,
                        IProvider<IVariantRandom<UnitN<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {

        public readonly TNumeric Value { get; }

        public UnitN(TNumeric value)
        {
            Value = MathN.Clamp(value, Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>());
        }

        private UnitN(SerializationInfo info, StreamingContext context)
        {
            Value = MathN.Clamp((TNumeric)info.GetValue(nameof(Value), typeof(TNumeric) ?? throw new InvalidOperationException()), Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>());
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Value), Value, typeof(TNumeric));

        public int CompareTo(object? obj) => obj is UnitN<TNumeric> other ? CompareTo(other) : 1;
        public int CompareTo(UnitN<TNumeric> other) => Value.CompareTo(other.Value);
        public bool Equals(UnitN<TNumeric> other) => Value.Equals(other.Value);
        public override bool Equals(object? obj) => obj is UnitN<TNumeric> unit && Equals(unit);
        public override int GetHashCode() => Value.GetHashCode();
        public override string? ToString() => Value.ToString();
        public string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);

        public static implicit operator TNumeric(UnitN<TNumeric> unit) => unit.Value;
        public static explicit operator UnitN<TNumeric>(TNumeric value) => new UnitN<TNumeric>(value);

        public static bool operator !=(UnitN<TNumeric> left, UnitN<TNumeric> right) => !left.Equals(right);
        public static bool operator <(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.IsLessThan(right.Value);
        public static bool operator <=(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.IsLessThanOrEqualTo(right.Value);
        public static bool operator ==(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Equals(right);
        public static bool operator >(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.IsGreaterThan(right.Value);
        public static bool operator >=(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.IsGreaterThanOrEqualTo(right.Value);
        public static TNumeric operator %(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.Remainder(right.Value);
        public static TNumeric operator -(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.Subtract(right.Value);
        public static TNumeric operator -(UnitN<TNumeric> value) => value.Value.Negative();
        public static TNumeric operator *(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.Multiply(right.Value);
        public static TNumeric operator /(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.Divide(right.Value);
        public static TNumeric operator +(UnitN<TNumeric> left, UnitN<TNumeric> right) => left.Value.Add(right.Value);
        public static TNumeric operator +(UnitN<TNumeric> value) => value.Value;

        public static bool operator !=(UnitN<TNumeric> left, TNumeric right) => !left.Value.Equals(right);
        public static bool operator <(UnitN<TNumeric> left, TNumeric right) => left.Value.IsLessThan(right);
        public static bool operator <=(UnitN<TNumeric> left, TNumeric right) => left.Value.IsLessThanOrEqualTo(right);
        public static bool operator ==(UnitN<TNumeric> left, TNumeric right) => left.Value.Equals(right);
        public static bool operator >(UnitN<TNumeric> left, TNumeric right) => left.Value.IsGreaterThan(right);
        public static bool operator >=(UnitN<TNumeric> left, TNumeric right) => left.Value.IsGreaterThanOrEqualTo(right);
        public static TNumeric operator %(UnitN<TNumeric> left, TNumeric right) => left.Value.Remainder(right);
        public static TNumeric operator -(UnitN<TNumeric> left, TNumeric right) => left.Value.Subtract(right);
        public static TNumeric operator *(UnitN<TNumeric> left, TNumeric right) => left.Value.Multiply(right);
        public static TNumeric operator /(UnitN<TNumeric> left, TNumeric right) => left.Value.Divide(right);
        public static TNumeric operator +(UnitN<TNumeric> left, TNumeric right) => left.Value.Add(right);

        public static bool operator !=(TNumeric left, UnitN<TNumeric> right) => !left.Equals(right.Value);
        public static bool operator <(TNumeric left, UnitN<TNumeric> right) => left.IsLessThan(right.Value);
        public static bool operator <=(TNumeric left, UnitN<TNumeric> right) => left.IsLessThanOrEqualTo(right.Value);
        public static bool operator ==(TNumeric left, UnitN<TNumeric> right) => left.Equals(right.Value);
        public static bool operator >(TNumeric left, UnitN<TNumeric> right) => left.IsGreaterThan(right.Value);
        public static bool operator >=(TNumeric left, UnitN<TNumeric> right) => left.IsGreaterThanOrEqualTo(right.Value);
        public static TNumeric operator %(TNumeric left, UnitN<TNumeric> right) => left.Remainder(right.Value);
        public static TNumeric operator -(TNumeric left, UnitN<TNumeric> right) => left.Subtract(right.Value);
        public static TNumeric operator *(TNumeric left, UnitN<TNumeric> right) => left.Multiply(right.Value);
        public static TNumeric operator /(TNumeric left, UnitN<TNumeric> right) => left.Divide(right.Value);
        public static TNumeric operator +(TNumeric left, UnitN<TNumeric> right) => left.Add(right.Value);

        INumericBitConverter<UnitN<TNumeric>> IProvider<INumericBitConverter<UnitN<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UnitN<TNumeric>> IProvider<IVariantRandom<UnitN<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            INumericBitConverter<UnitN<TNumeric>>,
            IVariantRandom<UnitN<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            UnitN<TNumeric> IVariantRandom<UnitN<TNumeric>>.Next(Random random, Scenarios scenarios)
                => new UnitN<TNumeric>(random.NextVariant<TNumeric>(scenarios));

            UnitN<TNumeric> INumericBitConverter<UnitN<TNumeric>>.Read(IReader<byte> stream) => new UnitN<TNumeric>(BitConverterN.Read<TNumeric>(stream));
            void INumericBitConverter<UnitN<TNumeric>>.Write(UnitN<TNumeric> value, IWriter<byte> stream) => BitConverterN.Write(stream, value.Value);
        }
    }

    public static class UnitN
    {

        public static UnitN<TNumeric> Zero<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new UnitN<TNumeric>(Numeric.Zero<TNumeric>());

        public static UnitN<TNumeric> MaxValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new UnitN<TNumeric>(Numeric.MaxUnit<TNumeric>());

        public static UnitN<TNumeric> MinValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => new UnitN<TNumeric>(Numeric.MinUnit<TNumeric>());

        public static UnitN<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
            => new UnitN<TNumeric>(Numeric.Parse<TNumeric>(s, style, provider));
    }
}

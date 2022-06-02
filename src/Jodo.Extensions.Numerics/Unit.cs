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
    public readonly struct Unit<N> :
        IProvider<IBitConverter<Unit<N>>>,
        IProvider<IRandom<Unit<N>>>,
        IProvider<IStringParser<Unit<N>>>,
        ISerializable
        where N : struct, INumeric<N>
    {
        public readonly static Unit<N> Zero = new Unit<N>(Numeric<N>.Zero);
        public readonly static Unit<N> MaxValue = new Unit<N>(Numeric<N>.MaxUnit);
        public readonly static Unit<N> MinValue = new Unit<N>(Numeric<N>.MinUnit);

        public readonly N Value { get; }


        public Unit(N value)
        {
            Value = Math<N>.Clamp(value, Numeric<N>.MinUnit, Numeric<N>.MaxUnit);
        }

        private Unit(SerializationInfo info, StreamingContext context)
        {
            Value = Math<N>.Clamp((N)info.GetValue(nameof(Value), typeof(N)), Numeric<N>.MinUnit, Numeric<N>.MaxUnit);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Value), Value, typeof(N));

        public bool Equals(Unit<N> other) => Value.Equals(other.Value);
        public override bool Equals(object? obj) => obj is Unit<N> unit && Equals(unit);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

        IBitConverter<Unit<N>> IProvider<IBitConverter<Unit<N>>>.GetInstance()
        {
            throw new NotImplementedException();
        }

        IRandom<Unit<N>> IProvider<IRandom<Unit<N>>>.GetInstance()
        {
            throw new NotImplementedException();
        }

        IStringParser<Unit<N>> IProvider<IStringParser<Unit<N>>>.GetInstance()
        {
            throw new NotImplementedException();
        }

        public static implicit operator N(Unit<N> unit) => unit.Value;
        public static explicit operator Unit<N>(N value) => new Unit<N>(value);
        public static explicit operator Unit<N>(byte value) => new Unit<N>(Convert<N>.ToValue(value));
        public static bool operator ==(Unit<N> left, Unit<N> right) => left.Equals(right);
        public static bool operator !=(Unit<N> left, Unit<N> right) => !(left == right);
    }
}

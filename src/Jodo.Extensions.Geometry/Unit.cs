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
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Unit<T> : IGeometric<Unit<T>> where T : struct, INumeric<T>
    {
        public readonly static Unit<T> Zero = new Unit<T>(Math<T>.Zero);
        public readonly static Unit<T> MaxValue = new Unit<T>(Math<T>.MaxUnit);
        public readonly static Unit<T> MinValue = new Unit<T>(Math<T>.MinUnit);

        public readonly T Value { get; }

        IBitConverter<Unit<T>> IBitConvertible<Unit<T>>.BitConverter => throw new NotImplementedException();
        IRandom<Unit<T>> IRandomisable<Unit<T>>.Random => throw new NotImplementedException();
        IStringParser<Unit<T>> IStringParsable<Unit<T>>.StringParser => throw new NotImplementedException();

        public Unit(T value)
        {
            Value = Math<T>.Clamp(value, Math<T>.MinUnit, Math<T>.MaxUnit);
        }

        private Unit(SerializationInfo info, StreamingContext context) : this(
            (T)info.GetValue(nameof(Value), typeof(T)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Value), Value, typeof(T));

        public bool Equals(Unit<T> other) => Value.Equals(other.Value);
        public override bool Equals(object? obj) => obj is Unit<T> unit && Equals(unit);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

        public static implicit operator T(Unit<T> unit) => unit.Value;
        public static explicit operator Unit<T>(T value) => new Unit<T>(value);
        public static explicit operator Unit<T>(byte value) => new Unit<T>(Convert<T>.ToValue(value));
        public static bool operator ==(Unit<T> left, Unit<T> right) => left.Equals(right);
        public static bool operator !=(Unit<T> left, Unit<T> right) => !(left == right);
    }
}

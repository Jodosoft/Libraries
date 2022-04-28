﻿// Copyright (c) 2022 Joseph J. Short
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

using Jodo.Extensions.CheckedNumerics;
using Jodo.Extensions.Primitives;
using System;

namespace Jodo.Extensions.CheckedGeometry
{
    public readonly struct Vector3<T> : IEquatable<Vector3<T>>, IBitConverter<Vector3<T>> where T : struct, INumeric<T>, IBitConverter<T>
    {
        public readonly T X;
        public readonly T Y;
        public readonly T Z;

        public T Length => Math<T>.Sqrt((X * X) + (Y * Y) + (Z * Z));

        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Vector3<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public override bool Equals(object? obj) => obj is Vector3<T> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        public override string ToString() => TypeString.Combine(GetType(), X, Y, Z);

        public static bool TryParse(string value, out Vector3<T> result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static Vector3<T> Parse(string value)
        {
            value = value.Replace(TypeString.Combine(typeof(Vector3<T>)), string.Empty);
            var args = value.Replace("(", string.Empty).Replace(")", string.Empty).Split(",");
            if (args.Length != 3) throw new FormatException(""); // todo
            return new Vector3<T>(Math<T>.Parse(args[0].Trim()), Math<T>.Parse(args[1].Trim()), Math<T>.Parse(args[2].Trim()));
        }

        int IBitConverter<Vector3<T>>.Size => BitConverter<T>.Size * 3;

        Vector3<T> IBitConverter<Vector3<T>>.FromBytes(ReadOnlySpan<byte> bytes)
        {
            return new Vector3<T>(
                BitConverter<T>.FromBytes(bytes.Slice(0, BitConverter<T>.Size)),
                BitConverter<T>.FromBytes(bytes.Slice(BitConverter<T>.Size, BitConverter<T>.Size)),
                BitConverter<T>.FromBytes(bytes.Slice(BitConverter<T>.Size * 2, BitConverter<T>.Size)));
        }

        ReadOnlySpan<byte> IBitConverter<Vector3<T>>.GetBytes()
        {
            var result = new byte[BitConverter<T>.Size * 3];
            BitConverter<T>.GetBytes(X).CopyTo(new Span<byte>(result, 0, BitConverter<T>.Size));
            BitConverter<T>.GetBytes(Y).CopyTo(new Span<byte>(result, BitConverter<T>.Size, BitConverter<T>.Size));
            BitConverter<T>.GetBytes(Z).CopyTo(new Span<byte>(result, BitConverter<T>.Size * 2, BitConverter<T>.Size));
            return result;
        }

        public static Vector3<T> operator -(Vector3<T> value) => new Vector3<T>(-value.X, -value.Y, -value.Z);
        public static Vector3<T> operator -(Vector3<T> value1, Vector3<T> value2) => new Vector3<T>(value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z);
        public static Vector3<T> operator *(Vector3<T> value, T scalar) => new Vector3<T>(value.X * scalar, value.Y * scalar, value.Z * scalar);
        public static Vector3<T> operator *(T scalar, Vector3<T> value) => value * scalar;
        public static Vector3<T> operator /(Vector3<T> value, T scalar) => new Vector3<T>(value.X / scalar, value.Y / scalar, value.Z / scalar);
        public static Vector3<T> operator +(Vector3<T> value) => value;
        public static Vector3<T> operator +(Vector3<T> value1, Vector3<T> value2) => new Vector3<T>(value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z);
        public static implicit operator Vector3<T>((T, T, T) value) => new Vector3<T>(value.Item1, value.Item2, value.Item3);
        public static implicit operator (T, T, T)(Vector3<T> value) => (value.X, value.Y, value.Z);
        public static implicit operator Vector3<T>(Tuple<T, T, T> value) => new Vector3<T>(value.Item1, value.Item2, value.Item3);
        public static implicit operator Tuple<T, T, T>(Vector3<T> value) => new Tuple<T, T, T>(value.X, value.Y, value.Z);
        public static bool operator ==(Vector3<T> left, Vector3<T> right) => left.Equals(right);
        public static bool operator !=(Vector3<T> left, Vector3<T> right) => !(left == right);
    }
}
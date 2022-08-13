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

namespace Jodo.Primitives
{
    [CLSCompliant(false)]
    public static class ConvertibleExtensions
    {
        private static readonly Type Boolean = typeof(bool);
        private static readonly Type Char = typeof(char);
        private static readonly Type SByte = typeof(sbyte);
        private static readonly Type Byte = typeof(byte);
        private static readonly Type Int16 = typeof(short);
        private static readonly Type UInt16 = typeof(ushort);
        private static readonly Type Int32 = typeof(int);
        private static readonly Type UInt32 = typeof(uint);
        private static readonly Type Int64 = typeof(long);
        private static readonly Type UInt64 = typeof(ulong);
        private static readonly Type Single = typeof(float);
        private static readonly Type Double = typeof(double);
        private static readonly Type Decimal = typeof(decimal);
        private static readonly Type DateTime = typeof(DateTime);
        private static readonly Type String = typeof(string);
        private static readonly Type Object = typeof(object);
        private static readonly Type Enum = typeof(Enum);

        public static object ToTypeDefault(this IConvertible value, Type targetType, IFormatProvider? provider)
        {
            if (ReferenceEquals(value.GetType(), targetType)) return value;
            if (ReferenceEquals(targetType, Boolean)) return value.ToBoolean(provider);
            if (ReferenceEquals(targetType, Char)) return value.ToChar(provider);
            if (ReferenceEquals(targetType, SByte)) return value.ToSByte(provider);
            if (ReferenceEquals(targetType, Byte)) return value.ToByte(provider);
            if (ReferenceEquals(targetType, Int16)) return value.ToInt16(provider);
            if (ReferenceEquals(targetType, UInt16)) return value.ToUInt16(provider);
            if (ReferenceEquals(targetType, Int32)) return value.ToInt32(provider);
            if (ReferenceEquals(targetType, UInt32)) return value.ToUInt32(provider);
            if (ReferenceEquals(targetType, Int64)) return value.ToInt64(provider);
            if (ReferenceEquals(targetType, UInt64)) return value.ToUInt64(provider);
            if (ReferenceEquals(targetType, Single)) return value.ToSingle(provider);
            if (ReferenceEquals(targetType, Double)) return value.ToDouble(provider);
            if (ReferenceEquals(targetType, Decimal)) return value.ToDecimal(provider);
            if (ReferenceEquals(targetType, DateTime)) return value.ToDateTime(provider);
            if (ReferenceEquals(targetType, String)) return value.ToString(provider);
            if (ReferenceEquals(targetType, Object)) return value;
            if (ReferenceEquals(targetType, Enum)) return (Enum)value;

            throw new InvalidCastException($"Invalid cast from '{value.GetType().FullName}' to '{targetType.FullName}'.");
        }
    }
}

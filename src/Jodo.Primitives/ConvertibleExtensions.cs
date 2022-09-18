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
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Primitives
{
    /// <summary>
    ///     Provides extension methods for <see cref="IConvertible"/>.
    /// </summary>
    [CLSCompliant(false)]
    public static class ConvertibleExtensions
    {
        private static readonly Type BooleanType = typeof(bool);
        private static readonly Type CharType = typeof(char);
        private static readonly Type SByteType = typeof(sbyte);
        private static readonly Type ByteType = typeof(byte);
        private static readonly Type Int16Type = typeof(short);
        private static readonly Type UInt16Type = typeof(ushort);
        private static readonly Type Int32Type = typeof(int);
        private static readonly Type UInt32Type = typeof(uint);
        private static readonly Type Int64Type = typeof(long);
        private static readonly Type UInt64Type = typeof(ulong);
        private static readonly Type SingleType = typeof(float);
        private static readonly Type DoubleType = typeof(double);
        private static readonly Type DecimalType = typeof(decimal);
        private static readonly Type DateTimeType = typeof(DateTime);
        private static readonly Type StringType = typeof(string);
        private static readonly Type ObjectType = typeof(object);
        private static readonly Type EnumType = typeof(Enum);

        /// <summary>
        ///     Converts the value of this instance to an <see cref="object"/> of the specified
        ///     <see cref="Type"/> by calling one of the named conversions from <see cref="IConvertible"/>,
        ///     such as <see cref="IConvertible.ToChar(IFormatProvider)"/> or 
        ///     <see cref="IConvertible.ToDouble(IFormatProvider)"/>.
        /// </summary>
        /// <param name="value">The <see cref="IConvertible"/> to convert.</param>
        /// <param name="targetType">The <see cref="Type"/> to which the value of this instance is converted.</param>
        /// <param name="provider"> An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An <see cref="object"/> instance of type conversionType whose value is equivalent to the value of this instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="value"/> or <paramref name="targetType"/> are null.</exception>
        /// <exception cref="InvalidCastException">If the value cannot be converted using a method from <see cref="IConvertible"/>.</exception>
        /// <remarks>
        ///     This method does not call <see cref="IConvertible.ToType(Type, IFormatProvider)"/> so that it can be used
        ///     as a default implementation for that method.
        /// </remarks>
        [SuppressMessage("csharpsquid", "S3776:Cognitive Complexity of methods should not be too high", Justification = "Branchy but simple.")]
        public static object ToTypeDefault(this IConvertible value, Type targetType, IFormatProvider? provider)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            if (ReferenceEquals(value.GetType(), targetType)) return value;
            if (ReferenceEquals(targetType, BooleanType)) return value.ToBoolean(provider);
            if (ReferenceEquals(targetType, CharType)) return value.ToChar(provider);
            if (ReferenceEquals(targetType, SByteType)) return value.ToSByte(provider);
            if (ReferenceEquals(targetType, ByteType)) return value.ToByte(provider);
            if (ReferenceEquals(targetType, Int16Type)) return value.ToInt16(provider);
            if (ReferenceEquals(targetType, UInt16Type)) return value.ToUInt16(provider);
            if (ReferenceEquals(targetType, Int32Type)) return value.ToInt32(provider);
            if (ReferenceEquals(targetType, UInt32Type)) return value.ToUInt32(provider);
            if (ReferenceEquals(targetType, Int64Type)) return value.ToInt64(provider);
            if (ReferenceEquals(targetType, UInt64Type)) return value.ToUInt64(provider);
            if (ReferenceEquals(targetType, SingleType)) return value.ToSingle(provider);
            if (ReferenceEquals(targetType, DoubleType)) return value.ToDouble(provider);
            if (ReferenceEquals(targetType, DecimalType)) return value.ToDecimal(provider);
            if (ReferenceEquals(targetType, DateTimeType)) return value.ToDateTime(provider);
            if (ReferenceEquals(targetType, StringType)) return value.ToString(provider);
            if (ReferenceEquals(targetType, ObjectType)) return value;
            if (ReferenceEquals(targetType, EnumType)) return (Enum)value;

            // This method is intended to be a default implementation for ToType(...),
            // so do not call ToType(...) in this method.

            throw new InvalidCastException($"Invalid cast from '{value.GetType().FullName}' to '{targetType.FullName}'.");
        }
    }
}

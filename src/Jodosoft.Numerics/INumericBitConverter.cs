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

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Converts numeric values to arrays of bytes, and an array of bytes to numeric values.
    /// </summary>
    /// <typeparam name="TNumeric">The type of numeric value to convert.</typeparam>
    /// <seealso cref="INumeric{TSelf}"/>
    /// <seealso cref="BitConverter"/>
    public interface INumericBitConverter<TNumeric> where TNumeric : struct, INumeric<TNumeric>
    {
        /// <summary>
        /// Returns the number of bytes that will be used to <see cref="ToNumeric(byte[], int)"/>
        /// to form a numeric value, which is also the length of byte arrays returned by
        /// <see cref="GetBytes(TNumeric)"/>.
        /// </summary>
        /// <remarks>Note: this is not the same as the number of bytes consumed in memory by a numeric value.</remarks>
        /// <returns>The number of bytes used to convert a <typeparamref name="TNumeric"/> value.</returns>
        int ConvertedSize { get; }

        /// <summary>
        /// Returns a numeric value converted from bytes at a specified position in a byte array.
        /// The number of bytes can be obtained from the <see cref="ConvertedSize"/> method.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A numeric value formed by bytes beginning at <paramref name="startIndex"/>.</returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="startIndex"/> is greater than or equal to the length of <paramref name="value"/>
        ///     plus one, minus the number returned by <see cref="ConvertedSize"/>, and is less than or equal
        ///     to the length of <paramref name="value"/> minus 1.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex"/> is less than zero or greater than the length of
        ///     <paramref name="value"/> minus 1.
        /// </exception>
        TNumeric ToNumeric(byte[] value, int startIndex);

#if HAS_SPANS
        /// <summary>
        /// Converts a read-only byte span into a numeric value.
        /// </summary>
        /// <param name="value">A read-only span containing the bytes to convert.</param>
        /// <returns>A numeric value representing the converted bytes.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The length of <paramref name="value"/> is less than
        ///     <see cref="INumericBitConverter{TNumeric}.ConvertedSize"/>.
        /// </exception>
        TNumeric ToNumeric(ReadOnlySpan<byte> value);
#endif

        /// <summary>
        /// Returns the specified numeric value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length determined by <see cref="ConvertedSize"/>.</returns>
        byte[] GetBytes(TNumeric value);

#if HAS_SPANS
        /// <summary>
        /// Converts a numeric value into a span of bytes.
        /// </summary>
        /// <param name="destination">When this method returns, the bytes representing the converted numeric value.</param>
        /// <param name="value">The numeric value to convert.</param>
        /// <returns><see langword="true"/> if the conversion was successful; <see langword="false"/> otherwise.</returns>
        bool TryWriteBytes(Span<byte> destination, TNumeric value);
#endif
    }
}

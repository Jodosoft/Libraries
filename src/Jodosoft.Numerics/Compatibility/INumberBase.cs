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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Jodosoft.Primitives.Compatibility;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>
    ///     Defines the base of other number types.
    ///     This is a subsitute for <see href="https://learn.microsoft.com/en-us/dotnet/api/system.numerics.inumberbase-1?view=net-7.0">System.Numerics.INumberBase&lt;Self&gt;</see>
    ///     for targets before NET 7.0, promoting a near-compatible implementation for targets without static abstract methods.
    /// </summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    public interface INumberBase<TSelf> :
        IAdditionOperators<TSelf, TSelf, TSelf>,
        IAdditiveIdentity<TSelf, TSelf>,
        IDecrementOperators<TSelf>,
        IDivisionOperators<TSelf, TSelf, TSelf>,
        IEquatable<TSelf>,
        IEqualityOperators<TSelf, TSelf, bool>,
        IIncrementOperators<TSelf>,
        IMultiplicativeIdentity<TSelf, TSelf>,
        IMultiplyOperators<TSelf, TSelf, TSelf>,
#if HAS_SPANS
        ISpanFormattable,
        ISpanParsable<TSelf>,
#endif
        ISubtractionOperators<TSelf, TSelf, TSelf>,
        IUnaryPlusOperators<TSelf, TSelf>,
        IUnaryNegationOperators<TSelf, TSelf>
    where TSelf : INumberBase<TSelf>?, new()
    {
        /// <summary>Gets the value <c>1</c> for the type.</summary>
        TSelf One { get; }

        /// <summary>Gets the radix, or base, for the type.</summary>
        int Radix { get; }

        /// <summary>Gets the value <c>0</c> for the type.</summary>
        TSelf Zero { get; }

        /// <summary>Computes the absolute of a value.</summary>
        /// <param name="value">The value for which to get its absolute.</param>
        /// <returns>The absolute of <paramref name="value" />.</returns>
        /// <exception cref="OverflowException">The absolute of <paramref name="value" /> is not representable by <typeparamref name="TSelf" />.</exception>
        TSelf Abs(TSelf value);

        /// <summary>Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TSelf" />.</param>
        /// <returns>An instance of <typeparamref name="TSelf" /> created from <paramref name="value" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value" /> is not representable by <typeparamref name="TSelf" />.</exception>
        TSelf CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TSelf" />.</param>
        /// <returns>An instance of <typeparamref name="TSelf" /> created from <paramref name="value" />, saturating if <paramref name="value" /> falls outside the representable range of <typeparamref name="TSelf" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        TSelf CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TSelf" />.</param>
        /// <returns>An instance of <typeparamref name="TSelf" /> created from <paramref name="value" />, truncating if <paramref name="value" /> falls outside the representable range of <typeparamref name="TSelf" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        TSelf CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Determines if a value is in its canonical representation.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is in its canonical representation; otherwise, <c>false</c>.</returns>
        bool IsCanonical(TSelf value);

        /// <summary>Determines if a value represents a complex value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a complex number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where <c>b</c> is zero.</remarks>
        bool IsComplexNumber(TSelf value);

        /// <summary>Determines if a value represents an even integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an even integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>2.0</c> will return <c>true</c> while <c>2.2</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger(TSelf)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is not even nor odd.</para>
        /// </remarks>
        bool IsEvenInteger(TSelf value);

        /// <summary>Determines if a value is finite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is finite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsInfinity(TSelf)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        bool IsFinite(TSelf value);

        /// <summary>Determines if a value represents an imaginary value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an imaginary number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where <c>a</c> is non-zero.</remarks>
        bool IsImaginaryNumber(TSelf value);

        /// <summary>Determines if a value is infinite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is infinite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsFinite(TSelf)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        bool IsInfinity(TSelf value);

        /// <summary>Determines if a value represents an integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an integer; otherwise, <c>false</c>.</returns>
        /// <remarks>This correctly handles floating-point values and so <c>2.0</c> and <c>3.0</c> will return <c>true</c> while <c>2.2</c> and <c>3.3</c> will return <c>false</c>.</remarks>
        bool IsInteger(TSelf value);

        /// <summary>Determines if a value is NaN.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is NaN; otherwise, <c>false</c>.</returns>
        bool IsNaN(TSelf value);

        /// <summary>Determines if a value is negative.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is negative; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsPositive(TSelf)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</remarks>
        bool IsNegative(TSelf value);

        /// <summary>Determines if a value is negative infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is negative infinity; otherwise, <c>false</c>.</returns>
        bool IsNegativeInfinity(TSelf value);

        /// <summary>Determines if a value is normal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is normal; otherwise, <c>false</c>.</returns>
        bool IsNormal(TSelf value);

        /// <summary>Determines if a value represents an odd integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an odd integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>3.0</c> will return <c>true</c> while <c>3.3</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger(TSelf)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is neither even nor odd.</para>
        /// </remarks>
        bool IsOddInteger(TSelf value);

        /// <summary>Determines if a value is positive.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is positive; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsNegative(TSelf)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</remarks>
        bool IsPositive(TSelf value);

        /// <summary>Determines if a value is positive infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is positive infinity; otherwise, <c>false</c>.</returns>
        bool IsPositiveInfinity(TSelf value);

        /// <summary>Determines if a value represents a real value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a real number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>true</c> for a complex number <c>a + bi</c> where <c>b</c> is zero.</remarks>
        bool IsRealNumber(TSelf value);

        /// <summary>Determines if a value is subnormal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is subnormal; otherwise, <c>false</c>.</returns>
        bool IsSubnormal(TSelf value);

        /// <summary>Determines if a value is zero.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is zero; otherwise, <c>false</c>.</returns>
        /// <remarks>This function treats both positive and negative zero as zero and so will return <c>true</c> for <c>+0.0</c> and <c>-0.0</c>.</remarks>
        bool IsZero(TSelf value);

        /// <summary>Compares two values to compute which is greater.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        TSelf MaxMagnitude(TSelf x, TSelf y);

        /// <summary>Compares two values to compute which has the greater magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        TSelf MaxMagnitudeNumber(TSelf x, TSelf y);

        /// <summary>Compares two values to compute which is lesser.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        TSelf MinMagnitude(TSelf x, TSelf y);

        /// <summary>Compares two values to compute which has the lesser magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        TSelf MinMagnitudeNumber(TSelf x, TSelf y);

        /// <summary>Parses a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="s" /> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="TSelf" />.</exception>
        TSelf Parse(string s, NumberStyles style, IFormatProvider? provider);

#if HAS_SPANS

        /// <summary>Parses a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="TSelf" />.</exception>
        TSelf Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider);

#endif

        /// <summary>Tries to parses a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result);

#if HAS_SPANS

        /// <summary>Tries to parses a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result);

#endif

    }
}

#endif

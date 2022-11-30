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

namespace Jodo.Numerics
{
    /// <summary>
    /// Provides methods for trigonometric, logarithmic, and other common mathematical functions.
    /// </summary>
    /// <typeparam name="TNumeric">The type of number supported for mathematical functions.</typeparam>
    public interface IMath<TNumeric>
    {
        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// If <typeparamref name="TNumeric"/> is integral, this value is rounded to 2.
        /// </summary>
        TNumeric E { get; }

        /// <summary>
        ///     Represents the ratio of the circumference of a circle to its diameter,
        ///     specified by the constant, π. If <typeparamref name="TNumeric"/> is integral,
        ///     this value is rounded to 3.
        /// </summary>
        TNumeric PI { get; }

        /// <summary>
        ///     Two times the value of <see cref="PI"/>.
        /// </summary>
        TNumeric Tau { get; }

        /// <summary>
        /// Returns an integer that indicates the sign of a number.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>
        ///     A number that indicates the sign of <paramref name="value"/>, as shown in the following table.
        ///     <list type="table">
        ///         <listheader>
        ///             <term>Return value</term>
        ///             <term>Meaning</term>
        ///         </listheader>
        ///         <item>
        ///             <description>-1</description>
        ///             <description><paramref name="value"/> is less than zero</description>
        ///         </item>
        ///         <item>
        ///             <description>0</description>
        ///             <description><paramref name="value"/> is equal to zero.</description>
        ///         </item>
        ///         <item>
        ///             <description>1</description>
        ///             <description><paramref name="value"/> is greater than zero.</description>
        ///         </item>
        ///     </list>
        /// </returns>
        /// <exception cref="ArithmeticException"><paramref name="value"/> is equal to <c>NaN</c>.</exception>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Sign(double)"/>
        int Sign(TNumeric value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="value">
        ///     A number that is greater than or equal to <see cref="Numeric.MinValue{T}"/>,
        ///     but less than or equal to <see cref="Numeric.MaxValue{T}"/>.
        /// </param>
        /// <returns>A number, x, such that 0 ≤ x ≤ <see cref="Numeric.MaxValue{T}"/>.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Abs(double)"/>
        TNumeric Abs(TNumeric value);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="x">
        ///     A number representing a cosine, where <paramref name="x"/> must be greater
        ///     than or equal to <see cref="Numeric.MinUnit{T}"/>, but less than or equal to
        ///     <see cref="Numeric.MaxUnit{T}"/>.
        /// </param>
        /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π.</returns>
        /// <seealso cref="Math.Acos(double)"/>
        TNumeric Acos(TNumeric x);

        /// <summary>
        ///     Returns the angle whose hyperbolic cosine is the specified number.
        /// </summary>
        /// <param name="x">
        ///     A number representing a hyperbolic cosine, where <paramref name="x"/> must be
        ///     greater than or equal to 1.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        TNumeric Acosh(TNumeric x);

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="x">A number representing a sine, where <paramref name="x" /> must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Asin(double)"/>
        TNumeric Asin(TNumeric x);

        /// <summary>
        /// Returns the angle whose hyperbolic sine is the specified number.
        /// </summary>
        /// <param name="x">A number representing a hyperbolic sine</param>
        /// <returns>An angle, θ, measured in radians.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        TNumeric Asinh(TNumeric x);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="x">A number representing a tangent.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Atan(double)"/>
        TNumeric Atan(TNumeric x);

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The x coordinate of a point.</param>
        /// <param name="y">The y coordinate of a point.</param>
        /// <returns>
        /// An angle, θ, measured in radians, such that tan(θ) = <paramref name="y" /> / <paramref name="x" />, where (<paramref name="x" />, <paramref name="y" />) is a point in the Cartesian plane. Observe the following:
        /// 
        /// <list type="bullet">
        /// <item><description>For (<paramref name="x" />, <paramref name="y" />) in quadrant 1, 0 &lt; θ &lt; π/2.</description></item>
        /// <item><description>For (<paramref name="x" />, <paramref name="y" />) in quadrant 2, π/2 &lt; θ ≤ π.</description></item>
        /// <item><description>For (<paramref name="x" />, <paramref name="y" />) in quadrant 3, -π ≤ θ &lt; -π/2.</description></item>
        /// <item><description>For (<paramref name="x" />, <paramref name="y" />) in quadrant 4, -π/2 &lt; θ &lt; 0.</description></item>
        /// </list>
        /// 
        /// For points on the boundaries of the quadrants, the return value is the following:
        ///
        /// <list type="bullet">
        /// <item><description>If <paramref name="y" /> is 0 and <paramref name="x" /> is not negative, θ = 0.</description></item>
        /// <item><description>If <paramref name="y" /> is 0 and <paramref name="x" /> is negative, θ = π.</description></item>
        /// <item><description>If <paramref name="y" /> is positive and <paramref name="x" /> is 0, θ = π/2.</description></item>
        /// <item><description>If <paramref name="y" /> is negative and <paramref name="x" /> is 0, θ = -π/2.</description></item>
        /// <item><description>If <paramref name="y" /> is 0 and <paramref name="x" /> is 0, θ = 0.</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Atan2(double, double)"/>
        TNumeric Atan2(TNumeric x, TNumeric y);

        /// <summary>
        /// Returns the angle whose hyperbolic tangent is the specified number.
        /// </summary>
        /// <param name="x">A number representing a hyperbolic tangent, where <paramref name="x" /> must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>An angle, θ, measured in radians.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        TNumeric Atanh(TNumeric x);

        /// <summary>Returns the cube root of a specified number.</summary>
        /// <param name="x">The number whose cube root is to be found.</param>
        /// <returns>The cube root of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        TNumeric Cbrt(TNumeric x);

        /// <param name="x">A number.</param>
        /// <summary>Returns the smallest integral value that is greater than or equal to the specified number.</summary>
        /// <returns>The smallest integral value that is greater than or equal to <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Ceiling(double)"/>
        TNumeric Ceiling(TNumeric x);

        /// <summary>Returns <paramref name="value" /> clamped to the inclusive range of <paramref name="bound1" /> and <paramref name="bound2" />.</summary>
        /// <param name="value">The value to be clamped.</param>
        /// <param name="bound1">The first bound of the result (may be the lower or upper bound).</param>
        /// <param name="bound2">The second bound of the result (may be the lower or upper bound).</param>
        /// <returns>
        ///     <para><paramref name="value" /> if <paramref name="bound1" /> ≤ <paramref name="value" /> ≤ <paramref name="bound2" />.</para>
        ///     <para>-or-</para>
        ///     <para><paramref name="bound1" /> if <paramref name="value" /> &lt; <paramref name="bound1" />.</para>
        ///     <para>-or-</para>
        ///     <para><paramref name="bound2" /> if <paramref name="bound2" /> &lt; <paramref name="value" />.</para>
        /// </returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        TNumeric Clamp(TNumeric value, TNumeric bound1, TNumeric bound2);

        /// <summary>Returns the cosine of the specified angle.</summary>
        /// <param name="x">An angle, measured in radians.</param>
        /// <returns>The cosine of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Cos(double)"/>
        TNumeric Cos(TNumeric x);

        /// <summary>Returns the hyperbolic cosine of the specified angle.</summary>
        /// <param name="value">An angle, measured in radians.</param>
        /// <returns>The hyperbolic cosine of <paramref name="value" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Cosh(double)"/>
        TNumeric Cosh(TNumeric value);

        /// <summary>Returns <see langword="e" /> raised to the specified power.</summary>
        /// <param name="x">A number specifying a power.</param>
        /// <returns>The number <see langword="e" /> raised to the power <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Exp(double)"/>
        TNumeric Exp(TNumeric x);

        /// <summary>Returns the largest integral value less than or equal to the specified number.</summary>
        /// <param name="x">A number.</param>
        /// <returns>The largest integral value less than or equal to <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Floor(double)"/>
        TNumeric Floor(TNumeric x);

        /// <summary>Returns the remainder resulting from the division of a specified number by another specified number.</summary>
        /// <param name="x">A dividend.</param>
        /// <param name="y">A divisor.</param>
        /// <returns>
        ///     A number equal to <paramref name="x" /> - (<paramref name="y" /> Q),
        ///     where Q is the quotient of <paramref name="x" /> / <paramref name="y" /> rounded to the nearest integer
        ///     (if <paramref name="x" /> / <paramref name="y" /> falls halfway between two integers, the even integer is returned).
        /// </returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.IEEERemainder(double, double)"/>
        TNumeric IEEERemainder(TNumeric x, TNumeric y);

        /// <summary>Returns the natural (base <see langword="e" />) logarithm of a specified number.</summary>
        /// <param name="x">The number whose logarithm is to be found.</param>
        /// <returns>
        ///     The natural logarithm of <paramref name="x" />; that is, ln <paramref name="x" />, or log e <paramref name="x" />.
        /// </returns>
        /// <remarks>
        ///     May return <c>NaN</c> or Infinity (see <see cref="Math.Log(double)"/>).
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then a <see cref="ArithmeticException"/> may be thrown.
        /// </remarks>
        /// <seealso cref="Math.Log(double)"/>
        TNumeric Log(TNumeric x);

        /// <summary>Returns the logarithm of a specified number in a specified base.</summary>
        /// <param name="a">The number whose logarithm is to be found.</param>
        /// <param name="newBase">The base of the logarithm.</param>
        /// <returns>log newBase(a)</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Log(double, double)"/>
        TNumeric Log(TNumeric a, TNumeric newBase);

        /// <summary>Returns the base 10 logarithm of a specified number.</summary>
        /// <param name="x">A number whose logarithm is to be found.</param>
        /// <returns>The base 10 log of <paramref name="x" />; that is, log 10<paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Log10(double)"/>
        TNumeric Log10(TNumeric x);

        /// <summary>Returns the larger of two numbers.</summary>
        /// <param name="val1">The first of two numbers to compare.</param>
        /// <param name="val2">The second of two numbers to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is larger.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Max(double, double)"/>
        TNumeric Max(TNumeric val1, TNumeric val2);

        /// <summary>Returns the smaller of two numbers.</summary>
        /// <param name="val1">The first of two numbers to compare.</param>
        /// <param name="val2">The second of two numbers to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is smaller.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Min(double, double)"/>
        TNumeric Min(TNumeric val1, TNumeric val2);

        /// <summary>Returns a specified number raised to the specified power.</summary>
        /// <param name="x">A number to be raised to a power.</param>
        /// <param name="y">A number that specifies a power.</param>
        /// <returns>The number <paramref name="x" /> raised to the power <paramref name="y" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Pow(double, double)"/>
        TNumeric Pow(TNumeric x, TNumeric y);

        /// <summary>Rounds a value to the nearest integral value, and rounds midpoint values to the nearest even number.</summary>
        /// <param name="x">A number to be rounded.</param>
        /// <returns>
        ///     The integer nearest the <paramref name="x" /> parameter.
        ///     If the fractional component of <paramref name="x" /> is halfway between two integers,
        ///     one of which is even and the other odd, the even number is returned.
        /// </returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Round(double, int)"/>
        TNumeric Round(TNumeric x);

        /// <summary>Rounds a value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.</summary>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>The number nearest to <paramref name="value" /> that contains a number of fractional digits equal to <paramref name="digits" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Round(double, int)"/>
        TNumeric Round(TNumeric value, int digits);

        /// <param name="value">A number to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
        /// <summary>Rounds a value to a specified number of fractional digits using the specified rounding convention.</summary>
        /// <returns>
        ///     The number that has <paramref name="digits" /> fractional digits that <paramref name="value" /> is rounded to.
        ///     If <paramref name="value" /> has fewer fractional digits than <paramref name="digits" />,
        ///     <paramref name="value" /> is returned unchanged.
        /// </returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Round(double, int, MidpointRounding)"/>
        TNumeric Round(TNumeric value, int digits, MidpointRounding mode);

        /// <summary>Rounds a value an integer using the specified rounding convention.</summary>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
        /// <returns>The integer that <paramref name="value" /> is rounded to.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Round(double, MidpointRounding)"/>
        TNumeric Round(TNumeric value, MidpointRounding mode);

        /// <summary>Returns the sine of the specified angle.</summary>
        /// <param name="x">An angle, measured in radians.</param>
        /// <returns>The sine of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Sin(double)"/>
        TNumeric Sin(TNumeric x);

        /// <summary>Returns the hyperbolic sine of the specified angle.</summary>
        /// <param name="x">An angle, measured in radians.</param>
        /// <returns>The hyperbolic sine of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Sinh(double)"/>
        TNumeric Sinh(TNumeric x);

        /// <summary>Returns the square root of a specified number.</summary>
        /// <param name="x">The number whose square root is to be found.</param>
        /// <returns>The positive square root of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Sqrt(double)"/>
        TNumeric Sqrt(TNumeric x);

        /// <param name="x">An angle, measured in radians.</param>
        /// <summary>Returns the tangent of the specified angle.</summary>
        /// <returns>The tangent of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Tan(double)"/>
        TNumeric Tan(TNumeric x);

        /// <summary>Returns the hyperbolic tangent of the specified angle.</summary>
        /// <param name="x">An angle, measured in radians.</param>
        /// <returns>The hyperbolic tangent of <paramref name="x" />.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Tanh(double)"/>
        TNumeric Tanh(TNumeric x);

        /// <summary>Calculates the integral part of a specified number.</summary>
        /// <param name="x">A number to truncate.</param>
        /// <returns>The integral part of <paramref name="x" />; that is, the number that remains after any fractional digits have been discarded.</returns>
        /// <remarks>
        ///     This method may return <c>NaN</c> or Infinity.
        ///     If <c>NaN</c> or Infinity cannot be represented by <typeparamref name="TNumeric"/>,
        ///     then this method may throw an <see cref="ArithmeticException"/>.
        /// </remarks>
        /// <seealso cref="Math.Truncate(double)"/>
        TNumeric Truncate(TNumeric x);
    }
}

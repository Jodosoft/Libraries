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
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    /// <summary>
    /// Provides static methods for trigonometric, logarithmic, and other common mathematical functions for
    /// implementations of <see cref="INumeric{TSelf}"/>
    /// </summary>
    public static class MathN
    {
        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// If <typeparamref name="TNumeric"/> is integral, this value is rounded to 2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric E<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.E;

        /// <summary>
        ///     Represents the ratio of the circumference of a circle to its diameter,
        ///     specified by the constant, π. If <typeparamref name="TNumeric"/> is integral,
        ///     this value is rounded to 3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric PI<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.PI;

        /// <summary>
        ///     Two times the value of <see cref="PI"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tau<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tau;

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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sign(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="value">
        ///     A number that is greater than or equal to <see cref="Numeric.MinValue{T}"/>,
        ///     but less than or equal to <see cref="Numeric.MaxValue{T}"/>.
        /// </param>
        /// <returns>A number, x, such that 0 ≤ x ≤ <see cref="Numeric.MaxValue{T}"/>.</returns>
        /// <exception cref="OverflowException">
        ///     value is too small to be represented as a positive,
        ///     e.g. the <c>MinValue</c> of an integral number.
        /// </exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Abs<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Abs(value);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="n">
        ///     A number representing a cosine, where <paramref name="n"/> must be greater
        ///     than or equal to <see cref="Numeric.MinUnit{T}"/>, but less than or equal to
        ///     <see cref="Numeric.MaxUnit{T}"/>.
        /// </param>
        /// <returns>
        ///     An angle, θ, measured in radians, such that 0 ≤ θ ≤ <see cref="PI{TNumeric}"/>
        ///     -or- <c>NaN</c> if <see cref="Numeric.HasNaN{T}"/> equals
        ///     <c>true</c> and <paramref name="n"/> &lt; -1 or <paramref name="n"/> &gt; 1 or
        ///     d equals <c>NaN</c>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Acos<TNumeric>(TNumeric n) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Acos(n);

        /// <summary>
        ///     Returns the angle whose hyperbolic cosine is the specified number.
        /// </summary>
        /// <param name="n">
        ///     A number representing a hyperbolic cosine, where <paramref name="n"/> must be
        ///     greater than or equal to 1.
        /// </param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Acosh<TNumeric>(TNumeric n) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Acosh(n);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Asin<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Asin(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Asinh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Asinh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atan<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atan(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atan2<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atan2(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atanh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atanh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cbrt<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cbrt(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Ceiling<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Ceiling(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Clamp<TNumeric>(TNumeric x, TNumeric bound1, TNumeric bound2) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cos<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cos(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cosh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cosh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Exp<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Exp(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Floor<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Floor(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric IEEERemainder<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.IEEERemainder(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log10<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log10(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Max<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Max(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Min<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Min(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Pow<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Pow(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, int digits) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, digits);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, int digits, MidpointRounding mode) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, digits, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, MidpointRounding mode) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sin<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sin(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sinh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sinh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sqrt<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sqrt(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tan<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tan(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tanh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tanh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Truncate<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Truncate(x);
    }
}

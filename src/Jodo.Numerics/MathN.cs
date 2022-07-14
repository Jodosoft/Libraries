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
    public static class MathN
    {
        /// <summary>
        ///     Represents the natural logarithmic base, specified by the constant, e.
        ///     If <typeparamref name="N"/> is integral, this value is rounded to 2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N E<N>() where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.E;

        /// <summary>
        ///     Represents the ratio of the circumference of a circle to its diameter,
        ///     specified by the constant, π. If <typeparamref name="N"/> is integral,
        ///     this value is rounded to 3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N PI<N>() where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.PI;

        /// <summary>
        ///     Two times the value of <see cref="PI"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Tau<N>() where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Tau;

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
        public static int Sign<N>(N value) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Sign(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="value">
        ///     A number that is greater than or equal to <see cref="Numeric{T}.MinValue"/>,
        ///     but less than or equal to <see cref="Numeric{T}.MaxValue"/>.
        /// </param>
        /// <returns>A number, x, such that 0 ≤ x ≤ <see cref="Numeric{T}.MaxValue"/>.</returns>
        /// <exception cref="OverflowException">
        ///     value is too small to be represented as a positive,
        ///     e.g. the <c>MinValue</c> of an integral number.
        /// </exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Abs<N>(N value) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Abs(value);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="n">
        ///     A number representing a cosine, where <paramref name="n"/> must be greater
        ///     than or equal to <see cref="Numeric{T}.MinUnit"/>, but less than or equal to
        ///     <see cref="Numeric{T}.MaxUnit"/>.
        /// </param>
        /// <returns>
        ///     An angle, θ, measured in radians, such that 0 ≤ θ ≤ <see cref="Math{T}.PI"/>
        ///     -or- <c>NaN</c> if <see cref="Numeric{T}.HasNaN"/> equals
        ///     <c>true</c> and <paramref name="n"/> &lt; -1 or <paramref name="n"/> &gt; 1 or
        ///     d equals <c>NaN</c>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Acos<N>(N n) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Acos(n);

        //
        // Summary:
        //     Returns the angle whose hyperbolic cosine is the specified number.
        //
        // Parameters:
        //   d:
        //     A number representing a hyperbolic cosine, where d must be greater than or equal
        //     to 1, but less than or equal to System.Double.PositiveInfinity.
        //
        // Returns:
        //     An angle, θ, measured in radians, such that 0 ≤ θ ≤ ∞. -or- System.Double.NaN
        //     if d < 1 or d equals System.Double.NaN.

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
        public static N Acosh<N>(N n) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Acosh(n);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Asin<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Asin(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Asinh<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Asinh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Atan<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Atan(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Atan2<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Atan2(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Atanh<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Atanh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Cbrt<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Cbrt(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Ceiling<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Ceiling(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Clamp<N>(N x, N bound1, N bound2) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Cos<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Cos(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Cosh<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Cosh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N DegreesToRadians<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.DegreesToRadians(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Exp<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Exp(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Floor<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Floor(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N IEEERemainder<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.IEEERemainder(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Log<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Log(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Log<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Log(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Log10<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Log10(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Max<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Max(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Min<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Min(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Pow<N>(N x, N y) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Pow(x, y);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N RadiansToDegrees<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.RadiansToDegrees(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Round<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Round(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Round<N>(N x, int digits) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Round(x, digits);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Round<N>(N x, int digits, MidpointRounding mode) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Round(x, digits, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Round<N>(N x, MidpointRounding mode) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Round(x, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Sin<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Sin(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Sinh<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Sinh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Sqrt<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Sqrt(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Tan<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Tan(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Tanh<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Tanh(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Truncate<N>(N x) where N : struct, INumeric<N> => Provider<N, IMath<N>>.Default.Truncate(x);


    }
}

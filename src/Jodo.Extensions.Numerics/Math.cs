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
using Jodo.Extensions.Primitives;

namespace Jodo.Extensions.Numerics
{
    /// <summary>
    ///     Provides constants and static methods for trigonometric, logarithmic,
    ///     and other common mathematical functions.
    /// </summary>
    /// <typeparam name="N">
    ///     A numeric type that provides a default instance of <see cref="IMath{N}"/>.
    /// </typeparam>
    public static partial class Math<N> where N : struct, IProvider<IMath<N>>
    {
        private static readonly IMath<N> Default = default(N).GetInstance();

        /// <summary>
        ///     Represents the natural logarithmic base, specified by the constant, e.
        ///     If <typeparamref name="N"/> is integral, this value is rounded to 2.
        /// </summary>
        public static N E => Default.E;

        /// <summary>
        ///     Represents the ratio of the circumference of a circle to its diameter,
        ///     specified by the constant, π. If <typeparamref name="N"/> is integral,
        ///     this value is rounded to 3.
        /// </summary>
        public static N PI => Default.PI;

        /// <summary>
        ///     Two times the value of <see cref="PI"/>.
        /// </summary>
        public static N Tau => Default.Tau;

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
        public static int Sign(N value) => Default.Sign(value);

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
        public static N Abs(N value) => Default.Abs(value);

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
        public static N Acos(N n) => Default.Acos(n);

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
        public static N Acosh(N n) => Default.Acosh(n);

        [DebuggerStepThrough]
        public static N Asin(N x) => Default.Asin(x);

        [DebuggerStepThrough]
        public static N Asinh(N x) => Default.Asinh(x);

        [DebuggerStepThrough]
        public static N Atan(N x) => Default.Atan(x);

        [DebuggerStepThrough]
        public static N Atan2(N x, N y) => Default.Atan2(x, y);

        [DebuggerStepThrough]
        public static N Atanh(N x) => Default.Atanh(x);

        [DebuggerStepThrough]
        public static N Cbrt(N x) => Default.Cbrt(x);

        [DebuggerStepThrough]
        public static N Ceiling(N x) => Default.Ceiling(x);

        [DebuggerStepThrough]
        public static N Clamp(N x, N bound1, N bound2) => Default.Clamp(x, bound1, bound2);

        [DebuggerStepThrough]
        public static N Cos(N x) => Default.Cos(x);

        [DebuggerStepThrough]
        public static N Cosh(N x) => Default.Cosh(x);

        [DebuggerStepThrough]
        public static N DegreesToRadians(N x) => Default.DegreesToRadians(x);

        [DebuggerStepThrough]
        public static N Exp(N x) => Default.Exp(x);

        [DebuggerStepThrough]
        public static N Floor(N x) => Default.Floor(x);

        [DebuggerStepThrough]
        public static N IEEERemainder(N x, N y) => Default.IEEERemainder(x, y);

        [DebuggerStepThrough]
        public static N Log(N x) => Default.Log(x);

        [DebuggerStepThrough]
        public static N Log(N x, N y) => Default.Log(x, y);

        [DebuggerStepThrough]
        public static N Log10(N x) => Default.Log10(x);

        [DebuggerStepThrough]
        public static N Max(N x, N y) => Default.Max(x, y);

        [DebuggerStepThrough]
        public static N Min(N x, N y) => Default.Min(x, y);

        [DebuggerStepThrough]
        public static N Pow(N x, N y) => Default.Pow(x, y);

        [DebuggerStepThrough]
        public static N RadiansToDegrees(N x) => Default.RadiansToDegrees(x);

        [DebuggerStepThrough]
        public static N Round(N x) => Default.Round(x);

        [DebuggerStepThrough]
        public static N Round(N x, int digits) => Default.Round(x, digits);

        [DebuggerStepThrough]
        public static N Round(N x, int digits, MidpointRounding mode) => Default.Round(x, digits, mode);

        [DebuggerStepThrough]
        public static N Round(N x, MidpointRounding mode) => Default.Round(x, mode);

        [DebuggerStepThrough]
        public static N Sin(N x) => Default.Sin(x);

        [DebuggerStepThrough]
        public static N Sinh(N x) => Default.Sinh(x);

        [DebuggerStepThrough]
        public static N Sqrt(N x) => Default.Sqrt(x);

        [DebuggerStepThrough]
        public static N Tan(N x) => Default.Tan(x);

        [DebuggerStepThrough]
        public static N Tanh(N x) => Default.Tanh(x);

        [DebuggerStepThrough]
        public static N Truncate(N x) => Default.Truncate(x);
    }
}

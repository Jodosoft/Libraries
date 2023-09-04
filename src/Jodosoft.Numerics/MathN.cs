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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Provides static methods for trigonometric, logarithmic, and other common mathematical functions for
    /// implementations of <see cref="INumeric{TSelf}"/>
    /// </summary>
    public static class MathN
    {
        /// <inheritdoc cref="IMath{TNumeric}.E" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric E<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.E;

        /// <inheritdoc cref="IMath{TNumeric}.PI" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric PI<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.PI;

        /// <inheritdoc cref="IMath{TNumeric}.Tau" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tau<TNumeric>() where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tau;

        /// <inheritdoc cref="IMath{TNumeric}.Sign(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sign(value);

        /// <inheritdoc cref="IMath{TNumeric}.Abs(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Abs<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Abs(value);

        /// <inheritdoc cref="IMath{TNumeric}.Acos(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Acos<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Acos(x);

        /// <inheritdoc cref="IMath{TNumeric}.Acosh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Acosh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Acosh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Asin(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Asin<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Asin(x);

        /// <inheritdoc cref="IMath{TNumeric}.Asinh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Asinh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Asinh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Atan(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atan<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atan(x);

        /// <inheritdoc cref="IMath{TNumeric}.Atan2(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atan2<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atan2(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Atanh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Atanh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Atanh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Cbrt(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cbrt<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cbrt(x);

        /// <inheritdoc cref="IMath{TNumeric}.Ceiling(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Ceiling<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Ceiling(x);

        /// <inheritdoc cref="IMath{TNumeric}.Clamp(TNumeric, TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Clamp<TNumeric>(TNumeric x, TNumeric bound1, TNumeric bound2) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Clamp(x, bound1, bound2);

        /// <inheritdoc cref="IMath{TNumeric}.Cos(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cos<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cos(x);

        /// <inheritdoc cref="IMath{TNumeric}.Cosh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Cosh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Cosh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Exp(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Exp<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Exp(x);

        /// <inheritdoc cref="IMath{TNumeric}.Floor(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Floor<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Floor(x);

        /// <inheritdoc cref="IMath{TNumeric}.IEEERemainder(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric IEEERemainder<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.IEEERemainder(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Log(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log(x);

        /// <inheritdoc cref="IMath{TNumeric}.Log(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Log10(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Log10<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Log10(x);

        /// <inheritdoc cref="IMath{TNumeric}.Max(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Max<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Max(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Min(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Min<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Min(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Pow(TNumeric, TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Pow<TNumeric>(TNumeric x, TNumeric y) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Pow(x, y);

        /// <inheritdoc cref="IMath{TNumeric}.Round(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x);

        /// <inheritdoc cref="IMath{TNumeric}.Round(TNumeric, int)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, int digits) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, digits);

        /// <inheritdoc cref="IMath{TNumeric}.Round(TNumeric, int)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, int digits, MidpointRounding mode) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, digits, mode);

        /// <inheritdoc cref="IMath{TNumeric}.Round(TNumeric, int, MidpointRounding)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Round<TNumeric>(TNumeric x, MidpointRounding mode) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Round(x, mode);

        /// <inheritdoc cref="IMath{TNumeric}.Sin(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sin<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sin(x);

        /// <inheritdoc cref="IMath{TNumeric}.Sinh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sinh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sinh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Sqrt(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Sqrt<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Sqrt(x);

        /// <inheritdoc cref="IMath{TNumeric}.Tan(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tan<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tan(x);

        /// <inheritdoc cref="IMath{TNumeric}.Tanh(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Tanh<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Tanh(x);

        /// <inheritdoc cref="IMath{TNumeric}.Truncate(TNumeric)" />
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Truncate<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric> => DefaultProvider<TNumeric, IMath<TNumeric>>.Instance.Truncate(x);
    }
}

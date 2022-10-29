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
using System.Globalization;
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class Numeric
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFloatingPoint<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.HasFloatingPoint;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasInfinity<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.HasInfinity;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasNaN<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.HasNaN;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReal<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsReal;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIntegral<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => !DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsReal;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSigned<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsSigned;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUnsigned<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => !DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsSigned;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Epsilon<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Epsilon;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric MaxUnit<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.MaxUnit;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric MaxValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.MaxValue;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric MinUnit<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.MinUnit;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric MinValue<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.MinValue;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric One<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.One;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Zero<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Zero;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsFinite(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsNaN(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsNegative(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsNegativeInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNormal<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsNormal(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsPositiveInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.IsSubnormal(x);

        [DebuggerStepThrough]
        public static TNumeric Parse<TNumeric>(string s) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Parse(s, null, null);

        [DebuggerStepThrough]
        public static TNumeric Parse<TNumeric>(string s, IFormatProvider? formatProvider) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Parse(s, null, formatProvider);

        [DebuggerStepThrough]
        public static TNumeric Parse<TNumeric>(string s, NumberStyles numberStyles) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Parse(s, numberStyles, null);

        [DebuggerStepThrough]
        public static TNumeric Parse<TNumeric>(string s, NumberStyles numberStyles, IFormatProvider? formatProvider) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Parse(s, numberStyles, formatProvider);

        [DebuggerStepThrough]
        public static TNumeric Parse<TNumeric>(string s, NumberStyles? numberStyles, IFormatProvider? formatProvider) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericStatic<TNumeric>>.Instance.Parse(s, numberStyles, formatProvider);

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="x"/> equals <c>0</c>. Equivalent to checking whether
        /// <paramref name="x"/> equals <c>default</c>.
        /// </summary>
        /// <typeparam name="TNumeric">The type of number to test.</typeparam>
        /// <param name="x">The number to test for equality to <c>0</c>.</param>
        /// <returns><see langword="true"/> if <paramref name="x"/> equals <c>0</c>; otherwise <see langword="false"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero<TNumeric>(TNumeric x) where TNumeric : struct, INumeric<TNumeric>
        {
            return x.Equals(default);
        }

        public static bool TryParse<TNumeric>(string s, out TNumeric result) where TNumeric : struct, INumeric<TNumeric>
        {
            try
            {
                result = Parse<TNumeric>(s);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse<TNumeric>(string s, IFormatProvider? provider, out TNumeric result) where TNumeric : struct, INumeric<TNumeric>
        {
            try
            {
                result = Parse<TNumeric>(s, provider);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse<TNumeric>(string s, NumberStyles style, out TNumeric result) where TNumeric : struct, INumeric<TNumeric>
        {
            try
            {
                result = Parse<TNumeric>(s, style);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse<TNumeric>(string s, NumberStyles style, IFormatProvider? provider, out TNumeric result) where TNumeric : struct, INumeric<TNumeric>
        {
            try
            {
                result = Parse<TNumeric>(s, style, provider);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }
    }
}

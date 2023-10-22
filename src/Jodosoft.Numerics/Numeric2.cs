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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{

    public static class Numeric2
    {
#if !HAS_SYSTEM_NUMERICS
        private static class Default<TNumber> where TNumber : new()
        {
            public static readonly TNumber T = new();
        }
#endif

        /// <inheritdoc cref="IAdditiveIdentity{TSelf}.AdditiveIdentity"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AdditiveIdentity<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.AdditiveIdentity;

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf}.MultiplicativeIdentity"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MultiplicativeIdentity<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.MultiplicativeIdentity;

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf}.MultiplicativeIdentity"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(returnValue: false)] out T result) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.TryParse(s, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Abs(value);

        /// <inheritdoc cref="INumberBase{TSelf}.CreateChecked{TOther}(TOther)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateChecked<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.CreateChecked(value);

        /// <inheritdoc cref="INumberBase{TSelf}.CreateSaturating{TOther}(TOther)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateSaturating<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.CreateSaturating(value);

        /// <inheritdoc cref="INumberBase{TSelf}.CreateTruncating{TOther}(TOther)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateTruncating<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.CreateTruncating(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCanonical<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsCanonical(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsComplexNumber<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsComplexNumber(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsEvenInteger(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsEvenInteger(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsFinite(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImaginaryNumber<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsImaginaryNumber(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsInfinity(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInteger<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsInteger(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsNaN(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsNegative(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsNegativeInfinity(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNormal<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsNormal(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsOddInteger(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositive<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsPositive(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsPositiveInfinity(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsRealNumber(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsSubnormal(value);

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero<T>(T value) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.IsZero(value);

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxMagnitude<T>(T x, T y) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxMagnitudeNumber<T>(T x, T y) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.MaxMagnitudeNumber(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinMagnitude<T>(T x, T y) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.MinMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinMagnitudeNumber<T>(T x, T y) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.MinMagnitudeNumber(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.One"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T One<T>() where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.One;

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, IFormatProvider?)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(string s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Parse(s, style, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Parse(s, style, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Radix"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Radix<T>() where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Radix;

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider?, out TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.TryParse(s, style, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.TryParse(s, style, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.Zero"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Zero<T>() where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Zero;

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(string s, IFormatProvider? provider) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Parse(s, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(ReadOnlySpan<char> s, IFormatProvider? provider) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.Parse(s, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(returnValue: false)] out T result) where T : INumberBase<T>, new() =>
#if !HAS_SYSTEM_NUMERICS
            Default<T>.
#endif
                    T.TryParse(s, provider, out result);

    }
}

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

using System.Numerics;
using System.Runtime.CompilerServices;

#if HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    public static class ComparisonOperatorsExtensions
    {
        /// <summary>Compares two values to determine which is less.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThan<TSelf, TOther, TResult>(this TSelf left, TOther right) where TSelf : IComparisonOperators<TSelf, TOther, TResult>, new() => left < right;

        /// <summary>Compares two values to determine which is less or equal.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThanOrEqualTo<TSelf, TOther, TResult>(this TSelf left, TOther right) where TSelf : IComparisonOperators<TSelf, TOther, TResult>, new() => left <= right;

        /// <summary>Compares two values to determine which is greater.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThan<TSelf, TOther, TResult>(this TSelf left, TOther right) where TSelf : IComparisonOperators<TSelf, TOther, TResult>, new() => left > right;

        /// <summary>Compares two values to determine which is greater or equal.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThanOrEqualTo<TSelf, TOther, TResult>(this TSelf left, TOther right) where TSelf : IComparisonOperators<TSelf, TOther, TResult>, new() => left >= right;
    }
}

#endif

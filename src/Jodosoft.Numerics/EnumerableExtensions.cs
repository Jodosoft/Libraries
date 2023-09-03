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
using System.Collections.Generic;

namespace Jodosoft.Numerics
{
    public static class EnumerableExtensions
    {
        /// <summary>Computes the average of a sequence of numeric values.</summary>
        /// <typeparam name="TNumeric">The type of numeric value to average.</typeparam>
        /// <param name="source">A sequence of <typeparamref name="TNumeric"/> values to calculate the average of.</param>
        /// <returns>The average of the sequence of values.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
        public static TNumeric Average<TNumeric>(this IEnumerable<TNumeric> source) where TNumeric : struct, INumeric<TNumeric>
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using IEnumerator<TNumeric> enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

            TNumeric sum = enumerator.Current;
            TNumeric count = Numeric.One<TNumeric>();
            while (enumerator.MoveNext())
            {
                sum = sum.Add(enumerator.Current);
                count = count.Add(Numeric.One<TNumeric>());
            }
            return sum.Divide(count);
        }

        /// <summary>Computes the sum of a sequence of numeric values.</summary>
        /// <typeparam name="TNumeric">The type of numeric value to sum.</typeparam>
        /// <param name="source">A sequence of <typeparamref name="TNumeric"/> values to calculate the sum of.</param>
        /// <returns>The sum of the sequence of values.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
        public static TNumeric Sum<TNumeric>(this IEnumerable<TNumeric> source) where TNumeric : struct, INumeric<TNumeric>
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using IEnumerator<TNumeric> enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

            TNumeric sum = enumerator.Current;
            while (enumerator.MoveNext())
            {
                sum = sum.Add(enumerator.Current);
            }
            return sum;
        }
    }
}

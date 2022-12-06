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

namespace Jodo.Primitives
{
    /// <summary>
    /// Provides support for pseudo-random generation of variants of a type using <see cref="Random"/>.
    /// </summary>
    /// <typeparam name="T">The type for which to generate variants.</typeparam>
    /// <seealso cref="Variants"/>
    public interface IVariantRandom<out T>
    {
        /// <summary>
        /// Returns a random value of <typeparamref name="T"/> matching one of the specified variants.
        /// </summary>
        /// <param name="random">The instance of <see cref="Random"/> to use for supporting pseudo-random number generation.</param>
        /// <param name="variants">A bitwise combination of the enumeration values that specify which variants of <typeparamref name="T"/> may be generated.</param>
        /// <returns>The value of <typeparamref name="T"/> that was generated.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="variants"/> is equal to <see cref="Variants.None"/>.</exception>
        T Generate(Random random, Variants variants);
    }
}

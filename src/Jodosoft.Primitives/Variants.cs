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

namespace Jodosoft.Primitives
{
    /// <summary>
    /// Specifies categories for the random generation of objects. The exact definition
    /// of each category is left to the implementor.
    /// 
    /// <seealso cref="IVariantRandom{T}"/>
    /// </summary>
    [Flags]
    public enum Variants : byte
    {
        /// <summary>
        /// Does not specify a category for random generation. The behavior of implementations is undefined.
        /// </summary>
        None = 0,

        /// <summary>
        /// Includes null, zero, and any other default state for a given object.
        /// </summary>
        Defaults = 1,

        /// <summary>
        /// Includes small values and values with reduced significance.
        /// </summary>
        LowMagnitude = 2,

        /// <summary>
        /// Includes any value from the set of all possible values, excluding errors.
        /// </summary>
        AnyMagnitude = 4,

        /// <summary>
        /// Includes minimum and maximum values.
        /// </summary>
        Boundaries = 8,

        /// <summary>
        /// Includes values that are typical of error scenarios, or values intended to elicit errors.
        /// </summary>
        Errors = 16,

        /// <summary>
        /// Encompasses all variants.
        /// </summary>
        All = Defaults | LowMagnitude | AnyMagnitude | Boundaries | Errors,

        /// <summary>
        /// Encompasses all variants, except for errors.
        /// </summary>
        NonError = Defaults | LowMagnitude | AnyMagnitude | Boundaries,
    }
}

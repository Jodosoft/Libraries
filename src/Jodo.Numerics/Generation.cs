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

namespace Jodo.Numerics
{
    /// <summary>
    /// Specifies how numbers should be randomly generated.
    /// </summary>
    public enum Generation : byte
    {
        /// <summary>
        /// Numbers will be generated according the conventions established by <see cref="System.Random"/>:
        /// <list type="bullet">
        ///     <item><description>Lower bounds are inclusive and upper bounds are exclusive.</description></item>
        ///     <item><description>An <see cref="System.ArgumentOutOfRangeException"/> is thrown if the lower bound is greater than the upper bound.</description></item>
        ///     <item><description>If no lower bound is specified then values returned are greater than or equal to zero.</description></item>
        ///     <item><description>If no upper bound is specified then values returned are less than the <c>MaxValue</c> constant for integral types, otherwise less than one.</description></item>
        ///     <item><description>If the bounds are equal then the lower bound is returned.</description></item>
        /// </list>
        /// </summary>
        Default = 0,

        /// <summary>
        /// Numbers will be generated with extended bounds: 
        /// <list type="bullet">
        ///     <item><description>Both upper and lower bounds are inclusive.</description></item>
        ///     <item><description>The upper and lower bounds will be swapped if specified in reverse order.</description></item>
        ///     <item><description>If no lower bound is specified then values returned are greater than or equal to the <c>MinValue</c> constant.</description></item>
        ///     <item><description>If no upper bound is specified then values returned are less than or equal to the <c>MaxValue</c> constant.</description></item>
        ///     <item><description>If the bounds are equal then the lower bound is returned.</description></item>
        /// </list>
        /// </summary>
        Extended = 1
    }
}

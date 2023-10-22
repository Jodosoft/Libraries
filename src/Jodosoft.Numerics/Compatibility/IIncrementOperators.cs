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

using System.Diagnostics.CodeAnalysis;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines a mechanism for incrementing a given value.</summary>
    /// <typeparam name="TSelf">The type that implements this interface.</typeparam>
    [SuppressMessage("csharpsquid", "S3246:Generic type parameters should be co/contravariant when possible.", Justification = "Maintaining similarity with the .NET 7 API .")]
    public interface IIncrementOperators<TSelf>
        where TSelf : IIncrementOperators<TSelf>?, new()
    {
        /// <summary>Increments a value.</summary>
        /// <param name="value">The value to Increment.</param>
        /// <returns>The result of Incrementing <paramref name="value" />.</returns>
        TSelf Increment(TSelf value);
    }
}

#endif

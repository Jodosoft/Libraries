﻿// Copyright (c) 2023 Joe Lawry-Short
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
    /// <summary>Defines a mechanism for computing the sum of two values.</summary>
    /// <typeparam name="TSelf">The type that implements this interface.</typeparam>
    /// <typeparam name="TOther">The type that will be added to <typeparamref name="TSelf" />.</typeparam>
    /// <typeparam name="TResult">The type that contains the sum of <typeparamref name="TSelf" /> and <typeparamref name="TOther" />.</typeparam>
    [SuppressMessage("csharpsquid", "S3246:Generic type parameters should be co/contravariant when possible.", Justification = "Maintaining similarity with the .NET 7 API .")]
    [SuppressMessage("csharpsquid", "S2436:Types and methods should not have too many generic parameters.", Justification = "Maintaining similarity with the .NET 7 API .")]
    public interface IAdditionOperators<TSelf, TOther, TResult>
        where TSelf : IAdditionOperators<TSelf, TOther, TResult>?, new()
    {
        /// <summary>Adds two values together to compute their sum.</summary>
        /// <param name="left">The value to which <paramref name="right" /> is added.</param>
        /// <param name="right">The value which is added to <paramref name="left" />.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        TResult Add(TSelf? left, TOther? right);
    }
}

#endif

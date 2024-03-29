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

using System;
using System.Diagnostics.CodeAnalysis;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// An extended version of <see cref="INumeric{TNumeric}"/> that supports non-CLS-compliant
    /// operations such as conversion to unsigned numbers.
    /// </summary>
    /// <typeparam name="TSelf">The type that implements <see cref="INumericExtended{TNumeric}"/></typeparam>
    [CLSCompliant(false)]
    [SuppressMessage("csharpsquid", "S3444:Interfaces should not simply inherit from base interfaces with colliding members", Justification = "By design - IProvider instances are accessed via static classes")]
    public interface INumericExtended<TSelf> :
            INumeric<TSelf>,
            IConvertible,
            IProvider<IConvertExtended<TSelf>>
        where TSelf : struct, INumericExtended<TSelf>
    {
    }
}

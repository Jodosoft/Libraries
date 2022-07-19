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
using Jodo.Numerics;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public class AssemblyFixtureBase : GlobalFixtureBase
    {
        [SetUp]
        public void AssemblySetUp()
        {
        }

        public static AARectangle<N> GenerateAARectangle<N>() where N : struct, INumeric<N>
        {
            N minOrigin = Numeric<N>.IsSigned ? ConvertN.ToNumeric<N>(-10) : Numeric<N>.Zero;
            N maxOrigin = ConvertN.ToNumeric<N>(10);
            N minDimension = Numeric<N>.IsSigned ? ConvertN.ToNumeric<N>(-10) : Numeric<N>.Zero;
            N maxDimension = ConvertN.ToNumeric<N>(10);
            return new AARectangle<N>(
                new Vector2<N>(
                    Random.NextNumeric(minOrigin, maxOrigin),
                    Random.NextNumeric(minOrigin, maxOrigin)),
                new Vector2<N>(
                    Random.NextNumeric(minDimension, maxDimension),
                    Random.NextNumeric(minDimension, maxDimension)));
        }
    }
}

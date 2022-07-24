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
using FluentAssertions;
using Jodo.Primitives;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class BitConvertTests<TNumeric> : Primitives.Tests.BitConvertTests<TNumeric> where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void GetBytes_RandomSmallValue_SameAsOriginal()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>());

            //act
            TNumeric result = BitConvert.FromBytes<TNumeric>(BitConvert.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_MaxValueRoundTrip_SameAsOriginal()
        {
            //arrange
            TNumeric input = Numeric.MaxValue<TNumeric>();

            //act
            TNumeric result = BitConvert.FromBytes<TNumeric>(BitConvert.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_MinValueRoundTrip_SameAsOriginal()
        {
            //arrange
            TNumeric input = Numeric.MinValue<TNumeric>();

            //act
            TNumeric result = BitConvert.FromBytes<TNumeric>(BitConvert.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_EpsilonRoundTrip_SameAsOriginal()
        {
            //arrange
            TNumeric input = Numeric.Epsilon<TNumeric>();

            //act
            TNumeric result = BitConvert.FromBytes<TNumeric>(BitConvert.GetBytes(input));

            //assert
            result.Should().Be(input);
        }
    }
}

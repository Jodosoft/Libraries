﻿// Copyright (c) 2022 Joseph J. Short
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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericFloatingPointTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.HasFloatingPoint<TNumeric>());

        [Test, Repeat(RandomVariations)]
        public void Round1_RandomFloatingPoint_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Round(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Round(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round2_RandomFloatingPoint_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10);
            int digits = Random.NextInt32(0, 2);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Round(randomValue, digits), Conversion.Cast);

            //act
            TNumeric result = MathN.Round(input, digits);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round3_RandomFloatingPoint_SameValue()
        {
            //arrange
            double randomValue = Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Round(randomValue, mode), Conversion.Cast);

            //act
            TNumeric result = MathN.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round4_RandomFloatingPoint_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10);
            int digits = Random.NextInt32(0, 2);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Round(randomValue, digits, mode), Conversion.Cast);

            //act
            TNumeric result = MathN.Round(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }
    }
}
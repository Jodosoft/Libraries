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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class MathErrorTests
    {
        public abstract class General<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
        }

        public abstract class SignedIntegral<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>() && Numeric.IsSigned<TNumeric>());

            [Test]
            public void Abs_MinValue_ThrowsOverflowException()
            {
                //arrange
                TNumeric input = Numeric.MinValue<TNumeric>();

                //act
                Action action = new Action(() => MathN.Abs(input));

                //assert
                action.Should().Throw<OverflowException>();
            }
        }

        public abstract class NaN<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.HasNaN<TNumeric>());

            [Test]
            public void Sign_NaN_ThrowsArithmeticException()
            {
                //arrange
                TNumeric input = ConvertN.ToNumeric<TNumeric>(float.NaN, Conversion.Cast);

                //act
                Action action = new Action(() => MathN.Sign(input));

                //assert
                action.Should().Throw<ArithmeticException>();
            }

            [Test]
            public void Acos_ValueOutOfRange_ReturnsNaNOrZero()
            {
                //arrange
                TNumeric input;
                do { input = Random.NextNumeric<TNumeric>(); }
                while (input.IsGreaterThanOrEqualTo(Numeric.MinUnit<TNumeric>()) && input.IsLessThanOrEqualTo(Numeric.MaxUnit<TNumeric>()));

                //act
                TNumeric result = MathN.Acos(input);

                //assert
                Numeric.IsNaN(result).Should().BeTrue();
            }
        }
    }
}

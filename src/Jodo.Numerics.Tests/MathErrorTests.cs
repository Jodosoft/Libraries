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
        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
        }

        public abstract class SignedIntegral<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.IsReal && Numeric<N>.IsSigned);

            [Test]
            public void Abs_MinValue_ThrowsOverflowException()
            {
                //arrange
                N input = Numeric<N>.MinValue;

                //act
                Action action = new Action(() => Math<N>.Abs(input));

                //assert
                action.Should().Throw<OverflowException>();
            }
        }

        public abstract class NaN<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.HasNaN);

            [Test]
            public void Sign_NaN_ThrowsArithmeticException()
            {
                //arrange
                N input = Cast<N>.ToNumeric(float.NaN);

                //act
                Action action = new Action(() => Math<N>.Sign(input));

                //assert
                action.Should().Throw<ArithmeticException>();
            }

            [Test]
            public void Acos_ValueOutOfRange_ReturnsNaNOrZero()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(); }
                while (input.IsGreaterThanOrEqualTo(Numeric<N>.MinUnit) && input.IsLessThanOrEqualTo(Numeric<N>.MaxUnit));

                //act
                N result = Math<N>.Acos(input);

                //assert
                Numeric<N>.IsNaN(result).Should().BeTrue();
            }
        }
    }
}

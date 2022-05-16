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

using FluentAssertions;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class ConstantsTestsBase<T> : GlobalTestBase where T : struct, INumeric<T>
    {
        [Test]
        public void Epsilon_LessThanOrEqualToOne()
        {
            Constants<T>.Epsilon.Should().BeLessThanOrEqualTo(Constants<T>.One);
        }

        [Test]
        public void MaxUnit_LessThanMaxValue()
        {
            Constants<T>.MaxUnit.Should().BeLessThan(Constants<T>.MaxValue);
        }

        [Test]
        public void MaxUnit_AsDouble_IsOne()
        {
            Constants<T>.MaxUnit.ToDouble().Should().Be(1);
        }

        [Test]
        public void MinUnit_LessThanMaxUnit()
        {
            Constants<T>.MinUnit.Should().BeLessThan(Constants<T>.MaxUnit);
        }

        [Test]
        public void MinUnit_Unsigned_IsZero()
        {
            if (Constants<T>.IsSigned) Assert.Inconclusive();
            Constants<T>.MinUnit.Should().Be(Constants<T>.Zero);
        }

        [Test]
        public void MinUnit_SignedAsDouble_IsMinusOne()
        {
            if (!Constants<T>.IsSigned) Assert.Inconclusive();
            Constants<T>.MinUnit.ToDouble().Should().Be(-1);
        }

        [Test]
        public void MinValue_Unsigned_IsZero()
        {
            if (Constants<T>.IsSigned) Assert.Inconclusive();
            Constants<T>.MinValue.Should().Be(Constants<T>.Zero);
        }

        [Test]
        public void One_AsDouble_IsOne()
        {
            Constants<T>.One.ToDouble().Should().Be(1);
        }

        [Test]
        public void Zero_LessThanEpsilon()
        {
            Constants<T>.Zero.Should().BeLessThan(Constants<T>.Epsilon);
        }

        [Test]
        public void Zero_AsDouble_IsZero()
        {
            Constants<T>.Zero.ToDouble().Should().Be(0);
        }

        [Test]
        public void Epsilon_IntegralAsDouble_IsOne()
        {
            if (Constants<T>.IsReal) Assert.Inconclusive();
            Constants<T>.Epsilon.ToDouble().Should().Be(1);
        }

        [Test]
        public void Epsilon_RealAsDouble_GreaterThanZero()
        {
            if (!Constants<T>.IsReal) Assert.Inconclusive();
            Constants<T>.Epsilon.ToDouble().Should().BeGreaterThan(0);
        }

        [Test]
        public void Epsilon_RealAsDouble_LessThanOne()
        {
            if (!Constants<T>.IsReal) Assert.Inconclusive();
            Constants<T>.Epsilon.ToDouble().Should().BeLessThan(1);
        }

        [Test]
        public void Epsilon_RealAsDouble_ApproximatelyZero()
        {
            if (!Constants<T>.IsReal) Assert.Inconclusive();
            Constants<T>.Epsilon.ToDouble().Should().BeApproximately(0, 0.0001);
        }
    }
}

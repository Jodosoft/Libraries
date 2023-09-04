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

using System;
using FluentAssertions;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public abstract class UnitNTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test]
        public void Zero_ValueEqualToNumericZero()
        {
            //arrange
            TNumeric expected = Numeric.Zero<TNumeric>();

            //act
            TNumeric result = UnitN.Zero<TNumeric>();

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void MaxValue_ValueEqualToNumericMaxUnit()
        {
            //arrange
            TNumeric expected = Numeric.MaxUnit<TNumeric>();

            //act
            TNumeric result = UnitN.MaxValue<TNumeric>();

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void MinValue_ValueEqualToNumericMaxUnit()
        {
            //arrange
            TNumeric expected = Numeric.MinUnit<TNumeric>();

            //act
            TNumeric result = UnitN.MinValue<TNumeric>();

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Ctor_ValueGreaterThanMaxUnit_ReturnsMaxUnit()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.MaxUnit<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended);

            //act
            UnitN<TNumeric> result = new UnitN<TNumeric>(input);

            //assert
            result.Value.Should().Be(Numeric.MaxUnit<TNumeric>());
        }

        [Test]
        public void Ctor_ValueGreaterThanMaxUnit_ReturnsMinUnit()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.MinValue<TNumeric>(), Numeric.MinUnit<TNumeric>(), Generation.Extended);

            //act
            UnitN<TNumeric> result = new UnitN<TNumeric>(input);

            //assert
            result.Value.Should().Be(Numeric.MinUnit<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void CompareTo1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.CompareTo(right.Value), () => left.CompareTo(right));
        }

        [Test, Repeat(RandomVariations)]
        public void CompareTo2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.CompareTo((object)right.Value), () => left.CompareTo((object)right));
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomValue_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(left.Value.ToString, left.ToString);
        }

        [Test, Repeat(RandomVariations)]
        public void GetHashCode_RandomValue_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(left.Value.GetHashCode, left.GetHashCode);
        }

        [Test, Repeat(RandomVariations)]
        public void Equals1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Equals(right.Value), () => left == right);
        }

        [Test, Repeat(RandomVariations)]
        public void Equals2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Equals(right.Value), () => left.Equals(right));
        }

        [Test, Repeat(RandomVariations)]
        public void NotEquals_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => !left.Value.Equals(right.Value), () => left != right);
        }

        [Test, Repeat(RandomVariations)]
        public void Add1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Add(right.Value), () => left + right);
        }

        [Test, Repeat(RandomVariations)]
        public void Add2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Add(right), () => left + right);
        }

        [Test, Repeat(RandomVariations)]
        public void Add3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Add(right.Value), () => left + right);
        }

        [Test, Repeat(RandomVariations)]
        public void Divide1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Divide(right.Value), () => left / right);
        }

        [Test, Repeat(RandomVariations)]
        public void Divide2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Divide(right), () => left / right);
        }

        [Test, Repeat(RandomVariations)]
        public void Divide3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Divide(right.Value), () => left / right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThan1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsGreaterThan(right.Value), () => left > right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThan2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsGreaterThan(right), () => left > right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThan3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.IsGreaterThan(right.Value), () => left > right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualTo1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsGreaterThanOrEqualTo(right.Value), () => left >= right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualTo2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsGreaterThanOrEqualTo(right), () => left >= right);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualTo3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.IsGreaterThanOrEqualTo(right.Value), () => left >= right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThan1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsLessThan(right.Value), () => left < right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThan2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsLessThan(right), () => left < right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThan3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.IsLessThan(right), () => left < right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThanOrEqualTo1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsLessThanOrEqualTo(right.Value), () => left <= right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThanOrEqualTo2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.IsLessThanOrEqualTo(right), () => left <= right);
        }

        [Test, Repeat(RandomVariations)]
        public void IsLessThanOrEqualTo3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.IsLessThanOrEqualTo(right.Value), () => left <= right);
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Multiply(right.Value), () => left * right);
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Multiply(right), () => left * right);
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Multiply(right.Value), () => left * right);
        }

        [Test, Repeat(RandomVariations)]
        public void Negative_RandomValue_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(left.Value.Negative, () => -left);
        }

        [Test, Repeat(RandomVariations)]
        public void Positive_RandomValue_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(left.Value.Positive, () => +left);
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Remainder(right.Value), () => left % right);
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Remainder(right), () => left % right);
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Remainder(right.Value), () => left % right);
        }

        [Test, Repeat(RandomVariations)]
        public void Subtract1_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Subtract(right.Value), () => left - right);
        }

        [Test, Repeat(RandomVariations)]
        public void Subtract2_RandomValues_SameAsNumeric()
        {
            //arrange
            UnitN<TNumeric> left = Random.NextUnit<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(() => left.Value.Subtract(right), () => left - right);
        }

        [Test, Repeat(RandomVariations)]
        public void Subtract3_RandomValues_SameAsNumeric()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            UnitN<TNumeric> right = Random.NextUnit<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(() => left.Subtract(right.Value), () => left - right);
        }
    }
}

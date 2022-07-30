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
    public static class UnitTests
    {
        public sealed class FixedPoint : General<Fix64> { }
        public sealed class FloatingPoint : General<SingleN> { }
        public sealed class UnsignedIntegral : General<ByteN> { }

        public abstract class General<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            public sealed class BitConvertTests : Primitives.Tests.BitConvertTests<Unit<TNumeric>> { }
            public sealed class StringParserTests : Primitives.Tests.StringParserTests<Unit<TNumeric>> { }
            public sealed class SerializableTests : Primitives.Tests.SerializableTests<Unit<TNumeric>> { }
            public sealed class ObjectTests : Primitives.Tests.ObjectTests<Unit<TNumeric>> { }
            public sealed class RandomTests : Primitives.Tests.RandomTests<Unit<TNumeric>> { }

            [Test]
            public void Zero_ValueEqualToNumericZero()
            {
                //arrange
                TNumeric expected = Numeric.Zero<TNumeric>();

                //act
                TNumeric result = Unit.Zero<TNumeric>();

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void MaxValue_ValueEqualToNumericMaxUnit()
            {
                //arrange
                TNumeric expected = Numeric.MaxUnit<TNumeric>();

                //act
                TNumeric result = Unit.MaxValue<TNumeric>();

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void MinValue_ValueEqualToNumericMaxUnit()
            {
                //arrange
                TNumeric expected = Numeric.MinUnit<TNumeric>();

                //act
                TNumeric result = Unit.MinValue<TNumeric>();

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ctor_ValueGreaterThanMaxUnit_ReturnsMaxUnit()
            {
                //arrange
                TNumeric input = Random.NextNumeric(Numeric.MaxUnit<TNumeric>(), Numeric.MaxValue<TNumeric>());

                //act
                Unit<TNumeric> result = new Unit<TNumeric>(input);

                //assert
                result.Value.Should().Be(Numeric.MaxUnit<TNumeric>());
            }

            [Test]
            public void Ctor_ValueGreaterThanMaxUnit_ReturnsMinUnit()
            {
                //arrange
                TNumeric input = Random.NextNumeric(Numeric.MinValue<TNumeric>(), Numeric.MinUnit<TNumeric>());

                //act
                Unit<TNumeric> result = new Unit<TNumeric>(input);

                //assert
                result.Value.Should().Be(Numeric.MinUnit<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left.CompareTo(right), () => left.Value.CompareTo(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left.CompareTo((object)right), () => left.Value.CompareTo((object)right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void ToString_RandomValue_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left.ToString(), () => left.Value.ToString());
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_RandomValue_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left.GetHashCode(), () => left.Value.GetHashCode());
            }

            [Test, Repeat(RandomVariations)]
            public void Equals1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left == right, () => left.Value.Equals(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Equals2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left.Equals(right), () => left.Value.Equals(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void NotEquals_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left != right, () => !left.Value.Equals(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Add1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left + right, () => left.Value.Add(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Add2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left + right, () => left.Value.Add(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Add3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left + right, () => left.Add(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Divide1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left / right, () => left.Value.Divide(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Divide2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left / right, () => left.Value.Divide(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Divide3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left / right, () => left.Divide(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left > right, () => left.Value.IsGreaterThan(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left > right, () => left.Value.IsGreaterThan(right));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left > right, () => left.IsGreaterThan(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left >= right, () => left.Value.IsGreaterThanOrEqualTo(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left >= right, () => left.Value.IsGreaterThanOrEqualTo(right));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left >= right, () => left.IsGreaterThanOrEqualTo(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThan1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left < right, () => left.Value.IsLessThan(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThan2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left < right, () => left.Value.IsLessThan(right));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThan3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left < right, () => left.IsLessThan(right));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThanOrEqualTo1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left <= right, () => left.Value.IsLessThanOrEqualTo(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThanOrEqualTo2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left <= right, () => left.Value.IsLessThanOrEqualTo(right));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThanOrEqualTo3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left <= right, () => left.IsLessThanOrEqualTo(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left * right, () => left.Value.Multiply(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left * right, () => left.Value.Multiply(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left * right, () => left.Multiply(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_RandomValue_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => -left, () => left.Value.Negative());
            }

            [Test, Repeat(RandomVariations)]
            public void Positive_RandomValue_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => +left, () => left.Value.Positive());
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left % right, () => left.Value.Remainder(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left % right, () => left.Value.Remainder(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left % right, () => left.Remainder(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Subtract1_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left - right, () => left.Value.Subtract(right.Value));
            }

            [Test, Repeat(RandomVariations)]
            public void Subtract2_RandomValues_SameAsNumeric()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left - right, () => left.Value.Subtract(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Subtract3_RandomValues_SameAsNumeric()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left - right, () => left.Subtract(right.Value));
            }
        }
    }
}

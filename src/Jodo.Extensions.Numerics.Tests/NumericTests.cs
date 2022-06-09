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
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class NumericTests
    {
        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [Test]
            public void Epsilon_LessThanOrEqualToOne()
            {
                Numeric<N>.Epsilon.Should().BeLessThanOrEqualTo(Numeric<N>.One);
            }

            [Test]
            public void Epsilon_GreaterThanZero()
            {
                (Numeric<N>.Epsilon > Numeric<N>.Zero).Should().BeTrue();
            }

            [Test]
            public void MaxUnit_LessThanMaxValue()
            {
                Numeric<N>.MaxUnit.Should().BeLessThan(Numeric<N>.MaxValue);
            }

            [Test]
            public void MaxUnit_IsOne()
            {
                Convert<N>.ToDouble(Numeric<N>.MaxUnit).Should().Be(1);
            }

            [Test]
            public void MinUnit_LessThanMaxUnit()
            {
                Numeric<N>.MinUnit.Should().BeLessThan(Numeric<N>.MaxUnit);
            }

            [Test]
            public void MaxValue_IsPositive()
            {
                Convert<N>.ToDouble(Numeric<N>.MaxValue).Should().BeGreaterThanOrEqualTo(sbyte.MaxValue);
            }

            [Test]
            public void One_IsOne()
            {
                Convert<N>.ToDouble(Numeric<N>.One).Should().Be(1);
            }

            [Test]
            public void Ten_IsTen()
            {
                Convert<N>.ToDouble(Numeric<N>.Ten).Should().Be(10);
            }

            [Test]
            public void Two_IsTwo()
            {
                Convert<N>.ToDouble(Numeric<N>.Two).Should().Be(2);
            }

            [Test]
            public void Zero_LessThanEpsilon()
            {
                Numeric<N>.Zero.Should().BeLessThan(Numeric<N>.Epsilon);
            }

            [Test]
            public void Zero_IsZero()
            {
                Convert<N>.ToDouble(Numeric<N>.Zero).Should().Be(0);
            }

            [Test, Repeat(RandomVariations)]
            public void Add_RandomValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left + right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToDouble(left) + Cast<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void AddSubtract_Random_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left + right - right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToDouble(left));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left * right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToDouble(left) * Cast<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Positive_RandomValue_ReturnsSameValue()
            {
                //arrange
                var input = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = +input;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_Zero_ReturnsZero()
            {
                //arrange
                var input = Numeric<N>.Zero;

                //act
                var result = -input;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByZero_ReturnsZero()
            {
                //arrange
                var input = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = input * Numeric<N>.Zero;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByOne_ReturnSameValue()
            {
                //arrange
                var input = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = input * Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByOne_ReturnsSameValue()
            {
                //arrange
                var input = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = input / Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByItself_ReturnsOne()
            {
                //arrange
                var input = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = input / Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValues_CorrectResult()
            {
                //arrange
                var randomValue1 = Random.NextDouble(1, 10);
                var randomValue2 = Random.NextDouble(1, randomValue1);
                if (!Numeric<N>.IsReal)
                {
                    randomValue1 = Math.Truncate(randomValue1);
                    randomValue2 = Math.Truncate(randomValue2);
                }
                if (Numeric<N>.IsSigned)
                {
                    if (Random.NextBoolean()) randomValue1 = -randomValue1;
                    if (Random.NextBoolean()) randomValue2 = -randomValue2;
                }
                var left = Cast<N>.ToNumeric(randomValue1);
                var right = Cast<N>.ToNumeric(randomValue2);
                var expected = Cast<N>.ToNumeric(randomValue1 / randomValue2);

                //act
                var result = left / right;

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Cast<N>.ToNumeric(left);
                var rightN = Cast<N>.ToNumeric(right);

                //act
                var result = leftN > rightN;

                //assert
                result.Should().Be(left > right);
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Cast<N>.ToNumeric(left);
                var rightN = Cast<N>.ToNumeric(right);

                //act
                var result = leftN >= rightN;

                //assert
                result.Should().Be(left >= right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThan_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Cast<N>.ToNumeric(left);
                var rightN = Cast<N>.ToNumeric(right);

                //act
                var result = leftN < rightN;

                //assert
                result.Should().Be(left < right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Cast<N>.ToNumeric(left);
                var rightN = Cast<N>.ToNumeric(right);

                //act
                var result = leftN <= rightN;

                //assert
                result.Should().Be(left <= right);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByOne_ReturnsZero()
            {
                //arrange
                var input = Math<N>.Truncate(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)));

                //act
                var result = input % Numeric<N>.One;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByItself_ReturnsZero()
            {
                //arrange
                var input = Math<N>.Truncate(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)));

                //act
                var result = input % Numeric<N>.One;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValues_CorrectResult()
            {
                //arrange
                var left = Math<N>.Truncate(Clamp<N>.ToNumeric(Random.Next(-10, 10)));
                var right = Math<N>.Truncate(Clamp<N>.ToNumeric(Random.Next(1, 10)));

                //act
                var result = left % right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToDouble(left) % Cast<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Equals1_RandomValues_SameAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToNumeric(input1);
                var sut2 = Convert<N>.ToNumeric(input2);

                //act
                var result = sut1.Equals(sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(RandomVariations)]
            public void Equals2_RandomValues_SameAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToNumeric(input1);
                var sut2 = Convert<N>.ToNumeric(input2);

                //act
                var result = sut1.Equals((object)sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_RandomValues_SameSignAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToNumeric(input1);
                var sut2 = Convert<N>.ToNumeric(input2);

                //act
                var result = Math.Sign(sut1.CompareTo(sut2));

                //assert
                result.Should().Be(Math.Sign(input1.CompareTo(input2)));
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_NullNullable_Returns1()
            {
                //arrange
                var input = Random.NextNumeric<N>();
                var other = (N?)null;

                //act
                var result = input.CompareTo(other);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_DifferentType_Returns1()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = input.CompareTo(this);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_SameValue_SameResult()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result1 = input.GetHashCode();
                var result2 = input.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_EqualValues_SameResult()
            {
                //arrange
                var input = Random.NextByte(0, 127);
                var sut1 = Convert<N>.ToNumeric(input);
                var sut2 = Convert<N>.ToNumeric(input);

                //act
                var result1 = sut1.GetHashCode();
                var result2 = sut2.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_DifferentSmallValues_DifferentResult()
            {
                //arrange
                var input1 = Random.NextByte(0, 127);
                byte input2;
                do { input2 = Random.NextByte(0, 127); ; } while (input2 == input1);
                var sut1 = Convert<N>.ToNumeric(input1);
                var sut2 = Convert<N>.ToNumeric(input2);

                //act
                var result1 = sut1.GetHashCode();
                var result2 = sut2.GetHashCode();

                //assert
                result1.Should().NotBe(result2);
            }

            [Test, Repeat(RandomVariations)]
            public void Serialize_RoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Random.NextNumeric<N>();
                var formatter = new BinaryFormatter();

                //act
#pragma warning disable SYSLIB0011
                using var stream = new MemoryStream();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                var result = (N)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

                //assert
                result.Should().Be(input);
            }
        }

        public abstract class Infinity<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.HasInfinity);

            [TestCase(double.PositiveInfinity, false)]
            [TestCase(double.NegativeInfinity, false)]
            [TestCase(double.NaN, false)]
            [TestCase(0, true)]
            public void IsFinite_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                var input = Cast<N>.ToNumeric(value);

                //act
                var result = Numeric<N>.IsFinite(input);

                //assert
                result.Should().Be(expected);
            }

            [TestCase(double.PositiveInfinity, true)]
            [TestCase(double.NegativeInfinity, true)]
            [TestCase(double.NaN, false)]
            [TestCase(0, false)]
            public void IsInfinity_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                var input = Cast<N>.ToNumeric(value);

                //act
                var result = Numeric<N>.IsInfinity(input);

                //assert
                result.Should().Be(expected);
            }

            [TestCase(double.PositiveInfinity, true)]
            [TestCase(double.NegativeInfinity, false)]
            [TestCase(double.NaN, false)]
            [TestCase(0, false)]
            public void IsPositiveInfinity_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                var input = Cast<N>.ToNumeric(value);

                //act
                var result = Numeric<N>.IsPositiveInfinity(input);

                //assert
                result.Should().Be(expected);
            }

            [TestCase(double.PositiveInfinity, false)]
            [TestCase(double.NegativeInfinity, true)]
            [TestCase(double.NaN, false)]
            [TestCase(0, false)]
            public void IsNegativeInfinity_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                var input = Cast<N>.ToNumeric(value);

                //act
                var result = Numeric<N>.IsNegativeInfinity(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class NaN<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.HasNaN);

            [TestCase(double.PositiveInfinity, false)]
            [TestCase(double.NegativeInfinity, false)]
            [TestCase(double.NaN, true)]
            [TestCase(0, false)]
            public void IsNaN_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                var input = Cast<N>.ToNumeric(value);

                //act
                var result = Numeric<N>.IsNaN(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.IsReal);

            [Test]
            public void Epsilon_IsOne()
            {
                Numeric<N>.Epsilon.Should().Be(Numeric<N>.One);
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomIntegralValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left & right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToInt32(left) & Cast<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left | right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToInt32(left) | Cast<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Clamp<N>.ToNumeric(Random.Next(-10, 10));

                //act
                var result = left ^ right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToInt32(left) ^ Cast<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_IntegralRoundTrip_SameValue()
            {
                //arrange
                var left = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = ~~left;

                //assert
                result.Should().Be(left);
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomIntegral_DifferentValue()
            {
                //arrange
                var left = Math<N>.Round(Clamp<N>.ToNumeric(Random.NextDouble(-10, 10)), 2);

                //act
                var result = ~left;

                //assert
                result.Should().NotBe(left);
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomIntegralValues_CorrectResult()
            {
                //arrange
                var left = Clamp<N>.ToNumeric(Random.Next(-10, 10));
                var right = Random.NextInt32(0, 2);

                //act
                var result = left << right;

                //assert
                result.Should().BeApproximately(Cast<N>.ToInt32(left) << right);
            }
        }

        public abstract class Real<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsReal);

            [Test]
            public void Epsilon_LessThanOne()
            {
                (Numeric<N>.Epsilon < Numeric<N>.One).Should().BeTrue();
            }

            [Test]
            public void Epsilon_ApproximatelyZero()
            {
                Convert<N>.ToDouble(Numeric<N>.Epsilon).Should().BeApproximately(0, 0.001);
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomValues_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();
                var right = Random.NextNumeric<N>();

                //act
                var action = new Func<N>(() => left & right);

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomValues_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();
                var right = Random.NextNumeric<N>();

                //act
                var action = new Func<N>(() => left | right);

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomValues_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();
                var right = Random.NextNumeric<N>();

                //act
                var action = new Func<N>(() => left ^ right);

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomValue_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();

                //act
                var action = new Func<N>(() => ~left);

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomValues_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();
                var right = Random.NextInt32(0, 2);

                //act
                var action = new Func<N>(() => left << right);

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void RightShift_RandomValue_DoesntThrow()
            {
                //arrange
                var left = Random.NextNumeric<N>();
                var right = Random.NextInt32(0, 2);

                //act
                var action = new Func<N>(() => left >> right);

                //assert
                action.Should().NotThrow();
            }
        }

        public abstract class Signed<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsSigned);

            [Test]
            public void MinUnit_IsMinusOne()
            {
                Convert<N>.ToDouble(Numeric<N>.MinUnit).Should().Be(-1);
            }

            [Test]
            public void MinValue_IsLessThanMinUnit()
            {
                (Numeric<N>.MinValue < Numeric<N>.MinUnit).Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_RandomNegativeValue_ReturnsPositive()
            {
                //arrange
                var input = Random.NextSByte(-127, -1);
                var inputN = Cast<N>.ToNumeric(input);

                //act
                var result = -inputN;

                //assert
                result.Should().Be(Cast<N>.ToNumeric(input * -1));
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegative_RandomValue_ReturnsCorrectResult()
            {
                //arrange
                var input = Random.NextNumeric<N>();
                var expected = input < Numeric<N>.Zero;

                //act
                var result = Numeric<N>.IsNegative(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Unsigned<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.IsSigned);

            [Test]
            public void MinUnit_Unsigned_IsZero()
            {
                Numeric<N>.MinUnit.Should().Be(Numeric<N>.Zero);
            }

            [Test]
            public void MinValue_Unsigned_IsZero()
            {
                Numeric<N>.MinValue.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegative_RandomValue_AlwaysFalse()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNegative(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoFloatingPoint<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.HasFloatingPoint);

            [Test, Repeat(RandomVariations)]
            public void IsNormal_RandomValue_AlwaysFalse()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNormal(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsSubnormal_RandomIntegral_AlwaysFalse()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsSubnormal(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoInfinity<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.HasInfinity);

            [Test, Repeat(RandomVariations)]
            public void IsFinite_RandomValue_AlwaysTrue()
            {
                //arrange
                var bytes = BitConverter<N>.GetBytes(default).ToArray();
                Random.NextBytes(bytes);
                var input = BitConverter<N>.FromBytes(bytes.AsSpan());

                //act
                var result = Numeric<N>.IsFinite(input);

                //assert
                result.Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void IsInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                var bytes = BitConverter<N>.GetBytes(default).ToArray();
                Random.NextBytes(bytes);
                var input = BitConverter<N>.FromBytes(bytes.AsSpan());

                //act
                var result = Numeric<N>.IsInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsPositiveInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                var bytes = BitConverter<N>.GetBytes(default).ToArray();
                Random.NextBytes(bytes);
                var input = BitConverter<N>.FromBytes(bytes.AsSpan());

                //act
                var result = Numeric<N>.IsPositiveInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegativeInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                var bytes = BitConverter<N>.GetBytes(default).ToArray();
                Random.NextBytes(bytes);
                var input = BitConverter<N>.FromBytes(bytes.AsSpan());

                //act
                var result = Numeric<N>.IsNegativeInfinity(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoNaN<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.HasNaN);

            [Test, Repeat(RandomVariations)]
            public void IsNaN_RandomValue_AlwaysFalse()
            {
                //arrange
                var bytes = BitConverter<N>.GetBytes(default).ToArray();
                Random.NextBytes(bytes);
                var input = BitConverter<N>.FromBytes(bytes.AsSpan());

                //act
                var result = Numeric<N>.IsNaN(input);

                //assert
                result.Should().BeFalse();
            }
        }
    }
}

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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FluentAssertions;
using Jodo.Numerics.Tests;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class NumericTests
    {
        public abstract class General<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [Test]
            public void Epsilon_LessThanOrEqualToOne()
            {
                Numeric.Epsilon<TNumeric>().Should().BeLessThanOrEqualTo(Numeric.One<TNumeric>());
            }

            [Test]
            public void Epsilon_GreaterThanZero()
            {
                Numeric.Epsilon<TNumeric>().IsGreaterThan(Numeric.Zero<TNumeric>()).Should().BeTrue();
            }

            [Test]
            public void MaxUnit_LessThanMaxValue()
            {
                Numeric.MaxUnit<TNumeric>().Should().BeLessThan(Numeric.MaxValue<TNumeric>());
            }

            [Test]
            public void MaxUnit_IsOne()
            {
                ConvertN.ToDouble(Numeric.MaxUnit<TNumeric>()).Should().Be(1);
            }

            [Test]
            public void MinUnit_LessThanMaxUnit()
            {
                Numeric.MinUnit<TNumeric>().Should().BeLessThan(Numeric.MaxUnit<TNumeric>());
            }

            [Test]
            public void MaxValue_IsPositive()
            {
                ConvertN.ToDouble(Numeric.MaxValue<TNumeric>()).Should().BeGreaterThanOrEqualTo(sbyte.MaxValue);
            }

            [Test]
            public void One_IsOne()
            {
                ConvertN.ToDouble(Numeric.One<TNumeric>()).Should().Be(1);
            }

            [Test]
            public void Ten_IsTen()
            {
                ConvertN.ToDouble(Numeric.Ten<TNumeric>()).Should().Be(10);
            }

            [Test]
            public void Two_IsTwo()
            {
                ConvertN.ToDouble(Numeric.Two<TNumeric>()).Should().Be(2);
            }

            [Test]
            public void Zero_LessThanEpsilon()
            {
                Numeric.Zero<TNumeric>().Should().BeLessThan(Numeric.Epsilon<TNumeric>());
            }

            [Test]
            public void Zero_IsZero()
            {
                ConvertN.ToDouble(Numeric.Zero<TNumeric>()).Should().Be(0);
            }

            [Test, Repeat(RandomVariations)]
            public void Add_RandomValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.Add(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToDouble(left, Conversion.Cast) + ConvertN.ToDouble(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void AddSubtract_Random_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.Add(right).Subtract(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToDouble(left, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.Multiply(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToDouble(left, Conversion.Cast) * ConvertN.ToDouble(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void Positive_RandomValue_ReturnsSameValue()
            {
                //arrange
                TNumeric input = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = input.Positive();

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_Zero_ReturnsZero()
            {
                //arrange
                TNumeric input = Numeric.Zero<TNumeric>();

                //act
                TNumeric result = input.Negative();

                //assert
                result.Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByZero_ReturnsZero()
            {
                //arrange
                TNumeric input = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = input.Multiply(Numeric.Zero<TNumeric>());

                //assert
                result.Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByOne_ReturnSameValue()
            {
                //arrange
                TNumeric input = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = input.Multiply(Numeric.One<TNumeric>());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByOne_ReturnsSameValue()
            {
                //arrange
                TNumeric input = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = input.Divide(Numeric.One<TNumeric>());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByItself_ReturnsOne()
            {
                //arrange
                TNumeric input = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = input.Divide(Numeric.One<TNumeric>());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValues_CorrectResult()
            {
                //arrange
                double randomValue1 = Random.NextDouble(1, 10);
                double randomValue2 = Random.NextDouble(1, randomValue1);
                if (Numeric.IsIntegral<TNumeric>())
                {
                    randomValue1 = Math.Truncate(randomValue1);
                    randomValue2 = Math.Truncate(randomValue2);
                }
                if (Numeric.IsSigned<TNumeric>())
                {
                    if (Random.NextBoolean()) randomValue1 = -randomValue1;
                    if (Random.NextBoolean()) randomValue2 = -randomValue2;
                }
                TNumeric left = ConvertN.ToNumeric<TNumeric>(randomValue1, Conversion.Cast);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(randomValue2, Conversion.Cast);
                TNumeric expected = ConvertN.ToNumeric<TNumeric>(randomValue1 / randomValue2, Conversion.Cast);

                //act
                TNumeric result = left.Divide(right);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan_RandomValues_SameAsSystem()
            {
                //arrange
                byte left = Random.NextByte(0, 127);
                byte right = Random.NextByte(0, 127);
                TNumeric leftN = ConvertN.ToNumeric<TNumeric>(left, Conversion.Cast);
                TNumeric rightN = ConvertN.ToNumeric<TNumeric>(right, Conversion.Cast);

                //act
                bool result = leftN.IsGreaterThan(rightN);

                //assert
                result.Should().Be(left > right);
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                byte left = Random.NextByte(0, 127);
                byte right = Random.NextByte(0, 127);
                TNumeric leftN = ConvertN.ToNumeric<TNumeric>(left, Conversion.Cast);
                TNumeric rightN = ConvertN.ToNumeric<TNumeric>(right, Conversion.Cast);

                //act
                bool result = leftN.IsGreaterThanOrEqualTo(rightN);

                //assert
                result.Should().Be(left >= right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThan_RandomValues_SameAsSystem()
            {
                //arrange
                byte left = Random.NextByte(0, 127);
                byte right = Random.NextByte(0, 127);
                TNumeric leftN = ConvertN.ToNumeric<TNumeric>(left, Conversion.Cast);
                TNumeric rightN = ConvertN.ToNumeric<TNumeric>(right, Conversion.Cast);

                //act
                bool result = leftN.IsLessThan(rightN);

                //assert
                result.Should().Be(left < right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                byte left = Random.NextByte(0, 127);
                byte right = Random.NextByte(0, 127);
                TNumeric leftN = ConvertN.ToNumeric<TNumeric>(left, Conversion.Cast);
                TNumeric rightN = ConvertN.ToNumeric<TNumeric>(right, Conversion.Cast);

                //act
                bool result = leftN.IsLessThanOrEqualTo(rightN);

                //assert
                result.Should().Be(left <= right);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByOne_ReturnsZero()
            {
                //arrange
                TNumeric input = MathN.Truncate(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp));

                //act
                TNumeric result = input.Remainder(Numeric.One<TNumeric>());

                //assert
                result.Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByItself_ReturnsZero()
            {
                //arrange
                TNumeric input = MathN.Truncate(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp));

                //act
                TNumeric result = input.Remainder(Numeric.One<TNumeric>());

                //assert
                result.Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValues_CorrectResult()
            {
                //arrange
                TNumeric left = MathN.Truncate(ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp));
                TNumeric right = MathN.Truncate(ConvertN.ToNumeric<TNumeric>(Random.Next(1, 10), Conversion.Clamp));

                //act
                TNumeric result = left.Remainder(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToDouble(left, Conversion.Cast) % ConvertN.ToDouble(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void Equals1_RandomValues_SameAsSystem()
            {
                //arrange
                byte input1 = Random.NextByte(0, 2);
                byte input2 = Random.NextByte(0, 2);
                TNumeric sut1 = ConvertN.ToNumeric<TNumeric>(input1);
                TNumeric sut2 = ConvertN.ToNumeric<TNumeric>(input2);

                //act
                bool result = sut1.Equals(sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(RandomVariations)]
            public void Equals2_RandomValues_SameAsSystem()
            {
                //arrange
                byte input1 = Random.NextByte(0, 2);
                byte input2 = Random.NextByte(0, 2);
                TNumeric sut1 = ConvertN.ToNumeric<TNumeric>(input1);
                TNumeric sut2 = ConvertN.ToNumeric<TNumeric>(input2);

                //act
                bool result = sut1.Equals((object)sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_RandomValues_SameSignAsSystem()
            {
                //arrange
                byte input1 = Random.NextByte(0, 2);
                byte input2 = Random.NextByte(0, 2);
                TNumeric sut1 = ConvertN.ToNumeric<TNumeric>(input1);
                TNumeric sut2 = ConvertN.ToNumeric<TNumeric>(input2);

                //act
                int result = Math.Sign(sut1.CompareTo(sut2));

                //assert
                result.Should().Be(Math.Sign(input1.CompareTo(input2)));
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_NullNullable_Returns1()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();
                TNumeric? other = null;

                //act
                int result = input.CompareTo(other);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(RandomVariations)]
            public void CompareTo1_DifferentType_Returns1()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                int result = input.CompareTo(this);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_SameValue_SameResult()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                int result1 = input.GetHashCode();
                int result2 = input.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_EqualValues_SameResult()
            {
                //arrange
                byte input = Random.NextByte(0, 127);
                TNumeric sut1 = ConvertN.ToNumeric<TNumeric>(input);
                TNumeric sut2 = ConvertN.ToNumeric<TNumeric>(input);

                //act
                int result1 = sut1.GetHashCode();
                int result2 = sut2.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(RandomVariations)]
            public void GetHashCode_DifferentSmallValues_DifferentResult()
            {
                //arrange
                byte input1 = Random.NextByte(0, 127);
                byte input2;
                do { input2 = Random.NextByte(0, 127); } while (input2 == input1);
                TNumeric sut1 = ConvertN.ToNumeric<TNumeric>(input1);
                TNumeric sut2 = ConvertN.ToNumeric<TNumeric>(input2);

                //act
                int result1 = sut1.GetHashCode();
                int result2 = sut2.GetHashCode();

                //assert
                result1.Should().NotBe(result2);
            }

            [Test, Repeat(RandomVariations)]
            [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
            public void Serialize_RoundTrip_SameAsOriginal()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();
                BinaryFormatter formatter = new BinaryFormatter();

                //act
                TNumeric result;
                using (MemoryStream stream = new MemoryStream())
                {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    formatter.Serialize(stream, input);
                    stream.Position = 0;
                    result = (TNumeric)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                }

                //assert
                result.Should().Be(input);
            }
        }

        public abstract class Infinity<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.HasInfinity<TNumeric>());

            [TestCase(double.PositiveInfinity, false)]
            [TestCase(double.NegativeInfinity, false)]
            [TestCase(double.NaN, false)]
            [TestCase(0, true)]
            public void IsFinite_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

                //act
                bool result = Numeric.IsFinite(input);

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
                TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

                //act
                bool result = Numeric.IsInfinity(input);

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
                TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

                //act
                bool result = Numeric.IsPositiveInfinity(input);

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
                TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

                //act
                bool result = Numeric.IsNegativeInfinity(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class NaN<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.HasNaN<TNumeric>());

            [TestCase(double.PositiveInfinity, false)]
            [TestCase(double.NegativeInfinity, false)]
            [TestCase(double.NaN, true)]
            [TestCase(0, false)]
            public void IsNaN_Examples_ReturnsExpected(double value, bool expected)
            {
                //arrange
                TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

                //act
                bool result = Numeric.IsNaN(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>());

            [Test]
            public void Epsilon_IsOne()
            {
                Numeric.Epsilon<TNumeric>().Should().Be(Numeric.One<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomIntegralValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.LogicalAnd(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) & ConvertN.ToInt32(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.LogicalOr(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) | ConvertN.ToInt32(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

                //act
                TNumeric result = left.LogicalExclusiveOr(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) ^ ConvertN.ToInt32(right, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_IntegralRoundTrip_SameValue()
            {
                //arrange
                TNumeric left = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = left.BitwiseComplement().BitwiseComplement();

                //assert
                result.Should().Be(left);
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomIntegral_DifferentValue()
            {
                //arrange
                TNumeric left = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

                //act
                TNumeric result = left.BitwiseComplement();

                //assert
                result.Should().NotBe(left);
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomIntegralValues_CorrectResult()
            {
                //arrange
                TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
                int right = Random.NextInt32(0, 2);

                //act
                TNumeric result = left.LeftShift(right);

                //assert
                result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) << right);
            }
        }

        public abstract class Real<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsReal<TNumeric>());

            [Test]
            public void Epsilon_LessThanOne()
            {
                Numeric.Epsilon<TNumeric>().IsLessThan(Numeric.One<TNumeric>()).Should().BeTrue();
            }

            [Test]
            public void Epsilon_ApproximatelyZero()
            {
                ConvertN.ToDouble(Numeric.Epsilon<TNumeric>()).Should().BeApproximately(0, 0.001);
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomValues_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalAnd(right));

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomValues_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalOr(right));

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomValues_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalExclusiveOr(right));

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomValue_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.BitwiseComplement());

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomValues_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                int right = Random.NextInt32(0, 2);

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.LeftShift(right));

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void RightShift_RandomValue_DoesntThrow()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                int right = Random.NextInt32(0, 2);

                //act
                Func<TNumeric> action = new Func<TNumeric>(() => left.RightShift(right));

                //assert
                action.Should().NotThrow();
            }
        }

        public abstract class SignedOnly<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsSigned<TNumeric>());

            [Test]
            public void MinUnit_IsMinusOne()
            {
                ConvertN.ToDouble(Numeric.MinUnit<TNumeric>()).Should().Be(-1);
            }

            [Test]
            public void MinValue_IsLessThanMinUnit()
            {
                Numeric.MinValue<TNumeric>().IsLessThan(Numeric.MinUnit<TNumeric>()).Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_RandomNegativeValue_ReturnsPositive()
            {
                //arrange
                sbyte input = Random.NextSByte(-127, -1);
                TNumeric inputN = ConvertN.ToNumeric<TNumeric>(input, Conversion.Cast);

                //act
                TNumeric result = inputN.Negative();

                //assert
                result.Should().Be(ConvertN.ToNumeric<TNumeric>(input * -1, Conversion.Cast));
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegative_RandomValue_ReturnsCorrectResult()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();
                bool expected = input.IsLessThan(Numeric.Zero<TNumeric>());

                //act
                bool result = Numeric.IsNegative(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class UnsignedOnly<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsUnsigned<TNumeric>());

            [Test]
            public void MinUnit_Unsigned_IsZero()
            {
                Numeric.MinUnit<TNumeric>().Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test]
            public void MinValue_Unsigned_IsZero()
            {
                Numeric.MinValue<TNumeric>().Should().Be(Numeric.Zero<TNumeric>());
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegative_RandomValue_AlwaysFalse()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                bool result = Numeric.IsNegative(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoFloatingPoint<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric.HasFloatingPoint<TNumeric>());

            [Test, Repeat(RandomVariations)]
            public void IsNormal_RandomValue_AlwaysFalse()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                bool result = Numeric.IsNormal(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsSubnormal_RandomIntegral_AlwaysFalse()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                bool result = Numeric.IsSubnormal(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoInfinity<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric.HasInfinity<TNumeric>());

            [Test, Repeat(RandomVariations)]
            public void IsFinite_RandomValue_AlwaysTrue()
            {
                //arrange
                byte[] bytes = BitConvert.GetBytes<TNumeric>(default);
                Random.NextBytes(bytes);
                TNumeric input = BitConvert.FromBytes<TNumeric>(bytes);

                //act
                bool result = Numeric.IsFinite(input);

                //assert
                result.Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void IsInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                byte[] bytes = BitConvert.GetBytes<TNumeric>(default);
                Random.NextBytes(bytes);
                TNumeric input = BitConvert.FromBytes<TNumeric>(bytes);

                //act
                bool result = Numeric.IsInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsPositiveInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                byte[] bytes = BitConvert.GetBytes<TNumeric>(default);
                Random.NextBytes(bytes);
                TNumeric input = BitConvert.FromBytes<TNumeric>(bytes);

                //act
                bool result = Numeric.IsPositiveInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test, Repeat(RandomVariations)]
            public void IsNegativeInfinity_RandomValue_AlwaysFalse()
            {
                //arrange
                byte[] bytes = BitConvert.GetBytes<TNumeric>(default);
                Random.NextBytes(bytes);
                TNumeric input = BitConvert.FromBytes<TNumeric>(bytes);

                //act
                bool result = Numeric.IsNegativeInfinity(input);

                //assert
                result.Should().BeFalse();
            }
        }

        public abstract class NoNaN<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric.HasNaN<TNumeric>());

            [Test, Repeat(RandomVariations)]
            public void IsNaN_RandomValue_AlwaysFalse()
            {
                //arrange
                byte[] bytes = BitConvert.GetBytes<TNumeric>(default);
                Random.NextBytes(bytes);
                TNumeric input = BitConvert.FromBytes<TNumeric>(bytes);

                //act
                bool result = Numeric.IsNaN(input);

                //assert
                result.Should().BeFalse();
            }
        }
    }
}

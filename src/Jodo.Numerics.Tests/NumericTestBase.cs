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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumericExtended<TNumeric>
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
        public void AdditionMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left + right,
#endif
                () => left.Add(right),
                () => DynamicInvoke.AdditionOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void BitwiseComplementMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => ~left,
#endif
                () => left.BitwiseComplement(),
                () => DynamicInvoke.BitwiseComplementOperator(left));
        }

        [Test, Repeat(RandomVariations)]
        public void DivisionMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left / right,
#endif
                () => left.Divide(right),
                () => DynamicInvoke.DivisionOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void EqualityMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
                () => left.Equals(right),
                () => left.Equals((object)right),
                () => left.CompareTo(right) == 0,
                () => left.CompareTo((object)right) == 0,
                () => DynamicInvoke.EqualityOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left > right,
#endif
                () => left.IsGreaterThan(right),
                () => left.CompareTo(right) > 0,
                () => left.CompareTo((object)right) > 0,
                () => DynamicInvoke.GreaterThanOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left >= right,
#endif
                () => left.IsGreaterThanOrEqualTo(right),
                () => left.CompareTo(right) >= 0,
                () => left.CompareTo((object)right) >= 0,
                () => DynamicInvoke.GreaterThanOrEqualOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void InequalityMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
                () => !left.Equals(right),
                () => !left.Equals((object)right),
                () => left.CompareTo(right) != 0,
                () => left.CompareTo((object)right) != 0,
                () => DynamicInvoke.InequalityOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LeftShiftMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            int right = Random.Next(-1, 65);

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left << right,
#endif
                () => left.LeftShift(right),
                () => DynamicInvoke.LeftShiftOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left < right,
#endif
                () => left.IsLessThan(right),
                () => left.CompareTo(right) < 0,
                () => left.CompareTo((object)right) < 0,
                () => DynamicInvoke.LessThanOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanOrEqualMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left <= right,
#endif
                () => left.IsLessThanOrEqualTo(right),
                () => left.CompareTo(right) <= 0,
                () => left.CompareTo((object)right) <= 0,
                () => DynamicInvoke.LessThanOrEqualOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalAndMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left & right,
#endif
                () => left.LogicalAnd(right),
                () => DynamicInvoke.LogicalAndOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalExclusiveOrMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left ^ right,
#endif
                () => left.LogicalExclusiveOr(right),
                () => DynamicInvoke.LogicalExclusiveOrOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalOrMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left | right,
#endif
                () => left.LogicalOr(right),
                () => DynamicInvoke.LogicalOrOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void MultiplicationMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left * right,
#endif
                () => left.Multiply(right),
                () => DynamicInvoke.MultiplicationOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void RemainderMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left % right,
#endif
                () => left.Remainder(right),
                () => DynamicInvoke.RemainderOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void RightShiftMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            int right = Random.Next(-1, 65);

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left >> right,
#endif
                () => left.RightShift(right),
                () => DynamicInvoke.RightShiftOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void SubtractionMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.Choose(left, Random.NextNumeric<TNumeric>());

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => left - right,
#endif
                () => left.Subtract(right),
                () => DynamicInvoke.SubtractionOperator(left, right));
        }

        [Test, Repeat(RandomVariations)]
        public void UnaryPlusMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Outcome(
#if HAS_DEFAULT_INTERFACE_METHODS
                    () => +left,
#endif
                () => left.Positive(),
                () => DynamicInvoke.UnaryPlusOperator(left));
        }
    }
}

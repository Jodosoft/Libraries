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
using System;
using System.Numerics;

namespace Jodo.Extensions.Numerics.Tests
{
    public sealed class DigitsTests : GlobalTestBase
    {
        [TestCase((byte)0, 1)]
        [TestCase(byte.MaxValue, 3)]
        public void Count_BoundaryByte_ExpectedResult(byte input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Count_RandomByte_CorrectResult()
        {
            //arrange
            byte input;
            do { input = Random.NextByte(); }
            while (input == 0);
            var expected = (byte)(Math.Floor(Math.Log10(input)) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((ushort)0, 1)]
        [TestCase(ushort.MaxValue, 5)]
        public void Count_BoundaryUInt16_ExpectedResult(ushort input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomUInt16_CorrectResult()
        {
            //arrange
            ushort input;
            do { input = Random.NextUInt16(); }
            while (input == 0);
            var expected = (byte)(Math.Floor(Math.Log10(input)) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((uint)0, 1)]
        [TestCase(uint.MaxValue, 10)]
        public void Count_BoundaryUInt32_ExpectedResult(uint input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomUInt32_CorrectResult()
        {
            //arrange
            uint input;
            do { input = Random.NextUInt32(); }
            while (input == 0);
            var expected = (byte)(Math.Floor(Math.Log10(input)) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((ulong)0, 1)]
        [TestCase(ulong.MaxValue, 20)]
        public void Count_BoundaryUInt64_ExpectedResult(ulong input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomUInt64_CorrectResult()
        {
            //arrange
            ulong input;
            do { input = Random.NextUInt64(); }
            while (input == 0);
            var expected = (byte)(Math.Floor(Math.Log10(input)) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((sbyte)0, 1)]
        [TestCase((sbyte)-1, 1)]
        [TestCase(sbyte.MinValue, 3)]
        [TestCase(sbyte.MaxValue, 3)]
        public void Count_BoundarySByte_ExpectedResult(sbyte input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomSByte_CorrectResult()
        {
            sbyte input;
            do { input = Random.NextSByte(); }
            while (input == 0 || input == sbyte.MinValue);
            var expected = (byte)(Math.Floor(Math.Log10(Math.Abs(input))) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((short)0, 1)]
        [TestCase((short)-1, 1)]
        [TestCase(short.MinValue, 5)]
        [TestCase(short.MaxValue, 5)]
        public void Count_BoundaryInt16_ExpectedResult(short input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomInt16_CorrectResult()
        {
            //arrange
            short input;
            do { input = Random.NextInt16(); }
            while (input == 0 || input == sbyte.MinValue);
            var expected = (byte)(Math.Floor(Math.Log10(Math.Abs(input))) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((int)0, 1)]
        [TestCase((int)-1, 1)]
        [TestCase(int.MinValue, 10)]
        [TestCase(int.MaxValue, 10)]
        public void Count_BoundaryInt32_ExpectedResult(int input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomInt32_CorrectResult()
        {
            //arrange
            int input;
            do { input = Random.NextInt32(); }
            while (input == 0 || input == sbyte.MinValue);
            var expected = (byte)(Math.Floor(Math.Log10(Math.Abs(input))) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((long)0, 1)]
        [TestCase((long)-1, 1)]
        [TestCase(long.MinValue, 19)]
        [TestCase(long.MaxValue, 19)]
        public void Count_BoundaryInt64_ExpectedResult(long input, byte expected)
        {
            //arrange
            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Count_RandomInt64_CorrectResult()
        {
            //arrange
            long input;
            do { input = Random.NextInt64(); }
            while (input == 0 || input == sbyte.MinValue);
            var expected = (byte)(Math.Floor(Math.Log10(Math.Abs(input))) + 1);

            //act
            var result = Digits.Count(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase((long)4, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)4, MidpointRounding.AwayFromZero, (long)0)]
        [TestCase((long)4, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)4, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)4, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)5, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)5, MidpointRounding.AwayFromZero, (long)10)]
        [TestCase((long)5, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)5, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)5, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)6, MidpointRounding.ToEven, (long)10)]
        [TestCase((long)6, MidpointRounding.AwayFromZero, (long)10)]
        [TestCase((long)6, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)6, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)6, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)-4, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)-4, MidpointRounding.AwayFromZero, (long)0)]
        [TestCase((long)-4, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-4, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-4, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)-5, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)-5, MidpointRounding.AwayFromZero, (long)-10)]
        [TestCase((long)-5, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-5, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-5, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)-6, MidpointRounding.ToEven, (long)-10)]
        [TestCase((long)-6, MidpointRounding.AwayFromZero, (long)-10)]
        [TestCase((long)-6, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-6, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-6, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)15, MidpointRounding.ToEven, (long)20)]
        [TestCase((long)15, MidpointRounding.AwayFromZero, (long)20)]
        [TestCase((long)15, MidpointRounding.ToZero, (long)10)]
        [TestCase((long)15, MidpointRounding.ToNegativeInfinity, (long)10)]
        [TestCase((long)15, MidpointRounding.ToPositiveInfinity, (long)20)]
        [TestCase((long)-15, MidpointRounding.ToEven, (long)-20)]
        [TestCase((long)-15, MidpointRounding.AwayFromZero, (long)-20)]
        [TestCase((long)-15, MidpointRounding.ToZero, (long)-10)]
        [TestCase((long)-15, MidpointRounding.ToNegativeInfinity, (long)-20)]
        [TestCase((long)-15, MidpointRounding.ToPositiveInfinity, (long)-10)]
        public void Round_ExampleInt64_ExpectedResult(long input, MidpointRounding mode, long expected)
        {
            //arrange
            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomInt64_CorrectResult()
        {
            //arrange
            var input = (long)Math.Round(Random.NextDouble(-4, 4) * 10);
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = (long)Math.Round(input / 10.0, mode) * 10;

            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_MultipleOf10Int64_SameResult()
        {
            //arrange
            var input = Random.NextInt64() / 10 * 10;
            var mode = Random.NextEnum<MidpointRounding>();

            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(input);
        }

        [TestCase((long)249, 2, MidpointRounding.ToEven, (long)200)]
        [TestCase((long)250, 2, MidpointRounding.ToEven, (long)200)]
        [TestCase((long)251, 2, MidpointRounding.ToEven, (long)200)]
        public void Round1_ExampleInt64_ExpectedResult(long input, int digits, MidpointRounding mode, long expected)
        {
            //arrange
            //act
            var result = Digits.Round(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomInt64MorePlacesThanDigits_ReturnsZero()
        {
            //arrange
            var places = Random.NextByte(2, 18);
            var scalingFactor = Math.Pow(10, places);
            var input = (ulong)Math.Round(Random.NextDouble(0, 4) * scalingFactor);
            var mode = Random.NextEnum<MidpointRounding>();

            //act
            var result = Digits.Round(input, places + 2, mode);

            //assert
            result.Should().Be(0);
        }

        [TestCase((ulong)4, MidpointRounding.ToEven, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.AwayFromZero, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)5, MidpointRounding.ToEven, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.AwayFromZero, (ulong)10)]
        [TestCase((ulong)5, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.ToEven, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.AwayFromZero, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)6, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)6, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToEven, (ulong)20)]
        [TestCase((ulong)15, MidpointRounding.AwayFromZero, (ulong)20)]
        [TestCase((ulong)15, MidpointRounding.ToZero, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToNegativeInfinity, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToPositiveInfinity, (ulong)20)]
        public void Round_ExampleUInt64_ExpectedResult(ulong input, MidpointRounding mode, ulong expected)
        {
            //arrange
            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomUInt64_CorrectResult()
        {
            //arrange
            var input = (ulong)Math.Round(Random.NextDouble(0, 4) * 10);
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = (ulong)Math.Round(input / 10.0, mode) * 10;

            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_MultipleOf10UInt64_SameResult()
        {
            //arrange
            var input = Random.NextUInt64() / 10 * 10;
            var mode = Random.NextEnum<MidpointRounding>();

            //act
            var result = Digits.Round(input, mode);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomUInt64MorePlacesThanDigits_ReturnsZero()
        {
            //arrange
            var places = Random.NextByte(2, 18);
            var scalingFactor = Math.Pow(10, places);
            var input = (long)Math.Round(Random.NextDouble(0, 4) * scalingFactor);
            var mode = Random.NextEnum<MidpointRounding>();

            //act
            var result = Digits.Round(input, places + 2, mode);

            //assert
            result.Should().Be(0);
        }
        [Test]
        public void Truncate_ByteExample_CorrectResult()
        {
            //arrange

            //act
            var result = Digits.Truncate(122, 1);

            //assert
            result.Should().Be(100);
        }

        [Test]
        public void Truncate_Int32Example1_CorrectResult()
        {
            //arrange

            //act
            var result = Digits.Truncate(233_254, 4);

            //assert
            result.Should().Be(233_200);
        }

        [Test]
        public void Truncate_Int32Example2_CorrectResult()
        {
            //arrange

            //act
            var result = Digits.Truncate(-233_254, 2);

            //assert
            result.Should().Be(-230_000);
        }

        [Test]
        public void Truncate_BigIntegerExample_CorrectResult()
        {
            //arrange

            //act
            var result = Digits.Truncate(new BigInteger(987654321L), 1);

            //assert
            result.Should().Be(new BigInteger(900000000));
        }

        [TestCase(233_254f, 4, 233_200f)]
        [TestCase(-233_254f, 2, -230_000f)]
        [TestCase(0f, 2, 0f)]
        [TestCase(1f, 2, 1f)]
        [TestCase(0.1f, 2, 0.1f)]
        [TestCase(0.01f, 2, 0.01f)]
        [TestCase(0.001f, 2, 0f)]
        [TestCase(0.9f, 2, 0.9f)]
        [TestCase(0.99f, 2, 0.99f)]
        [TestCase(0.999f, 2, 0.99f)]
        [TestCase(1.1f, 2, 1.1f)]
        [TestCase(1.01f, 2, 1f)]
        [TestCase(1.9f, 2, 1.9f)]
        [TestCase(1.99f, 2, 1.9f)]
        [TestCase(0.48681998f, 5, 0.48681f)]
        [TestCase(-0.48681998f, 5, -0.48681f)]
        [TestCase(0.00014015718f, 5, 0.00014015f)]
        [TestCase(-0.00014015718f, 5, -0.00014015f)]
        public void Truncate_SingleExamples_ExpectedResult(float input, int digits, float expected)
        {
            //arrange

            //act
            var result = Digits.Truncate(input, digits);

            //assert
            result.Should().Be(expected);
        }

        [TestCase(233_254d, 4, 233_200d)]
        [TestCase(-233_254d, 2, -230_000d)]
        [TestCase(0d, 2, 0d)]
        [TestCase(1d, 2, 1d)]
        [TestCase(0.1d, 2, 0.1d)]
        [TestCase(0.01d, 2, 0.01d)]
        [TestCase(0.001d, 2, 0d)]
        [TestCase(0.9d, 2, 0.9d)]
        [TestCase(0.99d, 2, 0.99d)]
        [TestCase(0.999d, 2, 0.99d)]
        [TestCase(1.1d, 2, 1.1d)]
        [TestCase(1.01d, 2, 1d)]
        [TestCase(1.9d, 2, 1.9d)]
        [TestCase(1.99d, 2, 1.9d)]
        [TestCase(0.48681998d, 5, 0.48681d)]
        [TestCase(-0.48681998d, 5, -0.48681d)]
        [TestCase(0.00014015718d, 5, 0.00014015d)]
        [TestCase(-0.00014015718d, 5, -0.00014015d)]
        public void Truncate_DoubleExamples_ExpectedResult(double input, int digits, double expected)
        {
            //arrange

            //act
            var result = Digits.Truncate(input, digits);

            //assert
            result.Should().Be(expected);
        }

        [TestCase(233_254f, 3, MidpointRounding.ToEven, 233_000f)]
        [TestCase(233_554f, 3, MidpointRounding.ToEven, 234_000f)]
        [TestCase(233_254f, 3, MidpointRounding.ToPositiveInfinity, 234_000f)]
        [TestCase(233_554f, 3, MidpointRounding.ToPositiveInfinity, 234_000f)]
        public void RoundToSignificance_SingleExamples_ExpectedResult(float input, int digits, MidpointRounding mode, float expected)
        {
            //arrange

            //act
            var result = Digits.RoundToSignificance(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }
    }
}

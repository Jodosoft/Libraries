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
using System.Linq;
using FluentAssertions;
using Jodo.Primitives.Compatibility;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Primitives.Tests
{
    public sealed class RandomExtensionsTests : GlobalFixtureBase
    {
        public static readonly decimal DecimalEpsilon = new decimal(1, 0, 0, false, 28);
        public const int NumberToGenerate = 1000;
        public const int ExpectedUniqueCount = NumberToGenerate / 10;
        public const int BoundedRange = 3;
        public const int BoundedNumberToGenerate = BoundedRange * ExpectedUniqueCount;

        [Test]
        public void NextByte_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            byte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextByte_Bounds_ReturnsValidValues()
        {
            //arrange
            byte min = (byte)(byte.MinValue / 2);
            byte max = (byte)(byte.MaxValue / 2);

            //act
            byte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            byte min = (byte)(byte.MinValue / 2);
            byte max = (byte)(byte.MaxValue / 2);

            //act
            byte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_NearMin_ReturnsAllValues()
        {
            //arrange
            byte min = byte.MinValue;
            byte max = (byte)(byte.MinValue + BoundedRange - 1);

            //act
            byte[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_NearMax_ReturnsAllValues()
        {
            //arrange
            byte min = (byte)(byte.MaxValue - BoundedRange + 1);
            byte max = byte.MaxValue;

            //act
            byte[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            byte bounds = Random.NextByte();

            //act
            System.Collections.Generic.IEnumerable<byte> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextSByte_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            sbyte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextSByte_Bounds_ReturnsValidValues()
        {
            //arrange
            sbyte min = (sbyte)(sbyte.MinValue / 2);
            sbyte max = (sbyte)(sbyte.MaxValue / 2);

            //act
            sbyte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            sbyte min = (sbyte)(sbyte.MinValue / 2);
            sbyte max = (sbyte)(sbyte.MaxValue / 2);

            //act
            sbyte[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_NearMin_ReturnsAllValues()
        {
            //arrange
            sbyte min = sbyte.MinValue;
            sbyte max = (sbyte)(sbyte.MinValue + BoundedRange - 1);

            //act
            sbyte[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_NearMax_ReturnsAllValues()
        {
            //arrange
            sbyte min = (sbyte)(sbyte.MaxValue - BoundedRange + 1);
            sbyte max = sbyte.MaxValue;

            //act
            sbyte[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            sbyte bounds = Random.NextSByte();

            //act
            System.Collections.Generic.IEnumerable<sbyte> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt16_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            short[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt16_Bounds_ReturnsValidValues()
        {
            //arrange
            short min = (short)(short.MinValue / 2);
            short max = (short)(short.MaxValue / 2);

            //act
            short[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            short min = (short)(short.MinValue / 2);
            short max = (short)(short.MaxValue / 2);

            //act
            short[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_NearMin_ReturnsAllValues()
        {
            //arrange
            short min = short.MinValue;
            short max = (short)(short.MinValue + BoundedRange - 1);

            //act
            short[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_NearMax_ReturnsAllValues()
        {
            //arrange
            short min = (short)(short.MaxValue - BoundedRange + 1);
            short max = short.MaxValue;

            //act
            short[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            short bounds = Random.NextInt16();

            //act
            System.Collections.Generic.IEnumerable<short> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt16_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            ushort[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt16_Bounds_ReturnsValidValues()
        {
            //arrange
            ushort min = (ushort)(ushort.MinValue / 2);
            ushort max = (ushort)(ushort.MaxValue / 2);

            //act
            ushort[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            ushort min = (ushort)(ushort.MinValue / 2);
            ushort max = (ushort)(ushort.MaxValue / 2);

            //act
            ushort[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_NearMin_ReturnsAllValues()
        {
            //arrange
            ushort min = ushort.MinValue;
            ushort max = (ushort)(ushort.MinValue + BoundedRange - 1);

            //act
            ushort[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_NearMax_ReturnsAllValues()
        {
            //arrange
            ushort min = (ushort)(ushort.MaxValue - BoundedRange + 1);
            ushort max = ushort.MaxValue;

            //act
            ushort[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            ushort bounds = Random.NextUInt16();

            //act
            System.Collections.Generic.IEnumerable<ushort> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt32_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            int[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            int min = int.MinValue / 2;
            int max = int.MaxValue / 2;

            //act
            int[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            int min = int.MinValue / 2;
            int max = int.MaxValue / 2;

            //act
            int[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            int min = int.MinValue;
            int max = int.MinValue + BoundedRange - 1;

            //act
            int[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_NearMax_ReturnsAllValues()
        {
            //arrange
            int min = int.MaxValue - BoundedRange + 1;
            int max = int.MaxValue;

            //act
            int[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            int bounds = Random.NextInt32();

            //act
            System.Collections.Generic.IEnumerable<int> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt32_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            uint[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            uint min = uint.MinValue / 2;
            uint max = uint.MaxValue / 2;

            //act
            uint[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            uint min = uint.MinValue / 2;
            uint max = uint.MaxValue / 2;

            //act
            uint[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            uint min = uint.MinValue;
            uint max = uint.MinValue + BoundedRange - 1;

            //act
            uint[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_NearMax_ReturnsAllValues()
        {
            //arrange
            uint min = uint.MaxValue - BoundedRange + 1;
            uint max = uint.MaxValue;

            //act
            uint[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            uint bounds = Random.NextUInt32();

            //act
            System.Collections.Generic.IEnumerable<uint> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt64_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            long[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64WithoutBounds()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            long min = long.MinValue / 2;
            long max = long.MaxValue / 2;

            //act
            long[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            long min = long.MinValue / 2;
            long max = long.MaxValue / 2;

            //act
            long[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            long min = long.MinValue;
            long max = long.MinValue + BoundedRange - 1;

            //act
            long[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMax_ReturnsAllValues()
        {
            //arrange
            long min = long.MaxValue - BoundedRange + 1;
            long max = long.MaxValue;

            //act
            long[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            long bounds = Random.NextInt64WithoutBounds();

            //act
            System.Collections.Generic.IEnumerable<long> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt64_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            ulong[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            ulong min = ulong.MinValue / 2;
            ulong max = ulong.MaxValue / 2;

            //act
            ulong[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            ulong min = ulong.MinValue / 2;
            ulong max = ulong.MaxValue / 2;

            //act
            ulong[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            ulong min = ulong.MinValue;
            ulong max = ulong.MinValue + BoundedRange - 1;

            //act
            ulong[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_NearMax_ReturnsAllValues()
        {
            //arrange
            ulong min = ulong.MaxValue - BoundedRange + 1;
            ulong max = ulong.MaxValue;

            //act
            ulong[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            ulong bounds = Random.NextUInt64();

            //act
            System.Collections.Generic.IEnumerable<ulong> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextSingle_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            float[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextSingle_Bounds_ReturnsValidValues()
        {
            //arrange
            float min = (float)(float.MinValue / 2);
            float max = (float)(float.MaxValue / 2);

            //act
            float[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            float min = (float)(float.MinValue / 2);
            float max = (float)(float.MaxValue / 2);

            //act
            float[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_NearMin_ReturnsAllValues()
        {
            //arrange
            float min = float.MinValue;
            float max = float.MinValue;
            for (int i = 0; i < BoundedRange - 1; i++) max = MathFCompat.BitIncrement(max);

            //act
            float[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_NearMax_ReturnsAllValues()
        {
            //arrange
            float min = float.MaxValue;
            float max = float.MaxValue;
            for (int i = 0; i < BoundedRange - 1; i++) min = MathFCompat.BitDecrement(min);

            //act
            float[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            float bounds = Random.NextSingle();

            //act
            System.Collections.Generic.IEnumerable<float> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextDouble_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            double[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextDouble_Bounds_ReturnsValidValues()
        {
            //arrange
            double min = (double)(double.MinValue / 2);
            double max = (double)(double.MaxValue / 2);

            //act
            double[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_RandomBounds_ReturnsValidValues()
        {
            //arrange
            double bound1 = Random.NextDouble(double.MinValue, double.MaxValue);
            double bound2 = Random.NextDouble(double.MinValue, double.MaxValue);

            //act
            double[] results = Enumerable.Range(0, NumberToGenerate * 10)
                .Select(_ => Random.NextDouble(bound1, bound2)).ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().OnlyContain(x => double.IsFinite(x) && x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDouble_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            double min = (double)(double.MinValue / 2);
            double max = (double)(double.MaxValue / 2);

            //act
            double[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_NearMin_ReturnsAllValues()
        {
            //arrange
            double bound1 = double.MinValue;
            double bound2 = double.MinValue;
            for (int i = 0; i < BoundedRange - 1; i++) bound2 = MathCompat.BitIncrement(bound2);
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            double[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDouble_NearMax_ReturnsAllValues()
        {
            //arrange
            double bound1 = double.MaxValue;
            double bound2 = double.MaxValue;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = MathCompat.BitDecrement(bound1);
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            double[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test, Repeat(RandomVariations)]
        public void NextDouble_RandomRange_ReturnsAllValues()
        {
            //arrange
            double bound1 = Random.NextDouble(double.MinValue, double.MaxValue) / 10;
            double bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = MathCompat.BitIncrement(bound1);

            //act
            double[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test, Repeat(RandomVariations)]
        public void NextDouble_RandomSmallRange_ReturnsAllValues()
        {
            //arrange
            double bound1 = Random.NextDouble(-1, 1);
            double bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = MathCompat.BitIncrement(bound1);

            //act
            double[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDouble_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            double bounds = Random.NextDouble();

            //act
            System.Collections.Generic.IEnumerable<double> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextDecimal_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            decimal[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextDecimal_Bounds_ReturnsValidValues()
        {
            //arrange
            decimal min = decimal.MinValue / 2;
            decimal max = decimal.MaxValue / 2;

            //act
            decimal[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDecimal_RandomBounds_ReturnsValidValues()
        {
            //arrange
            decimal bound1 = Random.NextDecimal(decimal.MinValue, decimal.MaxValue);
            decimal bound2 = Random.NextDecimal(decimal.MinValue, decimal.MaxValue);

            //act
            decimal[] results = Enumerable.Range(0, NumberToGenerate * 10)
                .Select(_ => Random.NextDecimal(bound1, bound2)).ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDecimal_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            decimal min = decimal.MinValue / 2;
            decimal max = decimal.MaxValue / 2;

            //act
            decimal[] results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDecimal_NearMin_ReturnsAllValues()
        {
            //arrange
            decimal bound1 = -79228162514264337593543950335M;
            decimal bound2 = -79228162514264337593543950333M;
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            decimal[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDecimal(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(3);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDecimal_NearMax_ReturnsAllValues()
        {
            //arrange
            decimal bound1 = 79228162514264337593543950335M;
            decimal bound2 = 79228162514264337593543950333M;
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            decimal[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDecimal(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(3);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test, Repeat(RandomVariations)]
        public void NextDecimal_RandomSmallRange_ReturnsAllValues()
        {
            //arrange
            decimal bound1 = Random.NextDecimal(-1, 1);
            decimal bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 += DecimalEpsilon;

            //act
            decimal[] results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDecimal(bound1, bound2)).Distinct().ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDecimal_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            decimal bounds = Random.NextDecimal();

            //act
            System.Collections.Generic.IEnumerable<decimal> results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDecimal(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }
    }
}

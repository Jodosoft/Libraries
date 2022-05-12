using FluentAssertions;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;
using System.Linq;

namespace Jodo.Extensions.Primitives.Tests
{
    public sealed class RandomExtensionsTests : GlobalTestBase
    {
        public const int NumberToGenerate = 100;
        public const int ExpectedUniqueCount = NumberToGenerate / 10;
        public const int BoundedRange = 3;
        public const int BoundedNumberToGenerate = BoundedRange * ExpectedUniqueCount;

        [Test]
        public void NextByte_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextByte_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (byte)(byte.MinValue / 2);
            var max = (byte)(byte.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (byte)(byte.MinValue / 2);
            var max = (byte)(byte.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextByte(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = byte.MinValue;
            var max = (byte)(byte.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (byte)(byte.MaxValue - BoundedRange + 1);
            var max = byte.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextByte_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextByte();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextByte(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextSByte_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextSByte_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (sbyte)(sbyte.MinValue / 2);
            var max = (sbyte)(sbyte.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (sbyte)(sbyte.MinValue / 2);
            var max = (sbyte)(sbyte.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSByte(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = sbyte.MinValue;
            var max = (sbyte)(sbyte.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (sbyte)(sbyte.MaxValue - BoundedRange + 1);
            var max = sbyte.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSByte_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextSByte();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSByte(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt16_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt16_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (short)(short.MinValue / 2);
            var max = (short)(short.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (short)(short.MinValue / 2);
            var max = (short)(short.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt16(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = short.MinValue;
            var max = (short)(short.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (short)(short.MaxValue - BoundedRange + 1);
            var max = short.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt16_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextInt16();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt16(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt16_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt16_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (ushort)(ushort.MinValue / 2);
            var max = (ushort)(ushort.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (ushort)(ushort.MinValue / 2);
            var max = (ushort)(ushort.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt16(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = ushort.MinValue;
            var max = (ushort)(ushort.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (ushort)(ushort.MaxValue - BoundedRange + 1);
            var max = ushort.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt16_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextUInt16();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt16(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt32_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (int)(int.MinValue / 2);
            var max = (int)(int.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (int)(int.MinValue / 2);
            var max = (int)(int.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = int.MinValue;
            var max = (int)(int.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (int)(int.MaxValue - BoundedRange + 1);
            var max = int.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextInt32();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt32(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt32_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (uint)(uint.MinValue / 2);
            var max = (uint)(uint.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (uint)(uint.MinValue / 2);
            var max = (uint)(uint.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = uint.MinValue;
            var max = (uint)(uint.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (uint)(uint.MaxValue - BoundedRange + 1);
            var max = uint.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextUInt32();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt32(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextInt64_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (long)(long.MinValue / 2);
            var max = (long)(long.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (long)(long.MinValue / 2);
            var max = (long)(long.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = long.MinValue;
            var max = (long)(long.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (long)(long.MaxValue - BoundedRange + 1);
            var max = long.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextInt64();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextUInt64_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (ulong)(ulong.MinValue / 2);
            var max = (ulong)(ulong.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (ulong)(ulong.MinValue / 2);
            var max = (ulong)(ulong.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = ulong.MinValue;
            var max = (ulong)(ulong.MinValue + BoundedRange - 1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = (ulong)(ulong.MaxValue - BoundedRange + 1);
            var max = ulong.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextUInt64();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextUInt64(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextSingle_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextSingle_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (float)(float.MinValue / 2);
            var max = (float)(float.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (float)(float.MinValue / 2);
            var max = (float)(float.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextSingle(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = float.MinValue;
            var max = float.MinValue;
            for (int i = 0; i < BoundedRange - 1; i++) max = MathF.BitIncrement(max);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = float.MaxValue;
            var max = float.MaxValue;
            for (int i = 0; i < BoundedRange - 1; i++) min = MathF.BitDecrement(min);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextSingle_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextSingle();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextSingle(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }

        [Test]
        public void NextDouble_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble()).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextDouble_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = (double)(double.MinValue / 2);
            var max = (double)(double.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble(min, max)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = (double)(double.MinValue / 2);
            var max = (double)(double.MaxValue / 2);

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDouble(max, min)).Distinct().ToArray();

            //assert
            results.Count().Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test, Ignore("TODO https://github.com/JosephJShort/Jodo.Extensions/issues/1")]
        public void NextDouble_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = double.MinValue;
            var max = double.MinValue;
            for (int i = 0; i < BoundedRange - 1; i++) max = Math.BitIncrement(max);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test, Ignore("TODO https://github.com/JosephJShort/Jodo.Extensions/issues/1")]
        public void NextDouble_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = double.MaxValue;
            var max = double.MaxValue;
            for (int i = 0; i < BoundedRange - 1; i++) min = Math.BitDecrement(min);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextDouble();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }
    }
}

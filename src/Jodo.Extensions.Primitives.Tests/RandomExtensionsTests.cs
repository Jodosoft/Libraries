using FluentAssertions;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;
using System.Linq;

namespace Jodo.Extensions.Primitives.Tests
{
    public sealed class RandomExtensionsTests : GlobalFixtureBase
    {
        public readonly static decimal DecimalEpsilon = new decimal(1, 0, 0, false, 28);
        public const int NumberToGenerate = 1000;
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = int.MinValue / 2;
            var max = int.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = int.MinValue / 2;
            var max = int.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt32(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = int.MinValue;
            var max = int.MinValue + BoundedRange - 1;

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
            var min = int.MaxValue - BoundedRange + 1;
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt32_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = uint.MinValue / 2;
            var max = uint.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = uint.MinValue / 2;
            var max = uint.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt32(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt32_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = uint.MinValue;
            var max = uint.MinValue + BoundedRange - 1;

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
            var min = uint.MaxValue - BoundedRange + 1;
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
                .Select(_ => Random.NextInt64WithoutBounds()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = long.MinValue / 2;
            var max = long.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = long.MinValue / 2;
            var max = long.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = long.MinValue;
            var max = long.MinValue + BoundedRange - 1;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_NearMax_ReturnsAllValues()
        {
            //arrange
            var min = long.MaxValue - BoundedRange + 1;
            var max = long.MaxValue;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(min, max)).Distinct().ToArray();

            //assert
            results.Should().HaveCount(BoundedRange);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextInt64_EqualBounds_ReturnsBoundsValue()
        {
            //arrange
            var bounds = Random.NextInt64WithoutBounds();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextInt64WithBounds(bounds, bounds));

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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextUInt64_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = ulong.MinValue / 2;
            var max = ulong.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = ulong.MinValue / 2;
            var max = ulong.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextUInt64(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextUInt64_NearMin_ReturnsAllValues()
        {
            //arrange
            var min = ulong.MinValue;
            var max = ulong.MinValue + BoundedRange - 1;

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
            var min = ulong.MaxValue - BoundedRange + 1;
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_RandomBounds_ReturnsValidValues()
        {
            //arrange
            var bound1 = Random.NextDouble(double.MinValue, double.MaxValue);
            var bound2 = Random.NextDouble(double.MinValue, double.MaxValue);

            //act
            var results = Enumerable.Range(0, NumberToGenerate * 10)
                .Select(_ => Random.NextDouble(bound1, bound2)).ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().OnlyContain(x => double.IsFinite(x) && x >= bound1 && x <= bound2);
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
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDouble_NearMin_ReturnsAllValues()
        {
            //arrange
            var bound1 = double.MinValue;
            var bound2 = double.MinValue;
            for (int i = 0; i < BoundedRange - 1; i++) bound2 = Math.BitIncrement(bound2);
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bound1 = double.MaxValue;
            var bound2 = double.MaxValue;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = Math.BitDecrement(bound1);
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bound1 = Random.NextDouble(double.MinValue, double.MaxValue) / 10;
            var bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = Math.BitIncrement(bound1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bound1 = Random.NextDouble(-1, 1);
            var bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 = Math.BitIncrement(bound1);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bounds = Random.NextDouble();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDouble(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }










        [Test]
        public void NextDecimal_NoBounds_RandomDistribution()
        {
            //arrange
            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal()).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount);
        }

        [Test]
        public void NextDecimal_Bounds_ReturnsValidValues()
        {
            //arrange
            var min = decimal.MinValue / 2;
            var max = decimal.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal(min, max)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDecimal_RandomBounds_ReturnsValidValues()
        {
            //arrange
            var bound1 = Random.NextDecimal(decimal.MinValue, decimal.MaxValue);
            var bound2 = Random.NextDecimal(decimal.MinValue, decimal.MaxValue);

            //act
            var results = Enumerable.Range(0, NumberToGenerate * 10)
                .Select(_ => Random.NextDecimal(bound1, bound2)).ToArray();

            //assert
            if (bound1 > bound2) (bound2, bound1) = (bound1, bound2);
            results.Should().OnlyContain(x => x >= bound1 && x <= bound2);
        }

        [Test]
        public void NextDecimal_ReverseBounds_ReturnsValidValues()
        {
            //arrange
            var min = decimal.MinValue / 2;
            var max = decimal.MaxValue / 2;

            //act
            var results = Enumerable.Range(0, NumberToGenerate)
                .Select(_ => Random.NextDecimal(max, min)).Distinct().ToArray();

            //assert
            results.Length.Should().BeGreaterThanOrEqualTo(ExpectedUniqueCount / 2);
            results.Should().OnlyContain(x => x >= min && x <= max);
        }

        [Test]
        public void NextDecimal_NearMin_ReturnsAllValues()
        {
            //arrange
            var bound1 = -79228162514264337593543950335M;
            var bound2 = -79228162514264337593543950333M;
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bound1 = 79228162514264337593543950335M;
            var bound2 = 79228162514264337593543950333M;
            if (Random.NextBoolean()) (bound2, bound1) = (bound1, bound2);

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bound1 = Random.NextDecimal(-1, 1);
            var bound2 = bound1;
            for (int i = 0; i < BoundedRange - 1; i++) bound1 += DecimalEpsilon;

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
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
            var bounds = Random.NextDecimal();

            //act
            var results = Enumerable.Range(0, BoundedNumberToGenerate)
                .Select(_ => Random.NextDecimal(bounds, bounds));

            //assert
            results.Should().OnlyContain(x => x == bounds);
        }
    }
}

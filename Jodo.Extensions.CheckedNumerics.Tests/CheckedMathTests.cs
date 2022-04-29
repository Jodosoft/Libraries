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
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    [SuppressMessage("Style", "IDE0004:Cast is redundant")]
    public class CheckedMathTests : AssemblyTestBase
    {
        [Test] public void ByteAdd_SmokeTest_CorrectResult() => CheckedMath.Add((byte)12, (byte)12).Should().Be(24);
        [Test] public void ByteAdd_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ByteAdd_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(byte.MinValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteSubtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((byte)12, (byte)8).Should().Be(4);
        [Test] public void ByteSubtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(byte.MaxValue, byte.MinValue).Should().Be(byte.MaxValue);
        [Test] public void ByteSubtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(byte.MinValue, byte.MaxValue).Should().Be(byte.MinValue);
        [Test] public void ByteMultiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((byte)12, (byte)12).Should().Be(144);
        [Test] public void ByteMultiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ByteMultiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(byte.MaxValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteDivide_SmokeTest_CorrectResult() => CheckedMath.Divide((byte)12, (byte)4).Should().Be(3);
        [Test] public void ByteDivide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextByte(), (byte)0).Should().Be(byte.MaxValue);
        [Test] public void ByteRemainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((byte)12, (byte)5).Should().Be(2);
        [Test] public void ByteRemainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextByte(), (byte)0).Should().Be(byte.MaxValue);
        [Test] public void BytePow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(byte.MinValue, (byte)3).Should().Be(byte.MinValue);
        [Test] public void BytePow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void BytePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(byte.MaxValue, (byte)2).Should().Be(byte.MaxValue);
        [Test] public void BytePow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextByte(), (byte)0).Should().Be((byte)1);

        [Test] public void UInt16Add_SmokeTest_CorrectResult() => CheckedMath.Add((ushort)12, (ushort)12).Should().Be(24);
        [Test] public void UInt16Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(ushort.MinValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((ushort)12, (ushort)8).Should().Be(4);
        [Test] public void UInt16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(ushort.MinValue, ushort.MaxValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((ushort)12, (ushort)12).Should().Be(144);
        [Test] public void UInt16Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((ushort)12, (ushort)4).Should().Be(3);
        [Test] public void UInt16Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextUInt16(), (ushort)0).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((ushort)12, (ushort)5).Should().Be(2);
        [Test] public void UInt16Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextUInt16(), (ushort)0).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(ushort.MinValue, (ushort)3).Should().Be(ushort.MinValue);
        [Test] public void UInt16Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(ushort.MaxValue, (ushort)2).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextUInt16(), (ushort)0).Should().Be((ushort)1);

        [Test] public void UInt32Add_SmokeTest_CorrectResult() => CheckedMath.Add((uint)12, (uint)12).Should().Be(24);
        [Test] public void UInt32Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(uint.MinValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((uint)12, (uint)8).Should().Be(4);
        [Test] public void UInt32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(uint.MaxValue, uint.MinValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(uint.MinValue, uint.MaxValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((uint)12, (uint)12).Should().Be(144);
        [Test] public void UInt32Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(uint.MaxValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((uint)12, (uint)4).Should().Be(3);
        [Test] public void UInt32Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextUInt32(), (uint)0).Should().Be(uint.MaxValue);
        [Test] public void UInt32Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((uint)12, (uint)5).Should().Be(2);
        [Test] public void UInt32Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextUInt32(), (uint)0).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(uint.MinValue, (uint)3).Should().Be(uint.MinValue);
        [Test] public void UInt32Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(uint.MaxValue, (uint)2).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextUInt32(), (uint)0).Should().Be((uint)1);

        [Test] public void UInt64Add_SmokeTest_CorrectResult() => CheckedMath.Add((ulong)12, (ulong)12).Should().Be(24);
        [Test] public void UInt64Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(ulong.MinValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((ulong)12, (ulong)8).Should().Be(4);
        [Test] public void UInt64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(ulong.MinValue, ulong.MaxValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((ulong)12, (ulong)12).Should().Be(144);
        [Test] public void UInt64Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((ulong)12, (ulong)4).Should().Be(3);
        [Test] public void UInt64Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextUInt64(), (ulong)0).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((ulong)12, (ulong)5).Should().Be(2);
        [Test] public void UInt64Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextUInt64(), (ulong)0).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(ulong.MinValue, (ulong)3).Should().Be(ulong.MinValue);
        [Test] public void UInt64Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(ulong.MaxValue, (ulong)2).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextUInt64(), (ulong)0).Should().Be((ulong)1);

        [Test] public void Int16Add_SmokeTest_CorrectResult() => CheckedMath.Add((short)12, (short)12).Should().Be(24);
        [Test] public void Int16Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(short.MinValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((short)12, (short)8).Should().Be(4);
        [Test] public void Int16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(short.MaxValue, short.MinValue).Should().Be(short.MaxValue);
        [Test] public void Int16Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(short.MinValue, short.MaxValue).Should().Be(short.MinValue);
        [Test] public void Int16Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((short)12, (short)12).Should().Be(144);
        [Test] public void Int16Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(short.MaxValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((short)12, (short)4).Should().Be(3);
        [Test] public void Int16Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextInt16(), (short)0).Should().Be(short.MaxValue);
        [Test] public void Int16Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((short)12, (short)5).Should().Be(2);
        [Test] public void Int16Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextInt16(), (short)0).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(short.MinValue, (short)3).Should().Be(short.MinValue);
        [Test] public void Int16Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(short.MaxValue, (short)2).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextInt16(), (short)0).Should().Be((short)1);

        [Test] public void Int32Add_SmokeTest_CorrectResult() => CheckedMath.Add((int)12, (int)12).Should().Be(24);
        [Test] public void Int32Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(int.MinValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((int)12, (int)8).Should().Be(4);
        [Test] public void Int32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(int.MaxValue, int.MinValue).Should().Be(int.MaxValue);
        [Test] public void Int32Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(int.MinValue, int.MaxValue).Should().Be(int.MinValue);
        [Test] public void Int32Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((int)12, (int)12).Should().Be(144);
        [Test] public void Int32Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(int.MaxValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((int)12, (int)4).Should().Be(3);
        [Test] public void Int32Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextInt32(), (int)0).Should().Be(int.MaxValue);
        [Test] public void Int32Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((int)12, (int)5).Should().Be(2);
        [Test] public void Int32Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextInt32(), (int)0).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(int.MinValue, (int)3).Should().Be(int.MinValue);
        [Test] public void Int32Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(int.MaxValue, (int)2).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextInt32(), (int)0).Should().Be((int)1);

        [Test] public void Int64Add_SmokeTest_CorrectResult() => CheckedMath.Add((long)12, (long)12).Should().Be(24);
        [Test] public void Int64Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Add(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Add_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Add(long.MinValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Subtract_SmokeTest_CorrectResult() => CheckedMath.Subtract((long)12, (long)8).Should().Be(4);
        [Test] public void Int64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Subtract(long.MaxValue, long.MinValue).Should().Be(long.MaxValue);
        [Test] public void Int64Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Subtract(long.MinValue, long.MaxValue).Should().Be(long.MinValue);
        [Test] public void Int64Multiply_SmokeTest_CorrectResult() => CheckedMath.Multiply((long)12, (long)12).Should().Be(144);
        [Test] public void Int64Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Multiply(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Multiply(long.MaxValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Divide_SmokeTest_CorrectResult() => CheckedMath.Divide((long)12, (long)4).Should().Be(3);
        [Test] public void Int64Divide_ByZero_ReturnsMaxValue() => CheckedMath.Divide(Random.NextInt64(), (long)0).Should().Be(long.MaxValue);
        [Test] public void Int64Remainder_SmokeTest_CorrectResult() => CheckedMath.Remainder((long)12, (long)5).Should().Be(2);
        [Test] public void Int64Remainder_ByZero_ReturnsMaxValue() => CheckedMath.Remainder(Random.NextInt64(), (long)0).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedMath.Pow(long.MinValue, (long)3).Should().Be(long.MinValue);
        [Test] public void Int64Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedMath.Pow(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedMath.Pow(long.MaxValue, (long)2).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_Zero_ReturnsOne() => CheckedMath.Pow(Random.NextInt64(), (long)0).Should().Be((long)1);


        [Test]
        public void MultiplyFloat_Random_CorrectResult()
        {
            //arrange
            var left = Random.NextSingle();
            var right = Random.NextSingle();
            var expected = left * right;
            if (float.IsPositiveInfinity(expected)) expected = float.MaxValue;
            if (float.IsNegativeInfinity(expected)) expected = float.MinValue;

            //act
            var result = CheckedMath.Multiply(left, right);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void MultiplyFloat_Nan_Returns0()
        {
            CheckedMath.Multiply(Random.NextSingle(), float.NaN).Should().Be(0);
        }
    }
}

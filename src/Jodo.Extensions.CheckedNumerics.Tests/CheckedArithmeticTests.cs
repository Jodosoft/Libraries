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
using FluentAssertions;
using Jodo.Extensions.Testing;
using NUnit.Framework;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    [SuppressMessage("Style", "IDE0004:Cast is redundant")]
    public class CheckedArithmeticTests : GlobalFixtureBase
    {
        [Test] public void ByteAdd_SmokeTest_CorrectResult() => CheckedArithmetic.Add((byte)12, (byte)12).Should().Be(24);
        [Test] public void ByteAdd_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ByteAdd_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(byte.MinValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteSubtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((byte)12, (byte)8).Should().Be(4);
        [Test] public void ByteSubtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(byte.MaxValue, byte.MinValue).Should().Be(byte.MaxValue);
        [Test] public void ByteSubtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(byte.MinValue, byte.MaxValue).Should().Be(byte.MinValue);
        [Test] public void ByteMultiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((byte)12, (byte)12).Should().Be(144);
        [Test] public void ByteMultiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ByteMultiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(byte.MaxValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteDivide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((byte)12, (byte)4).Should().Be(3);
        [Test] public void ByteDivide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextByte(), (byte)0).Should().Be(byte.MaxValue);
        [Test] public void ByteRemainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((byte)12, (byte)5).Should().Be(2);
        [Test] public void ByteRemainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextByte(), (byte)0).Should().Be(0);
        [Test] public void BytePow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(byte.MinValue, (byte)3).Should().Be(byte.MinValue);
        [Test] public void BytePow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void BytePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(byte.MaxValue, (byte)2).Should().Be(byte.MaxValue);
        [Test] public void BytePow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextByte(), (byte)0).Should().Be((byte)1);

        [Test] public void UInt16Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((ushort)12, (ushort)12).Should().Be(24);
        [Test] public void UInt16Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(ushort.MinValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((ushort)12, (ushort)8).Should().Be(4);
        [Test] public void UInt16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(ushort.MinValue, ushort.MaxValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((ushort)12, (ushort)12).Should().Be(144);
        [Test] public void UInt16Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((ushort)12, (ushort)4).Should().Be(3);
        [Test] public void UInt16Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextUInt16(), (ushort)0).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((ushort)12, (ushort)5).Should().Be(2);
        [Test] public void UInt16Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextUInt16(), (ushort)0).Should().Be(0);
        [Test] public void UInt16Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(ushort.MinValue, (ushort)3).Should().Be(ushort.MinValue);
        [Test] public void UInt16Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(ushort.MaxValue, (ushort)2).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextUInt16(), (ushort)0).Should().Be((ushort)1);

        [Test] public void UInt32Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((uint)12, (uint)12).Should().Be(24);
        [Test] public void UInt32Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(uint.MinValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((uint)12, (uint)8).Should().Be(4);
        [Test] public void UInt32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(uint.MaxValue, uint.MinValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(uint.MinValue, uint.MaxValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((uint)12, (uint)12).Should().Be(144);
        [Test] public void UInt32Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(uint.MaxValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((uint)12, (uint)4).Should().Be(3);
        [Test] public void UInt32Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextUInt32(), (uint)0).Should().Be(uint.MaxValue);
        [Test] public void UInt32Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((uint)12, (uint)5).Should().Be(2);
        [Test] public void UInt32Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextUInt32(), (uint)0).Should().Be(0);
        [Test] public void UInt32Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(uint.MinValue, (uint)3).Should().Be(uint.MinValue);
        [Test] public void UInt32Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(uint.MaxValue, (uint)2).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextUInt32(), (uint)0).Should().Be((uint)1);

        [Test] public void UInt64Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((ulong)12, (ulong)12).Should().Be(24);
        [Test] public void UInt64Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(ulong.MinValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((ulong)12, (ulong)8).Should().Be(4);
        [Test] public void UInt64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(ulong.MinValue, ulong.MaxValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((ulong)12, (ulong)12).Should().Be(144);
        [Test] public void UInt64Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((ulong)12, (ulong)4).Should().Be(3);
        [Test] public void UInt64Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextUInt64(), (ulong)0).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((ulong)12, (ulong)5).Should().Be(2);
        [Test] public void UInt64Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextUInt64(), (ulong)0).Should().Be(0);
        [Test] public void UInt64Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(ulong.MinValue, (ulong)3).Should().Be(ulong.MinValue);
        [Test] public void UInt64Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(ulong.MaxValue, (ulong)2).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextUInt64(), (ulong)0).Should().Be((ulong)1);

        [Test] public void Int16Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((short)12, (short)12).Should().Be(24);
        [Test] public void Int16Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(short.MinValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((short)12, (short)8).Should().Be(4);
        [Test] public void Int16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(short.MaxValue, short.MinValue).Should().Be(short.MaxValue);
        [Test] public void Int16Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(short.MinValue, short.MaxValue).Should().Be(short.MinValue);
        [Test] public void Int16Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((short)12, (short)12).Should().Be(144);
        [Test] public void Int16Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(short.MaxValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((short)12, (short)4).Should().Be(3);
        [Test] public void Int16Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextInt16(), (short)0).Should().Be(short.MaxValue);
        [Test] public void Int16Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((short)12, (short)5).Should().Be(2);
        [Test] public void Int16Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextInt16(), (short)0).Should().Be(0);
        [Test] public void Int16Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(short.MinValue, (short)3).Should().Be(short.MinValue);
        [Test] public void Int16Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(short.MaxValue, (short)2).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextInt16(), (short)0).Should().Be((short)1);

        [Test] public void Int32Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((int)12, (int)12).Should().Be(24);
        [Test] public void Int32Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(int.MinValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((int)12, (int)8).Should().Be(4);
        [Test] public void Int32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(int.MaxValue, int.MinValue).Should().Be(int.MaxValue);
        [Test] public void Int32Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(int.MinValue, int.MaxValue).Should().Be(int.MinValue);
        [Test] public void Int32Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((int)12, (int)12).Should().Be(144);
        [Test] public void Int32Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(int.MaxValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((int)12, (int)4).Should().Be(3);
        [Test] public void Int32Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextInt32(), (int)0).Should().Be(int.MaxValue);
        [Test] public void Int32Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((int)12, (int)5).Should().Be(2);
        [Test] public void Int32Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextInt32(), (int)0).Should().Be(0);
        [Test] public void Int32Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(int.MinValue, (int)3).Should().Be(int.MinValue);
        [Test] public void Int32Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(int.MaxValue, (int)2).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextInt32(), (int)0).Should().Be((int)1);

        [Test] public void Int64Add_SmokeTest_CorrectResult() => CheckedArithmetic.Add((long)12, (long)12).Should().Be(24);
        [Test] public void Int64Add_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Add_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(long.MinValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Subtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((long)12, (long)8).Should().Be(4);
        [Test] public void Int64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(long.MaxValue, long.MinValue).Should().Be(long.MaxValue);
        [Test] public void Int64Subtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(long.MinValue, long.MaxValue).Should().Be(long.MinValue);
        [Test] public void Int64Multiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((long)12, (long)12).Should().Be(144);
        [Test] public void Int64Multiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Multiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(long.MaxValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Divide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((long)12, (long)4).Should().Be(3);
        [Test] public void Int64Divide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextInt64WithoutBounds(), (long)0).Should().Be(long.MaxValue);
        [Test] public void Int64Remainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((long)12, (long)5).Should().Be(2);
        [Test] public void Int64Remainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextInt64WithoutBounds(), (long)0).Should().Be(0);
        [Test] public void Int64Pow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(long.MinValue, (long)3).Should().Be(long.MinValue);
        [Test] public void Int64Pow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(long.MaxValue, (long)2).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextInt64WithoutBounds(), (long)0).Should().Be((long)1);

        [Test] public void SByteAdd_SmokeTest_CorrectResult() => CheckedArithmetic.Add((sbyte)12, (sbyte)12).Should().Be(24);
        [Test] public void SByteAdd_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void SByteAdd_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(sbyte.MinValue, sbyte.MinValue).Should().Be(sbyte.MinValue);
        [Test] public void SByteSubtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((sbyte)12, (sbyte)8).Should().Be(4);
        [Test] public void SByteSubtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(sbyte.MaxValue, sbyte.MinValue).Should().Be(sbyte.MaxValue);
        [Test] public void SByteSubtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(sbyte.MinValue, sbyte.MaxValue).Should().Be(sbyte.MinValue);
        [Test] public void SByteMultiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((sbyte)12, (sbyte)4).Should().Be(48);
        [Test] public void SByteMultiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void SByteMultiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(sbyte.MaxValue, sbyte.MinValue).Should().Be(sbyte.MinValue);
        [Test] public void SByteDivide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((sbyte)12, (sbyte)4).Should().Be(3);
        [Test] public void SByteDivide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextSByte(), (sbyte)0).Should().Be(sbyte.MaxValue);
        [Test] public void SByteRemainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((sbyte)12, (sbyte)5).Should().Be(2);
        [Test] public void SByteRemainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextSByte(), (sbyte)0).Should().Be(0);
        [Test] public void SBytePow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(sbyte.MinValue, (sbyte)3).Should().Be(sbyte.MinValue);
        [Test] public void SBytePow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void SBytePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(sbyte.MaxValue, (sbyte)2).Should().Be(sbyte.MaxValue);
        [Test] public void SBytePow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextSByte(), (sbyte)0).Should().Be((sbyte)1);

        [Test] public void SingleAdd_SmokeTest_CorrectResult() => CheckedArithmetic.Add((float)12, (float)12).Should().Be(24);
        [Test] public void SingleAdd_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void SingleAdd_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(float.MinValue, float.MinValue).Should().Be(float.MinValue);
        [Test] public void SingleSubtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((float)12, (float)8).Should().Be(4);
        [Test] public void SingleSubtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(float.MaxValue, float.MinValue).Should().Be(float.MaxValue);
        [Test] public void SingleSubtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(float.MinValue, float.MaxValue).Should().Be(float.MinValue);
        [Test] public void SingleMultiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((float)12, (float)12).Should().Be(144);
        [Test] public void SingleMultiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void SingleMultiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(float.MaxValue, float.MinValue).Should().Be(float.MinValue);
        [Test] public void SingleDivide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((float)12, (float)4).Should().Be(3);
        [Test] public void SingleDivide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextSingle(), (float)0).Should().Be(float.MaxValue);
        [Test] public void SingleRemainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((float)12, (float)5).Should().Be(2);
        [Test] public void SingleRemainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextSingle(), (float)0).Should().Be(0);
        [Test] public void SinglePow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(float.MinValue, (float)3).Should().Be(float.MinValue);
        [Test] public void SinglePow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void SinglePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(float.MaxValue, (float)2).Should().Be(float.MaxValue);
        [Test] public void SinglePow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextSingle(), (float)0).Should().Be((float)1);

        [Test] public void DoubleAdd_NaN1_CorrectResult() => CheckedArithmetic.Add(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleAdd_NaN2_CorrectResult() => CheckedArithmetic.Add(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleAdd_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Add(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void DoubleAdd_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Add(double.MinValue, double.MinValue).Should().Be(double.MinValue);
        [Test] public void DoubleAdd_SmokeTest_CorrectResult() => CheckedArithmetic.Add((double)12, (double)12).Should().Be(24);
        [Test] public void DoubleDivide_ByZero_ReturnsMaxValue() => CheckedArithmetic.Divide(Random.NextDouble(), (double)0).Should().Be(double.MaxValue);
        [Test] public void DoubleDivide_NaN1_CorrectResult() => CheckedArithmetic.Divide(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleDivide_NaN2_CorrectResult() => CheckedArithmetic.Divide(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleDivide_SmokeTest_CorrectResult() => CheckedArithmetic.Divide((double)12, (double)4).Should().Be(3);
        [Test] public void DoubleMultiply_NaN1_CorrectResult() => CheckedArithmetic.Multiply(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleMultiply_NaN2_CorrectResult() => CheckedArithmetic.Multiply(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleMultiply_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Multiply(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void DoubleMultiply_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Multiply(double.MaxValue, double.MinValue).Should().Be(double.MinValue);
        [Test] public void DoubleMultiply_SmokeTest_CorrectResult() => CheckedArithmetic.Multiply((double)12, (double)12).Should().Be(144);
        [Test] public void DoublePow_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Pow(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void DoublePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => CheckedArithmetic.Pow(double.MaxValue, (double)2).Should().Be(double.MaxValue);
        [Test] public void DoublePow_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Pow(double.MinValue, (double)3).Should().Be(double.MinValue);
        [Test] public void DoublePow_Zero_ReturnsOne() => CheckedArithmetic.Pow(Random.NextDouble(), (double)0).Should().Be((double)1);
        [Test] public void DoubleRemainder_ByZero_ReturnsZero() => CheckedArithmetic.Remainder(Random.NextDouble(), (double)0).Should().Be(0);
        [Test] public void DoubleRemainder_NaN1_CorrectResult() => CheckedArithmetic.Remainder(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleRemainder_NaN2_CorrectResult() => CheckedArithmetic.Remainder(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleRemainder_SmokeTest_CorrectResult() => CheckedArithmetic.Remainder((double)12, (double)5).Should().Be(2);
        [Test] public void DoubleSubtract_NaN1_CorrectResult() => CheckedArithmetic.Subtract(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleSubtract_NaN2_CorrectResult() => CheckedArithmetic.Subtract(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleSubtract_OverflowFromMaxValue_ReturnsMaxValue() => CheckedArithmetic.Subtract(double.MaxValue, double.MinValue).Should().Be(double.MaxValue);
        [Test] public void DoubleSubtract_OverflowFromMinValue_ReturnsMinValue() => CheckedArithmetic.Subtract(double.MinValue, double.MaxValue).Should().Be(double.MinValue);
        [Test] public void DoubleSubtract_SmokeTest_CorrectResult() => CheckedArithmetic.Subtract((double)12, (double)8).Should().Be(4);
    }
}

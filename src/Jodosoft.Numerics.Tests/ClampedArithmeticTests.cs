// Copyright (c) 2023 Joe Lawry-Short
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
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public class ClampedArithmeticTests : GlobalFixtureBase
    {
        [Test] public void ByteAdd_SmokeTest_CorrectResult() => ClampedArithmetic.Add((byte)12, (byte)12).Should().Be(24);
        [Test] public void ByteAdd_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ByteAdd_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(byte.MinValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteSubtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract((byte)12, (byte)8).Should().Be(4);
        [Test] public void ByteSubtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(byte.MaxValue, byte.MinValue).Should().Be(byte.MaxValue);
        [Test] public void ByteSubtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(byte.MinValue, byte.MaxValue).Should().Be(byte.MinValue);
        [Test] public void ClampedByteultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply((byte)12, (byte)12).Should().Be(144);
        [Test] public void ClampedByteultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void ClampedByteultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(byte.MaxValue, byte.MinValue).Should().Be(byte.MinValue);
        [Test] public void ByteDivide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide((byte)12, (byte)4).Should().Be(3);
        [Test] public void ByteDivide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextByte(), (byte)0).Should().Be(byte.MaxValue);
        [Test] public void ByteRemainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder((byte)12, (byte)5).Should().Be(2);
        [Test] public void ByteRemainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextByte(), (byte)0).Should().Be(0);
        [Test] public void BytePow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(byte.MinValue, (byte)3).Should().Be(byte.MinValue);
        [Test] public void BytePow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(byte.MaxValue, byte.MaxValue).Should().Be(byte.MaxValue);
        [Test] public void BytePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(byte.MaxValue, (byte)2).Should().Be(byte.MaxValue);
        [Test] public void BytePow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextByte(), (byte)0).Should().Be(1);

        [Test] public void UInt16Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add((ushort)12, (ushort)12).Should().Be(24);
        [Test] public void UInt16Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(ushort.MinValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract((ushort)12, (ushort)8).Should().Be(4);
        [Test] public void UInt16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(ushort.MinValue, ushort.MaxValue).Should().Be(ushort.MinValue);
        [Test] public void ClampedUInt16ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply((ushort)12, (ushort)12).Should().Be(144);
        [Test] public void ClampedUInt16ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void ClampedUInt16ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(ushort.MaxValue, ushort.MinValue).Should().Be(ushort.MinValue);
        [Test] public void UInt16Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide((ushort)12, (ushort)4).Should().Be(3);
        [Test] public void UInt16Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextUInt16(), (ushort)0).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder((ushort)12, (ushort)5).Should().Be(2);
        [Test] public void UInt16Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextUInt16(), (ushort)0).Should().Be(0);
        [Test] public void UInt16Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(ushort.MinValue, (ushort)3).Should().Be(ushort.MinValue);
        [Test] public void UInt16Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(ushort.MaxValue, ushort.MaxValue).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(ushort.MaxValue, (ushort)2).Should().Be(ushort.MaxValue);
        [Test] public void UInt16Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextUInt16(), (ushort)0).Should().Be(1);

        [Test] public void UInt32Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, (uint)12).Should().Be(24);
        [Test] public void UInt32Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(uint.MinValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, (uint)8).Should().Be(4);
        [Test] public void UInt32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(uint.MaxValue, uint.MinValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(uint.MinValue, uint.MaxValue).Should().Be(uint.MinValue);
        [Test] public void ClampedUInt32ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, (uint)12).Should().Be(144);
        [Test] public void ClampedUInt32ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void ClampedUInt32ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(uint.MaxValue, uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void UInt32Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, (uint)4).Should().Be(3);
        [Test] public void UInt32Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextUInt32(), 0).Should().Be(uint.MaxValue);
        [Test] public void UInt32Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, (uint)5).Should().Be(2);
        [Test] public void UInt32Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextUInt32(), 0).Should().Be(0);
        [Test] public void UInt32Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(uint.MinValue, 3).Should().Be(uint.MinValue);
        [Test] public void UInt32Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(uint.MaxValue, uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(uint.MaxValue, 2).Should().Be(uint.MaxValue);
        [Test] public void UInt32Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextUInt32(), 0).Should().Be(1);

        [Test] public void UInt64Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, (ulong)12).Should().Be(24);
        [Test] public void UInt64Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(ulong.MinValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, (ulong)8).Should().Be(4);
        [Test] public void UInt64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(ulong.MinValue, ulong.MaxValue).Should().Be(ulong.MinValue);
        [Test] public void ClampedUInt64ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, (ulong)12).Should().Be(144);
        [Test] public void ClampedUInt64ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void ClampedUInt64ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(ulong.MaxValue, ulong.MinValue).Should().Be(ulong.MinValue);
        [Test] public void UInt64Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, (ulong)4).Should().Be(3);
        [Test] public void UInt64Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextUInt64(), 0).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, (ulong)5).Should().Be(2);
        [Test] public void UInt64Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextUInt64(), 0).Should().Be(0);
        [Test] public void UInt64Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(ulong.MinValue, 3).Should().Be(ulong.MinValue);
        [Test] public void UInt64Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(ulong.MaxValue, ulong.MaxValue).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(ulong.MaxValue, 2).Should().Be(ulong.MaxValue);
        [Test] public void UInt64Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextUInt64(), 0).Should().Be(1);

        [Test] public void Int16Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add((short)12, (short)12).Should().Be(24);
        [Test] public void Int16Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(short.MinValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract((short)12, (short)8).Should().Be(4);
        [Test] public void Int16Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(short.MaxValue, short.MinValue).Should().Be(short.MaxValue);
        [Test] public void Int16Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(short.MinValue, short.MaxValue).Should().Be(short.MinValue);
        [Test] public void ClampedInt16ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply((short)12, (short)12).Should().Be(144);
        [Test] public void ClampedInt16ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void ClampedInt16ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(short.MaxValue, short.MinValue).Should().Be(short.MinValue);
        [Test] public void Int16Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide((short)12, (short)4).Should().Be(3);
        [Test] public void Int16Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextInt16(), (short)0).Should().Be(short.MaxValue);
        [Test] public void Int16Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder((short)12, (short)5).Should().Be(2);
        [Test] public void Int16Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextInt16(), (short)0).Should().Be(0);
        [Test] public void Int16Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(short.MinValue, (short)3).Should().Be(short.MinValue);
        [Test] public void Int16Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(short.MaxValue, short.MaxValue).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(short.MaxValue, (short)2).Should().Be(short.MaxValue);
        [Test] public void Int16Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextInt16(), (short)0).Should().Be(1);

        [Test] public void Int32Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, 12).Should().Be(24);
        [Test] public void Int32Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(int.MinValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, 8).Should().Be(4);
        [Test] public void Int32Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(int.MaxValue, int.MinValue).Should().Be(int.MaxValue);
        [Test] public void Int32Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(int.MinValue, int.MaxValue).Should().Be(int.MinValue);
        [Test] public void ClampedInt32ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, 12).Should().Be(144);
        [Test] public void ClampedInt32ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void ClampedInt32ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(int.MaxValue, int.MinValue).Should().Be(int.MinValue);
        [Test] public void Int32Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, 4).Should().Be(3);
        [Test] public void Int32Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextInt32(), 0).Should().Be(int.MaxValue);
        [Test] public void Int32Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, 5).Should().Be(2);
        [Test] public void Int32Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextInt32(), 0).Should().Be(0);
        [Test] public void Int32Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(int.MinValue, 3).Should().Be(int.MinValue);
        [Test] public void Int32Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(int.MaxValue, int.MaxValue).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(int.MaxValue, 2).Should().Be(int.MaxValue);
        [Test] public void Int32Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextInt32(), 0).Should().Be(1);

        [Test] public void Int64Add_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, (long)12).Should().Be(24);
        [Test] public void Int64Add_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Add_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(long.MinValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Subtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, (long)8).Should().Be(4);
        [Test] public void Int64Subtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(long.MaxValue, long.MinValue).Should().Be(long.MaxValue);
        [Test] public void Int64Subtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(long.MinValue, long.MaxValue).Should().Be(long.MinValue);
        [Test] public void ClampedInt64ultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, (long)12).Should().Be(144);
        [Test] public void ClampedInt64ultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void ClampedInt64ultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(long.MaxValue, long.MinValue).Should().Be(long.MinValue);
        [Test] public void Int64Divide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, (long)4).Should().Be(3);
        [Test] public void Int64Divide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextInt64(), 0).Should().Be(long.MaxValue);
        [Test] public void Int64Remainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, (long)5).Should().Be(2);
        [Test] public void Int64Remainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextInt64(), 0).Should().Be(0);
        [Test] public void Int64Pow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(long.MinValue, 3).Should().Be(long.MinValue);
        [Test] public void Int64Pow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(long.MaxValue, long.MaxValue).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(long.MaxValue, 2).Should().Be(long.MaxValue);
        [Test] public void Int64Pow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextInt64(), 0).Should().Be(1);

        [Test] public void SByteAdd_SmokeTest_CorrectResult() => ClampedArithmetic.Add((sbyte)12, (sbyte)12).Should().Be(24);
        [Test] public void SByteAdd_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void SByteAdd_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(sbyte.MinValue, sbyte.MinValue).Should().Be(sbyte.MinValue);
        [Test] public void SByteSubtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract((sbyte)12, (sbyte)8).Should().Be(4);
        [Test] public void SByteSubtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(sbyte.MaxValue, sbyte.MinValue).Should().Be(sbyte.MaxValue);
        [Test] public void SByteSubtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(sbyte.MinValue, sbyte.MaxValue).Should().Be(sbyte.MinValue);
        [Test] public void ClampedSByteultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply((sbyte)12, (sbyte)4).Should().Be(48);
        [Test] public void ClampedSByteultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void ClampedSByteultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(sbyte.MaxValue, sbyte.MinValue).Should().Be(sbyte.MinValue);
        [Test] public void SByteDivide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide((sbyte)12, (sbyte)4).Should().Be(3);
        [Test] public void SByteDivide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextSByte(), (sbyte)0).Should().Be(sbyte.MaxValue);
        [Test] public void SByteRemainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder((sbyte)12, (sbyte)5).Should().Be(2);
        [Test] public void SByteRemainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextSByte(), (sbyte)0).Should().Be(0);
        [Test] public void SBytePow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(sbyte.MinValue, (sbyte)3).Should().Be(sbyte.MinValue);
        [Test] public void SBytePow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(sbyte.MaxValue, sbyte.MaxValue).Should().Be(sbyte.MaxValue);
        [Test] public void SBytePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(sbyte.MaxValue, (sbyte)2).Should().Be(sbyte.MaxValue);
        [Test] public void SBytePow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextSByte(), (sbyte)0).Should().Be(1);

        [Test] public void SingleAdd_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, (float)12).Should().Be(24);
        [Test] public void SingleAdd_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void SingleAdd_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(float.MinValue, float.MinValue).Should().Be(float.MinValue);
        [Test] public void SingleSubtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, (float)8).Should().Be(4);
        [Test] public void SingleSubtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(float.MaxValue, float.MinValue).Should().Be(float.MaxValue);
        [Test] public void SingleSubtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(float.MinValue, float.MaxValue).Should().Be(float.MinValue);
        [Test] public void ClampedSingleultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, (float)12).Should().Be(144);
        [Test] public void ClampedSingleultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void ClampedSingleultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(float.MaxValue, float.MinValue).Should().Be(float.MinValue);
        [Test] public void SingleDivide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, (float)4).Should().Be(3);
        [Test] public void SingleDivide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextSingle(), 0).Should().Be(float.MaxValue);
        [Test] public void SingleRemainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, (float)5).Should().Be(2);
        [Test] public void SingleRemainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextSingle(), 0).Should().Be(0);
        [Test] public void SinglePow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(float.MinValue, 3).Should().Be(float.MinValue);
        [Test] public void SinglePow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(float.MaxValue, float.MaxValue).Should().Be(float.MaxValue);
        [Test] public void SinglePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(float.MaxValue, 2).Should().Be(float.MaxValue);
        [Test] public void SinglePow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextSingle(), 0).Should().Be(1);

        [Test] public void DoubleAdd_NaN1_CorrectResult() => ClampedArithmetic.Add(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleAdd_NaN2_CorrectResult() => ClampedArithmetic.Add(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleAdd_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Add(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void DoubleAdd_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Add(double.MinValue, double.MinValue).Should().Be(double.MinValue);
        [Test] public void DoubleAdd_SmokeTest_CorrectResult() => ClampedArithmetic.Add(12, (double)12).Should().Be(24);
        [Test] public void DoubleDivide_ByZero_ReturnsMaxValue() => ClampedArithmetic.Divide(Random.NextDouble(), 0).Should().Be(double.MaxValue);
        [Test] public void DoubleDivide_NaN1_CorrectResult() => ClampedArithmetic.Divide(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleDivide_NaN2_CorrectResult() => ClampedArithmetic.Divide(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleDivide_SmokeTest_CorrectResult() => ClampedArithmetic.Divide(12, (double)4).Should().Be(3);
        [Test] public void ClampedDoubleultiply_NaN1_CorrectResult() => ClampedArithmetic.Multiply(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void ClampedDoubleultiply_NaN2_CorrectResult() => ClampedArithmetic.Multiply(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void ClampedDoubleultiply_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Multiply(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void ClampedDoubleultiply_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Multiply(double.MaxValue, double.MinValue).Should().Be(double.MinValue);
        [Test] public void ClampedDoubleultiply_SmokeTest_CorrectResult() => ClampedArithmetic.Multiply(12, (double)12).Should().Be(144);
        [Test] public void DoublePow_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Pow(double.MaxValue, double.MaxValue).Should().Be(double.MaxValue);
        [Test] public void DoublePow_OverflowFromMaxValueBoundary_ReturnsMaxValue() => ClampedArithmetic.Pow(double.MaxValue, 2).Should().Be(double.MaxValue);
        [Test] public void DoublePow_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Pow(double.MinValue, 3).Should().Be(double.MinValue);
        [Test] public void DoublePow_Zero_ReturnsOne() => ClampedArithmetic.Pow(Random.NextDouble(), 0).Should().Be(1);
        [Test] public void DoubleRemainder_ByZero_ReturnsZero() => ClampedArithmetic.Remainder(Random.NextDouble(), 0).Should().Be(0);
        [Test] public void DoubleRemainder_NaN1_CorrectResult() => ClampedArithmetic.Remainder(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleRemainder_NaN2_CorrectResult() => ClampedArithmetic.Remainder(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleRemainder_SmokeTest_CorrectResult() => ClampedArithmetic.Remainder(12, (double)5).Should().Be(2);
        [Test] public void DoubleSubtract_NaN1_CorrectResult() => ClampedArithmetic.Subtract(double.NaN, Random.NextDouble()).Should().Be(0);
        [Test] public void DoubleSubtract_NaN2_CorrectResult() => ClampedArithmetic.Subtract(Random.NextDouble(), double.NaN).Should().Be(0);
        [Test] public void DoubleSubtract_OverflowFromMaxValue_ReturnsMaxValue() => ClampedArithmetic.Subtract(double.MaxValue, double.MinValue).Should().Be(double.MaxValue);
        [Test] public void DoubleSubtract_OverflowFromMinValue_ReturnsMinValue() => ClampedArithmetic.Subtract(double.MinValue, double.MaxValue).Should().Be(double.MinValue);
        [Test] public void DoubleSubtract_SmokeTest_CorrectResult() => ClampedArithmetic.Subtract(12, (double)8).Should().Be(4);
    }
}

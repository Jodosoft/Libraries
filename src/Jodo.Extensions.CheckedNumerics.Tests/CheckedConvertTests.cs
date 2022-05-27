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

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public class CheckedConvertTests : GlobalTestBase
    {
        [Test] public void SingleToUInt32_SmokeTest_CorrectResult() => CheckedConvert.ToUInt32((float)999999).Should().Be(999999);
        [Test] public void SingleToUInt32_PositiveMaximumPrecision_CorrectResult() => CheckedConvert.ToUInt32(4294967167f).Should().Be(4294967040);
        [Test] public void SingleToUInt32_MinValue_CorrectResult() => CheckedConvert.ToUInt32((float)uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void SingleToUInt32_NaN_ReturnsZero() => CheckedConvert.ToUInt32(float.NaN).Should().Be(0);
        [Test] public void SingleToUInt32_PositiveInfinity_ReturnsMaxValue() => CheckedConvert.ToUInt32(float.PositiveInfinity).Should().Be(uint.MaxValue);
        [Test] public void SingleToUInt32_NegativeInfinity_ReturnsMinValue() => CheckedConvert.ToUInt32(float.NegativeInfinity).Should().Be(uint.MinValue);
        [Test] public void SingleToUInt32_OverflowFromMaxValue_ReturnsMaxValue() => CheckedConvert.ToUInt32((float)uint.MaxValue + 1).Should().Be(uint.MaxValue);
        [Test] public void SingleToUInt32_OverflowFromMinValue_ReturnsMinValue() => CheckedConvert.ToUInt32((float)uint.MinValue - 1).Should().Be(uint.MinValue);

        [Test] public void DoubleToUInt32_SmokeTest_CorrectResult() => CheckedConvert.ToUInt32((double)999999).Should().Be(999999);
        [Test] public void DoubleToUInt32_MaxValue_CorrectResult() => CheckedConvert.ToUInt32((double)uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_MinValue_CorrectResult() => CheckedConvert.ToUInt32((double)uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_NegativeValue_ReturnsZero() => CheckedConvert.ToUInt32((double)-Random.NextDouble()).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_NaN_ReturnsZero() => CheckedConvert.ToUInt32(double.NaN).Should().Be(0);
        [Test] public void DoubleToUInt32_PositiveInfinity_ReturnsMaxValue() => CheckedConvert.ToUInt32(double.PositiveInfinity).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_NegativeInfinity_ReturnsMinValue() => CheckedConvert.ToUInt32(double.NegativeInfinity).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_OverflowFromMaxValue_ReturnsMaxValue() => CheckedConvert.ToUInt32((double)uint.MaxValue + 1).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_OverflowFromMinValue_ReturnsMinValue() => CheckedConvert.ToUInt32((double)uint.MinValue - 1).Should().Be(uint.MinValue);

        [Test]
        public void AllNumericConversions_RandomSmallValue_ReturnsCorrectResult()
        {
            //arrange
            var input = Random.NextByte(0, 127);

            //act
            //assert
            CheckedConvert.ToByte(CheckedConvert.ToDecimal(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64(input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((decimal)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((decimal)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((double)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((double)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte(input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((short)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((short)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((int)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((int)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((long)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((long)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((sbyte)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((sbyte)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((float)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((float)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((ushort)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((ushort)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((uint)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt64((uint)input)).Should().Be(input);

            CheckedConvert.ToByte(CheckedConvert.ToByte((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDecimal((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToDouble((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt16((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt32((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToInt64((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSByte((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToSingle((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt16((ulong)input)).Should().Be(input);
            CheckedConvert.ToByte(CheckedConvert.ToUInt32((ulong)input)).Should().Be(input);
        }
    }
}

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
    public class CheckedCastTests : GlobalFixtureBase
    {
        [Test] public void SingleToUInt32_SmokeTest_CorrectResult() => CheckedCast.ToUInt32((float)999999).Should().Be(999999);
        [Test] public void SingleToUInt32_PositiveMaximumPrecision_CorrectResult() => CheckedCast.ToUInt32(4294967167f).Should().Be(4294967040);
        [Test] public void SingleToUInt32_MinValue_CorrectResult() => CheckedCast.ToUInt32((float)uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void SingleToUInt32_NaN_ReturnsZero() => CheckedCast.ToUInt32(float.NaN).Should().Be(0);
        [Test] public void SingleToUInt32_PositiveInfinity_ReturnsMaxValue() => CheckedCast.ToUInt32(float.PositiveInfinity).Should().Be(uint.MaxValue);
        [Test] public void SingleToUInt32_NegativeInfinity_ReturnsMinValue() => CheckedCast.ToUInt32(float.NegativeInfinity).Should().Be(uint.MinValue);
        [Test] public void SingleToUInt32_OverflowFromMaxValue_ReturnsMaxValue() => CheckedCast.ToUInt32((float)uint.MaxValue + 1).Should().Be(uint.MaxValue);
        [Test] public void SingleToUInt32_OverflowFromMinValue_ReturnsMinValue() => CheckedCast.ToUInt32((float)uint.MinValue - 1).Should().Be(uint.MinValue);

        [Test] public void DoubleToUInt32_SmokeTest_CorrectResult() => CheckedCast.ToUInt32((double)999999).Should().Be(999999);
        [Test] public void DoubleToUInt32_MaxValue_CorrectResult() => CheckedCast.ToUInt32((double)uint.MaxValue).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_MinValue_CorrectResult() => CheckedCast.ToUInt32((double)uint.MinValue).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_NegativeValue_ReturnsZero() => CheckedCast.ToUInt32((double)-Random.NextDouble()).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_NaN_ReturnsZero() => CheckedCast.ToUInt32(double.NaN).Should().Be(0);
        [Test] public void DoubleToUInt32_PositiveInfinity_ReturnsMaxValue() => CheckedCast.ToUInt32(double.PositiveInfinity).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_NegativeInfinity_ReturnsMinValue() => CheckedCast.ToUInt32(double.NegativeInfinity).Should().Be(uint.MinValue);
        [Test] public void DoubleToUInt32_OverflowFromMaxValue_ReturnsMaxValue() => CheckedCast.ToUInt32((double)uint.MaxValue + 1).Should().Be(uint.MaxValue);
        [Test] public void DoubleToUInt32_OverflowFromMinValue_ReturnsMinValue() => CheckedCast.ToUInt32((double)uint.MinValue - 1).Should().Be(uint.MinValue);

        [Test]
        public void AllNumericConversions_RandomSmallValue_ReturnsCorrectResult()
        {
            //arrange
            var input = Random.NextByte(0, 127);

            //act
            //assert
            CheckedCast.ToByte(CheckedCast.ToDecimal(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64(input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((decimal)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((decimal)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((double)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((double)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte(input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((short)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((short)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((int)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((int)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((long)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((long)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((sbyte)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((sbyte)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((float)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((float)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((ushort)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((ushort)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((uint)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt64((uint)input)).Should().Be(input);

            CheckedCast.ToByte(CheckedCast.ToByte((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDecimal((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToDouble((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt16((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt32((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToInt64((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSByte((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToSingle((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt16((ulong)input)).Should().Be(input);
            CheckedCast.ToByte(CheckedCast.ToUInt32((ulong)input)).Should().Be(input);
        }
    }
}

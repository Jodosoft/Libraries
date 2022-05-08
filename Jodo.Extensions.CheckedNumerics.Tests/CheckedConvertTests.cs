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
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    [SuppressMessage("Style", "IDE0004:Cast is redundant")]
    public class CheckedConvertTests : AssemblyTestBase
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

    }
}

﻿// Copyright (c) 2022 Joseph J. Short
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
using Jodo.Extensions.Benchmarking;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.CheckedNumerics.Benchmarks
{
    [Timeout((DurationInSeconds + 5) * 1000)]
    public class CIntBenchmarks : GlobalBenchmarkBase
    {
        private const int DurationInSeconds = 30;

        [Test]
        public void CInt_Versus_Int32_Negation()
        {
            //arrange
            var baseline = Random.NextInt32(100, 1000);
            var sut = (cint)baseline;

            //act
            var result = Benchmark.Compare(() => -sut, () => -baseline, DurationInSeconds);

            //assert
            result.TimesSlower.Should().BeLessThan(4);
        }

        [Test]
        public void CInt_Versus_Int32_Division()
        {
            //arrange
            var baselineLeft = Random.NextInt32(100, 1000);
            var baselineRight = Random.NextInt32(2, 10);
            var sutLeft = (cint)baselineLeft;
            var sutRight = (cint)baselineRight;

            //act
            var result = Benchmark.Compare(() => sutLeft / sutRight, () => baselineLeft / baselineRight, DurationInSeconds);

            //assert
            result.TimesSlower.Should().BeLessThan(4);
        }

        [Test]
        public void CInt_Versus_Int32_ConversionToFloat()
        {
            //arrange
            var baseline = Random.NextInt32(100, 1000);
            var sut = (cint)baseline;

            //act
            var result = Benchmark.Compare(() => (float)sut, () => (float)baseline, DurationInSeconds);

            //assert
            result.TimesSlower.Should().BeLessThan(4);
        }

        [Test]
        public void CInt_Versus_Int32_StringParsing()
        {
            //arrange
            var input = Random.NextInt32(-100, 100).ToString();

            //act
            var result = Benchmark.Compare(() => cint.Parse(input), () => int.Parse(input), DurationInSeconds);

            //assert
            result.TimesSlower.Should().BeLessThan(4);
        }

        [Test]
        public void CInt_Versus_Int32_Overflow()
        {
            //arrange
            var functionInput = cint.MaxValue;
            var baselineInput = int.MaxValue;

            //act
            var result = Benchmark.Compare(() => functionInput * functionInput, () => baselineInput * baselineInput, DurationInSeconds);

            //assert
            result.TimesSlower.Should().BeLessThan(4);
        }
    }
}

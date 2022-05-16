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

using Jodo.Extensions.Benchmarking;
using System;

namespace Jodo.Extensions.Numerics.Benchmarks
{
    public static class GShortBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public static void GShort_Versus_Int16_Negation()
        {
            var baseline = Random.NextInt16(100, 1000);
            var sut = (xshort)baseline;

            Benchmark.Run(
                () => -sut,
                () => -baseline);
        }

        [Benchmark]
        public static void GShort_Versus_Int16_Division()
        {
            var baselineLeft = Random.NextInt16(100, 1000);
            var baselineRight = Random.NextInt16(2, 10);
            var sutLeft = (xshort)baselineLeft;
            var sutRight = (xshort)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void GShort_Versus_Int16_ConversionToFloat()
        {
            var baseline = Random.NextInt16(100, 1000);
            var sut = (xshort)baseline;

            Benchmark.Run(
                () => (float)sut,
                () => (float)baseline);
        }

        [Benchmark]
        public static void GShort_Versus_Int16_StringParsing()
        {
            var input = Random.NextInt16(-100, 100).ToString();

            Benchmark.Run(
                () => xshort.Parse(input),
                () => short.Parse(input));
        }

        [Benchmark]
        public static void GShort_Versus_Int16_Overflow()
        {
            var functionInput = xshort.MaxValue;
            var baselineInput = short.MaxValue;

            Benchmark.Run(
                () => functionInput * functionInput,
                () => baselineInput * baselineInput);
        }
    }
}

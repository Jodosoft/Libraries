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
using Jodo.Extensions.Benchmarking;

namespace Jodo.Extensions.CheckedNumerics.Benchmarks
{
    [ExcludeFromCodeCoverage]
    public static class CIntBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public static void CInt_Negation_Vs_Int()
        {
            int baseline = Random.NextInt32(100, 1000);
            cint sut = (cint)baseline;

            Benchmark.Run(
                () => -sut,
                () => -baseline);
        }

        [Benchmark]
        public static void CInt_Division_Vs_Int()
        {
            int baselineLeft = Random.NextInt32(100, 1000);
            int baselineRight = Random.NextInt32(2, 10);
            cint sutLeft = (cint)baselineLeft;
            cint sutRight = (cint)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void CInt_ConversionToFloat_Vs_Int()
        {
            int baseline = Random.NextInt32(100, 1000);
            cint sut = (cint)baseline;

            Benchmark.Run(
                () => (float)sut,
                () => (float)baseline);
        }

        [Benchmark]
        public static void CInt_StringParsing_Vs_Int()
        {
            string input = Random.NextInt32(-100, 100).ToString();

            Benchmark.Run(
                () => cint.Parse(input),
                () => int.Parse(input));
        }

        [Benchmark]
        public static void CInt_MultiplicationOverflow_Vs_Int()
        {
            cint functionInput = cint.MaxValue;
            int baselineInput = int.MaxValue;

            Benchmark.Run(
                () => functionInput * functionInput,
                () => baselineInput * baselineInput);
        }
    }
}

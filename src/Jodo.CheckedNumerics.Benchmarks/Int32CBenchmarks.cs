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
using Jodo.Benchmarking;
using Jodo.Primitives;

namespace Jodo.CheckedNumerics.Benchmarks
{
    [ExcludeFromCodeCoverage]
    public static class Int32CBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public static void Int32C_Negation_Vs_Int()
        {
            int baseline = Random.NextInt32(100, 1000);
            Int32C sut = (Int32C)baseline;

            Benchmark.Run(
                () => -sut,
                () => -baseline);
        }

        [Benchmark]
        public static void Int32C_Division_Vs_Int()
        {
            int baselineLeft = Random.NextInt32(100, 1000);
            int baselineRight = Random.NextInt32(2, 10);
            Int32C sutLeft = (Int32C)baselineLeft;
            Int32C sutRight = (Int32C)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void Int32C_ConversionToFloat_Vs_Int()
        {
            int baseline = Random.NextInt32(100, 1000);
            Int32C sut = (Int32C)baseline;

            Benchmark.Run(
                () => (float)sut,
                () => (float)baseline);
        }

        [Benchmark]
        public static void Int32C_StringParsing_Vs_Int()
        {
            string input = Random.NextInt32(-100, 100).ToString();

            Benchmark.Run(
                () => Int32C.Parse(input),
                () => int.Parse(input));
        }

        [Benchmark]
        public static void Int32C_MultiplicationOverflow_Vs_Int()
        {
            Int32C functionInput = Int32C.MaxValue;
            int baselineInput = int.MaxValue;

            Benchmark.Run(
                () => functionInput * functionInput,
                () => baselineInput * baselineInput);
        }
    }
}

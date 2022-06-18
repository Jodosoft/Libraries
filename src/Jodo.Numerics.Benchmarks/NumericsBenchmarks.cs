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

namespace Jodo.Numerics.Benchmarks
{
    [ExcludeFromCodeCoverage]
    public static class NumericsBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public static void XInt_Versus_Int32_Division()
        {
            int baselineLeft = Random.NextInt32(100, 1000);
            int baselineRight = Random.NextInt32(2, 10);
            xint sutLeft = (xint)baselineLeft;
            xint sutRight = (xint)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void XInt_Versus_Int32_ConversionToFloat()
        {
            int baseline = Random.NextInt32(100, 1000);
            xint sut = (xint)baseline;

            Benchmark.Run(
                () => (float)sut,
                () => (float)baseline);
        }

        [Benchmark]
        public static void XInt_Versus_Int32_StringParsing()
        {
            string input = Random.NextInt32(-100, 100).ToString();

            Benchmark.Run(
                () => xint.Parse(input),
                () => int.Parse(input));
        }

        [Benchmark]
        public static void XInt_Versus_Int32_Overflow()
        {
            xint functionInput = xint.MaxValue;
            int baselineInput = int.MaxValue;

            Benchmark.Run(
                () => functionInput * functionInput,
                () => baselineInput * baselineInput);
        }

        [Benchmark]
        public static void XDouble_Versus_Double_Division()
        {
            double baselineLeft = Random.NextDouble(100, 1000);
            double baselineRight = Random.NextDouble(2, 10);
            xdouble sutLeft = (xdouble)baselineLeft;
            xdouble sutRight = (xdouble)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void XDouble_Versus_Double_StringParsing()
        {
            string input = Random.NextDouble(-100, 100).ToString();

            Benchmark.Run(
                () => xdouble.Parse(input),
                () => double.Parse(input));
        }

        [Benchmark]
        public static void Fix64_Versus_Double_Division()
        {
            double baselineLeft = Random.NextDouble(100, 1000);
            double baselineRight = Random.NextDouble(2, 10);
            fix64 sutLeft = (fix64)baselineLeft;
            fix64 sutRight = (fix64)baselineRight;

            Benchmark.Run(
                () => sutLeft / sutRight,
                () => baselineLeft / baselineRight);
        }

        [Benchmark]
        public static void Fix64_Versus_Double_StringParsing()
        {
            string input = Random.NextDouble(-100, 100).ToString();

            Benchmark.Run(
                () => fix64.Parse(input),
                () => double.Parse(input));
        }
    }
}

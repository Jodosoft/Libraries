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
using System.Diagnostics;

namespace Jodosoft.Benchmarking
{
    public class Benchmark<T> : Benchmark
    {
        public Func<T> DataFactory { get; }
        public Func<T, object> Subject1 { get; }
        public Func<T, object> Subject2 { get; }

        public Benchmark(string name, Func<T> dataFactory, Func<T, object> subject1, Func<T, object> subject2) : base(name)
        {
            DataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
            Subject2 = subject2 ?? throw new ArgumentNullException(nameof(subject2));
            Subject1 = subject1 ?? throw new ArgumentNullException(nameof(subject1));
        }

        public override BenchmarkResult Execute(TimeSpan duration)
        {
            (Count Subject1, Count Subject2) measurements = Counter.Measure(DataFactory, Subject1, Subject2, duration);

            return new BenchmarkResult(Name, measurements.Subject1, measurements.Subject2);
        }
    }

    public abstract class Benchmark
    {
        public string Name { get; }

        protected Benchmark(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public abstract BenchmarkResult Execute(TimeSpan duration);

        public static BenchmarkBuilder.WithNameAndData<T> Using<T>(Func<T> factory)
        {
            return new BenchmarkBuilder.WithNameAndData<T>(new StackTrace().GetFrame(1).GetMethod().Name, factory);
        }

        public static BenchmarkBuilder.WithNameAndData<T> UsingData<T>(T value)
        {
            return new BenchmarkBuilder.WithNameAndData<T>(new StackTrace().GetFrame(1).GetMethod().Name, () => value);
        }
    }
}

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

namespace Jodosoft.Benchmarking
{
    public static class BenchmarkBuilder
    {
        public sealed class WithNameAndData<T>
        {
            public string Name { get; }
            public Func<T> DataFactory { get; }

            public WithNameAndData(string name, Func<T> dataFactory)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                DataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
            }

            public WithNameDataAndSubject1<T> Measure(Func<T, object> subject1)
            {
                return new WithNameDataAndSubject1<T>(Name, DataFactory, subject1);
            }
        }

        public class WithNameDataAndSubject1<T>
        {
            public string Name { get; }
            public Func<T> DataFactory { get; }
            public Func<T, object> Subject1 { get; }

            public WithNameDataAndSubject1(string name, Func<T> dataFactory, Func<T, object> subject1)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                DataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
                Subject1 = subject1 ?? throw new ArgumentNullException(nameof(subject1));
            }

            public Benchmark<T> Versus(Func<T, object> subject2)
            {
                return new Benchmark<T>(Name, DataFactory, Subject1, subject2);
            }
        }
    }
}

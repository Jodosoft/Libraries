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
using System.Collections.Generic;

namespace Jodosoft.Benchmarking
{
    public sealed class BenchmarkResult : IEquatable<BenchmarkResult>
    {
        public string Name { get; }
        public Count Subject1 { get; }
        public Count Subject2 { get; }

        public BenchmarkResult(string name, Count subject1, Count subject2)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must not be null, empty or whitespace.", nameof(name));
            Name = name;
            Subject1 = subject1;
            Subject2 = subject2;
        }

        public override bool Equals(object obj) => Equals(obj as BenchmarkResult);
        public bool Equals(BenchmarkResult other) => other != null && Name == other.Name && Subject2.Equals(other.Subject2) && Subject1.Equals(other.Subject1);
        public override int GetHashCode() => HashCode.Combine(Name, Subject2, Subject1);

        public static bool operator ==(BenchmarkResult left, BenchmarkResult right) => EqualityComparer<BenchmarkResult>.Default.Equals(left, right);
        public static bool operator !=(BenchmarkResult left, BenchmarkResult right) => !(left == right);
    }
}

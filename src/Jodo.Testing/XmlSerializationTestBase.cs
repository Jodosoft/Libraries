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

using System.IO;
using System.Text;
using System.Xml.Serialization;
using FluentAssertions;
using Jodo.Primitives;
using NUnit.Framework;

namespace Jodo.Testing
{
    public abstract class XmlSerializationTestBase<T> : GlobalFixtureBase where T : struct, IProvider<IVariantRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void Serialize_RandomValue_ReturnsFalse()
        {
            //arrange
            T input = Random.NextVariant<T>();
            StringBuilder target = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StringWriter(target);

            //act
            serializer.Serialize(writer, input);
            writer.Close();
            string result = target.ToString();

            //assert
            result.Should().Contain(input.ToString());
        }
    }
}

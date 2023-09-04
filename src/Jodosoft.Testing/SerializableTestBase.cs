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

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FluentAssertions;
using Jodosoft.Primitives;
using NUnit.Framework;

namespace Jodosoft.Testing
{
    /// <summary>
    /// Provides common test methods for structs that implement <see cref="ISerializable"/>.
    /// </summary>
    /// <typeparam name="T">The type that implements <see cref="ISerializable"/>.</typeparam>
    [SuppressMessage("csharpsquid", "S5773:Restrict types of objects allowed to be deserialized.", Justification = "Left unrestricted for testing purposes only.")]
    public abstract class SerializableTestBase<T> : GlobalFixtureBase where T : struct, ISerializable, IProvider<IVariantRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void Serialize_RoundTrip_SameAsOriginal()
        {
            //arrange
            T input = Random.NextVariant<T>(Variants.NonError);
            BinaryFormatter formatter = new BinaryFormatter();

            //act
            T result;
            using (MemoryStream stream = new MemoryStream())
            {
#pragma warning disable IDE0079 // Remove unnecessary suppression - Justification: Warning below not raised in all target frameworks
#pragma warning disable SYSLIB0011 // Type or member is obsolete - Justification: For test
                formatter.Serialize(stream, input);
                stream.Position = 0;
                result = (T)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
#pragma warning restore IDE0079 // Remove unnecessary suppression
            }

            //assert
            result.Should().Be(input);
        }
    }
}

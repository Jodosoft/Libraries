# Jodo.Extensions <img src="PackageIcon.png" alt="Logo" height="128"/>

[![Test](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml) [![CodeQL](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml)

Useful C# libraries written in the style of the .NET SDK.

## Jodo.Extensions.CheckedNumerics

> Note: This package contains work in progress.

Provides numeric value types and utilities that protect from overflow. Useful for preventing unexpected negative/positive, infinite or `NaN` values. 

### Numeric value types

> Note: These types increases CPU and memory usage compared to using built-in numeric types. See the [Performance](#performance) section for more details.

Usage is the same as with built-in numeric types, but with different results in cases of overflow and division by zero, as demonstrated by the following code example:
```csharp
var x = cint.MaxValue + 1;
Console.WriteLine(x);  // output: 2147483647

var x = (cfloat)4 / 0;
Console.WriteLine(x);  // output: 3.402823E+38
```

The following table summarizes the types available and their behaviour:

| Type | Underlying CLR type | Behaviour |
| - | - | - |
| `cint`<br />`ucint` | `int`<br />`uint` | <ul><li>Uses a [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) context to perform arithmetic.</li><li>Operations that would overflow do NOT throw an [OverflowException](https://docs.microsoft.com/en-us/dotnet/api/system.overflowexception) but return `MinValue` or `MaxValue` depending on the direction of the overflow.</li><li>Division by zero does NOT throw a [DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception) but returns `MaxValue`.</li></ul> |
| `cfloat`<br />`cdouble` | `float`<br />`double` | <ul><li>Operations that would overflow do NOT return `NegativeInfinity` or `PositiveInfinity` but return `MinValue` or `MaxValue` respectively.</li><li>Division by zero does NOT return `NegativeInfinity`, `PositiveInfinity` or `NaN` but returns `MaxValue`.</li><li>It is not possible for values to be `NegativeInfinity`, `PositiveInfinity` or `NaN`.</li></ul> |
| `fix64`<br />`ufix64` | `long`<br />`long` | <ul><li>A fixed-precision number with a 40 bit integral part and a 24 bit mantissa.</li><li>Useful in systems where high precision is required regardless of magnitude.</li></ul> |

### Other types

| Type | Description |
| - | - |
| `INumeric<T>` | <ul><li>Implemented by all value [numeric value types](#numeric-value-types).</li><li>Allows for the creation of generic numerical systems.</li><li>Can be implmented to create further user-defined numeric value types.</li></ul> |
| `Math<T>` | <ul><li>A static class that provides equivalents to functions to [Math](https://docs.microsoft.com/en-us/dotnet/api/system.math), e.g. `Log(T)`, `Pow(T)`, `Sqrt(T)`, etc.</li><li>Available for all types that implement `INumeric<T>` including user-defined types.</li></ul> |
| `BitConverter<T>` | <ul><li>A static class similar to [BitConverter](https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter) that provides conversion to and from `ReadOnlySpan<byte>`.</li><li>Available for all types that implement `INumeric<T>` including user-defined types.</li></ul> |
| `StringFormatter<T>` | <ul><li>A static class that provides string parsing and formatting methods.</li><li>Available for all types that implement `INumeric<T>` including user-defined types.</li></ul> |

### Other features

| Feature | Notes |
| - | - |
|  Operator overloading  | <ul><li>`==`, `!=`, `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/` and `%` are overloaded, allowing for use in expressions.</li><li>`&`, `\|`, `^`, `~`, `<<` and `>>` are overloaded for types based on integral primitives.</li><li>Implicit conversions from built-in numeric types are provided, allowing use in expressions with numeric literals.</li><li>The `INumeric<T>` interface defines overloads for arithmetic and comparison operators, allowing for limited expressions in a generic context (Note: equality and conversion operators are not supported on interfaces).</li></ul> |
| Float conversion | <ul><li>A method on INumeric\<T\>, `float Approximate(float offset)`, provides easy conversion to floats.</li><li>For use in graphical applications.</li></ul> |
| Formattable | <ul><li>All numeric value types implement [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable) and can be used with [standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).</li></ul> |
| Random generation | <ul><li>An extension method for [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random), `NextNumeric\<T\>`, provides randomly generated values.</li><li>Available for all types that implement INumeric\<T\> including user-defined types.</li><li>Values can be generated between two bounds or without bounds.</li></ul> |
| Serialization | <ul><li>All numeric types implement [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable), have the [Serializable](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute) and a deserialization constructor.</li></ul> |
| _Miscellaneous_ | <ul><li>All CheckedNumerics value types implement [IEquatable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1), [IComparable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1) and [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), override `EqualTo(object)`, `GetHashCode()` and `ToString()` and have a [DebuggerDisplay](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerdisplayattribute) attribute.</li></ul> |
  | Utilities | <ul><li>The static class CheckedMath provides checked arithmetic operations for built-in numeric types.</li></ul> |

### Performance
TBC

## Jodo.Extensions.CheckedGeometry

> Note: This package contains work in progress.

Provides geometric value types that make use of generic maths from CheckedNumerics.

| CheckedGeometry type | Notes |
| - | - |
| AARectangle\<T\> | Axis aligned rectangle |
| Rectangle\<T\> |  |
| Circle\<T\> |  |
| Angle\<T\> |  |
| Unit\<T\> |  |
| Vector2\<T\> |  |
| Vector3\<T\> |  |

## Jodo.Extensions.Collections

> Note: This package contains work in progress.

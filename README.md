Jodo.Extensions
===============
[![Test](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml) [![CodeQL](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml)

> Documentation in draft

A collection of useful C# libraries written in the style of the .NET SDK.

CheckedNumerics
---------------
Provides numeric value types with built-in protection from overflow. For use in systems where it is necessary to prevent unexpected negative, infinite or NaN values. Usage is identical to primitive value types, but with different results in cases of overflow and division by zero.

> Note: Checked arithmetic takes additional processor time, and the wrapper structs employed by CheckedNumerics increase memory usage compared to primitive types alone. If you wish to use CheckedNumerics in a performance critical application then consider profiling to assess the impact. As a rule of thumb, the impact is acceptable in business, game, or simulation applications, but not in number-crunching or big-data applications.

The following value types are provided:
| Type | Underlying CLR type | Behaviour |
| - | - | - |
| cint | int | <ul><li>Uses a [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) context to perform arithmetic.</li><li>Operations that would overflow do NOT throw a [OverflowException](https://docs.microsoft.com/en-us/dotnet/api/system.overflowexception), but return `MinValue` or `MaxValue` depending on the direction of the overflow.</li><li>Division by zero does NOT throw a [DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception), but returns `MaxValue`.</li></ul> |
| ucint | uint | _Same as cint._ |
| cfloat | float | <ul><li>Operations that would overflow do NOT return `PositiveInfinity` or `NegativeInfinity`, but return `MaxValue` or `MinValue` respectively.</li><li>Division by zero does NOT return `PositiveInfinity`, `NegativeInfinity` or `NaN`, but returns `MaxValue`.</li><li>It is not possible for values to be `PositiveInfinity`, `NegativeInfinity` or `NaN`.</li></ul> |
| cdouble | double | _Same as cfloat._ |
| fix64 | long | A signed fixed-point number with a 40 bit integral part and a 24 bit mantissa. |
| ufix64 | long | A unsigned fixed-point number with a 40 bit integral part and a 24 bit mantissa. |

The following features are provided for all CheckedNumerics value types:
| Feature | Notes |
| - | - |
|  Operator overloading  | <ul><li>`==`, `!=`, `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/` and `%` are overloaded, allowing for use in expressions.</li><li>`&`, `\|`, `^`, `~`, `<<` and `>>` are overloaded for types based on integral primitives.</li><li>Implicit conversions from built-in numeric types are provided, allowing use in expressions with numeric literals.</li></ul> |
| INumeric\<T\> | <ul><li>All CheckedNumerics value types implement INumeric\<T\>, allowing for the creation generic numerical systems.</li><li>The INumeric\<T\> interface provides overloads for arithmetic and comparison operators, allowing for limited expressions in a generic context (Note: equality and conversion operators are not supported on interfaces).</li></ul> |
| Math\<T\> | <ul><li>A static class that provides equivalents to all functions from [Math](https://docs.microsoft.com/en-us/dotnet/api/system.math) (e.g. `Log(T)`, `Pow(T)`, `Sqrt(T)`).</li><li>Available for all types that implement INumeric\<T\> including user-defined types.</li></ul> |
| BitConverter\<T\> | <ul><li>A static class similar to [BitConverter](https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter) that provides conversion to and from `ReadOnlySpan<byte>`.</li><li>Available for all types that implement INumeric\<T\> including user-defined types.</li></ul> |
| StringFormatter\<T\> | <ul><li>A static class that provides string parsing and formatting.</li><li>Available for all types that implement INumeric\<T\> including user-defined types.</li><li>In addition, all CheckedNumerics value types implement [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable) and can be used with [standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings) (e.g. "N2").</li></ul> |
| System.Random.NextNumeric\<T\> | <ul><li>An extension method for [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random) that provides randomly generated values for all types that implement INumeric\<T\>. Values can be generated between two bounds or without bounds.</li></ul> |
| Serialization | <ul><li>All numeric types implement [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable), have the [Serializable](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute) and a deserialization constructor.</li></ul> |
| `float Approximate(float offset)` | <ul><li>All types that implement INumeric\<T\> can be easily converted to floats for use in graphical applications.</li></ul> |
| _Other_ | <ul><li>All CheckedNumerics value types implement [IEquatable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1), [IComparable/<T/>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1) and [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), override `EqualTo(object)`, `GetHashCode()` and `ToString()` and have a (DebuggerDisplay)[https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerdisplayattribute] attribute.</li></ul> |

CheckedGeometry
---------------
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

Collections
-----------

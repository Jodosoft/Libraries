<br id="top" />
<p align="center"><img src="Banner.png" alt="Logo" height="96"/></p>
<h1 align="center">The Jodo Libraries</h1>

<p align="center">
  <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github&no-cache"></a>
  <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
</p>

## Contents

1\. [Introduction](#introduction)

2\. [Quickstart](#quickstart)

3\. [About the project](#about)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.1. [Design goals](#design-goals)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.2. [Roadmap](#roadmap)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.3. [Contributing](#contributing)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.4. [Documentation](#documentation)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.5. [Releases](#releases)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.6. [Changelog](#changelog)<br />

4\. [Jodo.Numerics](#numerics)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.1. [Fixed-point numbers](#numerics-fixed-point-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.2. [Non-overflowing numbers](#numerics-non-overflowing-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.3. [Framework for numbers](#numerics-framework-for-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.4. [Structures](#numerics-structures)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.5. [Random extensions](#numerics-random-extensions)<br />
&nbsp;&nbsp;&nbsp;&nbsp;4.6. [Performance considerations](#numerics-performance-considerations)<br />

5\. [Jodo.Geometry](#geometry) (preview)<br />

6\. [Jodo.Collections](#collections) (preview)<br />

7\. [Jodo.Primitives](#primitives)<br />
&nbsp;&nbsp;&nbsp;&nbsp;7.1. [Random variants](#primitives-random-variants)<br />
&nbsp;&nbsp;&nbsp;&nbsp;7.2. [Default providers](#primitives-default-providers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;7.3. [Shims](#primitives-shims)<br />
&nbsp;&nbsp;&nbsp;&nbsp;7.4. [Stream extensions](#primitives-stream-extensions) (preview)<br />

<br />
<p align="center">* * *</p>
<br />

## 1. Introduction <br id="introduction" />

Welcome to Jodo, a project to make simple, reliable .NET libraries covering numerics, geometry and data structures.

This document describes the goals the project, the features of each library, and steps for getting started.

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 2. Quickstart <br id="quickstart" />

To use the Jodo libraries:

1. Search "`jodo`" in the NuGet package manager.
2. Select a library (e.g. `Jodo.Numerics`), and click Install (most versions of .NET are supported).
3. Import the required namespace in your code files, e.g. "`using Jodo.Numerics;`".
4. Use the newly-available types in your code (no configuration or dependency injection is required).

The features available are:

* **[Jodo.Numerics](#numerics)** - numeric utilities, custom number types, and a generic interface for defining numbers
* **[Jodo.Geometry](#geometry) (preview)** - geometric structs and utilities that support custom number types.
* **[Jodo.Collections](#collections) (preview)** - Extra collection classes and interfaces to complement the .NET API
* **[Jodo.Primitives](#primitives)** - miscellaneous utilities used throughout the Jodo libraries


[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 3. About the project <br id="about" />

The Jodo libraries started as a collection of reusable types from the personal projects of [@JosephJShort](https://github.com/JosephJShort). The types are being revamped to make them fit for public consumption.

This section describes the design goals, roadmap, and other details of the project.

[\[Back to top\]](#top)

### 3.1. Design Goals <br id="design-goals" />

The table below summarizes the design goals of the project.

<table>
  <tr>
    <th>Item</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>Simplicity</td>
    <td> 
      <p>
        The Jodo libraries are designed to provide simple data structures and algorithms to use as the building blocks for more comlpex applications.
      </p>
      <p>
        As a rule of thumb, nothing within the libraries should require configuration or dependency injection. A competent developer should be able to use the libraries intuitively, without needing to refer to documentation.
      </p>
      <p>
        The libraries adhere to the <a href="https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/">.NET Framework Design Guidelines</a> to ensure ease-of-use and consistency with the .NET API.
      </p>
    </td>
  </tr>
  <tr>
    <td>Compatibility</td>
    <td>     
      <p>
        The Jodo libraries are designed to work with a wide array of programming languages and operating systems.
      </p>
      <p>
        .NET Standard 2.0 (<code>netstandard2.0</code>) and .NET Framework 4.6 (<code>net461</code>) targets are used in order to <a href="https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/cross-platform-targeting">maximize cross-platform support</a>,
        whilst additional targets such as .NET Standard 2.1 (<code>netstandard2.1</code>) are used to incorporate newer language features like <a href="https://docs.microsoft.com/en-gb/dotnet/csharp/whats-new/csharp-8#default-interface-methods">default interface methods</a>. No platform-dependant features are used.
      </p>
      <p>
        Publicly exposed types are marked as <a href="https://docs.microsoft.com/en-us/dotnet/standard/language-independence">CLS compliant</a>
        wherever possible, and language-agnostic naming conventions are used. This ensures that
        the libraries can be used in F# and Visual Basic as well as in their native language, C#.
      </p>
      <p>
        Care is taken to avoid name clashes with commonly-used types from the .NET API and popular NuGet packages.
      </p>
      <p>
        <a href="https://semver.org/">Semantic Versioning</a> is used to ensure that version numbers convey the presence of breaking changes to the libraries, and <a href="https://learn.microsoft.com/en-us/dotnet/fundamentals/package-validation/overview">package validation</a> is used to ensure backwards compatibility within each major version.
      </p>
    </td>
  </tr>
  <tr>
    <td>Reliability</td>
    <td>
      <p>
        The Jodo libraries are designed to be dependable. Unit tests, benchmarks,
        and continuous integration tools are used to ensure they remain fit for purpose.</p>
      <p>
        Tests are designed to cover boundary conditions, edge-cases, and error scenarios—not just happy paths.
        Code coverage is used, but is not considered a definitive metric of adequate testing.
        The code coverage target is 90%.</p>
      <p>
        As part of pull request validation, tests are executed against multiple .NET targets and operating systems.
        Currently, this includes
        .NET Framework 4.8 (<code>net48</code>), .NET Core 2.1 (<code>netcoreapp2.1</code>),
        .NET 5 (<code>net5.0</code>), .NET 6 (<code>net6.0</code>), Windows, Ubuntu, and macOS.
        This helps to ensure that the libraries behave as intended and are unaffected by .NET implementation details.
      </p>
      <p>
        <a href="https://dev.azure.com/JosephJShort/Jodo/_build?definitionId=5"><img alt="Azure DevOps tests" src="https://img.shields.io/azure-devops/tests/JosephJShort/Jodo/5/main?logo=azuredevops&style=flat-square&no-cache"></a>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/JosephJShort_Jodo/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Maintainability</td>
    <td>
      <p>
        The source code of the Jodo libraries is designed to be easy to understand and change.
      </p>
      <p>
        As part of pull request validation, <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo">SonarCloud</a>
        and <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main">CodeFactor</a> are used
        to detect code smells such as unused variables or overly complex functions.
      </p>
      <p>
        In the project configuration files, <code>TreatWarningsAsErrors</code> is set to <code>True</code>, <code>WarningLevel</code> is set to <code>4</code> and <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2022">Rosyln analysers</a> are enabled with maximum scope and severity. This helps to flag  issues during development.
        </p>
      <p>
        Warnings are only suppressed in exceptional circumstances, and suppression tags are always accompanied by a justification message.
      </p>
      <p>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Violations (long format)" src="https://img.shields.io/sonar/violations/JosephJShort_Jodo/main?label=smells&logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache" /></a>
        <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main"><img alt="CodeFactor Grade" src="https://img.shields.io/codefactor/grade/github/JosephJShort/Jodo/main?label=quality&logo=codefactor&style=flat-square&no-cache"></a>
      </p>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

### 3.2. Roadmap <br id="roadmap" />

The following table summarizes the development goals for upcoming versions of the Jodo libraries.

<table>
  <tr>
    <th>Version</th>
    <th>Goals</th>
  </tr>
  <tr>
    <td><code>1.1.0</code></td>
    <td>
      <ul>
        <li>Implement suggestions</li>
        <li>Add support for spans</li>
        <li>Add support for streaming</li>
        <li>Automate API documentation website and fill in major blanks</li>
      </ul>
      <a href="https://github.com/JosephJShort/Jodo/milestone/4"><img alt="GitHub milestone" src="https://img.shields.io/github/milestones/progress/JosephJShort/Jodo/4?label=closed%20issues&style=flat-square&logo=github&no-cache"></a>
    </td>
  </tr>
  <tr>
    <td><code>1.2.0</code></td>
    <td>
      <ul>
        <li>Create the first release of Jodo.Geometry</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td><code>1.3.0</code></td>
    <td>
      <ul>
        <li>Implement suggestions</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td><em>Future</em></td>
    <td>
      <ul>
        <li>Create the first release of Jodo.Geometry</li>
      </ul>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

### 3.3. Contributing <br id="contributing" />

Community contributions are welcome at https://github.com/JosephJShort/Jodo (the home of this repository). A list of reported issues can be found at <a href="https://github.com/JosephJShort/Jodo/issues">https://github.com/JosephJShort/Jodo/issues</a>. Contributors are requested to adhere to the <a href="CODE-OF-CONDUCT.md">code of conduct</a>.

This work is licensed under the <a href="LICENSE.md">MIT License</a>.

<p>
  <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github"></a>
  <a href="https://github.com/JosephJShort/Jodo/stargazers"><img alt="GitHub issues" src="https://img.shields.io/github/stars/JosephJShort/Jodo?logo=github&style=flat-square&color=005784&no-cache"></a>
</p>

[\[Back to top\]](#top)

### 3.4. Documentation <br id="documentation" />

<p>Work-in-progress API documentation is available at https://jodo.dev.</p>
<p>
  <a href="https://jodo.dev"><img alt="Documentation" src="https://img.shields.io/badge/documentation-passing-005784?style=flat-square&color=005784"></a>
</p>

[\[Back to top\]](#top)

### 3.5. Releases <br id="releases" />

<p>Builds of this project are available as NuGet packages on <a href="https://www.nuget.org/packages?q=Jodo.">NuGet.org</a> (for help, see: <a href="https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio">"Quickstart: Install and use a package"</a>).</p>
<p>Binaries are available on GitHub.com at <a href="https://github.com/JosephJShort/Jodo/releases">https://github.com/JosephJShort/Jodo/releases</a>.</p>
<p>The libraries can also be built from the source code in this repository using the appropriate <a href="https://dotnet.microsoft.com/en-us/download/visual-studio-sdks">.NET SDKs</a> and any IDE that supports .NET, such as <a href="https://visualstudio.microsoft.com/vs/community/">Visual Studio Community Edition</a>.</p>
<p>
  <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
  <a href="[https://www.nuget.org/packages?q=Jodo.](https://github.com/JosephJShort/Jodo/releases)"><img alt="GitHub release (latest SemVer including pre-releases)" src="https://img.shields.io/github/v/release/JosephJShort/Jodo?include_prereleases&logo=github&style=flat-square&color=005784&no-cache"></a>
</p>

[\[Back to top\]](#top)

### 3.6. Changelog <br id="changelog" />

The following table summarizes changes made to previous releases of the Jodo libraries:

<table>
  <tr>
    <th>Version</th>
    <th>Changes</th>
  </tr>
  <tr>
    <td><code>1.0.0</code></td>
    <td>
      <p>
        <ul>
          <li>The initial release of Jodo.Numerics and Jodo.Primitives</li>
          <li>Added cross-platform support</li>
          <li>Reached high level of test coverage</li>
          <li>Established code quality rules</li>
          <li>Created benchmarks</li>
        </ul>
        <a href="https://github.com/JosephJShort/Jodo/milestone/3"><img alt="GitHub milestone" src="https://img.shields.io/github/milestones/progress/JosephJShort/Jodo/3?label=closed%20issues&style=flat-square&logo=github&no-cache"></a>
      </p>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />


## 4. Jodo.Numerics <br id="numerics" />

Provides numeric utilities, custom number types, and a generic interface for defining numbers.

<a href="https://www.nuget.org/packages/Jodo.Numerics/"><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Numerics?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
  
[\[Back to top\]](#top)

### 4.1. Fixed-point numbers <br id="numerics-fixed-point-numbers" />

Unlike floating-point numbers, <a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">fixed-point</a> numbers maintain a constant degree of precision regardless of magnitude. This can be useful in situations where <a href="https://en.wikipedia.org/wiki/MIM-104_Patriot#Failure_at_Dhahran">precision remains important whilst numbers grow</a>. As a trade-off, fixed-point numbers have a much lower maximum magnitude than floating-point numbers of the same size.

<a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Fix64.htm">Fix64</a> and <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_UFix64.htm">UFix64</a> are number types that implement fixed-point arithmetic. As with all the number types provided by this library, they support a full range of math, operators, conversion, string parsing, etc (see <a href="#numerics-framework-for-numbers">§4.3. Framework for numbers</a>).

<pre lang="csharp"><code>using Jodo.Numerics;
using System;

Fix64 x = 100;
Fix64 y = 2 * MathN.Cos(x);
Fix64 z = Fix64.Parse("1000000.123456");
Fix64 r = new Random(1).NextNumeric&lt;Fix64&gt;(100, 200);
float f = ConvertN.ToSingle(z);
byte[] bytes = BitConverterN.GetBytes(y);

Console.WriteLine(x); // output: 100
Console.WriteLine(y); // output: 1.724636
Console.WriteLine(z); // output: 1000000.123456
Console.WriteLine(r); // output: 124.866858
Console.WriteLine(f); // output: 1000000.1
Console.WriteLine(bytes.Length); // output: 8</code></pre>

The table belows summarizes the capabilities of these types.

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td><sub><em>readonly struct</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Fix64.htm">Fix64</a></td>
    <td>
      <p>Signed fixed-point number type with 6 decimal digits of precision, represented internally by a 64-bit integer.</p>
      <p>Supports a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup>.</p>
    </td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>readonly struct</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_UFix64.htm">UFix64</a></td>
    <td>
      <p>Unsigned fixed-point number type with 6 decimal digits of precision, represented internally by a 64-bit integer.</p>
      <p>Supports a range of values from 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup>.</p>
    </td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Scaled.htm">Scaled</a></td>
    <td>
      <p>Provides static methods for performing arithmetic and string conversion on integers with a scaling factor. Used to implement <code>Fix64</code> and <code>UFix64</code>.</p>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

### 4.2 Non-overflowing numbers <br id="numerics-non-overflowing-numbers" />
  
Number types in the <a href="https://jodo.dev/jodo/api/N_Jodo_Numerics_Clamped.htm">Jodo.Numerics.Clamped</a> namespace have built-in protection from overflow. 

Operations that would normally error or overflow instead return `MinValue`, `MaxValue` or `Zero`.

This is useful in systems where overflow is expected

As with all the number types provided by this library, these types support a full range of math, operators, conversion, string parsing, etc (see <a href="#numerics-framework-for-numbers">§4.3. Framework for numbers</a>).
        
Usage is the same as with built-in numeric types but yields different results in cases of overflow.

```csharp
var i = Int32M.MaxValue + 1;
Console.WriteLine(i);  // output: 2147483647

var f = (SingleM)4 / 0;
Console.WriteLine(f);  // output: 3.402823E+38
```

The table below summarizes the clamped number types and utilities provided.

<table>
	<tr>
		<th>Type</th>
		<th>Description</th>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			<a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_ByteM.htm">ByteM</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_SByteM.htm">SByteM</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_Int16M.htm">Int16M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_UInt16M.htm">UInt16M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_Int32M.htm">Int32M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_UInt32M.htm">UInt32M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_Int64M.htm">Int64M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_UInt64M.htm">UInt64M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_DecimalM.htm">DecimalM</a>
		</td>
		<td>
			Operations that would normally overflow from positive to negative instead return <code>MaxValue</code>.
			Operations that would normally overflow from negative to positive instead return <code>MinValue</code>.
			Division by zero does NOT throw a
			<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception">System.DivideByZeroException</a>
			but returns <code>MaxValue</code>.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			<a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_SingleM.htm">SingleM</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_DoubleM.htm">DoubleM</a>
		</td>
		<td>
			Operations that would normally return <code>PositiveInfinity</code> instead return <code>MaxValue</code>.
			Operations that would normally return <code>NegativeInfinity</code> instead return <code>MinValue</code>.
      Operations that would normally return <code>NaN</code> instead return <code>0</code>.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			<a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_Fix64M.htm">Fix64M</a>,<br />
      <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_UFix64M.htm">UFix64M</a>
		</td>
		<td>
			Non-overflowing fixed-point numbers (see <a href="#numerics-fixed-point-numbers">§4.1. Fixed-point numbers</a>).
			Operations that would overflow instead return <code>MinValue</code>
			or <code>MaxValue</code> depending on the direction of the
			overflow. Division by zero does NOT throw a
			<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception">DivideByZeroException</a>
			but returns <code>MaxValue</code>.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>static class</em></sub><br />
			<a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Clamped_Clamped.htm">Clamped</a>
		</td>
		<td>
			Provides static methods for performing non-overflowing arithmetic.
		</td>
	</tr>
</table>

[\[Back to top\]](#top)

### 4.3. Framework for numbers <br id="numerics-framework-for-numbers" />

The <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a> interface defines a contract for number types with support for operators, maths, conversion, string-parsing, random generation, and more.

Static utility classes, such as <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_MathN.htm">MathN</a> and <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_ConvertN.htm">ConvertN</a>, expose these features in a way that is familiar to users of the .NET API.

<pre lang="csharp"><code>using Jodo.Numerics;
using System;

MyNumberType fromLiteral = 3.123;
MyNumberType usingOperators = (fromLiteral + 1) % 2;
MyNumberType usingMath = MathN.Pow(fromLiteral, 2);
MyNumberType fromRandom = new Random(1).NextNumeric&lt;MyNumberType&gt;(10, 20);
MyNumberType fromString = MyNumberType.Parse("-7.4E+5");
short conversion = ConvertN.ToInt16(usingMath);
string stringFormat = $"{fromLiteral:N3}";
byte[] asBytes = BitConverterN.GetBytes(usingMath);</code></pre>

The table below gives a full list of features supported by number types that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a>.

<table>
  <tr>
    <th>Feature</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_MathN.htm">MathN</a></td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.math">System.Math</a> for types that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a>, e.g. <code>Log(N)</code>, <code>Acosh(N)</code> and <code>Round(N, int)</code>.</p>
    <pre lang="csharp"><code>var result = MathN.Log10(1000 * MathN.PI&lt;MyNumberType&gt;());</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_BitConverterN.htm">BitConverterN</a></td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter">System.BitConverter</a> for types that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a>, allowing conversion to and from byte arrays.
      </p>
<pre lang="csharp"><code>byte[] result = BitConverterN.GetBytes((MyNumberType)256.512);</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_ConvertN.htm">ConvertN</a></td>
    <td>
      <p>
        Provides equivalent methods to
        <a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">System.Convert</a>
        for types that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a>
        (e.g. <code>ToBoolean(N)</code> and <code>ToDecimal(N)</code>).
        Overloads are provided to support alternative modes of conversion,
        e.g. <code>Default</code>, <code>Cast</code> and <code>Clamp</code>.
      </p>
      <pre lang="csharp"><code>var defaultResult = ConvertN.ToNumeric&lt;ByteN&gt;(199.956, Conversion.Default);
var castResult = ConvertN.ToNumeric&lt;ByteN&gt;(199.956, Conversion.Cast);</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br /><a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_Numeric.htm">Numeric</a></td>
    <td>
      <p>Provides access to constants and static methods for number types in a generic context.</p>
    <pre lang="csharp"><code>public void ExampleMethod&lt;T&gt;() where T : struct, INumeric<T>
{
    var zero = Numeric.Zero&lt;T&gt;();
    var parsed = Numeric.Parse&lt;T&gt;("1.2");
    var isFinite = Numeric.IsFinite(parsed);
}</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="operators">Overloaded operators</td>
    <td>
      <p>All the number types in this library have a full suite of overloaded operators, including:
      <ul>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Equality operators</a> (<code>==</code>, <code>!=</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Comparison operators</a> (<code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators">Arithmetic operators</a> (<code>++</code>, <code>--</code>, <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code>, <code>-</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators">Bitwise and shift operators</a> (<code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code>, <code>^</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators">Conversion operators</a> to/from the built-in numeric types</li>
      </ul>
  </p>
   <p>
Additionally, <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a> defines overloads for <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>, <code>++</code>, <code>--</code>, <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code>, <code>-</code>, <code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code> and <code>^</code>, allowing for limited expressions in a generic context (note that equality and conversion operators are not supported on interfaces).
  </p>
  <p> <em>Note: The bitwise and shift operators are overloaded for non-integral types. These operators perform the correct bitwise operations, but are unlikely to produce useful results.</em></p>
      </td>
    </tr>
  <tr />
   <tr>
<td id="stringformatting">String formatting</td>
<td>
<p>All the number types in this library can be used with <a href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">numeric format strings</a>, as in the following code sample:</p>
  <pre lang="csharp"><code>var var1 = (MyNumberType)1023;
var var2 = (MyNumberType)99.54322f;

Console.WriteLine($"{var1:N}"); // outputs: 1,023.00
Console.WriteLine($"{var1:X}"); // outputs: 3FF
Console.WriteLine($"{var2:E}"); // outputs: 9.954322E+001
Console.WriteLine($"{var2:000.000}"); // outputs: 099.543</code></pre>
</td>
</tr>
  <tr />
<tr>
<td>Random generation</td>
  <td>Extension methods on <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">System.Random</a> provide randomly generated values. Values can be generated between bounds or without bounds.</p>
  <pre lang="csharp"><code>var var1 = Random.NextNumeric&lt;MyNumberType&gt;();
var var2 = Random.NextNumeric&lt;MyNumberType&gt;(100, 120);

Console.WriteLine(var1); // outputs: 0.405808417991177 (example)
Console.WriteLine(var2); // outputs: 102.85086051826445 (example)</code></pre>
  
  </td>
</tr>
  <tr />
<tr>
<td>Commonly-used abstractions</td> <td>All the number types in this library implement <a href="https://docs.microsoft.com/en-us/dotnet/api/system.icomparable">System.IComparable</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1">System.IComparable&lt;T&gt;</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible">System.IConvertible</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1">System.IEquatable&lt;T&gt;</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformattable">System.IFormattable</a> and <a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable">System.ISerializable</a>. They also override <code>Equals(object)</code>, <code>GetHashCode()</code> and <code>ToString()</code>, and have the <a href="https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/enhancing-debugging-with-the-debugger-display-attributes">DebuggerDisplay</a> attribute. </td>
</tr>
  <tr />
  <tr>
    <td id="wrappers"><sub><em>readonly struct</em></sub><br />
      ByteN, SByteN,<br />
      Int16N, UInt16N,<br />
      Int32N, UInt32N,<br />
      Int64N, UInt64N,<br />
      SingleN, DoubleN,<br />
      DecimalN
    </td>
    <td>Wrappers for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/numerics">built-in numeric types</a> that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a>, allowing them to be used in a generic context.</td>
  </tr>
</table>

[\[Back to top\]](#top)

### 4.4. Structures <br id="numerics-structures" />

Numeric structures, such as vectors, are provided for use in mathematical applications. These structures are generic on number type, supporting any implementation of <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a> (see <a href="#numerics-framework-for-numbers">§4.3. Framework for numbers</a>). The table below summarizes the available structs and accompanying utilities.

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td><sub><em>readonly struct</em></sub><br />UnitN&lt;TNumeric&gt;</td>
    <td>A wrapper for numeric types that clamps values between -1 and 1 (or 0 and 1 when unsigned).</td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>readonly struct</em></sub><br />Vector2N&lt;TNumeric&gt;</td>
    <td>A collection of two numeric values, <code>X</code> and <code>Y</code>, with extensive interface and operator support.</td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>readonly struct</em></sub><br />Vector3N&lt;TNumeric&gt;</td>
    <td>A collection of three numeric values, <code>X</code>, <code>Y</code> and <code>Z</code>, with extensive interface and operator support.</td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br />Vector2N</td>
    <td>Provides static methods for performing vector-based mathematics on instances of Vector2N&lt;TNumeric&gt;, such as dot product.</td>
  </tr>
  <tr />
  <tr>
    <td><sub><em>static class</em></sub><br />Vector3N</td>
    <td>Provides static methods for performing vector-based mathematics on instances of Vector3N&lt;TNumeric&gt;, such as dot product.</td>
  </tr>
</table>

[\[Back to top\]](#top)

### 4.5. Random extensions <br id="numerics-random-extensions" />

Extension methods for <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">System.Random</a> add support for generating every built-in number type and types that implement <a href="https://jodo.dev/jodo/api/T_Jodo_Numerics_INumeric_1.htm">INumeric&lt;TSelf&gt;</a> (see <a href="#numerics-framework-for-numbers">§4.3. Framework for numbers</a>).

Overloads are provided that allow greater flexibility with bounds via the `Generation` enum:

<table>
  <tr>
    <td><code>Generation.Default</code></td>
    <td>Uses the conventions established System.Random.</td>
  </tr>
  <tr>
    <td><code>Generation.Extended</code></td>
    <td>Bounds are inclusive, and can be specified in any order.</td>
  </tr>
</table>

```csharp
using Jodo.Numerics;
using System;

var value1 = new Random().NextDouble(double.MinValue, double.MaxValue); // Returns any finite double.
var value2 = new Random().NextUInt64(200, 100, Generation.Extended); // Returns a ulong between 100 and 200 (inclusive).
```

[\[Back to top\]](#top)

### 4.6 Performance considerations <br id="numerics-performance-considerations" />

The number types provided by this library are structs that wrap built-in types and operations. Therefore they require additional memory and CPU time compared to using the built-in types alone.

Additionally, the number types within the *Jodo.Numerics.Clamped* namespace make use of the [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) keyword for conversion and arithmetic. This further increases CPU time compared to using unchecked operations, especially in cases of overflow.

If developing a performance-sensitive application, use a profiler to assess the impact of introducing these types. Generally speaking, the impact is likely to be acceptable unless CPU-bound arithmetic is already on the hot path for the given application (e.g. in machine learning or 3D physics applications).

Benchmarks are provided to facilitate comparison with the built-in number types. To run the benchmarks, clone this repository then build and run *Jodo.Numerics.Benchmarks* in RELEASE mode (without a attaching a debugger).

Sample output can be seen below:

> *Jodo.Numerics.Benchmarks - Results from 2022-09-28 07:58:50Z*
> * **Processor:** 11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz
> * **Architecture:** x64-based processor
> * **.NET Version:** .NET 5.0.17
> * **Architecture:** X64
> * **OS:** win10-x64
> * **Seconds per Benchmark:** 60.0

| Subjects "(1)\_Versus\_(2)" | Operations Per Second (1) | Operations Per Second (2) | Average Time (1) | Average Time (2) | Relative Speed (1) | Relative Speed (2) |
| --- | --- | --- | --- | --- | --- | --- |
| Fix64Logarithm_Versus_DoubleLogarithm | 7.789E+06 | 5.183E+07 | *<1μs* | *<1μs* | **0.15** | 6.65 |
| Fix64Rounding_Versus_DoubleRounding | 3.846E+07 | 3.637E+07 | *<1μs* | *<1μs* | 1.06 | 0.95 |
| Fix64StringParsing_Versus_DoubleStringParsing | 1.842E+07 | 1.973E+07 | *<1μs* | *<1μs* | 0.93 | 1.07 |
| Fix64Random_Versus_DoubleRandom | 2.4E+07 | 3.995E+07 | *<1μs* | *<1μs* | **0.60** | 1.66 |
| Fix64ToByteArray_Versus_DoubleToByteArray | 4.831E+07 | 4.876E+07 | *<1μs* | *<1μs* | 0.99 | 1.01 |
| Fix64FromByteArray_Versus_DoubleFromByteArray | 5.29E+07 | 5.225E+07 | *<1μs* | *<1μs* | 1.01 | 0.99 |
| Int32NArithmetic_Versus_Int32Arithmetic | 5.03E+07 | 5.282E+07 | *<1μs* | *<1μs* | 0.95 | 1.05 |
| Int32MArithmetic_Versus_Int32Arithmetic | 4.425E+07 | 5.215E+07 | *<1μs* | *<1μs* | **0.85** | 1.18 |
| SingleNArithmetic_Versus_SingleArithmetic | 4.122E+07 | 5.623E+07 | *<1μs* | *<1μs* | **0.73** | 1.36 |
| SingleMArithmetic_Versus_SingleArithmetic | 3.418E+07 | 5.634E+07 | *<1μs* | *<1μs* | **0.61** | 1.65 |
| DoubleNArithmetic_Versus_DoubleArithmetic | 4.129E+07 | 5.565E+07 | *<1μs* | *<1μs* | **0.74** | 1.35 |
| DoubleMArithmetic_Versus_DoubleArithmetic | 3.402E+07 | 5.527E+07 | *<1μs* | *<1μs* | **0.62** | 1.62 |
| DoubleNDivision_Versus_DoubleDivision | 4.833E+07 | 5.392E+07 | *<1μs* | *<1μs* | **0.90** | 1.12 |
| DoubleNLogarithm_Versus_DoubleLogarithm | 4.913E+07 | 5.244E+07 | *<1μs* | *<1μs* | 0.94 | 1.07 |
| DoubleNRounding_Versus_DoubleRounding | 3.396E+07 | 3.597E+07 | *<1μs* | *<1μs* | 0.94 | 1.06 |

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 5. Jodo.Geometry (preview) <br id="geometry" />

Provides geometric structs and utilities that support custom number types.

> Coming soon (see section 2.2. "[Roadmap](#roadmap)")

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 6. Jodo.Collections (preview) <br id="collections" />

Provides extra collection classes and interfaces to complement the .NET API.

> Coming soon (see section 2.2. "[Roadmap](#roadmap)")

[\[Back to top\]](#top)

## 7. Jodo.Primitives <br id="primitives" />

Provides utilities and abstractions that are used throughout the Jodo libraries.

<a href="https://www.nuget.org/packages/Jodo.Primitives/"><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>

[\[Back to top\]](#top)

### 7.1. Random variants <br id="primitives-random-variants" />

Provides a specification for randomly generating objects based on variants (categories). This feature is used extensively by the Jodo unit testing libraries to ensure that tests cover a variety of scenarios. Although the exact definition of each variant is left to the implementor, the following table serves as a guide:

<table>
    <tr>
        <th>Variant</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>Defaults</td>
	      <td>Null, zero, or any other default state for a given object.</td>
    </tr>
    <tr>
        <td>LowMagnitude</td>
	      <td>Small values and values with reduced significance.</td>
    </tr>
    <tr>
        <td>AnyMagnitude</td>
	      <td>Any value from the set of all possible values, excluding errors.</td>
    </tr>
    <tr>
        <td>Boundaries</td>
	      <td>Minimum and maximum values.</td>
    </tr>
    <tr>
        <td>Errors</td>
	      <td>Values that are typical of error scenarios, or values intended to elicit errors.</td>
    </tr>
    <tr>
        <td>All</td>
	      <td>Encompasses all variants.</td>
    </tr>
    <tr>
        <td>NonError</td>
	      <td>Encompasses all variants, except for errors.</td>
    </tr>
</table>

Extension methods for <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">System.Random</a> allow
for objects to be generated within these categories.

<pre lang="csharp"><code>var random = new Random();
short num1 = random.NextVariant&lt;Int16N&gt;(Variants.LowMagnitude);
short num2 = random.NextVariant&lt;Int16N&gt;(Variants.Defaults | Variants.Boundaries);

Console.WriteLine(num1); // output: 24 (example)
Console.WriteLine(num2); // output: -32768 (example)</code></pre>

[\[Back to top\]](#top)

### 7.2. Default providers <br id="primitives-default-providers" />

> Documentation tbc

[\[Back to top\]](#top)

### 7.3. Shims <br id="primitives-shims" />

> Documentation tbc

[\[Back to top\]](#top)

### 7.4. Stream extensions (preview) <br id="primitives-stream-extensions" />

> Documentation tbc

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

[![NuGet version (Eras.AwesomeAssertions.bUnit)](https://img.shields.io/nuget/v/Eras.AwesomeAssertions.bUnit.svg?style=flat-square)](https://www.nuget.org/packages/Eras.AwesomeAssertions.bUnit/)
[![Nuget](https://img.shields.io/nuget/dt/Eras.AwesomeAssertions.bUnit?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Eras.AwesomeAssertions.bUnit/)
[![.NET](https://github.com/benm-eras/AwesomeAssertions.bUnit/actions/workflows/dotnet.yml/badge.svg)](https://github.com/benm-eras/AwesomeAssertions.bUnit/actions/workflows/dotnet.yml)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/benm-eras/AwesomeAssertions.bUnit/blob/main/LICENSE)

# AwesomeAssertions.bUnit

AwesomeAssertions.bUnit is an assertions library that is used in conjunction with bUnit.

It offers fluent assertions syntax to rendered components.

## Why?

- Great for TDD
- Great for writing non-brittle tests


## Getting Started

Install Nuget Package into test project:
```
dotnet install Eras.AwesomeAssertions.bUnit
```

Use bUnit to render component.

Then write assertions...

```csharp
    [Fact]
    public void RenderWithChildContent()
    {
        Render(@<Button><h1>Test</h1></Button>)
            .Should().HaveTag("button")
            .And.HaveChildMarkup(@<h1>Test</h1>);
    }

    [Fact]
    public void SetDefaultCssClasses()
    {
        Render(@<Button><h1>Test</h1></Button>)
            .Should().HaveClass("btn")
            .And.HaveClass("btn-primary")
            .And.NotHaveClass("btn-outline-success");
    }
```

## Documentation

Use intellisense and look at the code for now :-)

### Find Element

[Find Element](https://github.com/benm-eras/AwesomeAssertions.bUnit/blob/main/Eras.AwesomeAssertions.bUnit/BUnitExtensions.cs)

### Assertions

[Assertions](https://github.com/benm-eras/AwesomeAssertions.bUnit/blob/main/Eras.AwesomeAssertions.bUnit/BUnitAssertions.cs)

## Contributions

Currently in a very early version/stage of this project.

Please raise issues and feel free to submit PRs (happy to discuss in an issue first to avoid wasted effort).


## Sponsors

Thanks [Powered4 TV](https://powered4.tv/) for supporting us.
using AngleSharp.Dom;
using Bunit;

namespace AwesomeAssertions.bUnit;

public static class AssertionExtensions
{
    public static RenderedFragmentAssertions Should(this IRenderedFragment actualValue) => new(actualValue);

    public static ElementAssertions Should(this IElement actualValue) => new(actualValue);
}
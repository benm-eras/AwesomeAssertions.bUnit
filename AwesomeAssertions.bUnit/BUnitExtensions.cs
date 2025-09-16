using AngleSharp.Dom;
using Bunit;

namespace AwesomeAssertions.bUnit;

public static class BUnitExtensions
{
    public static IElement FindByDataTestId(this IRenderedFragment component, string dataTestId)
        => component.Find($"[data-test-id='{dataTestId}']");

    public static IElement FindByDataTestClass(this IRenderedFragment component, string dataTestClass)
        => component.Find($"[data-test-class='{dataTestClass}']");

    public static IRefreshableElementCollection<IElement> FindAllByDataTestClass(this IRenderedFragment component,
        string dataTestClass)
        => component.FindAll($"[data-test-class='{dataTestClass}']");

    public static IElement AsElement(this IRenderedFragment component)
        => component.Nodes.QuerySelector("*") ?? throw new InvalidOperationException("No root element of component found.");
}
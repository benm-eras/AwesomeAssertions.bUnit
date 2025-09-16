using AngleSharp.Dom;
using AwesomeAssertions.Execution;
using AwesomeAssertions.Primitives;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace AwesomeAssertions.bUnit;

/// <summary>
/// Contains a number of methods to assert that a <see cref="IRenderedFragment"/> is in the expected state.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RenderedFragmentAssertions"/> class.
/// </remarks>
public class ElementAssertions(IElement value) : ElementAssertions<ElementAssertions>(value)
{
}

public class ElementAssertions<TAssertions>(IElement value)
    : ReferenceTypeAssertions<IElement, TAssertions>(value, AssertionChain.GetOrCreate())
    where TAssertions : ElementAssertions<TAssertions>
{
    private readonly TestContext context = new();

    protected override string Identifier => nameof(IRenderedFragment);

    public AndConstraint<TAssertions> HaveChildMarkup(RenderFragment expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.FirstChild is not null)
            .FailWith("Expected {context:IElement} to have child {0}{reason}, but found <null>.", context.Render(expected).Markup)
            .Then
            .Given(() => Subject.FirstChild!)
            .ForCondition(e =>
            {
                try
                {
                    e.MarkupMatches(expected);
                    return true;
                }
                catch
                {
                    return false;
                }
            })
            .FailWith("Expected {context:IElement} to have child {0}{reason}, but found {1}.", context.Render(expected).Markup, Subject.FirstChild!.ToMarkup().TrimStart());

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveChildMarkup(string expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.FirstChild is not null)
            .FailWith("Expected {context:IElement} to have child {0}{reason}, but found <null>.", expected)
            .Then
            .Given(() => Subject.FirstChild!)
            .ForCondition(e =>
            {
                try
                {
                    e.MarkupMatches(expected);
                    return true;
                }
                catch
                {
                    return false;
                }
            })
            .FailWith("Expected {context:IElement} to have child {0}{reason}, but found {1}.", expected, Subject.FirstChild!.ToMarkup().TrimStart());

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveMarkup(RenderFragment expected, string because = "", params object[] becauseArgs)
    {
        bool doesMarkupMatch;
        try
        {
            Subject.MarkupMatches(expected);
            doesMarkupMatch = true;
        }
        catch
        {
            doesMarkupMatch = false;
        }

        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(doesMarkupMatch)
            .FailWith("Expected {context:IElement} markup {0}{reason}, but found {1}.", context.Render(expected).Markup, Subject.ToMarkup());

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveMarkup(string expected, string because = "", params object[] becauseArgs)
    {
        bool doesMarkupMatch;
        try
        {
            Subject.MarkupMatches(expected);
            doesMarkupMatch = true;
        }
        catch
        {
            doesMarkupMatch = false;
        }

        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(doesMarkupMatch)
            .FailWith("Expected {context:IElement} markup {0}{reason}, but found {1}.", expected, Subject.ToMarkup());

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotHaveClass(string expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(!Subject.ClassList.Contains(expected))
            .FailWith("Expected {context:IElement} to not have class {0}{reason}, but found it.", expected);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveClass(string expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.ClassList.Any())
            .FailWith("Expected {context:IElement} to have class {0}{reason}, but found no classes.", expected)
            .Then
            .ForCondition(Subject.ClassList.Contains(expected))
            .FailWith("Expected {context:IElement} to have class {0}{reason}, but found classes [{1}].", expected, string.Join(", ", Subject.ClassList));

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveRel(string expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.Attributes["rel"] is not null)
            .FailWith("Expected {context:IElement} to have attribute {0}{reason}, but found <null>.", "rel")
            .Then
            .Given(() => Subject.Attributes["rel"]!)
            .ForCondition(attribute => attribute.Value.Split(" ").Contains(expected))
            .FailWith("Expected {context:IElement} {0} [{1}] to contain {2}{reason}.", "rel", Subject.Attributes["rel"]!.Value.Split(" ").ToList(), expected);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveTag(string expected, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.LocalName.Equals(expected, StringComparison.InvariantCulture))
            .FailWith("Expected {context:IElement} {0} to be {1}{reason}, but found {2}.", "tag", expected, Subject.LocalName);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> HaveAltText(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("alt", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveAriaLabel(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("aria-label", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveDataTestClass(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("data-test-class", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveDataTestId(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("data-test-id", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveHref(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("href", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveId(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("id", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveSrc(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("src", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveTarget(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("target", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveTitle(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("title", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveType(string expected, string because = "", params object[] becauseArgs)
        => HaveAttribute("type", expected, because, becauseArgs);

    public AndConstraint<TAssertions> HaveAttribute(string attributeName, string expectedValue, string because = "", params object[] becauseArgs)
    {
        base.CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject.Attributes[attributeName] is not null)
            .FailWith("Expected {context:IElement} to have attribute {0}{reason}, but found <null>.", attributeName)
            .Then
            .Given(() => Subject.Attributes[attributeName]!)
            .ForCondition(attribute => attribute.Value == expectedValue)
            .FailWith("Expected {context:IElement} {0} attribute to have value {1}{reason}, but found {2}.", attributeName, expectedValue, Subject.Attributes[attributeName]!.Value);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }
}
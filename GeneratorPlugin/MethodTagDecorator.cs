using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace GeneratorPlugin
{
    public class MethodTagDecorator : ITestMethodTagDecorator
    {
        public static readonly string TAG_NAME = "Order";
        private readonly ITagFilterMatcher _tagFilterMatcher;

        public MethodTagDecorator(ITagFilterMatcher tagFilterMatcher)
        {
            Logging.WriteLine("MethodTagDecorator", "Initialize");
            _tagFilterMatcher = tagFilterMatcher;
        }

        public int Priority { get; }

        public bool RemoveProcessedTags { get; }

        public bool ApplyOtherDecoratorsForProcessedTags { get; }

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            Logging.WriteLine("CanDecorateFrom", $"TagName: {tagName}");
            return _tagFilterMatcher.Match(TAG_NAME, tagName);
        }

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            var attribute = new CodeAttributeDeclaration(
                "NUnit.Framework.Order",
                new CodeAttributeArgument(new CodePrimitiveExpression(1)));

            Logging.WriteLine("DecorateFrom", $"Attribute: {attribute}");
            testMethod.CustomAttributes.Add(attribute);
        }
    }
}

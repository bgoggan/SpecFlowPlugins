using GeneratorPlugin;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: GeneratorPlugin(typeof(ImplementGeneratorPlugin))]

namespace GeneratorPlugin
{
    public class ImplementGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            //Register the decorator
            generatorPluginEvents.RegisterDependencies += RegisterDependencies;
        }

        private void RegisterDependencies(object sender, RegisterDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<MethodTagDecorator, ITestMethodTagDecorator>(MethodTagDecorator.TAG_NAME);
        }
    }
}

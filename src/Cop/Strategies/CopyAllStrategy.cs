using System.Linq;
using System.Reflection;

namespace Cop.Strategies
{
    internal class CopyAllStrategy : CopyStrategyBase, ICopyStrategy
    {
        public void Execute(ExecutionContext context)
        {
            var inputProperty = context.InputProperty;
            var currentOutputProperty = FindMatchingOutputProperty(context);
            currentOutputProperty?.SetValue(context.OutputObj, inputProperty.GetValue(context.InputObj));
        }

        private PropertyInfo FindMatchingOutputProperty(ExecutionContext context)
        {
            var outputProperties = GetOutputProperties(context);

            return outputProperties.FirstOrDefault(property =>
                property.Name == context.CopInfo.PropertyName &&
                property.CustomAttributes.Any(attr => attr.AttributeType == typeof(CopyAttribute)));
        }
    }
}

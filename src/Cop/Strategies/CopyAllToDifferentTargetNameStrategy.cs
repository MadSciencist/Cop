using System;
using System.Linq;
using System.Reflection;

namespace Cop.Strategies
{
    internal class CopyAllToDifferentTargetNameStrategy : CopyStrategyBase, ICopyStrategy
    {
        public void Execute(ExecutionContext context)
        {
            var inputProperty = context.InputProperty;
            var targetProperty = FindMatchingOutputProperty(context);

            if (targetProperty is null)
            {
                var message = $"Cannot find target property with name: {context.CopInfo.TargetPropertyName}";
                throw new InvalidOperationException(message);
            }

            targetProperty.SetValue(context.OutputObj, inputProperty.GetValue(context.InputObj));
        }

        private PropertyInfo FindMatchingOutputProperty(ExecutionContext context)
        {
            var outputProperties = GetOutputProperties(context);

            return outputProperties.FirstOrDefault(property =>
                property.Name == context.CopInfo.TargetPropertyName &&
                property.CustomAttributes.Any(attr => attr.AttributeType == typeof(CopyAttribute)));
        }
    }
}

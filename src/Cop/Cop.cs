using Cop.Strategies;
using System.Reflection;

namespace Cop
{
    public class Cop : ICop
    {
        public TOutput Copy<TOutput, TInput>(TOutput output, TInput input) where TInput : class where TOutput : class
        {
            Guard.NotNull(input, nameof(input));
            Guard.NotNull(output, nameof(output));

            foreach (var propertyInfo in input.GetType().GetProperties())
            {
                var copInfo = GetCopPropertyInfo(propertyInfo, input);
                if (copInfo is null) continue; // No Copy attribute at all

                var strategy = StrategyFactory.GetStrategy(copInfo);
                var context = new ExecutionContext(copInfo, input, output, propertyInfo);
                strategy.Execute(context);
            }

            return output;
        }

        private static CopInfo GetCopPropertyInfo(PropertyInfo property, object input)
        {
            var copyAttribute = property.GetCustomAttribute<CopyAttribute>(true);

            if (copyAttribute is null) return null;

            return new CopInfo
            {
                PropertyName = property.Name,
                CopyOption = copyAttribute.CopyOption,
                TargetPropertyName = copyAttribute.OutputPropertyName,
                IsInputPropertyNull = property.GetValue(input) is null
            };
        }
    }
}

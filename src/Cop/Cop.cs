using Cop.Strategies;
using System.Reflection;

namespace Cop
{
    public class Cop : ICop
    {
        public TOutput Copy<TOutput, TInput>(TOutput output, TInput input) where TInput : class where TOutput : class
        {
            Guard.GuardNotNull(input, nameof(input));
            Guard.GuardNotNull(output, nameof(output));

            foreach (var propertyInfo in input.GetType().GetProperties())
            {
                var copInfo = GetCopPropertyInfo(propertyInfo);
                if (copInfo is null) continue; // No Copy attribute at all

                var strategy = StrategyFactory.GetStrategy(copInfo);
                var context = new ExecutionContext(copInfo, input, output, propertyInfo);
                strategy.Execute(context);
            }

            return output;
        }

        private static CopInfo GetCopPropertyInfo(MemberInfo property)
        {
            var copyAttribute = property.GetCustomAttribute<CopyAttribute>(true);

            if (copyAttribute is null) return null;

            return new CopInfo
            {
                PropertyName = property.Name,
                CopyOption = copyAttribute.CopyOption == 0 ? CopyOption.CopyAlways : copyAttribute.CopyOption,
                TargetPropertyName = copyAttribute.OutputPropertyName
            };
        }
    }
}

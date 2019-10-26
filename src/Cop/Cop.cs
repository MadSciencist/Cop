using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cop
{
    public class Cop
    {
        public TOutput Copy<TOutput, TInput>(TOutput output, TInput input) where TInput : class where TOutput : class
        {
            GuardNotNull<TInput>(input);
            GuardNotNull<TOutput>(output);


            foreach (var property in input.GetType().GetProperties())
            {
                var copInfo = GetCopPropertyInfo(property);
                if (copInfo is null) continue; // No Copy attribute at all

                var outputProperties = output.GetType().GetProperties();

                var currentOutputProperty = outputProperties.FirstOrDefault(x =>
                    x.Name == property.Name &&
                    x.CustomAttributes.Any(attr => attr.AttributeType == typeof(CopyAttribute)));

                currentOutputProperty?.SetValue(output, property.GetValue(input));
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
                CopyOption = copyAttribute.CopyOption,
                TargetPropertyName = copyAttribute.OutputPropertyName
            };
        }

        private static void GuardNotNull<TObject>(TObject obj) where TObject : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(TObject));
            }
        }
    }
}

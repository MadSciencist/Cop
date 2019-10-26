using System.Reflection;

namespace Cop.Strategies
{
    internal abstract class CopyStrategyBase
    {
        protected PropertyInfo[] GetOutputProperties(ExecutionContext context)
        {
            return context.OutputObj.GetType().GetProperties();
        }
    }
}

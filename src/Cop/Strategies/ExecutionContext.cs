using System.Reflection;

namespace Cop.Strategies
{
    internal class ExecutionContext
    {
        internal CopInfo CopInfo { get; }
        internal object InputObj { get; }
        internal object OutputObj { get; }
        internal PropertyInfo InputProperty { get; }

        public ExecutionContext(CopInfo copInfo, object inputObj, object outputObj, PropertyInfo inputProperty)
        {
            CopInfo = copInfo;
            InputObj = inputObj;
            OutputObj = outputObj;
            InputProperty = inputProperty;
        }
    }
}

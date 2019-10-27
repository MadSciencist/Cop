using System.Reflection;

namespace Cop.Strategies
{
    internal class ExecutionContext
    {
        public CopInfo CopInfo { get; }
        public object InputObj { get; }
        public object OutputObj { get; }
        public PropertyInfo InputProperty { get; }

        public ExecutionContext(CopInfo copInfo, object inputObj, object outputObj, PropertyInfo inputProperty)
        {
            CopInfo = copInfo;
            InputObj = inputObj;
            OutputObj = outputObj;
            InputProperty = inputProperty;
        }
    }
}

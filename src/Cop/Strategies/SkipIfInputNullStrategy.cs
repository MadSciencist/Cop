namespace Cop.Strategies
{
    internal class SkipIfInputNullStrategy : CopyStrategyBase, ICopyStrategy
    {
        public void Execute(ExecutionContext context)
        {
            var inputPropertyValue = context.InputProperty.GetValue(context.InputObj);
            if (inputPropertyValue is null) return;

            new CopyAllStrategy().Execute(context);
        }
    }
}

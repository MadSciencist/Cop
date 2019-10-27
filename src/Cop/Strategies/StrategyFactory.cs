using System;

namespace Cop.Strategies
{
    internal class StrategyFactory
    {
        internal static ICopyStrategy GetStrategy(CopInfo copInfo)
        {
            Guard.NotNull(copInfo, nameof(copInfo));

            switch (copInfo)
            {
                case var _ when copInfo.CopyOption == CopyOption.SkipIfInputNull
                    && copInfo.TargetPropertyName != null && copInfo.IsInputPropertyNull:
                    return new SkipIfInputNullToDifferentTargetNameStrategy();

                case var _ when copInfo.TargetPropertyName != null:
                    return new CopyAllToDifferentTargetNameStrategy();

                case var _ when copInfo.CopyOption == CopyOption.SkipIfInputNull:
                    return new SkipIfInputNullStrategy();

                case var _ when copInfo.CopyOption == CopyOption.CopyAlways:
                    return new CopyAllStrategy();

                default:
                    throw new InvalidOperationException("Cannot match strategy for given CopInfo.");
            }
        }
    }
}

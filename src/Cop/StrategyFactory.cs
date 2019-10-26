using System;
using System.Collections.Generic;
using System.Text;
using Cop.Strategies;

namespace Cop
{
    public class StrategyFactory
    {
        static ICopyStrategy GetStrategy(CopInfo copInfo)
        {
            return new CopyAllDecoratedPropertiesStrategy();
        }
    }
}

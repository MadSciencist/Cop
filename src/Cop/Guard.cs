using System;

namespace Cop
{
    internal class Guard
    {
        internal static void NotNull(object obj, string name)
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"Parameter {name} cannot be null.");
            }
        }
    }
}

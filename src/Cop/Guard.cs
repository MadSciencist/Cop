using System;

namespace Cop
{
    internal class Guard
    {
        internal static void GuardNotNull(object obj, string name)
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"Parameter {name} cannot be null.");
            }
        }
    }
}

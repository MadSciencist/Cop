using System;

namespace Cop
{
    public class CopyAttribute : Attribute
    {
        public string OutputPropertyName { get; }
        public CopyOption CopyOption { get; }

        public CopyAttribute()
        {
            CopyOption = CopyOption.CopyAlways;
        }

        public CopyAttribute(CopyOption copyOption)
        {
            CopyOption = copyOption;
        }

        public CopyAttribute(string outputPropertyName, CopyOption copyOption = CopyOption.CopyAlways)
        {
            OutputPropertyName = outputPropertyName;
            CopyOption = copyOption;
        }
    }
}

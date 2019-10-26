using System;

namespace Cop
{
    public class CopyAttribute : Attribute
    {
        public string OutputPropertyName { get; }
        public CopyOption CopyOption { get; }

        public CopyAttribute()
        {
        }

        public CopyAttribute(CopyOption copyOption)
        {
            CopyOption = copyOption;
        }

        public CopyAttribute(string outputPropertyName)
        {
            OutputPropertyName = outputPropertyName;
        }

        public CopyAttribute(string outputPropertyName, CopyOption copyOption = CopyOption.CopyAlways)
        {
            OutputPropertyName = outputPropertyName;
            CopyOption = copyOption;
        }
    }

    public enum CopyOption
    { 
        CopyAlways = 1,
        SkipIfInputNull = 2
    }
}

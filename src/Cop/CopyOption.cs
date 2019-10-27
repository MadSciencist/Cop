namespace Cop
{
    public enum CopyOption
    { 
        /// <summary>
        /// Default. Will copy from input to output, when both properties have Copy attribute.
        /// </summary>
        CopyAlways = 1,

        /// <summary>
        /// Will skip copying property marked with this attribute, while input object's property is null.
        /// </summary>
        SkipIfInputNull = 2
    }
}
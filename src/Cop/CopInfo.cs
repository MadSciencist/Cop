namespace Cop
{
    internal class CopInfo
    {
        public string PropertyName { get; set; }
        public string TargetPropertyName { get; set; }
        public bool IsInputPropertyNull { get; set; }
        public CopyOption CopyOption { get; set; }
    }
}

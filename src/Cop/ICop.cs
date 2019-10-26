namespace Cop
{
    public interface ICop
    {
        TOutput Copy<TOutput, TInput>(TOutput output, TInput input) where TInput : class where TOutput : class;
    }
}
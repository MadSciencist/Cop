namespace Cop
{
    public interface ICop
    {
        /// <summary>
        /// Copies properties from input to output marked with Copy attribute.
        /// </summary>
        /// <typeparam name="TOutput">Type of output, should be reference type.</typeparam>
        /// <typeparam name="TInput">Type of input, should be reference type.</typeparam>
        /// <param name="output">Output (target) object.</param>
        /// <param name="input">Input entity.</param>
        /// <returns></returns>
        TOutput Copy<TOutput, TInput>(TOutput output, TInput input) where TInput : class where TOutput : class;
    }
}
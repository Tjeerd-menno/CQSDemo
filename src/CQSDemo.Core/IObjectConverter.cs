namespace CQSDemo.Core
{
    public interface IObjectConverter<out TOutput, in TInput>
    {
        TOutput Convert(TInput input);
    }
}
namespace CQSDemo.Core.Conversion
{
    public interface IObjectConverter<out TOutput, in TInput>
    {
        TOutput Convert(TInput input);
    }
}
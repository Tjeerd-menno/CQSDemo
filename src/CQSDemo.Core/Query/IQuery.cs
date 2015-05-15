namespace CQSDemo.Core.Query
{
    public interface IQuery<out TResult, in TParameters>
    {
        TResult Execute(TParameters parameters);
    }
}
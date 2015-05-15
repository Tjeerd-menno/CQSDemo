namespace CQSDemo.Core.Command
{
    public interface ICommand<in TParameters>
    {
        void Execute(TParameters command);
    }
}
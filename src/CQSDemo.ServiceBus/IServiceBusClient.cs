using DFZ.Communication;

namespace CQSDemo.ServiceBus
{
    public interface IServiceBusClient
    {
        Response Execute(Request request);
    }
}
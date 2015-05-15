using System.ServiceModel;
using DFZ.Communication;

namespace CQSDemo.ServiceBus
{
    public class ServiceBusClient : IServiceBusClient
    {
        public Response Execute(Request request)
        {
            var channelFactory = CreateChannelFactory();

            IDataService dataService = channelFactory.CreateChannel();

            Response response = dataService.Execute(request);

            channelFactory.Close();

            return response;
        }

        private static ChannelFactory<IDataService> CreateChannelFactory()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://servicebustest.defriesland.nl:11234/BusService.svc");
            return new ChannelFactory<IDataService>(binding, endpoint);
        }
    }
}
using System.Xml.Linq;
using CQSDemo.Relaties.Models;
using CQSDemo.ServiceBus;
using DFZ.Communication;

namespace CQSDemo.Relaties.Implementation
{
    public class RegistrerenSignaalBijRelatieCommand : IRegistrerenSignaalBijRelatieCommand
    {
        private readonly IServiceBusClient _serviceBusClient;
        private readonly ISignaalConverter _signaalConverter;

        public RegistrerenSignaalBijRelatieCommand(IServiceBusClient serviceBusClient, ISignaalConverter signaalConverter)
        {
            _serviceBusClient = serviceBusClient;
            _signaalConverter = signaalConverter;
        }

        public void Execute(Signaal signaal)
        {
            XElement signaalElement = _signaalConverter.Convert(signaal);
            CallService(signaalElement);
        }

        private void CallService(XElement signaalElement)
        {
            Request request = new Request
            {
                Name = "Vastleggen Signaal",
                MessageType = MessageType.RequestResponse,
                ErrorMode = ErrorMode.ThrowOnError,
                Parameters = new[]
                {
                    new Parameter {Name = signaalElement.Name.LocalName, Value = signaalElement.InnerXml()},
                    new Parameter { Name = "userid", Value = "BSN"}
                }
            };

            _serviceBusClient.Execute(request);
        }

    }
}
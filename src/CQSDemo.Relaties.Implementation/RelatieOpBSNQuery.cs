using CQSDemo.Relaties.Models;
using CQSDemo.ServiceBus;
using DFZ.Communication;


namespace CQSDemo.Relaties.Implementation
{
    public class RelatieOpBSNQuery : IRelatieOpBSNQuery
    {
        private readonly IServiceBusClient _client;
        private readonly IRelatieConverter _relatieConverter;

        public RelatieOpBSNQuery(IServiceBusClient client, IRelatieConverter relatieConverter)
        {
            _client = client;
            _relatieConverter = relatieConverter;
        }

        public Relatie Execute(string parameters)
        {
            var response = CallService(parameters);

            if (response.Result.Length == 1 && response.Fault == null)
            {
                return _relatieConverter.Convert(response.Result[0]);
            }
            return null;
        }

        private Response CallService(string bsn)
        {
            Request request = new Request
            {
                Name = "Raadplegen Relatie REPL",
                MessageType = MessageType.RequestResponse,
                ErrorMode = ErrorMode.NeverThrow,
                Parameters = new[]
                {
                    new Parameter {Name = "bsn", Value = bsn},
                    new Parameter { Name = "aanroepvariant", Value = "BSN"} 
                }
            };

            Response response = _client.Execute(request);
            return response;
        }
    }
}
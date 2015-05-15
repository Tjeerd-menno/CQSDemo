using System;
using System.Diagnostics;
using DFZ.Communication;
using Microsoft.Framework.Logging;

namespace CQSDemo.ServiceBus
{
    public class ServiceBusClientLogger : IServiceBusClient
    {
        private readonly IServiceBusClient _serviceBusClient;
        private readonly ILogger _logger;

        public ServiceBusClientLogger(IServiceBusClient serviceBusClient, ILogger logger)
        {
            _serviceBusClient = serviceBusClient;
            _logger = logger;
        }

        public Response Execute(Request request)
        {
            _logger.LogDebug(1000, "{0} START Executing request {1}", DateTime.Now.Ticks, request.Name);

            Stopwatch stopwatch = Stopwatch.StartNew();

            Response response = _serviceBusClient.Execute(request);

            stopwatch.Stop();

            _logger.LogDebug(1000, "{0} FINISHED Executing request {1} in {2}", DateTime.Now.Ticks, request.Name, stopwatch.ElapsedMilliseconds);

            return response;
        }
    }
}
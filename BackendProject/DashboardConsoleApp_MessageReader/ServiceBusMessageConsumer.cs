using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashboardConsoleApp_MessageReader
{
    public  class ServiceBusMessageConsumer
    {
        private static string Connection_String = "Endpoint=sb://xxx.servicebus.windows.net/;SharedAccessKeyName=palpolicy;SharedAccessKey=xxx;TransportType=AmqpWebSockets";
        private static string QUEUE_NAME = "palqueue1";
        private QueueClient _queueClient;
        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            _queueClient = new QueueClient(
              Connection_String,
              QUEUE_NAME);
            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }
        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var myPayload = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine(myPayload);
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            //_logger.LogError(exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");

            return Task.CompletedTask;
        }
        public async Task CloseQueueAsync()
        {
            await _queueClient.CloseAsync();
        }
    }
}

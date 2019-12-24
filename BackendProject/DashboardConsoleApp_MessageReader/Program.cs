using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace DashboardConsoleApp_MessageReader
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine(@"This console application is reading message on service bus and will process 
                them for application use or audit purpose");
            ServiceBusMessageConsumer obj = new ServiceBusMessageConsumer();
            obj.RegisterOnMessageHandlerAndReceiveMessages();

            Console.WriteLine("Press key to exist");
            Console.ReadLine();
            obj.CloseQueueAsync();
        }

       
    }
}

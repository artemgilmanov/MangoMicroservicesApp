using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;


namespace Mango.MessageBus
{
    internal class MessageBus : IMessageBus
    {
        private string connectionString = "connectionStringFromServiceBus";
        public async Task PublishMessage(object message, string topic_queue_Name)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topic_queue_Name);

            var jsonMessage = JsonConverter.SerializeObject(message);

            ServiceBusMessage finaleMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finaleMessage);
            await client.DisposeAsync();

        }
    }
}

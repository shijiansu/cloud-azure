using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Threading.Tasks;

public class Program
{
    private const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=asyncstorshijian;AccountKey=scVuRGSus/ArN0FusslyT1OkWYQd8Jc9vI4Az6WLk7r0fkj+z5Mbm/BkhuMMz0Zw1ezs4LftwCOgD1mmtNCi2A==;EndpointSuffix=core.windows.net";
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        // Validate Azure Storage access
        QueueClient client = new QueueClient(storageConnectionString, queueName);        
        await client.CreateAsync();

        Console.WriteLine($"---Account Metdata---");
        Console.WriteLine($"Account Uri:\t{client.Uri}");

        Console.WriteLine($"---Existing Messages---");
        int batchSize = 10;
        TimeSpan visibilityTimeout = TimeSpan.FromSeconds(2.5d);
        
        // read message
        Response<QueueMessage[]> messages = await client.ReceiveMessagesAsync(batchSize, visibilityTimeout);

        foreach(QueueMessage message in messages?.Value)
        {
            Console.WriteLine($"[{message.MessageId}]\t{message.MessageText}");
            // delete message
            // read message will not directly delete it.
            // if comment below, then the message will keep growing in the queue
            // await client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }

        Console.WriteLine($"---New Messages---");
        string greeting = "Hi, Developer!";

        // send message
        await client.SendMessageAsync(greeting);

        Console.WriteLine($"Sent Message:\t{greeting}");
    }
}
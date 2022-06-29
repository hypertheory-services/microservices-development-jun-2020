// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");



// one channel per server, you can use the same channel for all services on that server
var channel = GrpcChannel.ForAddress("https://localhost:4443");

var client = new GrpcServer.Greeter.GreeterClient(channel);
var topicClient = new GrpcServer.NotificationsService.NotificationsServiceClient(channel);

Console.Write("What is your name? :");
var name = Console.ReadLine();

var reply = await client.SayHelloAsync(new GrpcServer.HelloRequest { Name = name });

Console.WriteLine($"The Server said {reply.Message}");

Console.WriteLine("What topic do you want to 'subscribe to'? ");
var topic = Console.ReadLine();

using var streamingCall = topicClient.GetNotificationsForTopic(
    new GrpcServer.TopicRequest { TopicName = topic });


await foreach( var response in streamingCall.ResponseStream.ReadAllAsync() )
{
    Console.WriteLine(response.Message);
}
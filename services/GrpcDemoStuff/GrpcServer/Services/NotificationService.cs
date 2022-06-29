using Grpc.Core;

namespace GrpcServer.Services;

public class NotificationService : NotificationsService.NotificationsServiceBase
{
    public override async Task GetNotificationsForTopic(TopicRequest request, IServerStreamWriter<TopicResponse> responseStream, ServerCallContext context)
    {
        var message = request.TopicName;

        while(!context.CancellationToken.IsCancellationRequested)
        {
           // await Task.Delay(new Random().Next(1000, 5000));
            await responseStream.WriteAsync(new TopicResponse { Message = $"Your Topic Said ${DateTime.Now}" });
        }
    }
}

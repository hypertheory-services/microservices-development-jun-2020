// See https://aka.ms/new-console-template for more information
Console.WriteLine("Send a Message!");


//
var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:1337");
while(true)
{
    Console.Write("What is the email address?: ");
    var email = Console.ReadLine();

    Console.Write("What is the message?: ");
    var message = Console.ReadLine();

    var messageToSend = new EmailMessage(email, message);
    var httpMessageBody = new HttpRequestMessage();
    var json = System.Text.Json.JsonSerializer.Serialize(messageToSend);
    httpMessageBody.Content = new StringContent(json);
    httpMessageBody.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    // call the service.

    var response = client.PostAsync("/messages", httpMessageBody.Content).Result;
    // inspect the response... 
    if(response.IsSuccessStatusCode)
    {
        Console.WriteLine("Your Message Was Sent");

    } else
    {
        Console.WriteLine($"Got a {response.StatusCode}. Sorry");
    }
}

public record EmailMessage(string emailAddress, string message);

using Microsoft.Extensions.DependencyInjection;
using OllamaClient;
using Microsoft.Extensions.DependencyInjection;
using OllamaClient;
using OllamaClient.Extensions;

namespace Ollama_API_Teting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            var serviceProvider = new ServiceCollection()
                      .AddOllamaClient()
                      .BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<IOllamaHttpClient>();

            var pullResult = client.Pull(new OllamaClient.Models.PullRequest()
            {
                Name = "phi3",
            }, CancellationToken.None);

            Console.WriteLine(pullResult.Status);


            var models = client.GetModels(CancellationToken.None);

            //foreach (var model in models.Models)
            //{
            //    Console.WriteLine(model.Name);
            //}

            var result = client.SendChat(new OllamaClient.Models.ChatStreamRequest()
            {
                Model = "phi3",

                Messages = new List<OllamaClient.Models.Message>()
                { new OllamaClient.Models.Message()
                    {
                        Role = "user",
                        Content = "Hello, how are you?"
                    }
                }
            }, CancellationToken.None);


            await foreach (var message in result)
                  {
                if (message.Message is null) continue;

                Console.Write(message.Message.Content);
                  }

        }
    }
}

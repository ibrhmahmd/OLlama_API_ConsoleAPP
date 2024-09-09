using Microsoft.Extensions.DependencyInjection;
using OllamaClient;
using OllamaClient.Extensions;

namespace Ollama_API_Teting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                      .AddOllamaClient()
                      .BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<IOllamaHttpClient>();

            const string modelName = "phi3"; // matches one of the installed models

            // Synchronous call to Pull
            var pullResult = client.Pull(new OllamaClient.Models.PullRequest()
            {
                Name = modelName
            }, CancellationToken.None);


            Console.WriteLine(pullResult.Status);


            // Synchronous call to GetModels
            var models = client.GetModels(CancellationToken.None);

            //foreach (var model in models.Models)
            //{
            //    Console.WriteLine(model.Name);
            //}

            while (true)
            {
                Console.WriteLine("\nEnter :");
                var prompt = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(prompt))
                {
                    Console.WriteLine("Prompt cannot be empty, please enter a valid prompt.");
                }
                else
                {
                    var result = client.SendChat(new OllamaClient.Models.ChatStreamRequest()
                    {
                        Model = "phi3",

                        Messages = new List<OllamaClient.Models.Message>()
                        {
                            new OllamaClient.Models.Message()
                            {
                                Role = "user",
                                Content = prompt
                            }
                        }
                    }, CancellationToken.None);

                    await foreach (var message in result)
                    {
                        if (!string.IsNullOrEmpty(message?.Message?.Content))
                        {
                            Console.Write(modelName + " : " + message.Message.Content);
                        }
                    }
                }
            }
        }
    }
}

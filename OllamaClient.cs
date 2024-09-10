using Microsoft.Extensions.DependencyInjection;
using OllamaClient;
using OllamaClient.Extensions;
using OllamaClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ollama_API_Testing
{
    public class OllamaClient
    {
        private readonly IOllamaHttpClient _client;
        private readonly string _modelName;

        public OllamaClient(string modelName)
        {
            _modelName = modelName;

            var serviceProvider = new ServiceCollection()
                                  .AddOllamaClient()
                                  .BuildServiceProvider();

            _client = serviceProvider.GetRequiredService<IOllamaHttpClient>();
        }

        // Method to pull the model (asynchronous)
        private async Task PullModel()
        {
            try
            {
                var pullResult = await _client.Pull(new PullRequest
                {
                    Name = _modelName
                }, CancellationToken.None);

                Console.WriteLine($"Model pull status: {pullResult.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error pulling model: {ex.Message}");
            }
        }



        // fetching installed models (asynchronous)
        private async Task ListInstalledModels()
        {
            try
            {
                var modelsResponse = await _client.GetModels(CancellationToken.None);

                Console.WriteLine("Installed Models:");
                foreach (var model in modelsResponse.Models)
                {
                    Console.WriteLine(model.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching models: {ex.Message}");
            }
        }

        // chat interaction and return a full response (asynchronous)
        private async Task<string> GetChatResponse(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Prompt cannot be empty", nameof(prompt));
            }

            try
            {
                var result = _client.SendChat(new ChatStreamRequest
                {
                    Model = _modelName,
                    Messages = new List<Message>
                    {
                        new Message
                        {
                            Role = "user",
                            Content = prompt
                        }
                    }
                }, CancellationToken.None);

                StringBuilder fullResponse = new StringBuilder();

                await foreach (var message in result)
                {
                    if (!string.IsNullOrEmpty(message?.Message?.Content))
                    {
                        fullResponse.Append(message.Message.Content);
                    }
                }

                return fullResponse.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during chat interaction: {ex.Message}");
                return string.Empty;
            }
        }

        //start the loop
        public async Task StartChatLoop()
        {
            // pull model
            await PullModel();

            // list models
            await ListInstalledModels();

            // loop for chat 
            while (true)
            {
                Console.Write("\nEnter prompt (or type 'exit' to quit): ");
                var prompt = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(prompt))
                {
                    Console.WriteLine("Prompt cannot be empty. Please try again.");
                    continue;
                }

                if (prompt.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // response
                var response = await GetChatResponse(prompt);
                Console.WriteLine($"{_modelName}: {response}");
            }
        }
    }
}
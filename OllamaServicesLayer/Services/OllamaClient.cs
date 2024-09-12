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
        private string _modelName;

        public OllamaClient()
        {
            var serviceProvider = new ServiceCollection()
                                  .AddOllamaClient()
                                  .BuildServiceProvider();

            _client = serviceProvider.GetRequiredService<IOllamaHttpClient>();
        }




        //get installed models to select
        public async Task SelectModelAsync()
        {
            try
            {
                var modelsResponse = await _client.GetModels(CancellationToken.None);
                Console.WriteLine("Installed Models:");

                for (int i = 0; i < modelsResponse.Models.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {modelsResponse.Models[i].Name}");
                }

                Console.WriteLine("Select a model by entering the corresponding number:");
                if (int.TryParse(Console.ReadLine(), out int selectedIndex) &&
                    selectedIndex > 0 && selectedIndex <= modelsResponse.Models.Count())
                {
                    _modelName = modelsResponse.Models[selectedIndex - 1].Name;
                    Console.WriteLine($"Selected model: {_modelName}");
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    await SelectModelAsync(); // Prompt the user again if the input is invalid
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching models: {ex.Message}");
            }
        }






        // pull model (synchronous)
        private void PullModel()
        {
            try
            {
                if (string.IsNullOrEmpty(_modelName))
                {
                    Console.WriteLine("No model selected. Please select a model first.");
                    return;
                }

                var pullRequest = new PullRequest
                {
                    Name = _modelName
                };

                var pullResult = _client.Pull(pullRequest, CancellationToken.None);
                Console.WriteLine($"Model pull status: {pullResult.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error pulling model: {ex.Message}");
            }
        }





        // chat and return a full response (asynchronous)
        private async Task<string> GetChatResponse(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Prompt cannot be empty", nameof(prompt));
            }

            if (string.IsNullOrEmpty(_modelName))
            {
                throw new InvalidOperationException("Model is not selected.");
            }

            try
            {
                var chatRequest = new ChatStreamRequest
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
                };

                var result = _client.SendChat(chatRequest, CancellationToken.None);

                StringBuilder fullResponse = new StringBuilder();

                await foreach (var message in result)
                {
                    if (!string.IsNullOrEmpty(message?.Message?.Content))
                    {
                        fullResponse.Append(message.Message.Content);
                        //Console.Write(message.Message.Content); // Output each message as it's received
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

        // start the chat loop
        public async Task StartChatLoop()
        {
            // select 
            await SelectModelAsync();

            // pull model
            PullModel();

            // loop chat 
            while (true)
            {
                Console.WriteLine("\nEnter prompt (or type 'exit' to quit):");
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

                // get response 
                var response = await GetChatResponse(prompt);
                Console.WriteLine($"\n{_modelName}: {response}");
            }
        }
    }
}

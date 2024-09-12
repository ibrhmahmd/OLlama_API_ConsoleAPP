using OllamaSharp;
using OllamaSharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Ollama_API_Testing
{
   
    public class OllamaSharp
    {
        private readonly OllamaApiClient ollama;
        private string modelName;
        private Chat chat;





        public OllamaSharp(string serverUrl)
        {
            this.ollama = new OllamaApiClient(new Uri(serverUrl));
        }

        
        public async Task Initialize()
        {
            await ListModels();
            await SelectModel();
            await EnsureModelAvailable();

            this.chat = new Chat(ollama);
            Console.WriteLine("\nChat initialized. Ready to start conversation.");
        }

        public async Task ListModels()
        {
            Console.WriteLine("Available models:");
            var models = await ollama.ListLocalModels();
            foreach (var model in models)
            {
                Console.WriteLine($"- {model.Name}");
            }
        }


        private async Task SelectModel()
        {
            while (true)
            {
                Console.Write("\nEnter the name : ");
                modelName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(modelName))
                {
                    Console.WriteLine("Model name cannot be empty.");
                    continue;
                }

                var models = await ollama.ListLocalModels();
                if (models.Any(m => m.Name.Equals(modelName, StringComparison.OrdinalIgnoreCase)))
                {
                    ollama.SelectedModel = modelName;
                    Console.WriteLine($"Selected model: {modelName}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Model '{modelName}' not found. choose from the available models.");
                }
            }
        }





        public async Task EnsureModelAvailable()
        {
            Console.WriteLine($"\nEnsuring {modelName} is available. Pulling if necessary...");
            await foreach (var status in ollama.PullModel(modelName))
            {
                Console.Write($"\rProgress: {status.Percent}% - {status.Status}");
            }
            Console.WriteLine("\nModel ready.");
        }




        public async Task RunChat()
        {
            Console.WriteLine("\nChat started. Type your messages (or 'exit' to quit):");

            while (true)
            {
                Console.Write("\nYou: ");
                var userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Message cannot be empty. Please try again.");
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    break;
                }

                Console.Write($"{modelName}: ");
                await foreach (var response in chat.Send(userInput))
                {
                    Console.Write(response);
                }
                Console.WriteLine(); // New line after complete response
            }

            Console.WriteLine("Chat ended. Goodbye!");
        }
    }
}

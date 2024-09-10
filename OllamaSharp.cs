using OllamaSharp;
using OllamaSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ollama_API_Teting
{
   
    public class OllamaChatProgram
    {
        private readonly OllamaApiClient ollama;
        private readonly string modelName;
        private Chat chat;

        public OllamaChatProgram(string serverUrl, string modelName)
        {
            this.ollama = new OllamaApiClient(new Uri(serverUrl));
            this.modelName = modelName;
            this.ollama.SelectedModel = modelName;
        }

        public async Task Initialize()
        {
            Console.WriteLine($"Using model: {modelName}");

            await ListModels();
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

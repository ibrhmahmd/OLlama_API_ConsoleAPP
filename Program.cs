using Microsoft.Extensions.DependencyInjection;
using Ollama_API_Teting;
using OllamaClient;
using OllamaClient.Extensions;
using System.Text;
using System.Threading;

namespace Ollama_API_Testing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            ////ollamaSharp method
            //var chatProgram = new OllamaChatProgram("http://localhost:11434", "phi3");
            //await chatProgram.Initialize();
            //await chatProgram.RunChat();






            // ollamaClient method 
            const string modelName = "phi3"; // Example model name

            // Create an instance of OllamaClient
            var ollamaClient = new OllamaClient(modelName);

            // Start the chat loop
            await ollamaClient.StartChatLoop();
        }
    }
}




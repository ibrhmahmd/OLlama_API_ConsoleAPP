using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ollama_API_Teting.DataAccessLayer;

namespace Ollama_API_Testing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Build the host to configure services
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Configure DbContext with connection string from configuration
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                })
                .Build();

            // Resolve DbContext and perform operations
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Perform database operations here
            }
        }



        ////ollamaSharp method
        //var chatProgram = new OllamaSharp("http://localhost:11434");
        //await chatProgram.Initialize();
        //await chatProgram.RunChat();

        //// ollamaClient method 
        //const string modelName = "phi3"; // Example model name
        //var ollamaClient = new OllamaClient();
        //await ollamaClient.StartChatLoop();
    }
}




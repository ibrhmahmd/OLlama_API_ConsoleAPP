using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=IBRAHIM;Initial Catalog=OllamaChatDB;Integrated Security=True;Trust Server Certificate=True");

        public DbSet<User> Users { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<AIResponse> AIResponses { get; set; }
        public DbSet<LanguageModel> LanguageModels { get; set; }
        public DbSet<ModelCategory> ModelCategories { get; set; }
        public DbSet<RateLimitLog> RateLimitLogs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<AnalyticsLog> AnalyticsLogs { get; set; }
    }

}

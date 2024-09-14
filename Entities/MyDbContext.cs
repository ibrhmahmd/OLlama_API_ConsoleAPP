using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Ollama_API_Testing.DataAccessLayer
{
    public class MyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=IBRAHIM;Initial Catalog=OllamaChatDB;Integrated Security=True;Trust Server Certificate=True");

        public DbSet<User> Users { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ModelPrompt> Prompts { get; set; }
        public DbSet<AIResponse> AIResponses { get; set; }
        public DbSet<AIModel> LanguageModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<AnalyticsLog> AnalyticsLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure AIResponse to ChatSession relationship
            modelBuilder.Entity<AIResponse>()
                .HasOne(a => a.ChatSession)
                .WithMany()  // No collection on ChatSession 
                .HasForeignKey(a => a.ChatSessionID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths

            // Configure AIResponse to Feedback relationship
            modelBuilder.Entity<AIResponse>()
                .HasMany(a => a.Feedbacks)
                .WithOne()  // Assuming Feedback does not have a navigation property back to AIResponse
                .HasForeignKey("AIResponseId") 
                .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths
        }
    }
}

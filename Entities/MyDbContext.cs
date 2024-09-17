using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;

namespace Ollama_API_Testing.DataAccessLayer
{
    public class MyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Check if already configured (e.g., during tests)
            {
                optionsBuilder.UseSqlServer("Data Source=IBRAHIM;Initial Catalog=OllamaChatDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }


        public DbSet<User> Users { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ModelPrompt> Prompts { get; set; }
        public DbSet<AIModel> AIModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<AnalyticsLog> AnalyticsLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship between ChatMessage and Feedback
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.ChatMessage)
                .WithMany(cm => cm.Feedbacks)
                .HasForeignKey(f => f.ChatMessageID)
                .OnDelete(DeleteBehavior.NoAction); // Avoid cascade delete for ChatMessage


            // Configure relationship between ChatMessage and User
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.ChatMessages)
                .HasForeignKey(cm => cm.UserID)
                .OnDelete(DeleteBehavior.NoAction); // Avoid cascade delete for User

            // Configure relationship between ChatMessage and ChatSession
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.ChatSession)
                .WithMany(cs => cs.ChatMessages)
                .HasForeignKey(cm => cm.ChatSessionID)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascading delete for ChatSession

            // Configure relationship between ChatMessage and AIModel
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.AIModel)
                .WithMany(am => am.ChatMessages) 
                .HasForeignKey(cm => cm.AIModelID)
                .OnDelete(DeleteBehavior.NoAction); // Avoid cascade delete for AIModel
        }
    }
}

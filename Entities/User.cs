using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Ollama_API_Testing.DataAccessLayer
{

    public class User : IdentityUser<Guid>
    {

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        public virtual ICollection<ChatSession> ChatSessions { get; set; }
        public virtual ICollection<AIModel> Models { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<AnalyticsLog> AnalyticsLogs { get; set; }



        //[Key]
        //public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Username { get; set; }

        //[Required]
        //[EmailAddress]
        //[StringLength(100)]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(256)] // Adjust length according to your hashing method
        //public string Password { get; set; }

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class Prompt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserInput { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        [StringLength(50)]
        public string LanguageModel { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Context { get; set; }

        // Navigation properties
        public virtual ChatSession ChatSession { get; set; }
        public virtual User User { get; set; }
    }
}

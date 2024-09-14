using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Testing.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class ModelPrompt
    {
        [Key]
        public Guid ModelPromptID { get; set; }

        [Required]
        public string UserInput { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public Guid ModelID{ get; set; }
        public AIModel LanguageModel { get; set; }


        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [StringLength(300)]
        public string? Discrepsion { get; set; }
        
    }
}

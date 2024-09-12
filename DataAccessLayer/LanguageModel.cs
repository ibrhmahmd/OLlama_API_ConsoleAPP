using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class LanguageModel
    {
        [Key]
        public int ModelId { get; set; }

        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Version { get; set; }

        [Required]
        public DateTime ReleasedAt { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        public string TrainingData { get; set; }

        [Range(0.0, double.MaxValue)]
        public double CostPerToken { get; set; }

        [Range(0.0, 1.0)]
        public double Accuracy { get; set; }

        public string LanguagesSupported { get; set; } // If this is a list, consider using a different structure

        public long Parameters { get; set; }

        public bool IsQuantized { get; set; }

        public bool IsCustomizable { get; set; }

        // Navigation properties
        public virtual ICollection<ModelCategory> Categories { get; set; }
        public virtual ICollection<ChatSession> ChatSessions { get; set; }
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Testing.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class AIModel
    {
        [Key]
        public Guid AIModelID { get; set; }

        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }

        public string? Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Version { get; set; }

        [Required]
        public DateTime ReleasedAt { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        public string? TrainingData { get; set; }

        //[Range(0.0, double.MaxValue)]
        //public double CostPerToken { get; set; }

        [Range(0.0, 1.0)]
        public double Accuracy { get; set; }

        public List<string> LanguagesSupported { get; set; } // List of languages the model supports

        public long Parameters { get; set; }

        public string Quantization { get; set; }          // Indicates if the model quantization level
        public bool IsCustomizable { get; set; }       // Indicates if the model can be fine-tuned


        // Navigation properties
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ChatSession> ChatSessions { get; set; }
    }

}
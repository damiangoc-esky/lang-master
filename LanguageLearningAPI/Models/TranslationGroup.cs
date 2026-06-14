using System.ComponentModel.DataAnnotations;

namespace LanguageLearningAPI.Models
{
    public class TranslationGroup
    {
        [Key]
        public int GroupID { get; set; }

        [Required]
        [MaxLength(255)]
        public string GroupName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // ISO 639-1 language codes (e.g. "pl", "en") describing the translation
        // direction for every pair in this group: SourceContent -> TargetContent.
        [Required]
        [MaxLength(10)]
        public string SourceLanguage { get; set; } = "pl";

        [Required]
        [MaxLength(10)]
        public string TargetLanguage { get; set; } = "en";

        public List<TranslationPair> TranslationPairs { get; set; } = new();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageLearningAPI.Models
{
    public enum ContentType
    {
        Word,
        Phrase,
        Sentence
    }

    public class TranslationPair
    {
        [Key]
        public int PairID { get; set; }

        [ForeignKey(nameof(TranslationGroup))]
        public int GroupID { get; set; }

        public TranslationGroup? TranslationGroup { get; set; }

        // Language-agnostic content. The actual languages are defined on the
        // parent TranslationGroup (SourceLanguage / TargetLanguage).
        [Required]
        public string SourceContent { get; set; } = string.Empty;

        [Required]
        public string TargetContent { get; set; } = string.Empty;

        [Required]
        public ContentType Type { get; set; }
    }
}

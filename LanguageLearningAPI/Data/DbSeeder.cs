using LanguageLearningAPI.Models;

namespace LanguageLearningAPI.Data
{
    /// <summary>
    /// Seeds a small set of starter content so the app has something to show
    /// before real data is entered. Idempotent: it only seeds when the
    /// TranslationGroups table is empty, so it is safe to run on every startup.
    /// </summary>
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            if (db.TranslationGroups.Any())
            {
                return; // already seeded
            }

            // Group 1 — Polish -> English
            var weather = new TranslationGroup
            {
                GroupName = "Weather",
                Description = "Common weather vocabulary",
                SourceLanguage = "pl",
                TargetLanguage = "en",
                TranslationPairs = new List<TranslationPair>
                {
                    new() { SourceContent = "pogoda", TargetContent = "weather", Type = ContentType.Word },
                    new() { SourceContent = "deszcz", TargetContent = "rain", Type = ContentType.Word },
                    new() { SourceContent = "słońce", TargetContent = "sun", Type = ContentType.Word },
                    new() { SourceContent = "Jaka jest pogoda?", TargetContent = "What is the weather like?", Type = ContentType.Sentence },
                }
            };

            // Group 2 — Spanish -> English (demonstrates the multi-language capability)
            var greetings = new TranslationGroup
            {
                GroupName = "Greetings",
                Description = "Everyday Spanish greetings",
                SourceLanguage = "es",
                TargetLanguage = "en",
                TranslationPairs = new List<TranslationPair>
                {
                    new() { SourceContent = "hola", TargetContent = "hello", Type = ContentType.Word },
                    new() { SourceContent = "buenos días", TargetContent = "good morning", Type = ContentType.Phrase },
                    new() { SourceContent = "¿Cómo estás?", TargetContent = "How are you?", Type = ContentType.Sentence },
                }
            };

            db.TranslationGroups.AddRange(weather, greetings);
            db.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Data migration: seeds a beginner-level Italian -> English vocabulary set
    /// (greetings, numbers, colors, food &amp; drink, days of the week, common words).
    ///
    /// IDs are left to the database to generate so this never collides with the
    /// startup seed data; pairs link to their group via a subquery on GroupName.
    /// Idempotent-ish: each group is only inserted when a group with the same name
    /// does not already exist, so re-applying (or pairing with DbSeeder) is safe.
    /// </summary>
    public partial class SeedItalianBeginnerVocab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedGroup(migrationBuilder,
                groupName: "Italian — Greetings & Politeness",
                description: "Beginner Italian greetings and polite expressions",
                pairs: @"
                    ('ciao', 'hello / hi', 'Word'),
                    ('buongiorno', 'good morning', 'Word'),
                    ('buonasera', 'good evening', 'Word'),
                    ('buonanotte', 'good night', 'Word'),
                    ('arrivederci', 'goodbye', 'Word'),
                    ('per favore', 'please', 'Phrase'),
                    ('grazie', 'thank you', 'Word'),
                    ('prego', 'you''re welcome', 'Word'),
                    ('scusa', 'excuse me / sorry', 'Word'),
                    ('sì', 'yes', 'Word'),
                    ('no', 'no', 'Word'),
                    ('Come stai?', 'How are you?', 'Sentence'),
                    ('Mi chiamo...', 'My name is...', 'Phrase')");

            SeedGroup(migrationBuilder,
                groupName: "Italian — Numbers 1–10",
                description: "Beginner Italian numbers one to ten",
                pairs: @"
                    ('uno', 'one', 'Word'),
                    ('due', 'two', 'Word'),
                    ('tre', 'three', 'Word'),
                    ('quattro', 'four', 'Word'),
                    ('cinque', 'five', 'Word'),
                    ('sei', 'six', 'Word'),
                    ('sette', 'seven', 'Word'),
                    ('otto', 'eight', 'Word'),
                    ('nove', 'nine', 'Word'),
                    ('dieci', 'ten', 'Word')");

            SeedGroup(migrationBuilder,
                groupName: "Italian — Colors",
                description: "Beginner Italian color vocabulary",
                pairs: @"
                    ('rosso', 'red', 'Word'),
                    ('blu', 'blue', 'Word'),
                    ('verde', 'green', 'Word'),
                    ('giallo', 'yellow', 'Word'),
                    ('nero', 'black', 'Word'),
                    ('bianco', 'white', 'Word'),
                    ('arancione', 'orange', 'Word'),
                    ('rosa', 'pink', 'Word')");

            SeedGroup(migrationBuilder,
                groupName: "Italian — Food & Drink",
                description: "Beginner Italian food and drink vocabulary",
                pairs: @"
                    ('acqua', 'water', 'Word'),
                    ('pane', 'bread', 'Word'),
                    ('vino', 'wine', 'Word'),
                    ('caffè', 'coffee', 'Word'),
                    ('latte', 'milk', 'Word'),
                    ('formaggio', 'cheese', 'Word'),
                    ('mela', 'apple', 'Word'),
                    ('pizza', 'pizza', 'Word')");

            SeedGroup(migrationBuilder,
                groupName: "Italian — Days of the Week",
                description: "Beginner Italian days of the week",
                pairs: @"
                    ('lunedì', 'Monday', 'Word'),
                    ('martedì', 'Tuesday', 'Word'),
                    ('mercoledì', 'Wednesday', 'Word'),
                    ('giovedì', 'Thursday', 'Word'),
                    ('venerdì', 'Friday', 'Word'),
                    ('sabato', 'Saturday', 'Word'),
                    ('domenica', 'Sunday', 'Word')");

            SeedGroup(migrationBuilder,
                groupName: "Italian — Common Words",
                description: "Beginner Italian everyday nouns and words",
                pairs: @"
                    ('uomo', 'man', 'Word'),
                    ('donna', 'woman', 'Word'),
                    ('casa', 'house / home', 'Word'),
                    ('amico', 'friend', 'Word'),
                    ('gatto', 'cat', 'Word'),
                    ('cane', 'dog', 'Word'),
                    ('oggi', 'today', 'Word'),
                    ('domani', 'tomorrow', 'Word')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Cascade delete on the FK removes the associated TranslationPairs.
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'Italian — Greetings & Politeness',
                    'Italian — Numbers 1–10',
                    'Italian — Colors',
                    'Italian — Food & Drink',
                    'Italian — Days of the Week',
                    'Italian — Common Words'
                );");
        }

        private static void SeedGroup(MigrationBuilder migrationBuilder, string groupName, string description, string pairs)
        {
            var name = groupName.Replace("'", "''");
            var desc = description.Replace("'", "''");

            migrationBuilder.Sql($@"
                INSERT INTO ""TranslationGroups"" (""GroupName"", ""Description"", ""SourceLanguage"", ""TargetLanguage"")
                SELECT '{name}', '{desc}', 'it', 'en'
                WHERE NOT EXISTS (
                    SELECT 1 FROM ""TranslationGroups"" WHERE ""GroupName"" = '{name}'
                );

                INSERT INTO ""TranslationPairs"" (""GroupID"", ""SourceContent"", ""TargetContent"", ""Type"")
                SELECT g.""GroupID"", v.src, v.tgt, v.type
                FROM ""TranslationGroups"" g
                CROSS JOIN (VALUES {pairs}) AS v(src, tgt, type)
                WHERE g.""GroupName"" = '{name}'
                  AND NOT EXISTS (
                      SELECT 1 FROM ""TranslationPairs"" p
                      WHERE p.""GroupID"" = g.""GroupID"" AND p.""SourceContent"" = v.src
                  );");
        }
    }
}

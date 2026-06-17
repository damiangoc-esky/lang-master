using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Seeds two Advanced Polish → English groups of idiomatic language: common
    /// idioms and proverbs/sayings. The Polish side is the natural equivalent, the
    /// English side the idiom — so a learner recalls the idiom from its meaning.
    /// </summary>
    public partial class SeedEnglishIdioms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedGroup(migrationBuilder, "pl", "en", "Advanced", "English — Idioms", "Polish → English common idioms (Polish equivalent → English idiom)", @"
                ('To bułka z masłem.', 'It''s a piece of cake.', 'Phrase'),
                ('Leje jak z cebra.', 'It''s raining cats and dogs.', 'Sentence'),
                ('Trzymaj kciuki.', 'Keep your fingers crossed.', 'Phrase'),
                ('Raz na ruski rok.', 'Once in a blue moon.', 'Phrase'),
                ('Kosztować fortunę.', 'To cost an arm and a leg.', 'Phrase'),
                ('Czuć się nie w sosie.', 'To feel under the weather.', 'Phrase'),
                ('Owijać w bawełnę.', 'To beat around the bush.', 'Phrase'),
                ('Spać jak suseł.', 'To sleep like a log.', 'Phrase'),
                ('O wilku mowa.', 'Speak of the devil.', 'Phrase'),
                ('Rzut beretem.', 'A stone''s throw away.', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "en", "Advanced", "English — Proverbs & Sayings", "Polish → English proverbs and sayings (Polish equivalent → English proverb)", @"
                ('Lepszy wróbel w garści niż gołąb na dachu.', 'A bird in the hand is worth two in the bush.', 'Sentence'),
                ('Kto rano wstaje, temu Pan Bóg daje.', 'The early bird catches the worm.', 'Sentence'),
                ('Nie oceniaj książki po okładce.', 'Don''t judge a book by its cover.', 'Sentence'),
                ('Co dwie głowy, to nie jedna.', 'Two heads are better than one.', 'Sentence'),
                ('Lepiej późno niż wcale.', 'Better late than never.', 'Sentence'),
                ('Ćwiczenie czyni mistrza.', 'Practice makes perfect.', 'Sentence'),
                ('Gdzie kucharek sześć, tam nie ma co jeść.', 'Too many cooks spoil the broth.', 'Sentence'),
                ('Nie ma tego złego, co by na dobre nie wyszło.', 'Every cloud has a silver lining.', 'Sentence'),
                ('Czego oczy nie widzą, tego sercu nie żal.', 'Out of sight, out of mind.', 'Sentence'),
                ('Jabłko niedaleko pada od jabłoni.', 'The apple doesn''t fall far from the tree.', 'Sentence')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'English — Idioms',
                    'English — Proverbs & Sayings'
                );");
        }

        private static void SeedGroup(MigrationBuilder migrationBuilder, string sourceLang, string targetLang, string level, string groupName, string description, string pairs)
        {
            var name = groupName.Replace("'", "''");
            var desc = description.Replace("'", "''");

            migrationBuilder.Sql($@"
                INSERT INTO ""TranslationGroups"" (""GroupName"", ""Description"", ""SourceLanguage"", ""TargetLanguage"", ""Level"")
                SELECT '{name}', '{desc}', '{sourceLang}', '{targetLang}', '{level}'
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

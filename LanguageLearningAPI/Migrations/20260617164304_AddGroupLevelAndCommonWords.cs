using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Adds a difficulty Level column to TranslationGroups (defaulting existing rows
    /// to 'Beginner') and seeds three new Polish → Italian common-word groups, one
    /// per level, to demonstrate the Beginner / Medium / Advanced categories.
    /// </summary>
    public partial class AddGroupLevelAndCommonWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "TranslationGroups",
                type: "text",
                nullable: false,
                defaultValue: "Beginner");

            SeedGroup(migrationBuilder, "pl", "it", "Beginner", "Italian — Around the House", "Polish → Italian common household words", @"
                ('stół', 'tavolo', 'Word'),
                ('krzesło', 'sedia', 'Word'),
                ('łóżko', 'letto', 'Word'),
                ('drzwi', 'porta', 'Word'),
                ('okno', 'finestra', 'Word'),
                ('kuchnia', 'cucina', 'Word'),
                ('łazienka', 'bagno', 'Word'),
                ('lampa', 'lampada', 'Word'),
                ('klucz', 'chiave', 'Word'),
                ('zegar', 'orologio', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Medium", "Italian — Useful Words (Medium)", "Polish → Italian useful everyday words — intermediate", @"
                ('zdrowie', 'salute', 'Word'),
                ('podróż', 'viaggio', 'Word'),
                ('praca', 'lavoro', 'Word'),
                ('pogoda', 'tempo', 'Word'),
                ('pieniądze', 'denaro', 'Word'),
                ('przyszłość', 'futuro', 'Word'),
                ('przeszłość', 'passato', 'Word'),
                ('pomysł', 'idea', 'Word'),
                ('prawda', 'verità', 'Word'),
                ('decyzja', 'decisione', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Advanced", "Italian — Advanced Vocabulary", "Polish → Italian abstract and advanced vocabulary", @"
                ('rozwój', 'sviluppo', 'Word'),
                ('doświadczenie', 'esperienza', 'Word'),
                ('środowisko', 'ambiente', 'Word'),
                ('społeczeństwo', 'società', 'Word'),
                ('gospodarka', 'economia', 'Word'),
                ('rząd', 'governo', 'Word'),
                ('prawo', 'legge', 'Word'),
                ('badania', 'ricerca', 'Word'),
                ('wpływ', 'impatto', 'Word'),
                ('świadomość', 'consapevolezza', 'Word')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'Italian — Around the House',
                    'Italian — Useful Words (Medium)',
                    'Italian — Advanced Vocabulary'
                );");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TranslationGroups");
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

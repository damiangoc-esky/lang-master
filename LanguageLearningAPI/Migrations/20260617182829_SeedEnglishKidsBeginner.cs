using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Seeds beginner Polish → English groups aimed at younger learners (kids):
    /// numbers, colours, animals, fruits &amp; vegetables, toys and school things.
    /// All Beginner level.
    /// </summary>
    public partial class SeedEnglishKidsBeginner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Numbers 1–10", "Polish → English numbers one to ten (for kids)", @"
                ('jeden', 'one', 'Word'),
                ('dwa', 'two', 'Word'),
                ('trzy', 'three', 'Word'),
                ('cztery', 'four', 'Word'),
                ('pięć', 'five', 'Word'),
                ('sześć', 'six', 'Word'),
                ('siedem', 'seven', 'Word'),
                ('osiem', 'eight', 'Word'),
                ('dziewięć', 'nine', 'Word'),
                ('dziesięć', 'ten', 'Word')");

            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Colors", "Polish → English colours (for kids)", @"
                ('czerwony', 'red', 'Word'),
                ('niebieski', 'blue', 'Word'),
                ('zielony', 'green', 'Word'),
                ('żółty', 'yellow', 'Word'),
                ('czarny', 'black', 'Word'),
                ('biały', 'white', 'Word'),
                ('pomarańczowy', 'orange', 'Word'),
                ('różowy', 'pink', 'Word'),
                ('fioletowy', 'purple', 'Word'),
                ('brązowy', 'brown', 'Word')");

            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Animals", "Polish → English animals (for kids)", @"
                ('pies', 'dog', 'Word'),
                ('kot', 'cat', 'Word'),
                ('ptak', 'bird', 'Word'),
                ('ryba', 'fish', 'Word'),
                ('koń', 'horse', 'Word'),
                ('krowa', 'cow', 'Word'),
                ('owca', 'sheep', 'Word'),
                ('świnia', 'pig', 'Word'),
                ('kaczka', 'duck', 'Word'),
                ('królik', 'rabbit', 'Word')");

            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Fruits & Vegetables", "Polish → English fruits and vegetables (for kids)", @"
                ('jabłko', 'apple', 'Word'),
                ('banan', 'banana', 'Word'),
                ('pomarańcza', 'orange', 'Word'),
                ('truskawka', 'strawberry', 'Word'),
                ('winogrono', 'grape', 'Word'),
                ('marchewka', 'carrot', 'Word'),
                ('ziemniak', 'potato', 'Word'),
                ('pomidor', 'tomato', 'Word'),
                ('gruszka', 'pear', 'Word'),
                ('arbuz', 'watermelon', 'Word')");

            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Toys & Play", "Polish → English toys and play (for kids)", @"
                ('zabawka', 'toy', 'Word'),
                ('piłka', 'ball', 'Word'),
                ('lalka', 'doll', 'Word'),
                ('miś', 'teddy bear', 'Word'),
                ('samochodzik', 'toy car', 'Word'),
                ('klocki', 'blocks', 'Word'),
                ('latawiec', 'kite', 'Word'),
                ('rower', 'bicycle', 'Word'),
                ('gra', 'game', 'Word'),
                ('balon', 'balloon', 'Word')");

            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — At School", "Polish → English school things (for kids)", @"
                ('szkoła', 'school', 'Word'),
                ('nauczyciel', 'teacher', 'Word'),
                ('uczeń', 'student', 'Word'),
                ('książka', 'book', 'Word'),
                ('ołówek', 'pencil', 'Word'),
                ('długopis', 'pen', 'Word'),
                ('zeszyt', 'notebook', 'Word'),
                ('tablica', 'board', 'Word'),
                ('plecak', 'backpack', 'Word'),
                ('kredka', 'crayon', 'Word')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'English — Numbers 1–10',
                    'English — Colors',
                    'English — Animals',
                    'English — Fruits & Vegetables',
                    'English — Toys & Play',
                    'English — At School'
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

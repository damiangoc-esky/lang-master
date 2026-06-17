using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Seeds Polish → English groups for the conditional tenses (zero, first,
    /// second and third conditional), each as example sentences. Zero/first are
    /// Medium; second/third are Advanced.
    /// </summary>
    public partial class SeedEnglishConditionals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedGroup(migrationBuilder, "pl", "en", "Medium", "English — Zero Conditional", "Polish → English zero conditional (general truths: if + present, present)", @"
                ('Jeśli podgrzejesz lód, topnieje.', 'If you heat ice, it melts.', 'Sentence'),
                ('Jeśli pada deszcz, ziemia robi się mokra.', 'If it rains, the ground gets wet.', 'Sentence'),
                ('Jeśli nie jesz, robisz się głodny.', 'If you don''t eat, you get hungry.', 'Sentence'),
                ('Woda wrze, jeśli podgrzejesz ją do 100 stopni.', 'Water boils if you heat it to 100 degrees.', 'Sentence'),
                ('Jeśli naciśniesz ten przycisk, drzwi się otwierają.', 'If you press this button, the door opens.', 'Sentence'),
                ('Jeśli zmieszasz niebieski i żółty, otrzymasz zielony.', 'If you mix blue and yellow, you get green.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "en", "Medium", "English — First Conditional", "Polish → English first conditional (real future: if + present, will + base)", @"
                ('Jeśli będzie padać, zostanę w domu.', 'If it rains, I will stay at home.', 'Sentence'),
                ('Jeśli się pospieszysz, zdążysz na pociąg.', 'If you hurry, you will catch the train.', 'Sentence'),
                ('Jeśli będziesz się uczyć, zdasz egzamin.', 'If you study, you will pass the exam.', 'Sentence'),
                ('Zadzwonię do ciebie, jeśli będę miał czas.', 'I will call you if I have time.', 'Sentence'),
                ('Jeśli zjesz warzywa, dostaniesz deser.', 'If you eat your vegetables, you will get dessert.', 'Sentence'),
                ('Jeśli nie wyjdziesz teraz, spóźnisz się.', 'If you don''t leave now, you will be late.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "en", "Advanced", "English — Second Conditional", "Polish → English second conditional (unreal present: if + past, would + base)", @"
                ('Gdybym był bogaty, podróżowałbym po świecie.', 'If I were rich, I would travel the world.', 'Sentence'),
                ('Gdybym miał więcej czasu, nauczyłbym się grać na gitarze.', 'If I had more time, I would learn to play the guitar.', 'Sentence'),
                ('Co byś zrobił, gdybyś wygrał na loterii?', 'What would you do if you won the lottery?', 'Sentence'),
                ('Gdybym był tobą, przyjąłbym tę pracę.', 'If I were you, I would take that job.', 'Sentence'),
                ('Gdyby nie padało, poszlibyśmy na spacer.', 'If it weren''t raining, we would go for a walk.', 'Sentence'),
                ('Kupiłbym ten samochód, gdybym miał pieniądze.', 'I would buy that car if I had the money.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "en", "Advanced", "English — Third Conditional", "Polish → English third conditional (past unreal: if + past perfect, would have + participle)", @"
                ('Gdybym się uczył, zdałbym egzamin.', 'If I had studied, I would have passed the exam.', 'Sentence'),
                ('Gdybyś mi powiedział, pomógłbym ci.', 'If you had told me, I would have helped you.', 'Sentence'),
                ('Gdybyśmy wyszli wcześniej, nie spóźnilibyśmy się.', 'If we had left earlier, we wouldn''t have been late.', 'Sentence'),
                ('Gdyby nie padało, mecz by się odbył.', 'If it hadn''t rained, the match would have taken place.', 'Sentence'),
                ('Co byś zrobił, gdybyś znał prawdę?', 'What would you have done if you had known the truth?', 'Sentence'),
                ('Gdybym wiedział, przyszedłbym wcześniej.', 'If I had known, I would have come earlier.', 'Sentence')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'English — Zero Conditional',
                    'English — First Conditional',
                    'English — Second Conditional',
                    'English — Third Conditional'
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

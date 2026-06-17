using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Seeds new Polish → English / Spanish / Italian word and phrase groups across
    /// all three difficulty levels: Everyday Phrases (Medium), Emotions & Feelings
    /// (Beginner) and Business & Work (Advanced) — for each target language.
    /// </summary>
    public partial class SeedMultiLangPhraseGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---------- Everyday Phrases (Medium) ----------
            SeedGroup(migrationBuilder, "pl", "en", "Medium", "English — Everyday Phrases", "Polish → English everyday phrases", @"
                ('Miło Cię poznać.', 'Nice to meet you.', 'Phrase'),
                ('Co słychać?', 'How''s it going?', 'Sentence'),
                ('Nie ma problemu.', 'No problem.', 'Phrase'),
                ('Zgadzam się.', 'I agree.', 'Sentence'),
                ('Nie jestem pewien.', 'I''m not sure.', 'Sentence'),
                ('Może później.', 'Maybe later.', 'Phrase'),
                ('Powodzenia!', 'Good luck!', 'Phrase'),
                ('Do zobaczenia wkrótce.', 'See you soon.', 'Phrase'),
                ('Nie szkodzi.', 'It''s okay.', 'Phrase'),
                ('To zależy.', 'It depends.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "es", "Medium", "Spanish — Everyday Phrases", "Polish → Spanish everyday phrases", @"
                ('Miło Cię poznać.', 'Encantado de conocerte.', 'Phrase'),
                ('Co słychać?', '¿Qué tal?', 'Sentence'),
                ('Nie ma problemu.', 'No hay problema.', 'Phrase'),
                ('Zgadzam się.', 'Estoy de acuerdo.', 'Sentence'),
                ('Nie jestem pewien.', 'No estoy seguro.', 'Sentence'),
                ('Może później.', 'Quizás más tarde.', 'Phrase'),
                ('Powodzenia!', '¡Buena suerte!', 'Phrase'),
                ('Do zobaczenia wkrótce.', 'Hasta pronto.', 'Phrase'),
                ('Nie szkodzi.', 'No pasa nada.', 'Phrase'),
                ('To zależy.', 'Depende.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Medium", "Italian — Everyday Phrases", "Polish → Italian everyday phrases", @"
                ('Miło Cię poznać.', 'Piacere di conoscerti.', 'Phrase'),
                ('Co słychać?', 'Come va?', 'Sentence'),
                ('Nie ma problemu.', 'Nessun problema.', 'Phrase'),
                ('Zgadzam się.', 'Sono d''accordo.', 'Sentence'),
                ('Nie jestem pewien.', 'Non sono sicuro.', 'Sentence'),
                ('Może później.', 'Forse più tardi.', 'Phrase'),
                ('Powodzenia!', 'Buona fortuna!', 'Phrase'),
                ('Do zobaczenia wkrótce.', 'A presto.', 'Phrase'),
                ('Nie szkodzi.', 'Non fa niente.', 'Phrase'),
                ('To zależy.', 'Dipende.', 'Sentence')");

            // ---------- Emotions & Feelings (Beginner) ----------
            SeedGroup(migrationBuilder, "pl", "en", "Beginner", "English — Emotions & Feelings", "Polish → English words for emotions and feelings", @"
                ('szczęśliwy', 'happy', 'Word'),
                ('smutny', 'sad', 'Word'),
                ('zmęczony', 'tired', 'Word'),
                ('głodny', 'hungry', 'Word'),
                ('spragniony', 'thirsty', 'Word'),
                ('przestraszony', 'scared', 'Word'),
                ('zaskoczony', 'surprised', 'Word'),
                ('znudzony', 'bored', 'Word'),
                ('podekscytowany', 'excited', 'Word'),
                ('spokojny', 'calm', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Beginner", "Spanish — Emotions & Feelings", "Polish → Spanish words for emotions and feelings", @"
                ('szczęśliwy', 'feliz', 'Word'),
                ('smutny', 'triste', 'Word'),
                ('zmęczony', 'cansado', 'Word'),
                ('głodny', 'hambriento', 'Word'),
                ('spragniony', 'sediento', 'Word'),
                ('przestraszony', 'asustado', 'Word'),
                ('zaskoczony', 'sorprendido', 'Word'),
                ('znudzony', 'aburrido', 'Word'),
                ('podekscytowany', 'emocionado', 'Word'),
                ('spokojny', 'tranquilo', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Beginner", "Italian — Emotions & Feelings", "Polish → Italian words for emotions and feelings", @"
                ('szczęśliwy', 'felice', 'Word'),
                ('smutny', 'triste', 'Word'),
                ('zmęczony', 'stanco', 'Word'),
                ('głodny', 'affamato', 'Word'),
                ('spragniony', 'assetato', 'Word'),
                ('przestraszony', 'spaventato', 'Word'),
                ('zaskoczony', 'sorpreso', 'Word'),
                ('znudzony', 'annoiato', 'Word'),
                ('podekscytowany', 'emozionato', 'Word'),
                ('spokojny', 'tranquillo', 'Word')");

            // ---------- Business & Work (Advanced) ----------
            SeedGroup(migrationBuilder, "pl", "en", "Advanced", "English — Business & Work", "Polish → English business and work vocabulary", @"
                ('spotkanie', 'meeting', 'Word'),
                ('umowa', 'contract', 'Word'),
                ('termin', 'deadline', 'Word'),
                ('klient', 'client', 'Word'),
                ('faktura', 'invoice', 'Word'),
                ('negocjacje', 'negotiations', 'Word'),
                ('zysk', 'profit', 'Word'),
                ('wynagrodzenie', 'salary', 'Word'),
                ('rozmowa kwalifikacyjna', 'job interview', 'Phrase'),
                ('kierownik', 'manager', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Advanced", "Spanish — Business & Work", "Polish → Spanish business and work vocabulary", @"
                ('spotkanie', 'reunión', 'Word'),
                ('umowa', 'contrato', 'Word'),
                ('termin', 'plazo', 'Word'),
                ('klient', 'cliente', 'Word'),
                ('faktura', 'factura', 'Word'),
                ('negocjacje', 'negociaciones', 'Word'),
                ('zysk', 'beneficio', 'Word'),
                ('wynagrodzenie', 'salario', 'Word'),
                ('rozmowa kwalifikacyjna', 'entrevista de trabajo', 'Phrase'),
                ('kierownik', 'gerente', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Advanced", "Italian — Business & Work", "Polish → Italian business and work vocabulary", @"
                ('spotkanie', 'riunione', 'Word'),
                ('umowa', 'contratto', 'Word'),
                ('termin', 'scadenza', 'Word'),
                ('klient', 'cliente', 'Word'),
                ('faktura', 'fattura', 'Word'),
                ('negocjacje', 'negoziati', 'Word'),
                ('zysk', 'profitto', 'Word'),
                ('wynagrodzenie', 'stipendio', 'Word'),
                ('rozmowa kwalifikacyjna', 'colloquio di lavoro', 'Phrase'),
                ('kierownik', 'dirigente', 'Word')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'English — Everyday Phrases', 'Spanish — Everyday Phrases', 'Italian — Everyday Phrases',
                    'English — Emotions & Feelings', 'Spanish — Emotions & Feelings', 'Italian — Emotions & Feelings',
                    'English — Business & Work', 'Spanish — Business & Work', 'Italian — Business & Work'
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

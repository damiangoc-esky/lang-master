using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Reorients the beginner vocabulary so every translation goes Polish -> target
    /// language (pl -> it, pl -> es): the learner sees a Polish prompt and recalls
    /// the foreign word. Removes the earlier foreign -> English seed groups and
    /// inserts Polish-sourced equivalents across all themes.
    ///
    /// IDs are DB-generated and inserts are NOT EXISTS-guarded, so this is safe to
    /// re-apply. The Polish -> English demo "Weather" group (from DbSeeder) is left
    /// untouched since it is already Polish-sourced.
    /// </summary>
    public partial class ReseedPolishToTargetVocab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the old foreign-sourced groups (it->en, es->en); cascade removes pairs.
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""SourceLanguage"" IN ('it', 'es');");

            // ---------- POLISH -> ITALIAN (pl -> it) ----------
            SeedGroup(migrationBuilder, "pl", "it", "Italian — Greetings & Politeness", "Beginner Polish → Italian greetings and polite expressions", @"
                ('cześć', 'ciao', 'Word'),
                ('dzień dobry', 'buongiorno', 'Phrase'),
                ('dobry wieczór', 'buonasera', 'Phrase'),
                ('dobranoc', 'buonanotte', 'Word'),
                ('do widzenia', 'arrivederci', 'Word'),
                ('proszę', 'per favore', 'Phrase'),
                ('dziękuję', 'grazie', 'Word'),
                ('proszę bardzo', 'prego', 'Phrase'),
                ('przepraszam', 'scusa', 'Word'),
                ('tak', 'sì', 'Word'),
                ('nie', 'no', 'Word'),
                ('Jak się masz?', 'Come stai?', 'Sentence'),
                ('Mam na imię...', 'Mi chiamo...', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Numbers 1–10", "Beginner Polish → Italian numbers one to ten", @"
                ('jeden', 'uno', 'Word'),
                ('dwa', 'due', 'Word'),
                ('trzy', 'tre', 'Word'),
                ('cztery', 'quattro', 'Word'),
                ('pięć', 'cinque', 'Word'),
                ('sześć', 'sei', 'Word'),
                ('siedem', 'sette', 'Word'),
                ('osiem', 'otto', 'Word'),
                ('dziewięć', 'nove', 'Word'),
                ('dziesięć', 'dieci', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Numbers 11–20", "Beginner Polish → Italian numbers eleven to twenty", @"
                ('jedenaście', 'undici', 'Word'),
                ('dwanaście', 'dodici', 'Word'),
                ('trzynaście', 'tredici', 'Word'),
                ('czternaście', 'quattordici', 'Word'),
                ('piętnaście', 'quindici', 'Word'),
                ('szesnaście', 'sedici', 'Word'),
                ('siedemnaście', 'diciassette', 'Word'),
                ('osiemnaście', 'diciotto', 'Word'),
                ('dziewiętnaście', 'diciannove', 'Word'),
                ('dwadzieścia', 'venti', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Colors", "Beginner Polish → Italian color vocabulary", @"
                ('czerwony', 'rosso', 'Word'),
                ('niebieski', 'blu', 'Word'),
                ('zielony', 'verde', 'Word'),
                ('żółty', 'giallo', 'Word'),
                ('czarny', 'nero', 'Word'),
                ('biały', 'bianco', 'Word'),
                ('pomarańczowy', 'arancione', 'Word'),
                ('różowy', 'rosa', 'Word'),
                ('fioletowy', 'viola', 'Word'),
                ('szary', 'grigio', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Food & Drink", "Beginner Polish → Italian food and drink vocabulary", @"
                ('woda', 'acqua', 'Word'),
                ('chleb', 'pane', 'Word'),
                ('wino', 'vino', 'Word'),
                ('kawa', 'caffè', 'Word'),
                ('mleko', 'latte', 'Word'),
                ('ser', 'formaggio', 'Word'),
                ('jabłko', 'mela', 'Word'),
                ('mięso', 'carne', 'Word'),
                ('ryba', 'pesce', 'Word'),
                ('jajko', 'uovo', 'Word'),
                ('ryż', 'riso', 'Word'),
                ('piwo', 'birra', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Days of the Week", "Beginner Polish → Italian days of the week", @"
                ('poniedziałek', 'lunedì', 'Word'),
                ('wtorek', 'martedì', 'Word'),
                ('środa', 'mercoledì', 'Word'),
                ('czwartek', 'giovedì', 'Word'),
                ('piątek', 'venerdì', 'Word'),
                ('sobota', 'sabato', 'Word'),
                ('niedziela', 'domenica', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Months", "Beginner Polish → Italian months of the year", @"
                ('styczeń', 'gennaio', 'Word'),
                ('luty', 'febbraio', 'Word'),
                ('marzec', 'marzo', 'Word'),
                ('kwiecień', 'aprile', 'Word'),
                ('maj', 'maggio', 'Word'),
                ('czerwiec', 'giugno', 'Word'),
                ('lipiec', 'luglio', 'Word'),
                ('sierpień', 'agosto', 'Word'),
                ('wrzesień', 'settembre', 'Word'),
                ('październik', 'ottobre', 'Word'),
                ('listopad', 'novembre', 'Word'),
                ('grudzień', 'dicembre', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Family", "Beginner Polish → Italian family vocabulary", @"
                ('matka', 'madre', 'Word'),
                ('ojciec', 'padre', 'Word'),
                ('brat', 'fratello', 'Word'),
                ('siostra', 'sorella', 'Word'),
                ('syn', 'figlio', 'Word'),
                ('córka', 'figlia', 'Word'),
                ('dziadek', 'nonno', 'Word'),
                ('babcia', 'nonna', 'Word'),
                ('rodzina', 'famiglia', 'Word'),
                ('przyjaciel', 'amico', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Body Parts", "Beginner Polish → Italian body part vocabulary", @"
                ('głowa', 'testa', 'Word'),
                ('ręka', 'mano', 'Word'),
                ('stopa', 'piede', 'Word'),
                ('oko', 'occhio', 'Word'),
                ('usta', 'bocca', 'Word'),
                ('nos', 'naso', 'Word'),
                ('ucho', 'orecchio', 'Word'),
                ('ramię', 'braccio', 'Word'),
                ('noga', 'gamba', 'Word'),
                ('serce', 'cuore', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Animals", "Beginner Polish → Italian animal vocabulary", @"
                ('pies', 'cane', 'Word'),
                ('kot', 'gatto', 'Word'),
                ('koń', 'cavallo', 'Word'),
                ('ptak', 'uccello', 'Word'),
                ('ryba', 'pesce', 'Word'),
                ('krowa', 'mucca', 'Word'),
                ('świnia', 'maiale', 'Word'),
                ('kurczak', 'pollo', 'Word'),
                ('mysz', 'topo', 'Word'),
                ('niedźwiedź', 'orso', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Common Verbs", "Beginner Polish → Italian verbs (infinitive)", @"
                ('być', 'essere', 'Word'),
                ('mieć', 'avere', 'Word'),
                ('robić', 'fare', 'Word'),
                ('iść', 'andare', 'Word'),
                ('jeść', 'mangiare', 'Word'),
                ('pić', 'bere', 'Word'),
                ('mówić', 'parlare', 'Word'),
                ('chcieć', 'volere', 'Word'),
                ('móc', 'potere', 'Word'),
                ('przyjść', 'venire', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Common Adjectives", "Beginner Polish → Italian adjectives", @"
                ('duży', 'grande', 'Word'),
                ('mały', 'piccolo', 'Word'),
                ('dobry', 'buono', 'Word'),
                ('zły', 'cattivo', 'Word'),
                ('nowy', 'nuovo', 'Word'),
                ('stary', 'vecchio', 'Word'),
                ('gorący', 'caldo', 'Word'),
                ('zimny', 'freddo', 'Word'),
                ('łatwy', 'facile', 'Word'),
                ('trudny', 'difficile', 'Word')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Time & Weather", "Beginner Polish → Italian time and weather expressions", @"
                ('dzisiaj', 'oggi', 'Word'),
                ('jutro', 'domani', 'Word'),
                ('wczoraj', 'ieri', 'Word'),
                ('teraz', 'adesso', 'Word'),
                ('słońce', 'sole', 'Word'),
                ('deszcz', 'pioggia', 'Word'),
                ('śnieg', 'neve', 'Word'),
                ('wiatr', 'vento', 'Word'),
                ('Która godzina?', 'Che ore sono?', 'Sentence'),
                ('Jest gorąco', 'Fa caldo', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Travel & Places", "Beginner Polish → Italian travel and places vocabulary", @"
                ('dom', 'casa', 'Word'),
                ('miasto', 'città', 'Word'),
                ('ulica', 'strada', 'Word'),
                ('lotnisko', 'aeroporto', 'Word'),
                ('hotel', 'albergo', 'Word'),
                ('stacja', 'stazione', 'Word'),
                ('plaża', 'spiaggia', 'Word'),
                ('restauracja', 'ristorante', 'Word'),
                ('sklep', 'negozio', 'Word'),
                ('Gdzie jest...?', 'Dov''è...?', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Common Words", "Beginner Polish → Italian everyday words", @"
                ('mężczyzna', 'uomo', 'Word'),
                ('kobieta', 'donna', 'Word'),
                ('chłopiec', 'ragazzo', 'Word'),
                ('dziewczyna', 'ragazza', 'Word'),
                ('książka', 'libro', 'Word'),
                ('samochód', 'macchina', 'Word'),
                ('praca', 'lavoro', 'Word'),
                ('pieniądze', 'soldi', 'Word'),
                ('czas', 'tempo', 'Word'),
                ('ludzie', 'gente', 'Word')");

            // ---------- POLISH -> SPANISH (pl -> es) ----------
            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Greetings & Politeness", "Beginner Polish → Spanish greetings and polite expressions", @"
                ('cześć', 'hola', 'Word'),
                ('dzień dobry', 'buenos días', 'Phrase'),
                ('dobry wieczór', 'buenas noches', 'Phrase'),
                ('dobranoc', 'buenas noches', 'Word'),
                ('do widzenia', 'adiós', 'Word'),
                ('proszę', 'por favor', 'Phrase'),
                ('dziękuję', 'gracias', 'Word'),
                ('proszę bardzo', 'de nada', 'Phrase'),
                ('przepraszam', 'perdón', 'Word'),
                ('tak', 'sí', 'Word'),
                ('nie', 'no', 'Word'),
                ('Jak się masz?', '¿Cómo estás?', 'Sentence'),
                ('Mam na imię...', 'Me llamo...', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Numbers 1–10", "Beginner Polish → Spanish numbers one to ten", @"
                ('jeden', 'uno', 'Word'),
                ('dwa', 'dos', 'Word'),
                ('trzy', 'tres', 'Word'),
                ('cztery', 'cuatro', 'Word'),
                ('pięć', 'cinco', 'Word'),
                ('sześć', 'seis', 'Word'),
                ('siedem', 'siete', 'Word'),
                ('osiem', 'ocho', 'Word'),
                ('dziewięć', 'nueve', 'Word'),
                ('dziesięć', 'diez', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Numbers 11–20", "Beginner Polish → Spanish numbers eleven to twenty", @"
                ('jedenaście', 'once', 'Word'),
                ('dwanaście', 'doce', 'Word'),
                ('trzynaście', 'trece', 'Word'),
                ('czternaście', 'catorce', 'Word'),
                ('piętnaście', 'quince', 'Word'),
                ('szesnaście', 'dieciséis', 'Word'),
                ('siedemnaście', 'diecisiete', 'Word'),
                ('osiemnaście', 'dieciocho', 'Word'),
                ('dziewiętnaście', 'diecinueve', 'Word'),
                ('dwadzieścia', 'veinte', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Colors", "Beginner Polish → Spanish color vocabulary", @"
                ('czerwony', 'rojo', 'Word'),
                ('niebieski', 'azul', 'Word'),
                ('zielony', 'verde', 'Word'),
                ('żółty', 'amarillo', 'Word'),
                ('czarny', 'negro', 'Word'),
                ('biały', 'blanco', 'Word'),
                ('pomarańczowy', 'naranja', 'Word'),
                ('różowy', 'rosa', 'Word'),
                ('fioletowy', 'morado', 'Word'),
                ('szary', 'gris', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Food & Drink", "Beginner Polish → Spanish food and drink vocabulary", @"
                ('woda', 'agua', 'Word'),
                ('chleb', 'pan', 'Word'),
                ('wino', 'vino', 'Word'),
                ('kawa', 'café', 'Word'),
                ('mleko', 'leche', 'Word'),
                ('ser', 'queso', 'Word'),
                ('jabłko', 'manzana', 'Word'),
                ('mięso', 'carne', 'Word'),
                ('ryba', 'pescado', 'Word'),
                ('jajko', 'huevo', 'Word'),
                ('ryż', 'arroz', 'Word'),
                ('piwo', 'cerveza', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Days of the Week", "Beginner Polish → Spanish days of the week", @"
                ('poniedziałek', 'lunes', 'Word'),
                ('wtorek', 'martes', 'Word'),
                ('środa', 'miércoles', 'Word'),
                ('czwartek', 'jueves', 'Word'),
                ('piątek', 'viernes', 'Word'),
                ('sobota', 'sábado', 'Word'),
                ('niedziela', 'domingo', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Months", "Beginner Polish → Spanish months of the year", @"
                ('styczeń', 'enero', 'Word'),
                ('luty', 'febrero', 'Word'),
                ('marzec', 'marzo', 'Word'),
                ('kwiecień', 'abril', 'Word'),
                ('maj', 'mayo', 'Word'),
                ('czerwiec', 'junio', 'Word'),
                ('lipiec', 'julio', 'Word'),
                ('sierpień', 'agosto', 'Word'),
                ('wrzesień', 'septiembre', 'Word'),
                ('październik', 'octubre', 'Word'),
                ('listopad', 'noviembre', 'Word'),
                ('grudzień', 'diciembre', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Family", "Beginner Polish → Spanish family vocabulary", @"
                ('matka', 'madre', 'Word'),
                ('ojciec', 'padre', 'Word'),
                ('brat', 'hermano', 'Word'),
                ('siostra', 'hermana', 'Word'),
                ('syn', 'hijo', 'Word'),
                ('córka', 'hija', 'Word'),
                ('dziadek', 'abuelo', 'Word'),
                ('babcia', 'abuela', 'Word'),
                ('rodzina', 'familia', 'Word'),
                ('przyjaciel', 'amigo', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Body Parts", "Beginner Polish → Spanish body part vocabulary", @"
                ('głowa', 'cabeza', 'Word'),
                ('ręka', 'mano', 'Word'),
                ('stopa', 'pie', 'Word'),
                ('oko', 'ojo', 'Word'),
                ('usta', 'boca', 'Word'),
                ('nos', 'nariz', 'Word'),
                ('ucho', 'oreja', 'Word'),
                ('ramię', 'brazo', 'Word'),
                ('noga', 'pierna', 'Word'),
                ('serce', 'corazón', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Animals", "Beginner Polish → Spanish animal vocabulary", @"
                ('pies', 'perro', 'Word'),
                ('kot', 'gato', 'Word'),
                ('koń', 'caballo', 'Word'),
                ('ptak', 'pájaro', 'Word'),
                ('ryba', 'pez', 'Word'),
                ('krowa', 'vaca', 'Word'),
                ('świnia', 'cerdo', 'Word'),
                ('kurczak', 'pollo', 'Word'),
                ('mysz', 'ratón', 'Word'),
                ('niedźwiedź', 'oso', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Common Verbs", "Beginner Polish → Spanish verbs (infinitive)", @"
                ('być', 'ser', 'Word'),
                ('mieć', 'tener', 'Word'),
                ('robić', 'hacer', 'Word'),
                ('iść', 'ir', 'Word'),
                ('jeść', 'comer', 'Word'),
                ('pić', 'beber', 'Word'),
                ('mówić', 'hablar', 'Word'),
                ('chcieć', 'querer', 'Word'),
                ('móc', 'poder', 'Word'),
                ('przyjść', 'venir', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Common Adjectives", "Beginner Polish → Spanish adjectives", @"
                ('duży', 'grande', 'Word'),
                ('mały', 'pequeño', 'Word'),
                ('dobry', 'bueno', 'Word'),
                ('zły', 'malo', 'Word'),
                ('nowy', 'nuevo', 'Word'),
                ('stary', 'viejo', 'Word'),
                ('gorący', 'caliente', 'Word'),
                ('zimny', 'frío', 'Word'),
                ('łatwy', 'fácil', 'Word'),
                ('trudny', 'difícil', 'Word')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Time & Weather", "Beginner Polish → Spanish time and weather expressions", @"
                ('dzisiaj', 'hoy', 'Word'),
                ('jutro', 'mañana', 'Word'),
                ('wczoraj', 'ayer', 'Word'),
                ('teraz', 'ahora', 'Word'),
                ('słońce', 'sol', 'Word'),
                ('deszcz', 'lluvia', 'Word'),
                ('śnieg', 'nieve', 'Word'),
                ('wiatr', 'viento', 'Word'),
                ('Która godzina?', '¿Qué hora es?', 'Sentence'),
                ('Jest gorąco', 'Hace calor', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Travel & Places", "Beginner Polish → Spanish travel and places vocabulary", @"
                ('dom', 'casa', 'Word'),
                ('miasto', 'ciudad', 'Word'),
                ('ulica', 'calle', 'Word'),
                ('lotnisko', 'aeropuerto', 'Word'),
                ('hotel', 'hotel', 'Word'),
                ('stacja', 'estación', 'Word'),
                ('plaża', 'playa', 'Word'),
                ('restauracja', 'restaurante', 'Word'),
                ('sklep', 'tienda', 'Word'),
                ('Gdzie jest...?', '¿Dónde está...?', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "es", "Spanish — Common Words", "Beginner Polish → Spanish everyday words", @"
                ('mężczyzna', 'hombre', 'Word'),
                ('kobieta', 'mujer', 'Word'),
                ('chłopiec', 'niño', 'Word'),
                ('dziewczyna', 'niña', 'Word'),
                ('książka', 'libro', 'Word'),
                ('samochód', 'coche', 'Word'),
                ('praca', 'trabajo', 'Word'),
                ('pieniądze', 'dinero', 'Word'),
                ('czas', 'tiempo', 'Word'),
                ('ludzie', 'gente', 'Word')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the Polish-sourced it/es groups added here; cascade removes pairs.
            // (The earlier foreign->English groups are not restored.)
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""SourceLanguage"" = 'pl' AND ""TargetLanguage"" IN ('it', 'es');");
        }

        private static void SeedGroup(MigrationBuilder migrationBuilder, string sourceLang, string targetLang, string groupName, string description, string pairs)
        {
            var name = groupName.Replace("'", "''");
            var desc = description.Replace("'", "''");

            migrationBuilder.Sql($@"
                INSERT INTO ""TranslationGroups"" (""GroupName"", ""Description"", ""SourceLanguage"", ""TargetLanguage"")
                SELECT '{name}', '{desc}', '{sourceLang}', '{targetLang}'
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

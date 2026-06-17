using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Data migration: a broad beginner-level vocabulary curriculum for Spanish
    /// (es -> en) and Italian (it -> en). Adds many themed groups — numbers,
    /// colors, family, body, animals, verbs, adjectives, time/weather, travel, etc.
    ///
    /// IDs are DB-generated so this never collides with earlier seeds, and each
    /// group/pair insert is guarded by NOT EXISTS, so re-applying is safe and it
    /// will not duplicate the Italian groups added by SeedItalianBeginnerVocab.
    /// </summary>
    public partial class SeedSpanishItalianBeginnerVocab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---------- SPANISH (es -> en) ----------
            SeedGroup(migrationBuilder, "es", "Spanish — Greetings & Politeness", "Beginner Spanish greetings and polite expressions", @"
                ('hola', 'hello / hi', 'Word'),
                ('buenos días', 'good morning', 'Phrase'),
                ('buenas tardes', 'good afternoon', 'Phrase'),
                ('buenas noches', 'good evening / good night', 'Phrase'),
                ('adiós', 'goodbye', 'Word'),
                ('por favor', 'please', 'Phrase'),
                ('gracias', 'thank you', 'Word'),
                ('de nada', 'you''re welcome', 'Phrase'),
                ('perdón', 'excuse me / sorry', 'Word'),
                ('sí', 'yes', 'Word'),
                ('no', 'no', 'Word'),
                ('¿Cómo estás?', 'How are you?', 'Sentence'),
                ('Me llamo...', 'My name is...', 'Phrase')");

            SeedGroup(migrationBuilder, "es", "Spanish — Numbers 1–10", "Beginner Spanish numbers one to ten", @"
                ('uno', 'one', 'Word'),
                ('dos', 'two', 'Word'),
                ('tres', 'three', 'Word'),
                ('cuatro', 'four', 'Word'),
                ('cinco', 'five', 'Word'),
                ('seis', 'six', 'Word'),
                ('siete', 'seven', 'Word'),
                ('ocho', 'eight', 'Word'),
                ('nueve', 'nine', 'Word'),
                ('diez', 'ten', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Numbers 11–20", "Beginner Spanish numbers eleven to twenty", @"
                ('once', 'eleven', 'Word'),
                ('doce', 'twelve', 'Word'),
                ('trece', 'thirteen', 'Word'),
                ('catorce', 'fourteen', 'Word'),
                ('quince', 'fifteen', 'Word'),
                ('dieciséis', 'sixteen', 'Word'),
                ('diecisiete', 'seventeen', 'Word'),
                ('dieciocho', 'eighteen', 'Word'),
                ('diecinueve', 'nineteen', 'Word'),
                ('veinte', 'twenty', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Colors", "Beginner Spanish color vocabulary", @"
                ('rojo', 'red', 'Word'),
                ('azul', 'blue', 'Word'),
                ('verde', 'green', 'Word'),
                ('amarillo', 'yellow', 'Word'),
                ('negro', 'black', 'Word'),
                ('blanco', 'white', 'Word'),
                ('naranja', 'orange', 'Word'),
                ('rosa', 'pink', 'Word'),
                ('morado', 'purple', 'Word'),
                ('gris', 'gray', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Food & Drink", "Beginner Spanish food and drink vocabulary", @"
                ('agua', 'water', 'Word'),
                ('pan', 'bread', 'Word'),
                ('vino', 'wine', 'Word'),
                ('café', 'coffee', 'Word'),
                ('leche', 'milk', 'Word'),
                ('queso', 'cheese', 'Word'),
                ('manzana', 'apple', 'Word'),
                ('carne', 'meat', 'Word'),
                ('pescado', 'fish (food)', 'Word'),
                ('huevo', 'egg', 'Word'),
                ('arroz', 'rice', 'Word'),
                ('cerveza', 'beer', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Days of the Week", "Beginner Spanish days of the week", @"
                ('lunes', 'Monday', 'Word'),
                ('martes', 'Tuesday', 'Word'),
                ('miércoles', 'Wednesday', 'Word'),
                ('jueves', 'Thursday', 'Word'),
                ('viernes', 'Friday', 'Word'),
                ('sábado', 'Saturday', 'Word'),
                ('domingo', 'Sunday', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Months", "Beginner Spanish months of the year", @"
                ('enero', 'January', 'Word'),
                ('febrero', 'February', 'Word'),
                ('marzo', 'March', 'Word'),
                ('abril', 'April', 'Word'),
                ('mayo', 'May', 'Word'),
                ('junio', 'June', 'Word'),
                ('julio', 'July', 'Word'),
                ('agosto', 'August', 'Word'),
                ('septiembre', 'September', 'Word'),
                ('octubre', 'October', 'Word'),
                ('noviembre', 'November', 'Word'),
                ('diciembre', 'December', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Family", "Beginner Spanish family vocabulary", @"
                ('madre', 'mother', 'Word'),
                ('padre', 'father', 'Word'),
                ('hermano', 'brother', 'Word'),
                ('hermana', 'sister', 'Word'),
                ('hijo', 'son', 'Word'),
                ('hija', 'daughter', 'Word'),
                ('abuelo', 'grandfather', 'Word'),
                ('abuela', 'grandmother', 'Word'),
                ('familia', 'family', 'Word'),
                ('amigo', 'friend', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Body Parts", "Beginner Spanish body part vocabulary", @"
                ('cabeza', 'head', 'Word'),
                ('mano', 'hand', 'Word'),
                ('pie', 'foot', 'Word'),
                ('ojo', 'eye', 'Word'),
                ('boca', 'mouth', 'Word'),
                ('nariz', 'nose', 'Word'),
                ('oreja', 'ear', 'Word'),
                ('brazo', 'arm', 'Word'),
                ('pierna', 'leg', 'Word'),
                ('corazón', 'heart', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Animals", "Beginner Spanish animal vocabulary", @"
                ('perro', 'dog', 'Word'),
                ('gato', 'cat', 'Word'),
                ('caballo', 'horse', 'Word'),
                ('pájaro', 'bird', 'Word'),
                ('pez', 'fish', 'Word'),
                ('vaca', 'cow', 'Word'),
                ('cerdo', 'pig', 'Word'),
                ('pollo', 'chicken', 'Word'),
                ('ratón', 'mouse', 'Word'),
                ('oso', 'bear', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Common Verbs", "Beginner Spanish verbs (infinitive)", @"
                ('ser', 'to be', 'Word'),
                ('estar', 'to be (state)', 'Word'),
                ('tener', 'to have', 'Word'),
                ('hacer', 'to do / to make', 'Word'),
                ('ir', 'to go', 'Word'),
                ('comer', 'to eat', 'Word'),
                ('beber', 'to drink', 'Word'),
                ('hablar', 'to speak', 'Word'),
                ('querer', 'to want', 'Word'),
                ('poder', 'to be able / can', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Common Adjectives", "Beginner Spanish adjectives", @"
                ('grande', 'big', 'Word'),
                ('pequeño', 'small', 'Word'),
                ('bueno', 'good', 'Word'),
                ('malo', 'bad', 'Word'),
                ('nuevo', 'new', 'Word'),
                ('viejo', 'old', 'Word'),
                ('caliente', 'hot', 'Word'),
                ('frío', 'cold', 'Word'),
                ('fácil', 'easy', 'Word'),
                ('difícil', 'difficult', 'Word')");

            SeedGroup(migrationBuilder, "es", "Spanish — Time & Weather", "Beginner Spanish time and weather expressions", @"
                ('hoy', 'today', 'Word'),
                ('mañana', 'tomorrow / morning', 'Word'),
                ('ayer', 'yesterday', 'Word'),
                ('ahora', 'now', 'Word'),
                ('sol', 'sun', 'Word'),
                ('lluvia', 'rain', 'Word'),
                ('nieve', 'snow', 'Word'),
                ('viento', 'wind', 'Word'),
                ('¿Qué hora es?', 'What time is it?', 'Sentence'),
                ('Hace calor', 'It''s hot', 'Sentence')");

            SeedGroup(migrationBuilder, "es", "Spanish — Travel & Places", "Beginner Spanish travel and places vocabulary", @"
                ('casa', 'house / home', 'Word'),
                ('ciudad', 'city', 'Word'),
                ('calle', 'street', 'Word'),
                ('aeropuerto', 'airport', 'Word'),
                ('hotel', 'hotel', 'Word'),
                ('estación', 'station', 'Word'),
                ('playa', 'beach', 'Word'),
                ('restaurante', 'restaurant', 'Word'),
                ('tienda', 'shop / store', 'Word'),
                ('¿Dónde está...?', 'Where is...?', 'Phrase')");

            SeedGroup(migrationBuilder, "es", "Spanish — Common Words", "Beginner Spanish everyday words", @"
                ('hombre', 'man', 'Word'),
                ('mujer', 'woman', 'Word'),
                ('niño', 'boy / child', 'Word'),
                ('niña', 'girl', 'Word'),
                ('libro', 'book', 'Word'),
                ('coche', 'car', 'Word'),
                ('trabajo', 'work / job', 'Word'),
                ('dinero', 'money', 'Word'),
                ('tiempo', 'time / weather', 'Word'),
                ('gente', 'people', 'Word')");

            // ---------- ITALIAN (it -> en) — themes not covered by SeedItalianBeginnerVocab ----------
            SeedGroup(migrationBuilder, "it", "Italian — Numbers 11–20", "Beginner Italian numbers eleven to twenty", @"
                ('undici', 'eleven', 'Word'),
                ('dodici', 'twelve', 'Word'),
                ('tredici', 'thirteen', 'Word'),
                ('quattordici', 'fourteen', 'Word'),
                ('quindici', 'fifteen', 'Word'),
                ('sedici', 'sixteen', 'Word'),
                ('diciassette', 'seventeen', 'Word'),
                ('diciotto', 'eighteen', 'Word'),
                ('diciannove', 'nineteen', 'Word'),
                ('venti', 'twenty', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Months", "Beginner Italian months of the year", @"
                ('gennaio', 'January', 'Word'),
                ('febbraio', 'February', 'Word'),
                ('marzo', 'March', 'Word'),
                ('aprile', 'April', 'Word'),
                ('maggio', 'May', 'Word'),
                ('giugno', 'June', 'Word'),
                ('luglio', 'July', 'Word'),
                ('agosto', 'August', 'Word'),
                ('settembre', 'September', 'Word'),
                ('ottobre', 'October', 'Word'),
                ('novembre', 'November', 'Word'),
                ('dicembre', 'December', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Family", "Beginner Italian family vocabulary", @"
                ('madre', 'mother', 'Word'),
                ('padre', 'father', 'Word'),
                ('fratello', 'brother', 'Word'),
                ('sorella', 'sister', 'Word'),
                ('figlio', 'son', 'Word'),
                ('figlia', 'daughter', 'Word'),
                ('nonno', 'grandfather', 'Word'),
                ('nonna', 'grandmother', 'Word'),
                ('famiglia', 'family', 'Word'),
                ('amico', 'friend', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Body Parts", "Beginner Italian body part vocabulary", @"
                ('testa', 'head', 'Word'),
                ('mano', 'hand', 'Word'),
                ('piede', 'foot', 'Word'),
                ('occhio', 'eye', 'Word'),
                ('bocca', 'mouth', 'Word'),
                ('naso', 'nose', 'Word'),
                ('orecchio', 'ear', 'Word'),
                ('braccio', 'arm', 'Word'),
                ('gamba', 'leg', 'Word'),
                ('cuore', 'heart', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Animals", "Beginner Italian animal vocabulary", @"
                ('cane', 'dog', 'Word'),
                ('gatto', 'cat', 'Word'),
                ('cavallo', 'horse', 'Word'),
                ('uccello', 'bird', 'Word'),
                ('pesce', 'fish', 'Word'),
                ('mucca', 'cow', 'Word'),
                ('maiale', 'pig', 'Word'),
                ('pollo', 'chicken', 'Word'),
                ('topo', 'mouse', 'Word'),
                ('orso', 'bear', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Common Verbs", "Beginner Italian verbs (infinitive)", @"
                ('essere', 'to be', 'Word'),
                ('avere', 'to have', 'Word'),
                ('fare', 'to do / to make', 'Word'),
                ('andare', 'to go', 'Word'),
                ('mangiare', 'to eat', 'Word'),
                ('bere', 'to drink', 'Word'),
                ('parlare', 'to speak', 'Word'),
                ('volere', 'to want', 'Word'),
                ('potere', 'to be able / can', 'Word'),
                ('venire', 'to come', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Common Adjectives", "Beginner Italian adjectives", @"
                ('grande', 'big', 'Word'),
                ('piccolo', 'small', 'Word'),
                ('buono', 'good', 'Word'),
                ('cattivo', 'bad', 'Word'),
                ('nuovo', 'new', 'Word'),
                ('vecchio', 'old', 'Word'),
                ('caldo', 'hot', 'Word'),
                ('freddo', 'cold', 'Word'),
                ('facile', 'easy', 'Word'),
                ('difficile', 'difficult', 'Word')");

            SeedGroup(migrationBuilder, "it", "Italian — Time & Weather", "Beginner Italian time and weather expressions", @"
                ('oggi', 'today', 'Word'),
                ('domani', 'tomorrow', 'Word'),
                ('ieri', 'yesterday', 'Word'),
                ('adesso', 'now', 'Word'),
                ('sole', 'sun', 'Word'),
                ('pioggia', 'rain', 'Word'),
                ('neve', 'snow', 'Word'),
                ('vento', 'wind', 'Word'),
                ('Che ore sono?', 'What time is it?', 'Sentence'),
                ('Fa caldo', 'It''s hot', 'Sentence')");

            SeedGroup(migrationBuilder, "it", "Italian — Travel & Places", "Beginner Italian travel and places vocabulary", @"
                ('casa', 'house / home', 'Word'),
                ('città', 'city', 'Word'),
                ('strada', 'street / road', 'Word'),
                ('aeroporto', 'airport', 'Word'),
                ('albergo', 'hotel', 'Word'),
                ('stazione', 'station', 'Word'),
                ('spiaggia', 'beach', 'Word'),
                ('ristorante', 'restaurant', 'Word'),
                ('negozio', 'shop / store', 'Word'),
                ('Dov''è...?', 'Where is...?', 'Phrase')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Cascade delete on the FK removes the associated TranslationPairs.
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'Spanish — Greetings & Politeness',
                    'Spanish — Numbers 1–10',
                    'Spanish — Numbers 11–20',
                    'Spanish — Colors',
                    'Spanish — Food & Drink',
                    'Spanish — Days of the Week',
                    'Spanish — Months',
                    'Spanish — Family',
                    'Spanish — Body Parts',
                    'Spanish — Animals',
                    'Spanish — Common Verbs',
                    'Spanish — Common Adjectives',
                    'Spanish — Time & Weather',
                    'Spanish — Travel & Places',
                    'Spanish — Common Words',
                    'Italian — Numbers 11–20',
                    'Italian — Months',
                    'Italian — Family',
                    'Italian — Body Parts',
                    'Italian — Animals',
                    'Italian — Common Verbs',
                    'Italian — Common Adjectives',
                    'Italian — Time & Weather',
                    'Italian — Travel & Places'
                );");
        }

        private static void SeedGroup(MigrationBuilder migrationBuilder, string sourceLang, string groupName, string description, string pairs)
        {
            var name = groupName.Replace("'", "''");
            var desc = description.Replace("'", "''");

            migrationBuilder.Sql($@"
                INSERT INTO ""TranslationGroups"" (""GroupName"", ""Description"", ""SourceLanguage"", ""TargetLanguage"")
                SELECT '{name}', '{desc}', '{sourceLang}', 'en'
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

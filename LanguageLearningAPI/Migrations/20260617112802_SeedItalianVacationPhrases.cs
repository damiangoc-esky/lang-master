using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageLearningAPI.Migrations
{
    /// <summary>
    /// Seeds practical Polish → Italian (pl -> it) phrase groups for a vacation
    /// trip — train station, hotel, restaurant, directions, shopping, emergencies
    /// and everyday essentials. Short questions/phrases a traveller actually uses.
    ///
    /// Same identity-safe, NOT EXISTS-guarded pattern as the other seed migrations.
    /// </summary>
    public partial class SeedItalianVacationPhrases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: Train Station", "Polish → Italian phrases for the train station", @"
                ('Gdzie jest dworzec kolejowy?', 'Dov''è la stazione ferroviaria?', 'Sentence'),
                ('O której odjeżdża pociąg?', 'A che ora parte il treno?', 'Sentence'),
                ('Ile kosztuje bilet?', 'Quanto costa il biglietto?', 'Sentence'),
                ('Poproszę bilet do Rzymu.', 'Un biglietto per Roma, per favore.', 'Sentence'),
                ('Z którego peronu?', 'Da quale binario?', 'Sentence'),
                ('Czy ten pociąg jedzie do Florencji?', 'Questo treno va a Firenze?', 'Sentence'),
                ('Gdzie mogę kupić bilet?', 'Dove posso comprare il biglietto?', 'Sentence'),
                ('Czy pociąg jest opóźniony?', 'Il treno è in ritardo?', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: At the Hotel", "Polish → Italian phrases for checking in and staying at a hotel", @"
                ('Mam rezerwację.', 'Ho una prenotazione.', 'Sentence'),
                ('Czy są wolne pokoje?', 'Avete camere libere?', 'Sentence'),
                ('Ile kosztuje za noc?', 'Quanto costa a notte?', 'Sentence'),
                ('O której jest śniadanie?', 'A che ora è la colazione?', 'Sentence'),
                ('Czy mogę dostać klucz?', 'Posso avere la chiave?', 'Sentence'),
                ('Gdzie jest winda?', 'Dov''è l''ascensore?', 'Sentence'),
                ('Wi-Fi nie działa.', 'Il Wi-Fi non funziona.', 'Sentence'),
                ('O której muszę się wymeldować?', 'A che ora devo lasciare la camera?', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: At the Restaurant", "Polish → Italian phrases for ordering food and drink", @"
                ('Poproszę menu.', 'Il menù, per favore.', 'Sentence'),
                ('Stolik dla dwóch osób.', 'Un tavolo per due.', 'Phrase'),
                ('Co pan/pani poleca?', 'Cosa mi consiglia?', 'Sentence'),
                ('Poproszę rachunek.', 'Il conto, per favore.', 'Sentence'),
                ('Czy mogę zapłacić kartą?', 'Posso pagare con la carta?', 'Sentence'),
                ('Poproszę wodę.', 'Dell''acqua, per favore.', 'Sentence'),
                ('Jestem wegetarianinem.', 'Sono vegetariano.', 'Sentence'),
                ('Smacznego!', 'Buon appetito!', 'Phrase')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: Asking Directions", "Polish → Italian phrases for finding your way", @"
                ('Gdzie jest...?', 'Dov''è...?', 'Phrase'),
                ('Jak dojść do centrum?', 'Come arrivo al centro?', 'Sentence'),
                ('Czy to daleko?', 'È lontano?', 'Sentence'),
                ('Czy mogę iść pieszo?', 'Posso andare a piedi?', 'Sentence'),
                ('Proszę skręcić w lewo.', 'Giri a sinistra.', 'Sentence'),
                ('Proszę skręcić w prawo.', 'Giri a destra.', 'Sentence'),
                ('Proszę iść prosto.', 'Vada dritto.', 'Sentence'),
                ('Czy może pan/pani pokazać na mapie?', 'Può mostrarmi sulla mappa?', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: Shopping", "Polish → Italian phrases for shopping", @"
                ('Ile to kosztuje?', 'Quanto costa?', 'Sentence'),
                ('Czy mogę przymierzyć?', 'Posso provarlo?', 'Sentence'),
                ('Czy macie inny rozmiar?', 'Avete un''altra taglia?', 'Sentence'),
                ('To jest za drogie.', 'È troppo caro.', 'Sentence'),
                ('Tylko oglądam.', 'Sto solo guardando.', 'Sentence'),
                ('Czy przyjmujecie karty?', 'Accettate carte?', 'Sentence'),
                ('Poproszę paragon.', 'Lo scontrino, per favore.', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: Emergencies & Help", "Polish → Italian phrases for emergencies and asking for help", @"
                ('Pomocy!', 'Aiuto!', 'Phrase'),
                ('Potrzebuję lekarza.', 'Ho bisogno di un medico.', 'Sentence'),
                ('Proszę zadzwonić na policję.', 'Chiami la polizia.', 'Sentence'),
                ('Zgubiłem się.', 'Mi sono perso.', 'Sentence'),
                ('Gdzie jest szpital?', 'Dov''è l''ospedale?', 'Sentence'),
                ('Zgubiłem paszport.', 'Ho perso il passaporto.', 'Sentence'),
                ('Proszę mi pomóc.', 'Mi può aiutare?', 'Sentence'),
                ('Gdzie jest najbliższa apteka?', 'Dov''è la farmacia più vicina?', 'Sentence')");

            SeedGroup(migrationBuilder, "pl", "it", "Italian — Vacation: Essentials", "Polish → Italian everyday essential phrases", @"
                ('Czy mówi pan/pani po angielsku?', 'Parla inglese?', 'Sentence'),
                ('Nie rozumiem.', 'Non capisco.', 'Sentence'),
                ('Czy może pan/pani mówić wolniej?', 'Può parlare più lentamente?', 'Sentence'),
                ('Czy może pan/pani powtórzyć?', 'Può ripetere?', 'Sentence'),
                ('Przepraszam, gdzie jest toaleta?', 'Scusi, dov''è il bagno?', 'Sentence'),
                ('Bardzo dziękuję.', 'Grazie mille.', 'Phrase'),
                ('Nie ma za co.', 'Di niente.', 'Phrase'),
                ('Która jest godzina?', 'Che ore sono?', 'Sentence')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""TranslationGroups""
                WHERE ""GroupName"" IN (
                    'Italian — Vacation: Train Station',
                    'Italian — Vacation: At the Hotel',
                    'Italian — Vacation: At the Restaurant',
                    'Italian — Vacation: Asking Directions',
                    'Italian — Vacation: Shopping',
                    'Italian — Vacation: Emergencies & Help',
                    'Italian — Vacation: Essentials'
                );");
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

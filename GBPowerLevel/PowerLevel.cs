using CsvHelper;
using CsvHelper.Configuration;
using GBPowerLevel.GuildBattles;
using System.Globalization;
using System.Text;

namespace GBPowerLevel
{
    public class PowerLevel
    {
        private string _csvPath { get; set; }

        public PowerLevel(string csvPath)
        {
            _csvPath = csvPath;
        }

        public void GetPowerLevels()
        {
            if (File.Exists(_csvPath))
            {
                List<PlayerPowerLevel> playerPowerLevels = new List<PlayerPowerLevel>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    NewLine = Environment.NewLine,
                    Encoding = Encoding.UTF8,
                    HasHeaderRecord = true,
                };

                using (var reader = new StreamReader(_csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<GuildBattle19ClassMap>();
                    var records = csv.GetRecords<GuildBattle19>();

                    foreach (var record in records)
                    {
                        var detail = $"{record.In_GameName}: {record.HighestPowerDPS()} (Yuffie: {record.YuffiePowerLevel()}; Cloud: {record.CloudPowerLevel()}; Sephiroth: {record.SephirothPowerLevel()})";
                        Console.WriteLine(detail);

                        var highestDPS = record.HighestPowerDPS();

                        playerPowerLevels.Add(new PlayerPowerLevel()
                        {
                            InGameName = record.In_GameName,
                            PowerLevel = Math.Round(highestDPS.PowerLevel, 2),
                            Character = highestDPS.Character,
                            OtherCharacters = record.OtherDPSFormatted(),
                            CurrentGuild = record.YourGuild
                        });
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Sorted Players by Power Level");

                    var counter = 1;

                    foreach(var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
                    {
                        Console.WriteLine($"{counter}: {player.InGameName} ({player.CurrentGuild}); Power: {player.PowerLevel} ({player.Character}); Other DPS: {player.OtherCharacters}");
                        counter++;
                    }
                }
            }
        }
    }
}

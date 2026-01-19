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
                            CurrentGuild = record.YourGuild,
                            SummonModifier = record.SummonMultiplier(),
                            EnemySkillModifier = record.EnemySkillMultiplier(),
                            SupportModifier = record.GetSupportMultipler(),
                            SupportModifierDetails = record.GetSupportModifierDetails(),
                            SummonMaxLevel = record.SummonMaxLevel
                        });
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Sorted Players by Power Level");

                    var counter = 1;

                    foreach(var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
                    {
                        Console.WriteLine($"{counter}: {player.InGameName} ({player.CurrentGuild}) - {player.PowerLevel} ({player.Character})");
                        Console.WriteLine($"     - Other DPS: {player.OtherCharacters}");
                        Console.WriteLine($"     - Summon Bonus (Max {Math.Round((player.SummonMaxLevel / 10.0), 2)}): {player.SummonModifier}");
                        Console.WriteLine($"     - E.S. Bonus (Max .25): {player.EnemySkillModifier}");
                        Console.WriteLine($"     - Support Bonus: {player.SupportModifier} ({player.SupportModifierDetails})");
                        counter++;
                    }
                }
            }
        }
    }
}

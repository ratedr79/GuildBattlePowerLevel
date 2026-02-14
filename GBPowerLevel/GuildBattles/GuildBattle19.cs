using CsvHelper;
using CsvHelper.Configuration;
using GBPowerLevel.Extensions;
using GBPowerLevel.Interfaces;
using System.Globalization;
using System.Text;

namespace GBPowerLevel.GuildBattles
{
    public class GuildBattle19 : IGuildBattle
    {
        public double SummonMaxLevel { get { return 10; } }

        public DateTime Timestamp { get; set; }
        public string In_GameName { get; set; }
        public string YourGuild { get; set; }
        public string YourTimeZone { get; set; }
        public string HolidayOutfit { get; set; }
        public string Equilibrium { get; set; }
        public string ACMode { get; set; }
        public string Ragnarok { get; set; }
        public string HolidayBlade { get; set; }
        public string FusionSword { get; set; }
        public string GarboftheWorld_Ender { get; set; }
        public string CustomSuit { get; set; }
        public string CapeoftheWorthy { get; set; }
        public string ShinraFormalUniform { get; set; }
        public string DarkHarbinger { get; set; }
        public string GenjiBlade { get; set; }
        public string SerratedRemiges { get; set; }
        public string BladeoftheWorthy { get; set; }
        public string PhoenixOdachi { get; set; }
        public string NocturneJacket { get; set; }
        public string HPShout { get; set; }
        public string CoolCatsMegaphone { get; set; }
        public string NocturneHorn { get; set; }
        public string HeirloomKimono { get; set; }
        public string SaviorEnsemble { get; set; }
        public string HolidayCheerReindeer { get; set; }
        public string SparklingSkater { get; set; }
        public string Conformer { get; set; }
        public string RisingSun { get; set; }
        public string HeirloomBrush { get; set; }
        public string RockersGuitar { get; set; }
        public string HolidayBell { get; set; }
        public string PirateNavigator { get; set; }
        public string LimitedMoon { get; set; }
        public string PirateCollar { get; set; }
        public string BrilliantCollar { get; set; }
        public string SilverCollar { get; set; }
        public string CanyonCollar { get; set; }
        public string FloralWand { get; set; }
        public string CrimsonStaff { get; set; }
        public string Odin_Zantetsuken { get; set; }
        public string MemoriaoftheStallionofGoodFortune { get; set; }
        public string LightningArmyofOne { get; set; }
        public string HeavyShieldArmor { get; set; }
        public string BatteringSword { get; set; }

        public double CloudPowerLevel()
        {
            double characterLevel = 250.0;

            if (HolidayOutfit.IsOwned())
            {
                characterLevel += 250;
            }

            if (ACMode.IsOwned())
            {
                characterLevel += 100;
            }

            if (Equilibrium.IsOwned())
            {
                characterLevel += 100;
            }

            double multiplier = BaseMultipler();

            if (Ragnarok.IsOwned())
            {
                multiplier += 0.5;
            }

            multiplier += FusionSword.GetMultipler(0.2, 0.5, 0.7);
            multiplier += HolidayBlade.GetMultipler(0.3, 0.5, 0.9);

            return characterLevel * (multiplier + 1);
        }

        public double YuffiePowerLevel()
        {
            double characterLevel = 200.0;

            if (HeirloomKimono.IsOwned())
            {
                characterLevel += 100;
            }

            if (SaviorEnsemble.IsOwned())
            {
                characterLevel += 100;
            }

            if (HolidayCheerReindeer.IsOwned())
            {
                characterLevel += 150;
            }

            var outfitCount = 0;

            if (HolidayCheerReindeer.IsOwned())
                outfitCount++;

            if (SaviorEnsemble.IsOwned())
                outfitCount++;

            if (HeirloomKimono.IsOwned())
                outfitCount++;

            if (outfitCount < 3)
            {
                if (SparklingSkater.IsOwned())
                {
                    characterLevel += 100;
                }
            }

            double multiplier = BaseMultipler();

            if (RisingSun.IsOwned())
            {
                multiplier += 0.5;
            }
            else if (Conformer.IsOwned())
            {
                multiplier += 0.3;
            }

            multiplier += HolidayBell.GetMultipler(0.1, 0.3, 0.4);

            if (HeirloomBrush.IsOwned() && LimitedMoon.IsOwned())
            {
                multiplier += HeirloomBrush.GetMultipler(0.1, 0.25, 0.5);
            }
            else
            {
                if (LimitedMoon.IsOwned())
                {
                    multiplier += RockersGuitar.GetMultipler(0.05, 0.1, 0.15);
                }
                else
                {
                    multiplier += RockersGuitar.GetMultipler(0.075, 0.125, 0.2);
                }
            }

            return characterLevel * (multiplier + 1);
        }

        public double SephirothPowerLevel()
        {
            double characterLevel = 250.0;

            if (GarboftheWorld_Ender.IsOwned())
            {
                characterLevel += 100;
            }

            if (CapeoftheWorthy.IsOwned())
            {
                characterLevel += 100;
            }

            if (CustomSuit.IsOwned())
            {
                characterLevel += 250;
            }

            var outfitCount = 0;

            if (GarboftheWorld_Ender.IsOwned())
                outfitCount++;

            if (CapeoftheWorthy.IsOwned())
                outfitCount++;

            if (CustomSuit.IsOwned())
                outfitCount++;

            if (outfitCount < 3)
            {
                if (ShinraFormalUniform.IsOwned())
                {
                    characterLevel += 30;
                    outfitCount++;
                }
            }

            if (outfitCount < 3)
            {
                if (DarkHarbinger.IsOwned())
                {
                    characterLevel += 30;
                }
            }

            double multiplier = BaseMultipler();

            if (GenjiBlade.IsOwned())
            {
                multiplier += 0.3;
            }

            multiplier += SerratedRemiges.GetMultipler(0.3, 0.6, 1.0);

            if (PhoenixOdachi.IsOwned() && LimitedMoon.IsOwned())
            {
                multiplier += PhoenixOdachi.GetMultipler(0.08, 0.5, 1.0);
            }
            else
            {
                if (LimitedMoon.IsOwned())
                {
                    multiplier += BladeoftheWorthy.GetMultipler(0.05, 0.1, 0.15);
                }
                else
                {
                    multiplier += BladeoftheWorthy.GetMultipler(0.1, 0.2, 0.4);
                }
            }

            return characterLevel * (multiplier + 1);
        }

        public double ZackPowerLevel()
        {
            double characterLevel = 225.0;

            if (HeavyShieldArmor.IsOwned())
            {
                characterLevel += 300;
            }

            var swordLevel = BatteringSword.OnlyNumbers();

            if (!string.IsNullOrEmpty(swordLevel) && int.Parse(swordLevel) > 9)
            {
                characterLevel += 325;
            }
            else if (!string.IsNullOrEmpty(swordLevel) && int.Parse(swordLevel) > 5)
            {
                characterLevel += 250;
            }
            else if (!string.IsNullOrEmpty(swordLevel) && int.Parse(swordLevel) > 0)
            {
                characterLevel += 100;
            }

            double multiplier = BaseMultipler();

            multiplier += BatteringSword.GetMultipler(0.4, 0.8, 1.2);

            if (!string.IsNullOrEmpty(swordLevel) && int.Parse(swordLevel) >= 0)
            {
                if (LimitedMoon.IsOwned())
                {
                    multiplier += 0.1;
                }
                else
                {
                    //We'll just guess they have his WEX sword
                    multiplier += 0.3;
                }
            }

            return characterLevel * (multiplier + 1);
        }

        public List<DPSPowerLevel> DPSPowerLevels()
        {
            var dpsPowerLevels = new List<DPSPowerLevel>()
            {
                new DPSPowerLevel() {
                    Character = "Cloud",
                    PowerLevel = CloudPowerLevel()
                },
                new DPSPowerLevel() {
                    Character = "Sephiroth",
                    PowerLevel = SephirothPowerLevel(),
                },
                new DPSPowerLevel() {
                    Character = "Yuffie",
                    PowerLevel = YuffiePowerLevel()
                },
                new DPSPowerLevel() {
                    Character = "Zack",
                    PowerLevel = ZackPowerLevel()
                }
            };

            return dpsPowerLevels;
        }

        public DPSPowerLevel HighestPowerDPS()
        {
            var topDPS = DPSPowerLevels().OrderByDescending(p => p.PowerLevel).FirstOrDefault();

            return topDPS ?? new DPSPowerLevel()
            {
                Character = "UNKNOWNN",
                PowerLevel = 0
            };
        }

        public List<DPSPowerLevel> OtherDPS()
        {
            return DPSPowerLevels().OrderByDescending(p => p.PowerLevel).Skip(1).ToList();
        }

        public string OtherDPSFormatted()
        {
            var output = new StringBuilder();

            foreach(var dps in OtherDPS())
            {
                if (output.Length > 0)
                {
                    output.Append(", ");
                }

                output.Append($"{dps.Character} {Math.Round(dps.PowerLevel, 2)}");
            }

            return output.ToString();
        }

        public double BaseMultipler()
        {
            return SummonMultiplier() + EnemySkillMultiplier() + MemoriaMultiplier() + GetSupportMultipler();
        }

        public double SummonMultiplier()
        {
            var odinLevel = Odin_Zantetsuken.OnlyNumbers();

            if (string.IsNullOrEmpty(odinLevel))
                return 0.0;

            return double.Parse(odinLevel) / 10.0;
        }

        public double MemoriaMultiplier()
        {
            var memoriaLevel = MemoriaoftheStallionofGoodFortune.OnlyNumbers();

            if (string.IsNullOrEmpty(memoriaLevel))
                return 0.0;

            return double.Parse(memoriaLevel) / 10.0;
        }

        public double EnemySkillMultiplier()
        {
            var esLevel = LightningArmyofOne.OnlyNumbers();

            if (string.IsNullOrEmpty(esLevel))
                return 0.0;

            return double.Parse(esLevel) / 20.0;
        }

        public List<DPSPowerLevel> SupportPowerLevels()
        {
            var dpsPowerLevels = new List<DPSPowerLevel>()
            {
                new DPSPowerLevel() {
                    Character = "Red",
                    PowerLevel = RedMultiplier()
                },
                new DPSPowerLevel() {
                    Character = "Cait",
                    PowerLevel = CaitMultiplier(),
                },
                new DPSPowerLevel() {
                    Character = "Aerith",
                    PowerLevel = AerithMultiplier()
                }
            };

            return dpsPowerLevels;
        }

        public double GetSupportMultipler()
        {
            var supports = SupportPowerLevels().OrderByDescending(p => p.PowerLevel).Take(2).ToList();

            return Math.Round(supports.Sum(p => p.PowerLevel), 2);
        }

        public string GetSupportModifierDetails()
        {
            var output = new StringBuilder();
            var supports = SupportPowerLevels();

            foreach(var support in supports)
            {
                if (output.Length > 0)
                    output.Append("; ");

                output.Append($"{support.Character}: {Math.Round(support.PowerLevel, 2)}");
            }

            return output.ToString();
        }

        public double RedMultiplier()
        {
            double multiplier = 0;

            multiplier += PirateCollar.GetMultipler(0.1, 0.2, 0.4);
            multiplier += BrilliantCollar.GetMultipler(0.1, 0.4, 0.5);

            var weaponCount = 0;

            if (PirateCollar.IsOwned())
                weaponCount++;

            if (BrilliantCollar.IsOwned())
                weaponCount++;

            if (weaponCount < 2)
            {
                if (SilverCollar.IsOwned())
                {
                    multiplier += SilverCollar.GetMultipler(0.05, 0.08, 0.1);
                    weaponCount++;
                }
            }

            if (weaponCount < 2)
            {
                if (CanyonCollar.IsOwned())
                {
                    multiplier += CanyonCollar.GetMultipler(0.025, 0.05, 0.06);
                    weaponCount++;
                }
            }

            if (LimitedMoon.IsOwned())
            {
                multiplier += 0.4;
            }

            if (PirateNavigator.IsOwned())
            {
                multiplier += 0.2;
            }

            return multiplier;
        }

        public double CaitMultiplier()
        {
            double multiplier = 0;

            multiplier += NocturneHorn.GetMultipler(0.1, 0.3, 0.4);
            multiplier += CoolCatsMegaphone.GetMultipler(0.1, 0.2, 0.25);

            if (HPShout.IsOwned())
            {
                multiplier += 0.25;
            }

            if (NocturneJacket.IsOwned())
            {
                multiplier += 0.2;
            }

            return multiplier;
        }

        public double AerithMultiplier()
        {
            double multiplier = 0;

            multiplier += CrimsonStaff.GetMultipler(0.1, 0.25, 0.3);
            multiplier += FloralWand.GetMultipler(0.05, 0.075, 0.1);

            return multiplier;
        }

        public void GetOutput(string _csvPath)
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
                        var detail = $"{record.In_GameName}: {record.HighestPowerDPS()} (Yuffie: {record.YuffiePowerLevel()}; Cloud: {record.CloudPowerLevel()}; Sephiroth: {record.SephirothPowerLevel()}; Zack: {record.ZackPowerLevel()})";
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

                    foreach (var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
                    {
                        Console.WriteLine($"{counter}: {player.InGameName} ({player.CurrentGuild}) - {player.PowerLevel} ({player.Character})");
                        //Console.WriteLine($"     - Other DPS: {player.OtherCharacters}");
                        //Console.WriteLine($"     - Summon Bonus (Max {Math.Round((player.SummonMaxLevel / 10.0), 2)}): {player.SummonModifier}");
                        //Console.WriteLine($"     - E.S. Bonus (Max .25): {player.EnemySkillModifier}");
                        //Console.WriteLine($"     - Support Bonus: {player.SupportModifier} ({player.SupportModifierDetails})");
                        counter++;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("");
                    counter = 1;

                    foreach (var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
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

    public class GuildBattle19ClassMap : ClassMap<GuildBattle19>
    {
        public GuildBattle19ClassMap()
        {
            Map(m => m.Timestamp).Name("Timestamp");
            Map(m => m.In_GameName).Name("In-Game Name");
            Map(m => m.YourGuild).Name("Your Guild");
            Map(m => m.YourTimeZone).Name("Your Time Zone");
            Map(m => m.HolidayOutfit).Name("Holiday Outfit");
            Map(m => m.Equilibrium).Name("    Equilibrium");
            Map(m => m.ACMode).Name("AC Mode");
            Map(m => m.Ragnarok).Name("Ragnarok");
            Map(m => m.HolidayBlade).Name("Holiday Blade");
            Map(m => m.FusionSword).Name("Fusion Sword");
            Map(m => m.GarboftheWorld_Ender).Name("Garb of the World-Ender");
            Map(m => m.CustomSuit).Name("Custom Suit");
            Map(m => m.CapeoftheWorthy).Name("Cape of the Worthy");
            Map(m => m.ShinraFormalUniform).Name("Shinra Formal Uniform");
            Map(m => m.DarkHarbinger).Name("Dark Harbinger");
            Map(m => m.GenjiBlade).Name("Genji Blade");
            Map(m => m.SerratedRemiges).Name("Serrated Remiges");
            Map(m => m.BladeoftheWorthy).Name("Blade of the Worthy");
            Map(m => m.PhoenixOdachi).Name("Phoenix Odachi");
            Map(m => m.NocturneJacket).Name("Nocturne Jacket");
            Map(m => m.HPShout).Name("HP Shout");
            Map(m => m.CoolCatsMegaphone).Name("Cool Cat's Megaphone");
            Map(m => m.NocturneHorn).Name("Nocturne Horn");
            Map(m => m.HeirloomKimono).Name("Heirloom Kimono");
            Map(m => m.SaviorEnsemble).Name("Savior Ensemble");
            Map(m => m.HolidayCheerReindeer).Name("Holiday Cheer Reindeer");
            Map(m => m.SparklingSkater).Name("Sparkling Skater");
            Map(m => m.Conformer).Name("Conformer");
            Map(m => m.RisingSun).Name("Rising Sun");
            Map(m => m.HeirloomBrush).Name("Heirloom Brush");
            Map(m => m.RockersGuitar).Name("Rocker's Guitar");
            Map(m => m.HolidayBell).Name("Holiday Bell");
            Map(m => m.PirateNavigator).Name("Pirate Navigator ");
            Map(m => m.LimitedMoon).Name("Limited Moon");
            Map(m => m.PirateCollar).Name("Pirate Collar");
            Map(m => m.BrilliantCollar).Name("Brilliant Collar");
            Map(m => m.SilverCollar).Name("Silver Collar");
            Map(m => m.CanyonCollar).Name("Canyon Collar");
            Map(m => m.FloralWand).Name("Floral Wand");
            Map(m => m.CrimsonStaff).Name("Crimson Staff");
            Map(m => m.Odin_Zantetsuken).Name("Odin - Zantetsuken");
            Map(m => m.MemoriaoftheStallionofGoodFortune).Name("Memoria of the Stallion of Good Fortune");
            Map(m => m.LightningArmyofOne).Name("Lightning: Army of One");
            Map(m => m.HeavyShieldArmor).Name("Zack Outfit");
            Map(m => m.BatteringSword).Name("Zack Weapon");
        }
    }
}

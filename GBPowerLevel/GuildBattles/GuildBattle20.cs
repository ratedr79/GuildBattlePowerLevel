using CsvHelper;
using CsvHelper.Configuration;
using GBPowerLevel.Extensions;
using GBPowerLevel.Interfaces;
using System.Globalization;
using System.Text;

namespace GBPowerLevel.GuildBattles
{
    public class GuildBattle20 : IGuildBattle
    {
        public double SummonMaxLevel { get { return 22; } }
        public double EnemySkillMaxLevel { get { return .5; } }

        public DateTime Timestamp { get; set; }
        public string In_GameName { get; set; }
        public string DiscordNameIfdifferent { get; set; }
        public string YourGuild { get; set; }
        public string YourTimeZone { get; set; }
        public string Battlereleasedaybanner { get; set; }
        public string RulerofthePlanet { get; set; }
        public string CorruptorofthePlanet { get; set; }
        public string OnewiththeBlade { get; set; }
        public string HeavensCloud { get; set; }
        public string Muramasa { get; set; }
        public string Kikuichimonji { get; set; }
        public string Shiranui { get; set; }
        public string GoldenFlowerKimono { get; set; }
        public string BattlerEnsemble { get; set; }
        public string ACStyle { get; set; }
        public string FestiveBlueDaffodilAttire { get; set; }
        public string PassionMermaid { get; set; }
        public string PremiumHeart { get; set; }
        public string ShellKnuckles { get; set; }
        public string BlueDaffodilGloves { get; set; }
        public string LeatherCombatGloves { get; set; }
        public string GarbofthePossessed { get; set; }
        public string GuardianCorpsUniform { get; set; }
        public string ClassicConey { get; set; }
        public string Abraxas { get; set; }
        public string TerrasRod { get; set; }
        public string LightningsRod { get; set; }
        public string CrimsonStaff { get; set; }
        public string EggStaff { get; set; }
        public string GarboftheWorld_Ender { get; set; }
        public string CapeoftheWorthy { get; set; }
        public string CelebratoryGarb { get; set; }
        public string GenjiBlade { get; set; }
        public string WitheringBlaze { get; set; }
        public string PhoenixOdachi { get; set; }
        public string BladeoftheWorthy { get; set; }
        public string RadiantEdge { get; set; }
        public string ShinraCeremonialUniform { get; set; }
        public string Aldebaran { get; set; }
        public string ShinraCeremonialRifle { get; set; }
        public string MarineShooter { get; set; }
        public string RoseMusket { get; set; }
        public string PirateNavigator { get; set; }
        public string LimitedMoon { get; set; }
        public string PirateCollar { get; set; }
        public string PatissiersCollar { get; set; }
        public string IvyCollar { get; set; }
        public string RageCollar { get; set; }
        public string GuardianStyle { get; set; }
        public string RabbitButler { get; set; }
        public string SurferLook { get; set; }
        public string Durandal { get; set; }
        public string StreamGuard { get; set; }
        public string SwordoftheHunt { get; set; }
        public string Ifrit { get; set; }
        public string IfritBahamut { get; set; }
        public string Memoriaof2B { get; set; }
        public string MemoriaofStilva { get; set; }
        public string LightningArmyofOne { get; set; }
        public string WhirlingRavager { get; set; }
        public string FiraRefinedFiraMateria11PotorhigherOwned { get; set; }
        public string FiraRefinedFiraMateria8_10PotOwned { get; set; }
        public string FiraRefinedFiraMateria0_7PotOwned { get; set; }

        public double OSephirothPowerLevel()
        {
            double characterLevel = 250.0;

            if (RulerofthePlanet.IsOwned())
            {
                characterLevel += 100;
            }

            if (CorruptorofthePlanet.IsOwned())
            {
                characterLevel += 150;
            }

            if (OnewiththeBlade.IsOwned())
            {
                characterLevel += 150;
            }

            double multiplier = BaseMultipler();

            if (HeavensCloud.IsOwned())
            {
                if (GarbofthePossessed.IsOwned() || LimitedMoon.IsOwned())
                {
                    multiplier += 0.1;
                }
                else
                {
                    multiplier += 0.3;
                }
            }

            if (Shiranui.IsOwned())
            {
                multiplier += Shiranui.GetMultipler(0.2, 0.6, 0.7);

                if (Muramasa.IsOwned())
                {
                    multiplier += Muramasa.GetMultipler(0.3, 0.5, 0.9);
                }
                else
                {
                    multiplier += Kikuichimonji.GetMultipler(0.3, 0.5, 0.9);
                }
            }

            return characterLevel * (multiplier + 1);
        }

        public double TifaPowerLevel()
        {
            double characterLevel = 225.0;

            if (GoldenFlowerKimono.IsOwned())
            {
                characterLevel += 175;
            }

            if (PassionMermaid.IsOwned())
            {
                characterLevel += 150;
            }

            if (BattlerEnsemble.IsOwned())
            {
                characterLevel += 125;
            }

            var outfitCount = 0;

            if (GoldenFlowerKimono.IsOwned())
                outfitCount++;

            if (BattlerEnsemble.IsOwned())
                outfitCount++;

            if (PassionMermaid.IsOwned())
                outfitCount++;

            if (outfitCount < 3)
            {
                if (ACStyle.IsOwned())
                {
                    characterLevel += 125;
                    outfitCount++;
                }
            }

            if (outfitCount < 3)
            {
                if (FestiveBlueDaffodilAttire.IsOwned())
                {
                    characterLevel += 125;
                    outfitCount++;
                }
            }

            double multiplier = BaseMultipler();

            if (PremiumHeart.IsOwned())
            {
                multiplier += 0.3;
            }

            multiplier += ShellKnuckles.GetMultipler(0.2, 0.4, 0.5);

            if (LeatherCombatGloves.IsOwned())
            {
                multiplier += LeatherCombatGloves.GetMultipler(0.1, 0.2, 0.3);
            }
            else if (BlueDaffodilGloves.IsOwned())
            {
                if (GarbofthePossessed.IsOwned() || LimitedMoon.IsOwned())
                {
                    multiplier += BlueDaffodilGloves.GetMultipler(0.05, 0.1, 0.15);
                }
                else
                {
                    multiplier += BlueDaffodilGloves.GetMultipler(0.1, 0.2, 0.25);
                }
            }

            return characterLevel * (multiplier + 1);
        }

        public double YSephirothPowerLevel()
        {
            double characterLevel = 225.0;

            if (GarboftheWorld_Ender.IsOwned())
            {
                characterLevel += 125;
            }

            if (CapeoftheWorthy.IsOwned())
            {
                characterLevel += 125;
            }

            if (CelebratoryGarb.IsOwned())
            {
                characterLevel += 100;
            }

            double multiplier = BaseMultipler();

            if (GenjiBlade.IsOwned())
            {
                multiplier += 0.3;
            }

            var weaponCount = 0;

            if (WitheringBlaze.IsOwned())
            {
                multiplier += WitheringBlaze.GetMultipler(0.2, 0.4, 0.5);
                weaponCount++;
            }

            if (PhoenixOdachi.IsOwned())
            {
                multiplier += PhoenixOdachi.GetMultipler(0.08, 0.5, 1.0);
                weaponCount++;
            }

            if (weaponCount < 2 && GarbofthePossessed.IsOwned())
            {
                if (LimitedMoon.IsOwned())
                {
                    multiplier += BladeoftheWorthy.GetMultipler(0.05, 0.1, 0.15);
                }
                else
                {
                    multiplier += BladeoftheWorthy.GetMultipler(0.1, 0.2, 0.4);
                }

                weaponCount++;
            }

            if (weaponCount < 2)
            {
                multiplier += RadiantEdge.GetMultipler(0.05, 0.1, 0.15);
                weaponCount++;
            }

            return characterLevel * (multiplier + 1);
        }

        public double ZackPowerLevel()
        {
            double characterLevel = 175.0;

            if (GuardianStyle.IsOwned())
            {
                characterLevel += 125;
            }

            if (RabbitButler.IsOwned())
            {
                characterLevel += 100;
            }

            if (SurferLook.IsOwned())
            {
                characterLevel += 100;
            }

            double multiplier = BaseMultipler();

            if (Durandal.IsOwned())
            {
                multiplier += 0.1;
            }

            multiplier += StreamGuard.GetMultipler(0.2, 0.3, 0.35);

            if (GarbofthePossessed.IsOwned() || LimitedMoon.IsOwned())
            {
                multiplier += SwordoftheHunt.GetMultipler(0.05, 0.1, 0.15);
            }
            else
            {
                multiplier += SwordoftheHunt.GetMultipler(0.1, 0.15, 0.2);
            }

            return characterLevel * (multiplier + 1);
        }

        public List<DPSPowerLevel> DPSPowerLevels()
        {
            var dpsPowerLevels = new List<DPSPowerLevel>()
            {
                new DPSPowerLevel() {
                    Character = "Tifa",
                    PowerLevel = TifaPowerLevel()
                },
                new DPSPowerLevel() {
                    Character = "Zack",
                    PowerLevel = ZackPowerLevel()
                }
            };

            var oSephLevel = OSephirothPowerLevel();
            var ySephLevel = YSephirothPowerLevel();

            if (oSephLevel > ySephLevel)
            {
                dpsPowerLevels.Add(new DPSPowerLevel()
                {
                    Character = "Sephiroth (Original)",
                    PowerLevel = OSephirothPowerLevel()
                });
            }
            else
            {
                dpsPowerLevels.Add(new DPSPowerLevel()
                {
                    Character = "Sephiroth",
                    PowerLevel = YSephirothPowerLevel(),
                });
            }

            return dpsPowerLevels;
        }

        public List<DPSPowerLevel> HighestPowerDPS()
        {
            var topDPS = DPSPowerLevels().OrderByDescending(p => p.PowerLevel).Take(2).ToList();

            return topDPS ?? new List<DPSPowerLevel>()
            {
                new DPSPowerLevel()
                {
                    Character = "UNKNOWNN",
                    PowerLevel = 0
                }
            };
        }

        public List<DPSPowerLevel> OtherDPS()
        {
            return DPSPowerLevels().OrderByDescending(p => p.PowerLevel).Skip(2).ToList();
        }

        public DPSPowerLevel HighestSupport()
        {
            return SupportPowerLevels()
                .OrderByDescending(p => p.PowerLevel)
                .Take(1)
                .Select(s => new DPSPowerLevel()
                {
                    Character = s.Character,
                    PowerLevel = s.PowerLevel
                })
                .ToList()
                .First();
        }

        public string OtherDPSFormatted()
        {
            var output = new StringBuilder();

            foreach (var dps in OtherDPS())
            {
                if (output.Length > 0)
                {
                    output.Append(", ");
                }

                output.Append($"{dps.Character} {Math.Round(dps.PowerLevel, 2)}");
            }

            return output.ToString();
        }

        public string HighestDPSFormatted()
        {
            var output = new StringBuilder();

            foreach (var dps in HighestPowerDPS())
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
            return SummonMultiplier() + EnemySkillMultiplier() + MemoriaMultiplier() + GetSupportMultipler() + MateriaMultipler();
        }

        public double SummonMultiplier()
        {
            return SingleSummonMultiplier() + DoubleSummonMultiplier();
        }

        private double SingleSummonMultiplier()
        {
            var summonLevel = Ifrit.OnlyNumbers();

            if (string.IsNullOrEmpty(summonLevel))
                return 0.0;

            return double.Parse(summonLevel) / 10.0;
        }

        private double DoubleSummonMultiplier()
        {
            var summonLevel = IfritBahamut.OnlyNumbers();

            if (string.IsNullOrEmpty(summonLevel))
                return 0.0;

            return double.Parse(summonLevel) / 10.0;
        }

        public double MemoriaMultiplier()
        {
            var value2B = Memoriaof2B.OnlyNumbers();
            var valueStilva = MemoriaofStilva.OnlyNumbers();

            var memoria2BLevel = string.IsNullOrEmpty(value2B) ? 0 : int.Parse(value2B);
            var memoriaStilvaLevel = string.IsNullOrEmpty(valueStilva) ? 0 : int.Parse(valueStilva);

            var highestMemoria = memoria2BLevel > memoriaStilvaLevel ? memoria2BLevel : memoriaStilvaLevel;

            if (highestMemoria == 0)
                return 0.0;

            return highestMemoria / 10.0;
        }

        public double EnemySkillMultiplier()
        {
            return ArmyOfOneMultiplier() + WhirlingRavagerMultiplier();
        }

        private double ArmyOfOneMultiplier()
        {
            var esLevel = LightningArmyofOne.OnlyNumbers();

            if (string.IsNullOrEmpty(esLevel))
                return 0.0;

            return double.Parse(esLevel) / 20.0;
        }

        public double WhirlingRavagerMultiplier()
        {
            var esLevel = WhirlingRavager.OnlyNumbers();

            if (string.IsNullOrEmpty(esLevel))
                return 0.0;

            return double.Parse(esLevel) / 20.0;
        }

        public double MateriaMultipler()
        {
            var highPotValue = FiraRefinedFiraMateria11PotorhigherOwned.OnlyNumbers();
            var midPotValue = FiraRefinedFiraMateria8_10PotOwned.OnlyNumbers();
            var lowPotValue = FiraRefinedFiraMateria0_7PotOwned.OnlyNumbers();

            var highPotCount = string.IsNullOrWhiteSpace(highPotValue) ? 0 : int.Parse(highPotValue);
            var midPotCount = string.IsNullOrWhiteSpace(midPotValue) ? 0 : int.Parse(midPotValue);
            var lowPotCount = string.IsNullOrWhiteSpace(lowPotValue) ? 0 : int.Parse(lowPotValue);

            if ((highPotCount + midPotCount + lowPotCount) == 0)
                return 0;

            return (highPotCount / 3.0) + ((midPotCount / 3.0) * 0.6) + ((lowPotCount / 3.0) * 0.4);
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
                    Character = "Lucia",
                    PowerLevel = LuciaMultiplier(),
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
            var supports = SupportPowerLevels().OrderByDescending(p => p.PowerLevel).Take(1).ToList();

            return Math.Round(supports.Sum(p => p.PowerLevel), 2);
        }

        public string GetSupportModifierDetails()
        {
            var output = new StringBuilder();
            var supports = SupportPowerLevels();

            foreach (var support in supports)
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

            if (PirateNavigator.IsOwned())
                multiplier += 0.25;

            var weaponCount = 0;

            if (PirateCollar.IsOwned())
            {
                multiplier += PirateCollar.GetMultipler(0.1, 0.2, 0.3);
                weaponCount++;
            }

            if (PatissiersCollar.IsOwned())
            {
                multiplier += PatissiersCollar.GetMultipler(0.1, 0.2, 0.3);
                weaponCount++;
            }

            if (weaponCount < 2 && IvyCollar.IsOwned() && !GoldenFlowerKimono.IsOwned())
            {
                multiplier += IvyCollar.GetMultipler(0.05, 0.1, 0.15);
                weaponCount++;
            }

            if (weaponCount < 2 && RageCollar.IsOwned())
            {
                multiplier += RageCollar.GetMultipler(0.05, 0.1, 0.15);
                weaponCount++;
            }

            if (LimitedMoon.IsOwned())
            {
                multiplier += 0.5;
            }

            return multiplier;
        }

        public double AerithMultiplier()
        {
            double multiplier = 0;

            if (GarbofthePossessed.IsOwned())
                multiplier += 1.25;

            if (GuardianCorpsUniform.IsOwned())
                multiplier += 0.5;

            if (ClassicConey.IsOwned())
                multiplier += 0.25;

            var weaponCount = 0;

            if (LightningsRod.IsOwned())
            {
                multiplier += LightningsRod.GetMultipler(0.1, 0.3, 0.4);
                weaponCount++;
            }

            if (CrimsonStaff.IsOwned())
            {
                multiplier += CrimsonStaff.GetMultipler(0.1, 0.2, 0.25);
                weaponCount++;
            }

            if (weaponCount < 2 && TerrasRod.IsOwned() && !GoldenFlowerKimono.IsOwned())
            {
                multiplier += TerrasRod.GetMultipler(0.05, 0.1, 0.15);
                weaponCount++;
            }

            if (weaponCount < 2 && EggStaff.IsOwned())
            {
                multiplier += EggStaff.GetMultipler(0.05, 0.1, 0.15);
                weaponCount++;
            }

            if (Abraxas.IsOwned())
            {
                multiplier += 1.5;
            }

            return multiplier;
        }

        public double LuciaMultiplier()
        {
            double multiplier = 0;

            if (ShinraCeremonialUniform.IsOwned())
                multiplier += 0.3;

            var weaponCount = 0;

            if (ShinraCeremonialRifle.IsOwned())
            {
                if (GoldenFlowerKimono.IsOwned())
                {
                    multiplier += ShinraCeremonialRifle.GetMultipler(0.05, 0.1, 0.15);
                    weaponCount++;
                }
                else
                {
                    multiplier += ShinraCeremonialRifle.GetMultipler(0.1, 0.3, 0.4);
                    weaponCount++;
                }
            }

            if (GoldenFlowerKimono.IsOwned())
            {
                if (RoseMusket.IsOwned())
                {
                    multiplier += RoseMusket.GetMultipler(0.05, 0.075, 0.1);
                    weaponCount++;
                }
                else
                {
                    multiplier += MarineShooter.GetMultipler(0.025, 0.05, 0.075);
                    weaponCount++;
                }
            }
            else
            {
                if (MarineShooter.IsOwned())
                {
                    multiplier += MarineShooter.GetMultipler(0.05, 0.1, 0.15);
                    weaponCount++;
                }
                else
                {
                    multiplier += RoseMusket.GetMultipler(0.05, 0.075, 0.1);
                    weaponCount++;
                }
            }

            if (Aldebaran.IsOwned())
            {
                multiplier += 0.3;
            }

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
                    csv.Context.RegisterClassMap<GuildBattle20ClassMap>();
                    var records = csv.GetRecords<GuildBattle20>();

                    foreach (var record in records)
                    {
                        var detail = $"{record.In_GameName}: {string.Join(", ", record.HighestPowerDPS().Select(d => d.Character))} (OSeph: {record.OSephirothPowerLevel()}; YSeph: {record.YSephirothPowerLevel()}; Tifa: {record.TifaPowerLevel()}; Zack: {record.ZackPowerLevel()})";
                        Console.WriteLine(detail);

                        var highestDPS = record.HighestPowerDPS();

                        playerPowerLevels.Add(new PlayerPowerLevel()
                        {
                            InGameName = record.In_GameName,
                            PowerLevel = Math.Round(highestDPS.Sum(d => d.PowerLevel), 2),
                            Character = string.Join(", ", highestDPS.Select(d => d.Character).ToList()),
                            HighestDPS = record.HighestDPSFormatted(),
                            OtherCharacters = record.OtherDPSFormatted(),
                            CurrentGuild = record.YourGuild,
                            SummonModifier = record.SummonMultiplier(),
                            EnemySkillModifier = record.EnemySkillMultiplier(),
                            SupportModifier = record.GetSupportMultipler(),
                            SupportModifierDetails = record.GetSupportModifierDetails(),
                            SummonMaxLevel = record.SummonMaxLevel,
                            EnemySkillMaxLevel = record.EnemySkillMaxLevel,
                            HighestSupport = record.HighestSupport().Character,
                            MateriaModifier = record.MateriaMultipler()
                        });
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Sorted Players by Power Level");

                    var counter = 1;

                    foreach (var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
                    {
                        Console.WriteLine($"{counter}: {player.InGameName} ({player.CurrentGuild}) - {player.PowerLevel} ({player.Character})");
                        counter++;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("");
                    counter = 1;

                    foreach (var player in playerPowerLevels.OrderByDescending(l => l.PowerLevel))
                    {
                        Console.WriteLine($"{counter}: {player.InGameName} ({player.CurrentGuild}) - {player.PowerLevel} ({player.Character}, {player.HighestSupport})");
                        Console.WriteLine($"     - Highest DPS: {player.HighestDPS}");
                        Console.WriteLine($"     - Other DPS: {player.OtherCharacters}");
                        Console.WriteLine($"     - Summon Bonus (Max {Math.Round((player.SummonMaxLevel / 10.0), 2)}): {player.SummonModifier}");
                        Console.WriteLine($"     - E.S. Bonus (Max {player.EnemySkillMaxLevel}): {player.EnemySkillModifier}");
                        Console.WriteLine($"     - Support Bonus: {player.SupportModifier} ({player.SupportModifierDetails})");
                        Console.WriteLine($"     - Materia Bonus (Max 2): {player.MateriaModifier}");
                        counter++;
                    }
                }
            }
        }
    }

    public class GuildBattle20ClassMap : ClassMap<GuildBattle20>
    {
        public GuildBattle20ClassMap()
        {
            Map(m => m.Timestamp).Name("Timestamp");
            Map(m => m.In_GameName).Name("In-Game Name");
            Map(m => m.DiscordNameIfdifferent).Name("Discord Name (If different)");
            Map(m => m.YourGuild).Name("Your Guild");
            Map(m => m.YourTimeZone).Name("Your Time Zone");
            Map(m => m.Battlereleasedaybanner).Name("Battle release day banner?");
            Map(m => m.RulerofthePlanet).Name("Ruler of the Planet");
            Map(m => m.CorruptorofthePlanet).Name("Corruptor of the Planet");
            Map(m => m.OnewiththeBlade).Name("One with the Blade");
            Map(m => m.HeavensCloud).Name("Heaven's Cloud");
            Map(m => m.Muramasa).Name("Muramasa");
            Map(m => m.Kikuichimonji).Name("Kikuichimonji");
            Map(m => m.Shiranui).Name("Shiranui");
            Map(m => m.GoldenFlowerKimono).Name("Golden Flower Kimono");
            Map(m => m.BattlerEnsemble).Name("Battler Ensemble");
            Map(m => m.ACStyle).Name("AC Style");
            Map(m => m.FestiveBlueDaffodilAttire).Name("Festive Blue Daffodil Attire");
            Map(m => m.PassionMermaid).Name("Passion Mermaid");
            Map(m => m.PremiumHeart).Name("Premium Heart");
            Map(m => m.ShellKnuckles).Name("Shell Knuckles");
            Map(m => m.BlueDaffodilGloves).Name("Blue Daffodil Gloves");
            Map(m => m.LeatherCombatGloves).Name("Leather Combat Gloves");
            Map(m => m.GarbofthePossessed).Name("Garb of the Possessed");
            Map(m => m.GuardianCorpsUniform).Name("Guardian Corps Uniform");
            Map(m => m.ClassicConey).Name("Classic Coney");
            Map(m => m.Abraxas).Name("Abraxas");
            Map(m => m.TerrasRod).Name("Terra's Rod");
            Map(m => m.LightningsRod).Name("Lightning's Rod");
            Map(m => m.CrimsonStaff).Name("Crimson Staff");
            Map(m => m.EggStaff).Name("Egg Staff");
            Map(m => m.GarboftheWorld_Ender).Name("Garb of the World-Ender");
            Map(m => m.CapeoftheWorthy).Name("Cape of the Worthy");
            Map(m => m.CelebratoryGarb).Name("Celebratory Garb");
            Map(m => m.GenjiBlade).Name("Genji Blade");
            Map(m => m.WitheringBlaze).Name("Withering Blaze");
            Map(m => m.PhoenixOdachi).Name("Phoenix Odachi");
            Map(m => m.BladeoftheWorthy).Name("Blade of the Worthy");
            Map(m => m.RadiantEdge).Name("Radiant Edge");
            Map(m => m.ShinraCeremonialUniform).Name("Shinra Ceremonial Uniform");
            Map(m => m.Aldebaran).Name("Aldebaran");
            Map(m => m.ShinraCeremonialRifle).Name("Shinra Ceremonial Rifle");
            Map(m => m.MarineShooter).Name("Marine Shooter");
            Map(m => m.RoseMusket).Name("Rose Musket");
            Map(m => m.PirateNavigator).Name("Pirate Navigator ");
            Map(m => m.LimitedMoon).Name("Limited Moon");
            Map(m => m.PirateCollar).Name("Pirate Collar");
            Map(m => m.PatissiersCollar).Name("Patissier's Collar");
            Map(m => m.IvyCollar).Name("Ivy Collar");
            Map(m => m.RageCollar).Name("Rage Collar");
            Map(m => m.GuardianStyle).Name("Guardian Style");
            Map(m => m.RabbitButler).Name("Rabbit Butler");
            Map(m => m.SurferLook).Name("Surfer Look");
            Map(m => m.Durandal).Name("Durandal");
            Map(m => m.StreamGuard).Name("Stream Guard");
            Map(m => m.SwordoftheHunt).Name("Sword of the Hunt");
            Map(m => m.Ifrit).Name("Ifrit");
            Map(m => m.IfritBahamut).Name("Ifrit & Bahamut");
            Map(m => m.Memoriaof2B).Name("Memoria of 2B");
            Map(m => m.MemoriaofStilva).Name("Memoria of Stilva");
            Map(m => m.LightningArmyofOne).Name("Lightning: Army of One");
            Map(m => m.WhirlingRavager).Name("Whirling Ravager");
            Map(m => m.FiraRefinedFiraMateria11PotorhigherOwned).Name("Fira/Refined Fira Materia (11% Pot. or higher) Owned");
            Map(m => m.FiraRefinedFiraMateria8_10PotOwned).Name("Fira/Refined Fira Materia (8-10% Pot.) Owned");
            Map(m => m.FiraRefinedFiraMateria0_7PotOwned).Name("Fira/Refined Fira Materia (0-7% Pot.) Owned");
        }
    }
}
